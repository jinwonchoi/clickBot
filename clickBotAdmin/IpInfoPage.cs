using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using WeDoCommon;
using System.Collections.Generic;
using ClickBot.ValueObject;
using ClickBot.Common;
using System.Text;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class IpInfoPage : SamplePageBase
    {
        public event EventHandler<StringEventArgs> LogWriteHandler;
        String strLoginId;

        List<IpInfo> ipInfoList = new List<IpInfo>();
        List<LoginIdInfo> loginIdList = new List<LoginIdInfo>();
        List<LoginIdInfo> loginIdDaumList = new List<LoginIdInfo>();
        List<LoginIdInfo> loginIdNaverList = new List<LoginIdInfo>();
        

        public IpInfoPage()
        {
            InitializeComponent();
        }

        private void initData()
        {
            RBBrowserTypeChrome.Checked = true;
            RBDeviceTypeWeb.Checked = true;
            RBUseTypeLogin.Checked = true;
        }

        private void refreshData()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                handler.Open();

                //t_company
                sql = "select ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum from ipinfo";
                handler.SetQuery(sql);
                Logger.info("실행쿼리문:" + sql);

                dt = handler.DoQuery();
                dgUserInfo.DataSource = dt;
            }
            catch (Exception e)
            {
                Logger.error("사용자 확인 에러 : " + e.ToString());
            }
            finally
            {
                handler.Close();
            }
        }

        private bool deleteAllData()
        {
            bool result = true;
            try
            {
                Logger.debug("IP목록전체삭제 확인.");
                handler.Open();
                String sql = "delete from ipinfo ";
                handler.SetQuery(sql);
                handler.DoExecute();
            }
            catch (Exception e)
            {
                Logger.error("삭제 에러 : " + e.ToString());
                result = false;
            }
            finally
            {
                handler.Close();
            }
            return result;
        }

        private bool deleteData()
        {
            bool result = true;
            try
            {
                Logger.debug("사용자삭제 확인.");
                handler.Open();
                String sql = "delete from ipinfo "
                  + " where ip_address = @ip_address";
                handler.SetQuery(sql);
                handler.Parameters("@ip_address", TBIPAddress.Text.Trim());
                handler.DoExecute();
            }
            catch (Exception e)
            {
                Logger.error("삭제 에러 : " + e.ToString());
                result = false;
            }
            finally
            {
                handler.Close();
            }
            return result;
        }

        private bool updateData()
        {
            bool result = true;
            try
            {
                Logger.debug("사용자수정 확인.");
                handler.Open();
                String sql = "update ipinfo "
                  + " set browser_type = @browser_type "
                  + ",device_type = @device_type"
                  + ",use_type = @use_type"
                  + ",login_id_naver = @login_id_naver"
                  + ",login_pwd_naver = @login_pwd_naver"
                  + ",login_id_daum = @login_id_daum"
                  + ",login_pwd_daum = @login_pwd_daum"
                + " where ip_address = @ip_address";
                handler.SetQuery(sql);
                handler.Parameters("@ip_address", TBIPAddress.Text.Trim());
                if (RBBrowserTypeChrome.Checked) {
                    handler.Parameters("@browser_type", ConstDef.BROWSER_TYPE_CHROME);
                } else if (RBBrowserTypeIE.Checked) {
                    handler.Parameters("@browser_type", ConstDef.BROWSER_TYPE_IE);
                } else if (RBBrowserTypeFireFox.Checked) {
                    handler.Parameters("@browser_type", ConstDef.BROWSER_TYPE_FIREFOX);
                }
                handler.Parameters("@device_type", RBDeviceTypeMobile.Checked ? ConstDef.DEVICE_TYPE_MOBILE : ConstDef.DEVICE_TYPE_WEB);
                handler.Parameters("@use_type", RBUseTypeLogin.Checked ? ConstDef.IPINFO_USE_TYPE_LOGIN : ConstDef.IPINFO_USE_TYPE_NORMAL);
                handler.Parameters("@login_id_naver", TBLoginIdNaver.Text.Trim());
                handler.Parameters("@login_pwd_naver", TBPwdNaver.Text.Trim());
                handler.Parameters("@login_id_daum", TBLoginIdDaum.Text.Trim());
                handler.Parameters("@login_pwd_daum", TBPwdDaum.Text.Trim());
                handler.DoExecute();
            }
            catch (Exception e)
            {
                Logger.error("수정 에러 : " + e.ToString());
                result = false;
            }
            finally
            {
                handler.Close();
            }
            return result;
        }

        private bool InsertData()
        {
            bool result = true;
            try
            {
                Logger.debug("사용자등록 확인.");
                handler.Open();
                String sql = "insert into ipinfo "
                  + " (ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum)"
                  + " values (@ip_address,@browser_type,@device_type,@use_type,@login_id_naver,@login_pwd_naver,@login_id_daum,@login_pwd_daum)";
                handler.SetQuery(sql);
                handler.Parameters("@ip_address", TBIPAddress.Text.Trim());
                if (RBBrowserTypeChrome.Checked)
                {
                    handler.Parameters("@browser_type", ConstDef.BROWSER_TYPE_CHROME);
                }
                else if (RBBrowserTypeIE.Checked)
                {
                    handler.Parameters("@browser_type", ConstDef.BROWSER_TYPE_IE);
                }
                else if (RBBrowserTypeFireFox.Checked)
                {
                    handler.Parameters("@browser_type", ConstDef.BROWSER_TYPE_FIREFOX);
                }
                handler.Parameters("@device_type", RBDeviceTypeMobile.Checked ? ConstDef.DEVICE_TYPE_MOBILE : ConstDef.DEVICE_TYPE_WEB);
                handler.Parameters("@use_type", RBUseTypeLogin.Checked ? ConstDef.IPINFO_USE_TYPE_LOGIN : ConstDef.IPINFO_USE_TYPE_NORMAL);
                handler.Parameters("@login_id_naver", TBLoginIdNaver.Text.Trim());
                handler.Parameters("@login_pwd_naver", TBPwdNaver.Text.Trim());
                handler.Parameters("@login_id_daum", TBLoginIdDaum.Text.Trim());
                handler.Parameters("@login_pwd_daum", TBPwdDaum.Text.Trim());

                handler.DoExecute();
            }
            catch (Exception e)
            {
                Logger.error("입력 에러 : " + e.ToString());
                result = false;
            }
            finally
            {
                handler.Close();
            }
            return result;
        }

        private bool InsertData(List<IpInfo> ipInfoList)
        {
            bool result = true;
            try
            {
                Logger.debug("사용자등록 확인.");
                handler.Open();

                int rowCount = 0;
                StringBuilder builder = new StringBuilder();

                foreach (IpInfo ipInfo in ipInfoList)
                {
                    if (builder == null || builder.Length == 0) {
                        builder.Append("insert into ipinfo ");
                        builder.Append("( ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )");
                        builder.Append(" values ");
                        builder.Append(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                                    , ipInfo.IpAddress, ipInfo.BrowserType, ipInfo.DeviceType, ipInfo.UserType, ipInfo.LoginIdNaver
                                    , ipInfo.LoginPwdNaver, ipInfo.LoginIdDaum, ipInfo.LoginPwdDaum));

                    } else {
                        builder.Append(string.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                                    , ipInfo.IpAddress, ipInfo.BrowserType, ipInfo.DeviceType, ipInfo.UserType, ipInfo.LoginIdNaver
                                    , ipInfo.LoginPwdNaver, ipInfo.LoginIdDaum, ipInfo.LoginPwdDaum));
                    }

                    if ((rowCount % 100 == 0 && rowCount > 0) || rowCount == (ipInfoList.Count - 1))
                    {
                        handler.SetQuery(builder.ToString());
                        handler.DoExecute();
                        builder.Length = 0;
                    }
                    else
                    {
                    }
                    rowCount++;
                }
            }
            catch (Exception e)
            {
                Logger.error("입력 에러 : " + e.ToString());
                result = false;
            }
            finally
            {
                handler.Close();
            }
            return result;
        }


        private void GetLoginIdList()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                handler.Open();

                //t_company
                sql = "select login_id,passwd,id_type,userid,create_date,update_date from loginid";
                handler.SetQuery(sql);
                Logger.debug("실행쿼리문:" + sql);

                dt = handler.DoQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    LoginIdInfo loginId = new LoginIdInfo();
                    loginId.LoginId = dr["login_id"].ToString();
                    loginId.Passwd = dr["passwd"].ToString();
                    loginId.IdType = dr["id_type"].ToString();
                    loginId.UserId = dr["userid"].ToString();
                    if (loginId.IdType.Equals("N"))
                    {
                        loginIdNaverList.Add(loginId);
                    }
                    else
                    {
                        loginIdDaumList.Add(loginId);
                    }

                    Logger.info(loginId.ToString());
                }
            }
            catch (Exception e)
            {
                Logger.error("사용자 확인 에러 : " + e.ToString());
            }
            finally
            {
                handler.Close();
            }
        }

        private void dgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            EmptyForm();
            SetButton(0);
        }


        private void EmptyForm()
        {
            strLoginId = "";
            TBIPAddress.ReadOnly = false;
            TBIPAddress.Text = "";
            RBBrowserTypeChrome.Checked = true;
            RBDeviceTypeWeb.Checked = true;
            RBUseTypeLogin.Checked = true;
            
            TBLoginIdNaver.Text = "";
            TBPwdNaver.Text = "";
            TBLoginIdDaum.Text = "";
            TBPwdDaum.Text = "";
        }

        /// <summary>
        /// 0: insert, 1: edit
        /// </summary>
        /// <param name="mode"></param>
        private void SetButton(int mode)
        {
            if (mode == 0 ) {
                btnInsert.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private bool ValidateData()
        {
            bool result = true;

            if (TBIPAddress.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "IP주소를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check data
            if (ValidateData())
            {
                if (strLoginId == null || strLoginId.Trim().Equals(""))
                {
                    //insert
                    if (InsertData())
                    {
                        SetButton(1);
                        refreshData();
                    }
                }
                else
                {
                    //update
                    if (updateData())
                    {
                        SetButton(1);
                        refreshData();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //check data;
            if (TBIPAddress.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "IP주소를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //delete
            if (deleteData())
            {
                EmptyForm();
                SetButton(0);
                refreshData();
            }
        }

        private void dgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgUserInfo.Rows[e.RowIndex].Cells[0].Value == null) return;
            if (dgUserInfo.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                fillData(e.RowIndex);
            }
            SetButton(1);
        }

        private void dgProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || dgUserInfo.Rows[e.RowIndex].Cells[0].Value == null) return;
            if (dgUserInfo.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                fillData(e.RowIndex);
            }
            SetButton(1);
        }

        private void fillData(int rowIdx)
        {
            strLoginId = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            
            TBIPAddress.ReadOnly = true;
            TBIPAddress.Text = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            String browserType = dgUserInfo.Rows[rowIdx].Cells[1].Value.ToString();
            if (browserType.Equals(ConstDef.BROWSER_TYPE_CHROME))
            {
                RBBrowserTypeChrome.Checked = true;
            } else if (browserType.Equals(ConstDef.BROWSER_TYPE_IE))
            {
                RBBrowserTypeIE.Checked = true;
            } else if (browserType.Equals(ConstDef.BROWSER_TYPE_FIREFOX))
            {
                RBBrowserTypeFireFox.Checked = true;
            }
            String deviceType = dgUserInfo.Rows[rowIdx].Cells[2].Value.ToString();
            if (deviceType.Equals(ConstDef.DEVICE_TYPE_WEB))
            {
                RBDeviceTypeWeb.Checked = true;
            }
            else if (deviceType.Equals(ConstDef.DEVICE_TYPE_MOBILE))
            {
                RBDeviceTypeMobile.Checked = true;
            }
            String useType = dgUserInfo.Rows[rowIdx].Cells[3].Value.ToString();
            if (useType.Equals(ConstDef.IPINFO_USE_TYPE_LOGIN))
            {
                RBUseTypeLogin.Checked = true;
            }
            else if (useType.Equals(ConstDef.IPINFO_USE_TYPE_NORMAL))
            {
                RBUseTypeNormal.Checked = true;
            }

            TBLoginIdNaver.Text = dgUserInfo.Rows[rowIdx].Cells[4].Value.ToString();
            TBPwdNaver.Text = dgUserInfo.Rows[rowIdx].Cells[5].Value.ToString();
            TBLoginIdDaum.Text = dgUserInfo.Rows[rowIdx].Cells[6].Value.ToString();
            TBPwdDaum.Text = dgUserInfo.Rows[rowIdx].Cells[7].Value.ToString();
        }

        private void CalendarPageControls_VisibleChanged(object sender, EventArgs e)
        {
        }

        public override void InitData()
        {
            initData();
            refreshData();
        }

        private void ButtonFileUpload_Click(object sender, EventArgs e)
        {

            List<string> deviceTypeList = new List<string>();
            List<string> browserTypeList = new List<string>();
            if (OpenFileDlgIpList.ShowDialog() == DialogResult.OK)
            {
                string fileName = OpenFileDlgIpList.FileName;
                int counter = 0;
                string line;
                System.IO.StreamReader file = null;
                System.IO.StreamReader cntFile = null;

                GetLoginIdList();
                Utils.Shuffle(loginIdNaverList);
                Utils.Shuffle(loginIdDaumList);

                try
                {
                    int lineCount = 0;

                    int chromeCnt = 0; //40
                    int ieCnt= 0;      //40
                    int fireFoxCnt = 0;//20
                    int mobileCnt = 0;
                    int webCnt = 0;

                    cntFile = new System.IO.StreamReader(fileName);
                    while ((line = cntFile.ReadLine()) != null)
                        lineCount ++;
                    chromeCnt = lineCount*ConstDef.BROWSER_RATIO_CHROME/100;
                    ieCnt = lineCount * ConstDef.BROWSER_RATIO_IE/ 100;
                    fireFoxCnt = lineCount - (chromeCnt + ieCnt);

                    mobileCnt = lineCount * ConstDef.DEVICE_RATIO_MOBILE/ 100;
                    webCnt = lineCount - mobileCnt; //* ConstDef.DEVICE_RATIO_WEB / 100;

                    for (int i = 0; i < webCnt; i++) deviceTypeList.Add(ConstDef.DEVICE_TYPE_WEB);
                    for (int i = 0; i < mobileCnt; i++) deviceTypeList.Add(ConstDef.DEVICE_TYPE_MOBILE);
                    for (int i = 0; i < chromeCnt; i++) browserTypeList.Add(ConstDef.BROWSER_TYPE_CHROME);
                    for (int i = 0; i < ieCnt; i++) browserTypeList.Add(ConstDef.BROWSER_TYPE_IE);
                    for (int i = 0; i < fireFoxCnt; i++) browserTypeList.Add(ConstDef.BROWSER_TYPE_FIREFOX);

                    Utils.Shuffle(deviceTypeList);
                    Utils.Shuffle(browserTypeList);

                    // Read the file and display it line by line.
                    file = new System.IO.StreamReader(fileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] ipArr = line.Split(':');

                        if (ipArr.Length != 2)
                        {
                            MessageBox.Show(this, string.Format("목록 내용에 오류가 있습니다. 확인하세요.(라인:{0})", counter), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        IpInfo ipInfo = new IpInfo();
                        ipInfo.IpAddress = line;
                        ipInfo.BrowserType = browserTypeList[counter];
                        ipInfo.DeviceType = deviceTypeList[counter];

                        LoginIdInfo loginIdNaver = null;
                        LoginIdInfo loginIdDaum = null;

                        if (loginIdNaverList != null && loginIdNaverList.Count > 0 && loginIdNaverList.Count -1 >= counter)
                        {
                            loginIdNaver = loginIdNaverList[counter];
                            ipInfo.LoginIdNaver = loginIdNaver.LoginId;
                            ipInfo.LoginPwdNaver = loginIdNaver.Passwd;
                        }
                        if (loginIdDaumList != null && loginIdDaumList.Count > 0 && loginIdDaumList.Count - 1 >= counter)
                        {
                            loginIdDaum = loginIdDaumList[counter];
                            ipInfo.LoginIdDaum = loginIdDaum.LoginId;
                            ipInfo.LoginPwdDaum = loginIdDaum.Passwd;
                        }
                        if (loginIdDaum != null || loginIdNaver != null)
                            ipInfo.UserType = ConstDef.IPINFO_USE_TYPE_LOGIN;
                        else
                            ipInfo.UserType = ConstDef.IPINFO_USE_TYPE_NORMAL;

                        ipInfoList.Add(ipInfo);
                        Logger.info("ip목록 읽음:" + line);
                        counter++;
                    }

                    InsertData(ipInfoList);
                    InitData();
                }
                finally
                {
                    file.Close();
                    cntFile.Close();
                }
                Logger.info(string.Format("{0} 건 업로드.", counter));

                // Suspend the screen.
                System.Console.ReadLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteAllData();
        }
    }
}
