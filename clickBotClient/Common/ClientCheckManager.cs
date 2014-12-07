using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

namespace WeDoCommon
{
    class ClientCheckManager
    {

        public event EventHandler<StringEventArgs> LogWriteHandler;

        private ClientCheckStep _checkStep = ClientCheckStep.None;
        private FirewallHandler _fwManager = new FirewallHandler();
        private SocketHandler _socHandler;

        //방화벽목록
        //*프로그램
        //1. 클라이언트
        //2. 서버프로그램
        //
        //2.포트
        public const string WEDO_SERVER_NAME = "WeDo Server";
        public const string WEDO_CLIENT_NAME = "WeDo Messenger";
        public const string WEDO_MYQL_NAME = "WeDo MySql Client";

        public const string WEDO_SERVER = "C:\\eclues\\WeDo Server\\WD_Server.exe";         //WDMsgServer
        public const string WEDO_CLIENT = "C:\\eclues\\WeDo\\WDMsg_Client.exe";             //WDMsgClient
        public const string WEDO_MYSQL = "C:\\MiniCTI\\mysql-5.5.19-win32\\bin\\mysqld.exe";//WeDoMySQL
        public const int MYSQL_PORT = 3306;

        private int curMySqlPort = 3306;
        private string serverIp = "127.0.0.1";

        MySqlHandler handler;

        public ClientCheckManager()
        {
            serverIp = GetServerIp();
            _socHandler = new SocketHandler();
            _socHandler.LogWriteHandler += this.OnLogWrite;
            handler = new MySqlHandler(serverIp, curMySqlPort, "wedo_db", "root", "Genesys!@#");
        }

        public ClientCheckStep GetCheckStep()
        {
            return _checkStep;
        }

        private void OnLogWrite(object sender, StringEventArgs e)
        {
            OnWriteLog(e.EventString);
        }

        //클라이언트 방화벽 확인
        //1. WDMsg_Client.exe 
        //2. 각종유틸
        // ==> 상태확인
        public string CheckMsgrFirewallStatus()
        {
            Logger.info("메신저방화벽 체크중...");
            _checkStep = ClientCheckStep.MsgrFirewallCheck;

            return _fwManager.GetByProgramPath(WEDO_CLIENT);
        }

        public string CheckMySqlFirewallStatus()
        {
            Logger.info("MySql 방화벽 체크중...");
            _checkStep = ClientCheckStep.MySqlBasicTest;

            return _fwManager.GetByPort(MYSQL_PORT);
        }

        public bool SetMsgrFirewall()
        {
            Logger.info("메신저방화벽 등록...");
            _checkStep = ClientCheckStep.MsgrFirewallCheck;

            return _fwManager.AddProgram(WEDO_CLIENT_NAME, WEDO_CLIENT);
        }

        public bool ReleaseMsgrFirewall()
        {
            Logger.info("메신저방화벽 등록해제...");
            _checkStep = ClientCheckStep.MsgrFirewallCheck;

            return _fwManager.RemoveProgram(WEDO_CLIENT);
        }

        public bool SetMySqlFirewall()
        {
            Logger.info("MySql port 방화벽 등록...");
            _checkStep = ClientCheckStep.MySqlBasicTest;

            return _fwManager.AddPort(WEDO_MYQL_NAME, MYSQL_PORT, false);
        }

        public bool ReleaseMySqlFirewall()
        {
            Logger.info("MySql port 방화벽 등록해제...");
            _checkStep = ClientCheckStep.MySqlBasicTest;

            return _fwManager.RemovePort(MYSQL_PORT, false);
        }


        /// <summary>
        ///기본통신(UDP)
        ///  1. 클라이언트8884에서 최초 서버 8881로 보냄
        ///  2. 서버 8882에서 클라이언트 8883으로 받음
        ///  
        ///1. 8881로 데이터 보냄
        ///2. 8884가 응답받음
        ///3. 8883이 대기
        ///4. 8882로부터 수신
        ///5. 8882로 응답
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckBasicConnection()
        {
            _checkStep = ClientCheckStep.MsgrBasicTest;

            ///1. 8881로 데이터 보냄
            ///2. 8884가 응답받음
            _socHandler.SendUDP(8884, serverIp, 8881, "8881전송테스트");


            ///3. 8883이 대기
            ///4. 8882로부터 수신
            ///5. 8882로 응답
            //ReceiveUDP(8883);

            //_checkStep = CheckStep.None;
            return true;
        }


