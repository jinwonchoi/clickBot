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
        bool needChromeInstall = false;
        bool needFireFoxInstall = false;
        bool needJDKInstall = false;


        private FirewallHandler firewallHandler = new FirewallHandler();
        private WindowServiceHandler serviceHandler = new WindowServiceHandler();
        private SocketHandler socketHandler = new SocketHandler();

        public bool NeedChromeInstall
        {
            get { return needChromeInstall; }
            set { needChromeInstall = value; }
        }
        public bool NeedFireFoxInstall
        {
            get { return needFireFoxInstall; }
            set { needFireFoxInstall = value; }
        }
        public bool NeedJDKInstall
        {
            get { return needJDKInstall; }
            set { needJDKInstall = value; }
        }


        public bool CheckChromeInstalled()
        {
            OnWriteLog("Chrome 설치 확인");
            Logger.info("CheckChromeInstalled");
            return Utils.IsBrowserInstalled(ConstDef.CHROME);
        }

        public bool CheckFireFoxInstalled()
        {
            OnWriteLog("FireFox 설치 확인");
            Logger.info("CheckFireFoxInstalled");
            return Utils.IsBrowserInstalled(ConstDef.FIREFOX);
        }

        public bool CheckJDKInstalled()
        {
            OnWriteLog("JDK 설치 확인");
            Logger.info("CheckJDKInstalled");
            return Utils.IsJDKInstalled();
        }

        public bool InstallChrome()
        {
            return InstallProgram(ConstDef.CHROME_RES_FILE, ConstDef.CHROME_INSTALLER, true);
        }

        public bool InstallFireFox()
        {
            return InstallProgram(ConstDef.FIREFOX_RES_FILE, ConstDef.FIREFOX_INSTALLER, true);
        }

        public bool InstallJDK()
        {
            return InstallProgram(ConstDef.JDK_RES_FILE, ConstDef.JDK_INSTALLER, false);
        }

        public bool InstallProgram(string resFile, string fileName, bool needExecute)
        {
            OnWriteLog(ConstDef.WORK_DIR + fileName + " 설치 시작");
            Assembly _assembly;
            Process P = null;

            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                Stream exeStream = _assembly.GetManifestResourceStream(resFile);

                FileInfo fileInfoOutputFile = new FileInfo(ConstDef.WORK_DIR + fileName);

                if (fileInfoOutputFile.Exists)
                    fileInfoOutputFile.Delete();

                FileStream streamToOutputFile = fileInfoOutputFile.OpenWrite();
                //---------------------------------
                //SAVE TO DISK OPERATION
                //---------------------------------
                const int size = 4096;
                byte[] bytes = new byte[4096];
                int numBytes;
                while ((numBytes = exeStream.Read(bytes, 0, size)) > 0)
                {
                    streamToOutputFile.Write(bytes, 0, numBytes);
                }
                streamToOutputFile.Close();
                exeStream.Close();

                OnWriteLog(string.Format("{0} 파일을 복사합니다.", fileName));

                if (needExecute)
                {
                    P = Process.Start(ConstDef.WORK_DIR + fileName);
                    P.WaitForExit();
                    OnWriteLog(ConstDef.WORK_DIR + fileName + " 설치 완료");
                }
            }
            catch (Exception ex)
            {
                OnWriteLog(fileName + " 파일 생성중 에러발생");
                Logger.error(fileName + " 파일 생성중 에러발생 : " + ex.ToString());
                return false;
            }

            return (needExecute && P.ExitCode == 0);
        }

        public bool InstallJarFile()
        {
            OnWriteLog("InstallJarFile");
            Assembly _assembly;
            try
            {
                //폴더 삭제
                DirectoryInfo dBinInfo = new DirectoryInfo(ConstDef.CLICKBOT_BIN_DIR);
                if (dBinInfo.Exists)
                    dBinInfo.Delete(true);
                DirectoryInfo dConfInfo = new DirectoryInfo(ConstDef.CLICKBOT_CONF_DIR);
                if (dConfInfo.Exists)
                    dConfInfo.Delete(true);
                DirectoryInfo dLibInfo = new DirectoryInfo(ConstDef.CLICKBOT_LIB_DIR);
                if (dLibInfo.Exists)
                    dLibInfo.Delete(true);

                //jar file 압축 풀기
                Stream zipStream;
                _assembly = Assembly.GetExecutingAssembly();
                zipStream = _assembly.GetManifestResourceStream(ConstDef.JAR_RES_FILE);//"CustomAction.mysql.mysql-5.5.19-win32.zip");
                //byte[] data = Decompress(zipStream);
                OnWriteLog("biral.zip을 압축을 풉니다.");
                OnWriteLog("Copy " + ConstDef.JAR_INSTALLER + " ===> " + ConstDef.WORK_DIR);
                UnzipFromStream(zipStream, ConstDef.WORK_DIR);
                OnWriteLog("파일복사를 완료했습니다.");
            }
            catch (Exception ex)
            {
                OnWriteLog("biral.zip파일 압축풀기중 에러발생");
                Logger.error("biral.zip파일 압축풀기중 에러발생 : " + ex.ToString());
                return false;
            }
            return true;
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
                OnWriteLog("- Chrome Webdriver 방화벽 등록 확인");
                string wedoServerStatus = firewallHandler.GetByProgramName(ConstDef.WEBDRIVER_CHROME);
                if (wedoServerStatus == null)
                {
                    OnWriteLog("======> 미등록상태\n Chrome webdriver를 방화벽 예외등록합니다.");
                    if (firewallHandler.AddProgram(ConstDef.WEBDRIVER_CHROME_NAME, ConstDef.WEBDRIVER_CHROME_CMD))
                    {
                        OnWriteLog("======> 등록 완료");
                    }
                    else
                    {
                        OnWriteLog("======> 등록 실패");
                        throw new Exception("Chrome webdriver 방화벽 예외등록중 오류발생");
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
