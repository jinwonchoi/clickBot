using System;
namespace WeDoCommon
{
    /// <summary>
    /// /define:XXX
    /// XXX=WEDO_SERVER
    /// XXX=WEDO_MSGR
    /// XXX=CONFIG_UTIL
    /// XXX=DB_IMPORT
    /// XXX=SERVER_INSTAL
    /// XXX=MSGR_INSTALL
    /// XXX=CALL_SIP
    /// XXX=CALL_CID
    /// XXX=CALL_KPN
    /// </summary>
    public sealed class ConstDef
    {

        #region logfile
        public const int LOG_BACKUP_PERIOD = -14;
        public const string LOG_FILE_PREFIX = "clickBot_inst_"; //wedo server installer
        public const string LOG_DIR = WORK_DIR + "log\\";
        public const string LOG_FILE_EXT = ".log";
        public const string LOG_FILE = LOG_FILE_PREFIX +"{0}"+LOG_FILE_EXT;
        public const string LOG_BACKUP_FILE = LOG_FILE_PREFIX + "log_{0}" + ".zip";
        public const string LOG_BACKUP_DIR = WORK_DIR + "logBackup\\";
        public const string LOG_FILE_FMT = "yyyyMMdd";
        public const string LOG_DATE_TIME_FMT = "yyyy-MM-dd HH:mm:sss";

        public const string TIME_KEY_FMT = "yyyyMMddHHmmss";

        #endregion

        #region directory info
        public const string WEDO_MAIN_DIR = "bgSys";

        public const string WORK_DIR = "\\" + WEDO_MAIN_DIR + "\\clickBot\\";
        public const string APP_DATA_CONFIG_DIR = WORK_DIR + "config\\";
        public const string DB_BACKUP_DIR = WORK_DIR + "dbBackup\\";
        public const string CLICKBOT_BIN_DIR = WORK_DIR+"\\bin\\";         //WDMsgServer
        public const string CLICKBOT_CONF_DIR = WORK_DIR + "\\conf\\";         //WDMsgServer
        public const string CLICKBOT_LIB_DIR = WORK_DIR + "\\lib\\";         //WDMsgServer

        public const string mainTitle = "clickBot 프로그램 설치";
        public const string APP_NAMESPACE = "CustomAction";
        public const string CHROME_INSTALLER = "ChromeSetup.exe";
        public const string CHROME_RES_FILE = APP_NAMESPACE + ".browsers.ChromeSetup.exe";
        public const string FIREFOX_INSTALLER = "Firefox_Setup_29.0.1.exe";
        public const string FIREFOX_RES_FILE = APP_NAMESPACE + ".browsers.Firefox_Setup_29.0.1.exe";
        public const string JDK_INSTALLER = "jdk_7u55_windows_i586.exe";
        public const string JDK_RES_FILE = APP_NAMESPACE + ".browsers.jdk_7u55_windows_i586.exe";

        public const string JAR_INSTALLER = "biral.zip";
        public const string JAR_RES_FILE = APP_NAMESPACE + ".browsers.biral.zip";


        public const string WEDO_CLIENT_NAME = "clickBot";

        public const string WEDO_CLIENT_EXE = "clickBot.exe";         //WDMsgServer
        public const string WEDO_CLIENT_CONFIG = "clickBot.exe.config";         //WDMsgServer
        public const string WEDO_CLIENT_CMD = CLICKBOT_BIN_DIR + WEDO_CLIENT_EXE;         //WDMsgServer
        
        public const string WEBDRIVER_CHROME_PORT_FIREWALL_NAME = "clickBot ChromeDriver Port";
        public const string WEBDRIVER_IE_PORT_FIREWALL_NAME = "clickBot IeDriver Port";
        public const string WEBDRIVER_CHROME = "chromedriver.exe";
        public const string WEBDRIVER_CHROME_NAME = "chromedriver";
        public const string WEBDRIVER_CHROME_CMD = CLICKBOT_BIN_DIR + WEBDRIVER_CHROME;

        #endregion

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string YES = "yes";
        public const string NO = "no";
        public const string PIPE = "&PIP"; //==> "|"
        public const string UNDERSCORE = "&UNS"; //==> "_"


        public const string CHROME = "Google Chrome";
        public const string FIREFOX = "FIREFOX.EXE";
        public const string IEXPLORER = "IEXPLORE.EXE";

    }

}