        //public bool CheckConnectionToClient()
        //{
        //    _checkStep = ClientCheckStep.MsgrBasicTest;

        //    //tcp소켓생성
        //    //8886으로 전송
        //    //결과확인
        //    _checkStep = ClientCheckStep.MsgrCRMTest;
        //    _socHandler.SendTCP(serverIp, 8888, "24|a", false);//22&ani&senderID&receiverID&일자&시간&CustomerName
        //    string result = "";
        //    //_checkStep = CheckStep.None;
        //    return result;
        //}

        //CRM관련통신(TCP)
        //  CRM->서버 8886  
        public string CheckCRMConnection()
        {
            //tcp소켓생성
            //8886으로 전송
            //결과확인
            _checkStep = ClientCheckStep.MsgrCRMTest;
            _socHandler.SendTCP(serverIp, 8886, "22&01055554444&0001&0001&20130901&010101&CRM테스트", false);//22&ani&senderID&receiverID&일자&시간&CustomerName
            string result = "";
            //_checkStep = CheckStep.None;
            return result;
        }

        //파일전송(TCP)
        //  클라이언  -> 서버 9001
        //  클라이언트 -> 클라이언트 9002, 9004
        public string CheckFTPConnection()
        {
            //1. 9001서버로 전송
            //2. 결과받음
            //3. 9004 다른 클라이언트로 전송
            //4. 결과받음
            //5. 9002로 대기
            //6. 결과받음
            //7. 
            _checkStep = ClientCheckStep.MsgrFTPTest;

            _socHandler.SendTCP(serverIp, 9001, "9001전송테스트", true);
            string result = "";
            //_checkStep = CheckStep.None;
            return result;
        }

        public bool CheckMySqlConnection()
        {
            bool result = false;
            _checkStep = ClientCheckStep.MySqlBasicTest;
            try
            {
                OnWriteLog("MySql 서버 접속테스트...");
                _checkStep = ClientCheckStep.MySqlBasicTest;
                
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

        public string GetCompanyCd()
        {
            string result = null;
            _checkStep = ClientCheckStep.MySqlCompanyCdTest;
            try
            {
                OnWriteLog("회사코드 확인.");
                handler.Open();
                handler.SetQuery("select com_cd, com_nm from t_company");
                DataTable dt = null;
                dt = handler.DoQuery();


                foreach (DataRow dr in dt.Rows)
                {
                    result += dr["com_cd"].ToString() + ":" + dr["com_nm"].ToString();
                    OnWriteLog(string.Format("회사코드[{0}]회사명[{1}]", dr["com_cd"].ToString(), dr["com_nm"].ToString()));
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

        public string GetServerIp()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\MiniCTI\config\MiniCTI_config.xml");
            XmlNode node = doc.SelectSingleNode("//db/dbserverip/text()");
            return node.Value;
            // node.Value contains "test@ABC.com"
        }

        /// <summary>
        /// 방화벽 활성화/비활성화 확인
        /// </summary>
        /// <returns></returns>
        public bool IsFirewallEnabled()
        {
            Logger.info("방화벽 활성화 체크...");
            _checkStep = ClientCheckStep.MsgrFirewallCheck;

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


        public string DoSelectTest()
        {
            string result = null;
            _checkStep = ClientCheckStep.MySqlCompanyCdTest;
            try
            {
                OnWriteLog("회사코드 확인.");
                handler.Open();
                handler.SetQuery("select com_cd, user_id, user_nm from t_user where user_id like @user_id");
                DataTable dt = null;
                handler.Parameters("@user_id", "001%");
                dt = handler.DoQuery();


                foreach (DataRow dr in dt.Rows)
                {
                    result += dr["com_cd"].ToString() + ":" + dr["user_id"].ToString() + ":" + dr["user_nm"].ToString();
                    OnWriteLog(string.Format("회사코드[{0}]사용자[{1}:{2}]", dr["com_cd"].ToString(), dr["user_id"].ToString(), dr["user_nm"].ToString()));
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

    }

    public enum ClientCheckStep
    {
        None,
        MsgrFirewallCheck,
        MsgrBasicTest,
        MsgrCRMTest,
        MsgrFTPTest,
        MySqlBasicTest,
        MySqlCompanyCdTest
    }

}
