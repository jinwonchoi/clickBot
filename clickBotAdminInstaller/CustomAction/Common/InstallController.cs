using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using WeDoCommon;
using System.Management;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Data;

namespace CustomAction
{
    public class InstallController
    {
        bool needWinpcapInstall = false;

        private FirewallHandler firewallHandler = new FirewallHandler();
        private WindowServiceHandler serviceHandler = new WindowServiceHandler();
        private SocketHandler socketHandler = new SocketHandler();
        private ConfigFileHandler configFileHandler = new ConfigFileHandler(ConstDef.WEDO_SERVER_DIR, ConstDef.WEDO_SERVER_EXE);

        bool needPrevDbRemove = false;

        public bool NeedPrevDbRemove
        {
            get { return needPrevDbRemove; }
            set { needPrevDbRemove = value; }
        }

        int dbPort = 3308;
        public int DbPort { get { return dbPort; } set { dbPort = value; } }

        string prevMySqlDir = "";
        public string PrevMySqlDir
        {
            get { return prevMySqlDir; }
            set { prevMySqlDir = value; }
        }


        /// <summary>
        /// 1. WeDoSql 서비스가 존재하는지.
        /// </summary>
        /// <returns></returns>
        public bool prevDbExists()
        {
            Logger.info("CheckPrevDbExists");
            bool result = false;
            if (serviceHandler.ServiceExists(ConstDef.MYSQL_SERVICE_NAME))
            {
                prevMySqlDir = GetCurMySqlDir();
                Logger.info("서비스[" + ConstDef.MYSQL_SERVICE_NAME + "]등록상태");
                result = true;
            }
            else
            {
                Logger.info("서비스[" + ConstDef.MYSQL_SERVICE_NAME + "]미등록상태");
            }
            return result;
        }

        public bool PortAlreadyUsed(int port)
        {
            Logger.info("PortAlreadyUsed:"+port);
            return socketHandler.IsTcpPortInUse(port);
        }

        bool dbReinstalled = false;

        /// <summary>
        /// db가 재설치가 안됐고, 회사코드가 다른 경우
        /// 재설치 필요
        /// </summary>
        /// <param name="companyCd"></param>
        /// <returns></returns>
        public bool NeedDbReinstall(string companyCd)
        {
            return (prevMySqlDir != "" && !dbReinstalled) ;
        }

        public bool NeedDataGenerate()
        {
            return (prevMySqlDir == "" || dbReinstalled );
        }

        /// <summary>
        /// 1. backup db
        /// 2. remove db
        /// 3. create db
        /// 4. generate data
        /// </summary>
        /// <returns></returns>
        public bool RemoveAndInstallDb()
        {
            bool result = false;
            try
            {
                BackupPrevDb();
                RemovePrevDb();
                result = InstallDb();

                dbReinstalled = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                result = false;
            }
            return result;
        }


        /// <summary>
        /// 1. backup db
        /// c:\minicti\mysql-5.5.19-win32\bin\mysqldump --user root --password=Genesys!@# wedo_db > c:\minicti\wedo_db_20131028.dmp
        /// </summary>
        /// <returns></returns>
        public bool BackupPrevDb()
        {
            bool result = false;
            OnWriteLog("기존 DB를 삭제합니다.");

            //////////////////////////////////////////
            //1. backup db
            //  - backup
            //  - check backupfile (if exists or size > 0)
            //string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
            //////////////////////////////////////////
            string backupFile = "";
            string mySqlServiceCmd = "";
            string dbBackupCmd = "";
            string mySqlServiceDir = "";
            try
            {
                mySqlServiceDir = GetCurMySqlDir();
                dbBackupCmd = mySqlServiceDir + "\\bin\\mysqldump.exe";
                mySqlServiceCmd = mySqlServiceDir + "\\bin\\mysqld.exe";
                //c:\eclues\db_backup\wedo_db_20131028.dmp
                backupFile = string.Format(ConstDef.WEDO_DB_BACKUP_FILE, DateTime.Now.ToString("yyyyMMdd"));

                OnWriteLog(string.Format("DB를 파일[{0}]로 백업합니다.", backupFile));
                string sqlText = serviceHandler.RunProcess(dbBackupCmd, ConstDef.WEDO_DB_BACKUP_OPT);

                if (!Directory.Exists(ConstDef.DB_BACKUP_DIR))
                    Directory.CreateDirectory(ConstDef.DB_BACKUP_DIR);

                File.WriteAllText(backupFile, sqlText);

                if (!(new FileInfo(backupFile)).Exists)
                {
                    OnWriteLog(string.Format("DB 백업에 실패했습니다. 백업파일[{0}]이 존재하지 않습니다.", backupFile));
                    throw new Exception("MySql backup 파일 존재하지 않음");
                }
                OnWriteLog("DB백업 완료.");
                result = true;
            }
            catch (Exception ex)
            {
                OnWriteLog(string.Format("DB를 파일[{0}]로 백업하는 중 에러가 발생했습니다.", backupFile));
                Logger.error(ex.ToString());
                //throw new Exception("DB백업중 에러발생");
            }

            return result;
        }


