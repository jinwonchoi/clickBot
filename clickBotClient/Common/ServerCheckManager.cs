using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WeDoCommon
{
    class ServerCheckManager
    {

        public event EventHandler<StringEventArgs> LogWriteHandler;

        private ServerCheckStep _checkStep = ServerCheckStep.None;
        private FirewallHandler _fwManager = new FirewallHandler();

        private WindowServiceHandler serviceHandler = new WindowServiceHandler();
        private SocketHandler _socHandler;
        MySqlHandler handler;

        //방화벽목록
        //*프로그램
        //1. 클라이언트
        //2. 서버프로그램
        //
        //2.포트
        public const string WEDO_SERVER_NAME = "WeDo Server";
        public const string WEDO_CLIENT_NAME = "WeDo Messenger";
        public const string WEDO_MYSQL_NAME = "WeDo MySql Server";

        public const string WEDO_SERVER = "C:\\eclues\\WeDo Server\\WD_Server.exe";         //WDMsgServer
        public const string WEDO_CLIENT = "C:\\eclues\\WeDo\\WDMsg_Client.exe";             //WDMsgClient
        public const string WEDO_MYSQL = "C:\\MiniCTI\\mysql-5.5.19-win32\\bin\\mysqld.exe";//WeDoMySQL
        public const int MYSQL_PORT = 3306;

        public const string MY_SQL_SERVICE = "WedoSql";

        private int curMySqlPort = 3306;

        public ServerCheckManager()
        {
            _socHandler = new SocketHandler();
            _socHandler.LogWriteHandler += this.OnLogWrite;
            handler = new MySqlHandler("127.0.0.1", curMySqlPort, "wedo_db", "root", "Genesys!@#");
        }

        private void OnLogWrite(object sender, StringEventArgs e)
        {
            OnWriteLog(e.EventString);
        }
        
        public ServerCheckStep GetCheckStep()
        {
            return _checkStep;
        }

        //서비스 등록/기동 확인 확인
        public string CheckMySqlService()
        {
            string result = "";
            if (serviceHandler.ServiceExists(MY_SQL_SERVICE))
            {
                result = "서비스[WedoSql]등록상태";
            }
            else
            {
                result = "서비스[WedoSql]미등록상태";
            }
            if (serviceHandler.IsServiceRunning(MY_SQL_SERVICE))
            {
                result += "; 기동중";
            }
            else
            {
                result += "; 중지상태";
            }
            return result;
        }

        //서비스 기동
        public bool StartMySql()
        {
            return serviceHandler.StartService(MY_SQL_SERVICE);
        }
        //서비스 중지
        public bool StopMySql()
        {
            return serviceHandler.StopService(MY_SQL_SERVICE);
        }

        //포트 확인 
        public bool CheckMySqlPort(int port)
        {
            bool result = false;

            try
            {
                this.SetMySqlPort(port);
                result = _socHandler.IsTcpPortInUse(curMySqlPort);
            }            
            catch (Exception e)
            {
                OnWriteLog("MySql 포트 확인 에러 : " + e.ToString());
            }

            return result;
        }

        //클라이언트 방화벽 확인
        //1. WDMsg_Client.exe 
        //2. 각종유틸
        // ==> 상태확인
        public string CheckWDServerFirewallStatus()
        {
            Logger.info("WeDoServer방화벽 체크중...");
            _checkStep = ServerCheckStep.WDServerFirewallCheck;

            return _fwManager.GetByProgramPath(WEDO_SERVER);
        }

        public string CheckMySqlFirewallStatus()
        {
            Logger.info("MySql 방화벽 체크중...");
            _checkStep = ServerCheckStep.MySqlFirewallCheck;

            return _fwManager.GetByProgramPath(WEDO_MYSQL);
        }

        public bool SetWDServerFirewall()
        {
            Logger.info("WeDoServer방화벽 등록...");
            _checkStep = ServerCheckStep.WDServerFirewallCheck;

            return _fwManager.AddProgram(WEDO_SERVER_NAME, WEDO_SERVER);
        }

        public bool ReleaseWDServerFirewall()
        {
            Logger.info("WeDoServer방화벽 등록해제...");
            _checkStep = ServerCheckStep.WDServerFirewallCheck;

            return _fwManager.RemoveProgram(WEDO_SERVER);
        }

        public bool SetMySqlFirewall()
        {
            Logger.info("MySql port 방화벽 등록...");
            _checkStep = ServerCheckStep.MySqlFirewallCheck;

            return _fwManager.AddProgram(WEDO_MYSQL_NAME, WEDO_MYSQL);
        }

        public bool ReleaseMySqlFirewall()
        {
            Logger.info("MySql port 방화벽 등록해제...");
            _checkStep = ServerCheckStep.MySqlFirewallCheck;

            return _fwManager.RemoveProgram(WEDO_MYSQL);
        }

        public bool SetMySqlPort(int port)
        {
            bool result = false;
            try {
            this.curMySqlPort = port;
            handler = new MySqlHandler("127.0.0.1", curMySqlPort, "wedo_db", "root", "Genesys!@#");
            result = true;
            }
            catch (Exception e)
            {
                OnWriteLog("MySql 서버 접속테스트 에러 : " + e.ToString());
            }
            return result;

        }


        public bool CheckMySqlConnection()
        {
            bool result = false;
            _checkStep = ServerCheckStep.MySqlPing;
            try
            {
                OnWriteLog("MySql 서버 접속테스트...");
                
                handler.Open();

                result = handler.Ping();
                if (result)
                {
                    OnWriteLog("MySql 서버 접속테스트 성공");
                }
                else
                {
                    OnWriteLog("MySql 서버 접속테스트 실패");
                }
            }
            catch (Exception e)
            {
                OnWriteLog("MySql 서버 접속테스트 에러 : " + e.ToString());
            }
            finally
            {
                handler.Close();
            }
            return result;
        }

        /// <summary>
        /// 1. t_company
        /// 2. t_user
        /// 3. t_l_code
        /// 4. t_s_code
        /// </summary>
        /// <returns></returns>
        public string GetCompanyCd()
        {
            string result = null;
            _checkStep = ServerCheckStep.MySqlComCd;
            string sql = null;
            DataTable dt = null;
            try
            {
                OnWriteLog("회사코드 확인.");
                handler.Open();
                
                //t_company
                sql = "select com_cd, com_nm from t_company";
                handler.SetQuery(sql);
                OnWriteLog("실행쿼리문:"+sql);

                dt = handler.DoQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    result += dr["com_cd"].ToString() + ":" + dr["com_nm"].ToString();
                    OnWriteLog(string.Format("회사코드[{0}]회사명[{1}]", dr["com_cd"].ToString(), dr["com_nm"].ToString()));
                }
                //t_user
                sql = "select com_cd, user_id, user_nm from t_user";
                handler.SetQuery(sql);
                OnWriteLog("실행쿼리문:" + sql);
                
                dt = handler.DoQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    result += dr["com_cd"].ToString() + ":" + dr["user_id"].ToString() + ":" + dr["user_nm"].ToString();
                    OnWriteLog(string.Format("회사코드[{0}]사용자ID[{1}]사용자명[{2}]", dr["com_cd"].ToString(), dr["user_id"].ToString(), dr["user_nm"].ToString()));
                }
                //t_l_code
                sql = "select com_cd, l_menu_cd, l_menu_nm from t_l_code";
                handler.SetQuery(sql);
                OnWriteLog("실행쿼리문:" + sql);
                
                dt = handler.DoQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    result += dr["com_cd"].ToString() + ":" + dr["l_menu_cd"].ToString() + ":" + dr["l_menu_nm"].ToString();
                    OnWriteLog(string.Format("회사코드[{0}]코드[{1}]코드명[{2}]", dr["com_cd"].ToString(), dr["l_menu_cd"].ToString(), dr["l_menu_nm"].ToString()));
                }
                //t_s_code
                sql = "select com_cd, l_menu_cd, s_menu_cd, s_menu_nm from t_s_code";
                handler.SetQuery(sql);
                OnWriteLog("실행쿼리문:" + sql);
                
                dt = handler.DoQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    result += dr["com_cd"].ToString() + ":" + dr["l_menu_cd"].ToString() + ":" + dr["s_menu_cd"].ToString() + ":" + dr["s_menu_nm"].ToString();
                    OnWriteLog(string.Format("회사코드[{0}]코드[{1}]코드명[{2}]", dr["com_cd"].ToString(), dr["s_menu_cd"].ToString(), dr["s_menu_nm"].ToString()));
                }
            }
            catch (Exception e)
            {
                OnWriteLog("회사코드 확인 에러 : " + e.ToString());
            }
            finally
            {
                handler.Close();
            }
            return result;
            
        }
        /// <summary>
        /// 방화벽 활성화/비활성화 확인
        /// </summary>
        /// <returns></returns>
        public bool IsFirewallEnabled()
        {
            Logger.info("방화벽 활성화 체크...");
            _checkStep = ServerCheckStep.MySqlFirewallCheck;

            string fwStatus = "";

            if (_fwManager.IsFirewallEnabled())
            {
                fwStatus = "방화벽활성화상태";
            }
            else
            {
                fwStatus = "방화벽비활성화상태";
            }
            Logger.info("===>"+fwStatus);
            return _fwManager.IsFirewallEnabled();
        }

        public virtual void OnWriteLog(string msg)
        {
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
            }
        }

        //UDP 포트 확인 
        public bool CheckUdpPort(int port)
        {
            bool result = false;

            try
            {
                result = _socHandler.IsUdpPortInUse(port);
            }
            catch (Exception e)
            {
                OnWriteLog(string.Format("{0} 포트 확인 에러 : " + e.ToString(), port));
            }

            return result;
        }

        //TCP 포트 확인
        public bool CheckTcpPort(int port)
        {
            bool result = false;

            try
            {
                result = _socHandler.IsTcpPortInUse(port);
            }
            catch (Exception e)
            {
                OnWriteLog(string.Format("{0} 포트 확인 에러 : " + e.ToString(), port));
            }

            return result;
        }

        /// <summary>
        ///3. 8882로 전송
        ///4. 8883이 대기 및 수신
        /// </summary>
        /// <returns></returns>
        public bool CheckBasicConnection()
        {
            _checkStep = ServerCheckStep.WDServerPing;

            _socHandler.SendUDP(8883, "127.0.0.1", 8882, "8881전송테스트");

            return true;
        }

        public void RunMySqlClient()
        {
            string strCmdText;
            strCmdText = "/C c:\\MiniCTI\\mysql-5.5.19-win32\\bin\\mysql -h 127.0.0.1 -u root -p --password=Genesys!@# wedo_db";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        }

    }

    public enum ServerCheckStep
    {
        None,
        MySqlPing,
        MySqlComCd,
        MySqlServiceCheck,
        MySqlPortCheck,
        MySqlFirewallCheck,
        WDServerFirewallCheck,
        WDServerPortCheck,
        WDServerPing
    }
}
