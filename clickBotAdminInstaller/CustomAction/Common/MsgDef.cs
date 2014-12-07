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
        public const string LOG_FILE_PREFIX = "wd_server_inst_"; //wedo server installer
        public const string LOG_DIR = WEDO_SERVER_DIR + "log\\";
        public const string LOG_FILE_EXT = ".log";
        public const string LOG_FILE = LOG_FILE_PREFIX +"{0}"+LOG_FILE_EXT;
        public const string LOG_BACKUP_FILE = LOG_FILE_PREFIX + "log_{0}" + ".zip";
        public const string LOG_BACKUP_DIR = APP_DATA_DIR + "logBackup\\";
        public const string LOG_FILE_FMT = "yyyyMMdd";
        public const string LOG_DATE_TIME_FMT = "yyyy-MM-dd HH:mm:sss";

        public const string TIME_KEY_FMT = "yyyyMMddHHmmss";

        #endregion

        #region directory info
        public const string WEDO_MAIN_DIR = "bgSys";

        public const string WORK_DIR = "\\" + WEDO_MAIN_DIR + "\\";
        public const string APP_DATA_DIR = WORK_DIR + "AppData\\";
        public const string APP_DATA_CONFIG_DIR = APP_DATA_DIR + "config\\";
        public const string DB_BACKUP_DIR = APP_DATA_DIR + "dbBackup\\";
        public const string WEDO_SERVER_DIR = WORK_DIR + "clickbot Admin\\";         //WDMsgServer

        public const string mainTitle = "clickBot Admin 프로그램 설치";

        public const string WEDO_SERVER_NAME = "clickbot Admin";
        public const string WEDO_MYSQL_NAME = "Biral MySql Server";

        public const string WEDO_SERVER_EXE = "clickBotAdmin.exe";         //WDMsgServer
        public const string WEDO_SERVER_CONFIG = "clickBotAdmin.exe.config";         //WDMsgServer
        public const string WEDO_SERVER_CMD = WEDO_SERVER_DIR + WEDO_SERVER_EXE;         //WDMsgServer
        
        public const string WEDO_DB_PORT_FIREWALL_NAME = "Biral clickBot Db Port";

        #endregion

        #region db_install
        public const string MYSQL_SERVICE_NAME = "BiralSql";
        public const string MYINI_BASE_DIR = "C:/" + WEDO_MAIN_DIR + "/mysql-5.5.19-win32/";//WeDoMySQL
        public const string MYINI_DATA_DIR = MYINI_BASE_DIR + "Data/";//WeDoMySQL
        public const string MYSQL_DIR = WORK_DIR + "mysql-5.5.19-win32\\";//WeDoMySQL
        public const string MYSQL_INI = MYSQL_DIR + "my.ini";//WeDoMySQL
        public const string MYSQL_SERVICE_CMD = MYSQL_DIR + "bin\\mysqld.exe";//WeDoMySQL
        public const string MYSQL_INSTALL_OPT = "--install " + MYSQL_SERVICE_NAME
            + " --defaults-file=" + MYSQL_INI;
        public const string MYSQL_UNINSTALL_OPT = "--remove " + MYSQL_SERVICE_NAME;
        //\MiniCTI\mysql-5.5.19-win32\bin\mysqld --defaults-file=\MiniCTI\mysql-5.5.19-win32\my.ini WedoSql

        //db install
        public const string APP_NAMESPACE = "CustomAction";
        public const string MYSQL_ZIP_FILE = APP_NAMESPACE + ".mysql.mysql-5.5.19-win32.zip";
        public const string MYSQL_CREATE_USER_FILE = APP_NAMESPACE + ".mysql.create_user.sql";
        public const string MYSQL_CREATE_DB_FILE = APP_NAMESPACE + ".mysql.create_database.sql";
        public const string MYSQL_CREATE_TABLE_FILE = APP_NAMESPACE + ".mysql.create_table.sql";
        public const string MYSQL_INSERT_DATA_FILE = APP_NAMESPACE + ".mysql.insert_data.sql";

        
        //db backup
        public const string MYSQL_BACKUP_CMD = MYSQL_DIR + "bin\\mysqldump.exe";
        public const string WEDO_DB_BACKUP_OPT = " --default-character-set=euckr --user biralman --password=biralman!@# biraldb ";
        public const string WEDO_DB_BACKUP_FILE = DB_BACKUP_DIR + "\\biraldb_{0}.dmp";
        #endregion

        #region db_info
        public const string DEFAULT_DB = "mysql";
        public const string WEDO_DB = "biraldb";
        public const string WEDO_DB_URL = "127.0.0.1";
        public const string DEFAULT_DB_USER = "root";
        public const string DEFAULT_DB_PASSWORD = "Genesys!@#";
        public const string WEDO_DB_USER = "biralman";
        public const string WEDO_DB_PASSWORD = "biralman!@#";
        public const int MYSQL_PORT = 3308;
        #endregion

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string YES = "yes";
        public const string NO = "no";
        public const string PIPE = "&PIP"; //==> "|"
        public const string UNDERSCORE = "&UNS"; //==> "_"
    }

}