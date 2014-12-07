using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.IO;
using System.Diagnostics;

namespace WeDoCommon
{
    public partial class Logger
    {
        public static LOGLEVEL level = LOGLEVEL.DEBUG;
        public static string logDir = ConstDef.LOG_DIR;
        public static string logFile = ConstDef.LOG_FILE;

        public static void setLogLevel(LOGLEVEL level)
        {
            Logger.level = level;
        }

        public static void setLogDir(string dir)
        {
            logDir = dir;
        }

        public static void setLogFile(string file)
        {
            logFile = file;
        }

        public static void debug(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.DEBUG)
                WriteLine("[DEBUG]", format, arg);
        }
        public static void info(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.INFO)
                WriteLine("[INFO ]", format, arg);
        }
        public static void error(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.ERROR)
                WriteLine("[ERROR]", format, arg);
        }
        private static void WriteLine(string mode, string format, params object[] arg)
        {
            LogWrite(mode, string.Format(format, arg));
        }

        static StreamWriter sw;// = new StreamWriter(SocConst.LOG_FILE + DateTime.Now.ToString("yyyyMMdd") + ".txt", true, Encoding.Default);
        static Object logFileLock = new Object();

        private static StackFrame GetInvokingFrame(StackTrace trace, int depth)
        {
            StackFrame result = trace.GetFrame(depth);
            if (result == null)
                result = GetInvokingFrame(trace, ++depth);
            else
            {
                string fileName = trace.GetFrame(depth).GetFileName();
                string methodName = trace.GetFrame(depth).GetMethod().Name;
                if ((fileName != null && "Logger.cs".Equals(Utils.GetFileName(fileName)))
                    || "LogWrite".Equals(methodName))
                {
                    if (depth > 5)
                        result = trace.GetFrame(depth);
                    else
                        result = GetInvokingFrame(trace, ++depth);
                }
                else
                    result = trace.GetFrame(depth);
            }
            return result;
        }

        private static void LogWrite(string mode, string log)
        {
            lock (logFileLock)
            {
                try
                {
                    if (!Directory.Exists(logDir))
                        Directory.CreateDirectory(logDir);
                    sw = new StreamWriter(logDir + "\\" + string.Format(logFile, DateTime.Now.ToString(ConstDef.LOG_FILE_FMT)), true, Encoding.UTF8);

                    StackTrace stackTrace = new StackTrace(true);
                    StackFrame frame = GetInvokingFrame(stackTrace, 1);
                    string methodName = frame.GetMethod().DeclaringType.Name + "." + frame.GetMethod().Name;
                    string fileName = frame.GetFileName().Substring(frame.GetFileName().LastIndexOf('\\') + 1);
                    
                    int lineNo = frame.GetFileLineNumber();

                    string line;

                    if (level >= LOGLEVEL.DEBUG)
                        line = string.Format("[{0}][{1}][{2}:{3}][{4}]{5}", DateTime.Now.ToString(ConstDef.LOG_DATE_TIME_FMT), mode, fileName, lineNo, methodName, log);
                    else
                        line = string.Format("[{0}][{1}][{2}:{3}]{4}", DateTime.Now.ToString(ConstDef.LOG_DATE_TIME_FMT), mode, methodName, lineNo, log);

                    sw.WriteLine(line);
                    Console.WriteLine(line);
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    if (sw != null) sw.Close();
                    sw = new StreamWriter(logDir + "\\" + string.Format(logFile, DateTime.Now.ToString(ConstDef.LOG_FILE_FMT)), true, Encoding.UTF8);
                    string line = string.Format("[{0}][{1}]{2}", DateTime.Now.ToString(ConstDef.LOG_DATE_TIME_FMT), mode, log);
                    sw.WriteLine(line);
                    Console.WriteLine(line);
                    sw.Flush();
                }
                finally { if (sw != null) { sw.Close(); } }
            }
        }

        /// <summary>
        /// 최초 기동시 작업
        /// 1. 로그파일 백업
        /// 1.1. 10일이전 파일 백업 & 삭제 ==> \eclues\AppData\logBackup\wedo_server_log_20131127.zip
        /// </summary>
        public static void BackupOnInit()
        { 
            _BackupOnInit(ConstDef.LOG_FILE, ConstDef.LOG_FILE_PREFIX, ConstDef.LOG_BACKUP_FILE);

#if (WEDO_SERVER)
            _BackupOnInit(ConstDef.LOG_FILE_CALLSIP, ConstDef.LOG_FILE_PREFIX_CALLSIP, ConstDef.LOG_BACKUP_FILE_CALLSIP);
            _BackupOnInit(ConstDef.LOG_FILE_CALLCID, ConstDef.LOG_FILE_PREFIX_CALLCID, ConstDef.LOG_BACKUP_FILE_CALLCID);

            _BackupOnInit(ConstDef.LOG_FILE_CALLKPN, ConstDef.LOG_FILE_PREFIX_CALLKPN, ConstDef.LOG_BACKUP_FILE_CALLKPN);
#endif
        }

        private static void _BackupOnInit(string logFile, string logFilePrefix, string logBackupFile) {
            /*
             *         
        public const int LOG_BACKUP_PERIOD = -14;
        public const string LOG_FILE_PREFIX = "wd_server_";
        public const string LOG_FILE_EXT = ".log";
        public const string LOG_FILE = LOG_FILE_PREFIX +"{0}"+LOG_FILE_EXT;
        public const string LOG_DIR = WEDO_SERVER_DIR + "log";
        public const string LOG_FILE_FMT = "yyyyMMdd";
        public const string LOG_DATE_TIME_FMT = "yyyy-MM-dd HH:mm:sss";
             */
            DateTime compareDate = DateTime.Now.AddDays(ConstDef.LOG_BACKUP_PERIOD);
            string strCompareDate = compareDate.ToString(ConstDef.LOG_FILE_FMT);

            if (!Directory.Exists(ConstDef.LOG_DIR)) return;
            string[] files = Directory.GetFiles(ConstDef.LOG_DIR, logFile, SearchOption.TopDirectoryOnly);
            string fileDate = "";

            List<string> fileList = new List<string>();

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                
                fileDate = fileInfo.Name
                    .Replace(logFilePrefix, "")
                    .Replace(ConstDef.LOG_FILE_EXT, "");

                if (strCompareDate.CompareTo(fileDate) >= 0)
                {
                    fileList.Add(file);
                }
            }
            
            if (fileList.Count <= 10)
            {
                Logger.info(string.Format("로그파일갯수가 10개 이하[{0}]로 백업하지 않음.", fileList.Count));
                return;
            }

            string backupFile = ConstDef.LOG_BACKUP_DIR
                + string.Format(logBackupFile, DateTime.Now.ToString(ConstDef.LOG_FILE_FMT));

            ZipUtil.CreateZipfile(backupFile, fileList);

            foreach (string file in fileList)
            {
                FileInfo fileInfo = new FileInfo(file);

                fileInfo.Delete();

                Logger.info(string.Format("백업된 파일삭제[{0}]", file));
            }
        
        }

    }

    public enum LOGLEVEL
    {
        ERROR = 0,
        INFO = 1,
        DEBUG = 2
    }
}