        /// <summary>
        /// 1. backup db
        /// c:\minicti\mysql-5.5.19-win32\bin\mysqldump --user root --password=Genesys!@# wedo_db > c:\minicti\wedo_db_20131028.dmp
        /// 2. stop & remove service
        /// 3. delete db
        /// </summary>
        /// <returns></returns>
        public bool RemovePrevDb()
        {
            bool result = false;
            OnWriteLog("기존 DB를 삭제합니다.");

            //////////////////////////////////////////
            //1. backup db
            //  - backup
            //  - check backupfile (if exists or size > 0)
            //string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
            //////////////////////////////////////////
            string mySqlServiceCmd = "";
            string mySqlServiceDir = "";
            //////////////////////////////////////////
            //2. stop & remove service
            //////////////////////////////////////////

            try
            {
                mySqlServiceDir = GetCurMySqlDir();
                mySqlServiceCmd = mySqlServiceDir + "\\bin\\mysqld.exe";

                OnWriteLog(string.Format("DB서비스[{0}]를 중지합니다.", ConstDef.MYSQL_SERVICE_NAME));
                serviceHandler.StopService(ConstDef.MYSQL_SERVICE_NAME);
                OnWriteLog("DB서비스 중지 완료.");

                OnWriteLog(string.Format("DB서비스[{0}]를 삭제합니다.", ConstDef.MYSQL_SERVICE_NAME));
                serviceHandler.RunProcess(mySqlServiceCmd, ConstDef.MYSQL_UNINSTALL_OPT);
                OnWriteLog("DB서비스 삭제 완료.");
            }
            catch (Exception ex)
            {
                OnWriteLog(string.Format("DB서비스[{0}]를 삭제할 수 없습니다.", ConstDef.MYSQL_SERVICE_NAME));
                Logger.error(ex.ToString());
                throw new Exception("MySql Service삭제중 에러발생");
            }
            //////////////////////////////////////////
            //3. delete db
            //////////////////////////////////////////
            try
            {
                OnWriteLog(string.Format("DB[{0}]를 삭제합니다.", mySqlServiceDir));
                DirectoryInfo dirInfo = new DirectoryInfo(mySqlServiceDir);

                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
                dirInfo.Delete(true);
                OnWriteLog("DB 삭제 완료.");
            }
            catch (Exception ex)
            {
                OnWriteLog(string.Format("DB[{0}]를 삭제할 수 없습니다.", mySqlServiceDir));
                Logger.error(ex.ToString());
                throw new Exception("MySql 파일삭제중 에러발생");
            }

            return true;
        }

        private string GetCurMySqlDir()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service");
            ManagementObjectCollection collection = searcher.Get();

            string cmdStr = "";
            foreach (ManagementObject obj in collection)
            {
                if (ConstDef.MYSQL_SERVICE_NAME.Equals((string)obj["Name"]))
                {
                    cmdStr = (string)obj["PathName"];
                    break;
                }
                //string name = (string)obj["Name"];
                //string pathName = (string)obj["PathName"];
                //string option = (string)obj["ServiceType"];
                //Console.WriteLine(string.Format("[{0}][{1}][{2}]", name, pathName, option));
            }

            //string cmd = "c:\\testinstall\\mysql-5.5.19-win32\\bin\\mysqld.exe --defaults-file=\\testinstall\\mysql-5.5.19-win32\\my.ini WedoSqlTest";
            string[] cmdInfo = cmdStr.Split(' ');
            FileInfo info = new FileInfo(cmdInfo[0]);
            return info.Directory.Parent.FullName;
        }

