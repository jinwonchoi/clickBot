using System;
using System.Windows.Forms;
using ClickBot.ValueObject;
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
        #region wedo_server - 프로그램별 정의
        public const string REG_APP_NAME = "clickBot Admin";
        public const string VERSION = "1.0.0";
        #endregion

        #region logfile
        public const int LOG_BACKUP_PERIOD = -14;

        public const string LOG_FILE_PREFIX = "clickBotAdmin_"; //wedo_server
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
        public const string CLICKBOT_MAIN_DIR = "bgSys";

        public const string WORK_DIR = "\\" + CLICKBOT_MAIN_DIR + "\\clickBot Admin\\";         //WDMsgServer

        #endregion

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string YES = "yes";
        public const string NO = "no";

        public const string DbIpAddress = "127.0.0.1";
        public const int DbPort = 3308;
        public const string DbName ="biraldb";
        public const string DbUser = "biralman";
        public const string DbPasswd = "biralman!@#";


        public const string BROWSER_TYPE_CHROME = "C";
        public const string BROWSER_TYPE_IE = "I";
        public const string BROWSER_TYPE_FIREFOX = "F";

        public const string DEVICE_TYPE_MOBILE = "M";
        public const string DEVICE_TYPE_WEB= "W";

        public const string SITE_TYPE_NAVER = "N";
        public const string SITE_TYPE_DAUM = "D";

        public const string PURCHASE_TYPE_CARD = "C";
        public const string PURCHASE_TYPE_BANK = "B";

        public const string TASK_TYPE_AUTO = "A";
        public const string TASK_TYPE_AUTO_NAME = "검색어자동완성";
        public const string TASK_TYPE_KEYWORD = "K";
        public const string TASK_TYPE_KEYWORD_NAME = "연관검색어";
        public const string TASK_TYPE_TOPSITE = "T";
        public const string TASK_TYPE_TOPSITE_NAME = "사이트순위올리기";
        public const string TASK_TYPE_BLOG = "B";
        public const string TASK_TYPE_BLOG_NAME = "블로그순위올리기";


        public const int BROWSER_RATIO_CHROME = 40;
        public const int BROWSER_RATIO_IE = 40;
        public const int BROWSER_RATIO_FIREFOX = 20;

        public const int DEVICE_RATIO_WEB = 50;
        public const int DEVICE_RATIO_MOBILE = 50;

        public const int PERIOD_RATIO_BUSY = 50;
        public const int PERIOD_RATIO_PREV = 10;
        public const int PERIOD_RATIO_NEXT = 35;
        public const int PERIOD_RATIO_IDLE = 5;

        public const string IPINFO_USE_TYPE_NORMAL = "N";
        public const string IPINFO_USE_TYPE_LOGIN = "L";

    }

    public class CodeUtils
    {
        public static string TaskTypeName(string code)
        {
            if (code.Equals(ConstDef.TASK_TYPE_AUTO)) {
                return ConstDef.TASK_TYPE_AUTO_NAME;
            } 
            if (code.Equals(ConstDef.TASK_TYPE_KEYWORD)) {
                return ConstDef.TASK_TYPE_KEYWORD_NAME;
            }
            if (code.Equals(ConstDef.TASK_TYPE_TOPSITE)) {
                return ConstDef.TASK_TYPE_TOPSITE_NAME;
            }
            if (code.Equals(ConstDef.TASK_TYPE_BLOG)) {
                return ConstDef.TASK_TYPE_BLOG_NAME;
            }
            return "";
        }

        public static void InitCBTaskType(ComboBox cBox)
        {
            cBox.Items.Add(new ComboPair("K", "연관검색어"));
            cBox.Items.Add(new ComboPair("T", "사이트 순위올리기"));
            cBox.Items.Add(new ComboPair("B", "블로그 순위올리기"));
            cBox.Items.Add(new ComboPair("A", "검색어 자동완성"));
            cBox.SelectedIndex = -1;
        }
    }

}