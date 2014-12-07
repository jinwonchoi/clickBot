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
        public const string LOG_FILE_PREFIX = "clickBot_"; //wedo server installer
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
        public const string CLICKBOT_BIN_DIR = WORK_DIR + "\\bin\\";         //WDMsgServer
        public const string CLICKBOT_CONF_DIR = WORK_DIR + "\\conf\\";         //WDMsgServer
        public const string CLICKBOT_LIB_DIR = WORK_DIR + "\\lib\\";         //WDMsgServer

        #endregion

        #region db_install
        public const string MYSQL_SERVICE_NAME = "WedoSqlTest";
        public const string MYINI_BASE_DIR = "C:/" + WEDO_MAIN_DIR + "/db/mysql-5.5.19-win32/";//WeDoMySQL
        public const string MYINI_DATA_DIR = MYINI_BASE_DIR + "Data/";//WeDoMySQL
        public const string MYSQL_DIR = WORK_DIR + "db\\mysql-5.5.19-win32\\";//WeDoMySQL
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
        public const string WEDO_DB_BACKUP_OPT = " --default-character-set=euckr --user root --password=Genesys!@# wedo_db ";
        public const string WEDO_DB_BACKUP_FILE = DB_BACKUP_DIR + "\\wedo_db_{0}.dmp";
        #endregion

        #region db_info
        public const string DEFAULT_DB = "mysql";
        public const string WEDO_DB = "wedo_db";
        public const string WEDO_DB_URL = "127.0.0.1";
        public const string WEDO_DB_USER = "root";
        public const string WEDO_DB_PASSWORD = "Genesys!@#";
        public const int MYSQL_PORT = 3306;
        #endregion

#if (SERVER_INSTAL)
        public const string CONFIG_MSGR_PORT_NAME = "MSGR_PORT"; //wedo server installer
        public const string CONFIG_CRM_PORT_NAME = "CRM_PORT";
        public const string CONFIG_DB_PORT_NAME = "DB_PORT";
#endif
#if (MSGR_INSTALL)
        public const string CONFIG_MSGR_PORT_NAME = "SocketPortMsgr"; //wedo server installer
        public const string CONFIG_CRM_PORT_NAME = "SocketPortCrm";
        public const string CONFIG_FTP_PORT_NAME = "SocketPortFtp";
        public const string CONFIG_DB_PORT_NAME = "DbPort";
#endif

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string YES = "yes";
        public const string NO = "no";

        public const string DbIpAddress = "127.0.0.1";
        public const int DbPort = 3306;
        public const string DbName ="biraldb";
        public const string DbUser = "biralman";
        public const string DbPasswd = "biralman!@#";
        public const string CHROME = "Google Chrome";
        public const string FIREFOX = "FIREFOX.EXE";
        public const string IEXPLORER = "IEXPLORE.EXE";
        public const string JDK_INSTALLER = "jdk_7u55_windows_i586.exe";

    }


}