        /// <summary>
        /// 1. unzip mysql
        /// 2. set port
        /// 3. create service
        /// </summary>
        /// <returns></returns>
        public bool InstallDb()
        {
            //1. mysql압축 풀기
            OnWriteLog("InstallDb");
            Assembly _assembly;
            try
            {
                Stream zipStream;
                _assembly = Assembly.GetExecutingAssembly();
                zipStream = _assembly.GetManifestResourceStream(ConstDef.MYSQL_ZIP_FILE);//"CustomAction.mysql.mysql-5.5.19-win32.zip");
                //byte[] data = Decompress(zipStream);
                OnWriteLog("MySql을 설치합니다.");
                OnWriteLog("mysql-5.5.19 파일을 복사합니다.");
                OnWriteLog("Copy " + ConstDef.MYSQL_ZIP_FILE + " ===> " + ConstDef.MYSQL_DIR);
                UnzipFromStream(zipStream, ConstDef.MYSQL_DIR);
                OnWriteLog("파일복사를 완료했습니다.");
            }
            catch (Exception ex)
            {
                OnWriteLog("MySql zip파일 압축풀기중 에러발생");
                Logger.error("MySql zip파일 압축풀기중 에러발생 : " + ex.ToString());
                return false;
            }

            //2. 포트설정
            try
            {
                string text = File.ReadAllText(ConstDef.MYSQL_INI);
                text = Regex.Replace(text, @"\bport=\d{3,5}", string.Format("port={0}", dbPort));
                text = Regex.Replace(text, "basedir=\"BASE_DIR\"", string.Format("basedir=\"{0}\"", ConstDef.MYINI_BASE_DIR));
                text = Regex.Replace(text, "datadir=\"DATA_DIR\"", string.Format("datadir=\"{0}\"", ConstDef.MYINI_DATA_DIR));

                File.WriteAllText(ConstDef.MYSQL_INI, text);
                OnWriteLog(string.Format("포트 설정[port:{0}]",dbPort));
            }
            catch (Exception ex)
            {
                OnWriteLog("포트 설정중 에러발생");
                Logger.error("포트 설정중 에러발생 : " + ex.ToString());
                return false;
            }

            //3. 서비스등록 & 기동
            try
            {
                OnWriteLog("DB서비스 등록");
                serviceHandler.RunProcess(ConstDef.MYSQL_SERVICE_CMD, ConstDef.MYSQL_INSTALL_OPT);
                OnWriteLog(string.Format("DB서비스 등록완료[{0}]", ConstDef.MYSQL_SERVICE_CMD));
                OnWriteLog("DB서비스 기동");
                serviceHandler.StartService(ConstDef.MYSQL_SERVICE_NAME);
                OnWriteLog(string.Format("DB서비스 기동완료[{0}]", ConstDef.MYSQL_SERVICE_NAME));
            }
            catch (Exception ex)
            {
                OnWriteLog("MySql Service등록/기동중 에러발생");
                Logger.error("MySql Service등록/기동중 에러발생 : " + ex.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// 1. 기본 DB 데이터 생성
        /// 2. 회사코드 관련 데이터 생성
        /// </summary>
        /// <returns></returns>
        public bool GenerateData()
        {
            OnWriteLog("DB 데이터 생성");
            Logger.info("GenerateData");

            MySqlHandler handler = null;

            string fileName = "";
            try
            {
                OnWriteLog(string.Format("DB 접속:dbUrl[{0}]dbPort[{1}]defaultDb[{2}]dbUser[{3}]",
                    ConstDef.WEDO_DB_URL, dbPort, ConstDef.DEFAULT_DB, ConstDef.DEFAULT_DB_USER));
                handler = new MySqlHandler(ConstDef.WEDO_DB_URL, dbPort, ConstDef.DEFAULT_DB, ConstDef.DEFAULT_DB_USER);
                handler.Open();

                fileName = ConstDef.MYSQL_CREATE_USER_FILE;
                handler.ExecuteScriptByFileName(fileName);
                OnWriteLog("DB 계정생성");
                fileName = ConstDef.MYSQL_CREATE_DB_FILE;
                handler.ExecuteScriptByFileName(fileName);
                OnWriteLog("DB WeDo_DB생성");
            }
            catch (Exception ex)
            {
                OnWriteLog("DB 데이터 생성 실패");
                Logger.error(string.Format("Sql script[{0}] 실행중 오류발생", fileName) + ex.ToString());
                return false;
            }
            finally
            {
                if (handler != null) handler.Close();
            }

            //1. DB 데이터 생성
            try
            {
                handler = new MySqlHandler(ConstDef.WEDO_DB_URL, dbPort, ConstDef.WEDO_DB, ConstDef.WEDO_DB_USER, ConstDef.WEDO_DB_PASSWORD);
                handler.Open();
                fileName = ConstDef.MYSQL_CREATE_TABLE_FILE;
                handler.ExecuteScriptByFileName(fileName);
                OnWriteLog("DB 테이블 생성");
                OnWriteLog("----------------------------------------");
                OnWriteLog("DB 기초데이터 생성을 시작합니다.\n시스템에 따라 1~10분정도의 시간이 소요됩니다.");
                OnWriteLog("...");
                fileName = ConstDef.MYSQL_INSERT_DATA_FILE;
                handler.ExecuteScriptByFileName(fileName);
                OnWriteLog("DB 기초데이터 생성");

            }
            catch (Exception ex)
            {
                OnWriteLog("DB 데이터 생성 실패");
                Logger.error(string.Format("Sql script[{0}] 실행중 오류발생", fileName) + ex.ToString());
                return false;
            }
            finally
            {
                if (handler != null) handler.Close();
            }

            return true;
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        private int DoExecute(string query, Hashtable parameters)
        {
            int result = 0;
            MySqlHandler dbHandler = null;

            try
            {
                dbHandler = new MySqlHandler(ConstDef.WEDO_DB_URL, dbPort, ConstDef.WEDO_DB, ConstDef.WEDO_DB_USER, ConstDef.WEDO_DB_PASSWORD);
                dbHandler.Open();
                dbHandler.SetQuery(query);

                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                    {
                        dbHandler.Parameters(key, (string)parameters[key]);
                    }
                }

                result = dbHandler.DoExecute();
            }
            catch (Exception e)
            {
                Logger.error("트랜잭션 실행에러 : " + e.ToString());
                throw new Exception("트랜잭션 실행에러");
            }
            finally
            {
                dbHandler.Close();
            }
            return result;

        }

        private DataTable DoQuery(string query, Hashtable parameters)
        {
            DataTable dt = new DataTable();
            MySqlHandler dbHandler = null;

            try
            {
                dbHandler = new MySqlHandler(ConstDef.WEDO_DB_URL, dbPort, ConstDef.WEDO_DB, ConstDef.WEDO_DB_USER, ConstDef.WEDO_DB_PASSWORD);
                dbHandler.Open();
                dbHandler.SetQuery(query);

                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                    {
                        dbHandler.Parameters(key, (string)parameters[key]);
                    }
                }

                dt = dbHandler.DoQuery();
            }
            catch (Exception e)
            {
                Logger.error("쿼리실행에러 : " + e.ToString());
                throw new Exception("쿼리실행에러");
            }
            finally
            {
                dbHandler.Close();
            }
            return dt;
        }

        //1. 위두서버 방화벽확인 및 설치
        //2. 디비서버 방화벽확인 및 설치
        public bool RegisterFirewall()
        {
            bool result = false;

            OnWriteLog("<< 방화벽 설정 >>");
            OnWriteLog("----------------------------------------");
            Logger.info("RegisterFirewall");

            try
            {
                OnWriteLog("- MySql 서버 방화벽 등록 확인");

                string mySqlServerStatus = firewallHandler.GetByProgramPath(ConstDef.MYSQL_SERVICE_CMD);
                if (mySqlServerStatus == null)
                {
                    OnWriteLog("======> 미등록상태\n MySql 서버를 방화벽 예외등록합니다.");
                    if (firewallHandler.AddProgram(ConstDef.WEDO_MYSQL_NAME, ConstDef.MYSQL_SERVICE_CMD))
                    {
                        OnWriteLog("======> 등록 완료");
                    }
                    else
                    {
                        OnWriteLog("======> 등록 실패");
                        throw new Exception("MySqlDB서버가 방화벽 예외등록중 오류발생");
                    }
                }
                else
                {
                    OnWriteLog("이미 등록되어 있습니다.");
                }
                OnWriteLog("----------------------------------------");
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                result = false;
            }
            return result;
        }

        public event EventHandler<StringEventArgs> LogWriteHandler;

        public virtual void OnWriteLog(string msg)
        {
            Logger.info(msg);
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
            }
        }

        public void UnzipFromStream(Stream zipStream, string outFolder)
        {

            ZipInputStream zipInputStream = new ZipInputStream(zipStream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();
            int count = 0;
            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = Path.Combine(outFolder, entryFileName);
                string directoryName = Path.GetDirectoryName(fullZipToPath);
                if (directoryName.Length > 0)
                    Directory.CreateDirectory(directoryName);

                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(fullZipToPath))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);

                }
                OnWriteLog(fullZipToPath + "\\" + entryFileName);
                zipEntry = zipInputStream.GetNextEntry();

                if (count % 5 == 0) System.Threading.Thread.Sleep(500);
                count++;
            }
        }

    }
}
