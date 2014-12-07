using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using WeDoCommon;
using ClickBot.Common;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class UserInfoPage : SamplePageBase
    {
        public event EventHandler<StringEventArgs> LogWriteHandler;
        String strUserId;

        public UserInfoPage()
        {
            InitializeComponent();
        }

        private void initData()
        {
            rbUserTypeAdmin.Checked = true;
        }

        private void refreshData()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                handler.Open();

                //t_company
                sql = "select user_id, passwd,user_type,email,mobile,phone,company_name,etc,create_date,update_date  from user_info";
                handler.SetQuery(sql);
                Logger.debug("실행쿼리문:" + sql);

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

        private bool deleteData()
        {
            bool result = true;
            try
            {
                Logger.debug("사용자삭제 확인.");
                handler.Open();
                String sql = "delete from user_info "
                  + " where user_id = @user_id";
                handler.SetQuery(sql);
                handler.Parameters("@user_id", tbUserId.Text.Trim());
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
                String sql = "update user_info "
                  + " set passwd = @passwd "
                  + ",user_type = @user_type"
                  + ",email = @email"
                  + ",mobile = @mobile"
                  + ",phone = @phone"
                  + ",company_name = @company_name"
                  + ",etc = @etc"
                  + ",update_date = date_format(sysdate(),'%Y%m%d%H%i%s')"
                + " where user_id = @user_id";
                handler.SetQuery(sql);
                handler.Parameters("@user_id", tbUserId.Text.Trim());
                handler.Parameters("@passwd", tbPasswd.Text.Trim());
                handler.Parameters("@user_type", rbUserTypeAdmin.Checked ? "W" : "M");
                handler.Parameters("@email", tbEmail.Text.Trim());
                handler.Parameters("@mobile", tbMobile.Text.Trim());
                handler.Parameters("@phone", tbPhone.Text.Trim());
                handler.Parameters("@company_name", tbCompanyName.Text.Trim());
                handler.Parameters("@etc", tbEtc.Text.Trim());
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
                String sql = "insert into user_info "
                  + " (user_id, passwd,user_type,email,mobile,phone,company_name,etc,create_date,update_date)"
                  + " values (@user_id, @passwd,@user_type,@email,@mobile,@phone,@company_name,@etc,date_format(sysdate(),'%Y%m%d%H%i%s'), date_format(sysdate(),'%Y%m%d%H%i%s'))";
                handler.SetQuery(sql);
                handler.Parameters("@user_id", tbUserId.Text.Trim());
                handler.Parameters("@passwd", tbPasswd.Text.Trim());
                handler.Parameters("@user_type", rbUserTypeAdmin.Checked ? "A" : "C");
                handler.Parameters("@email", tbEmail.Text.Trim());
                handler.Parameters("@mobile", tbMobile.Text.Trim());
                handler.Parameters("@phone", tbPhone.Text.Trim());
                handler.Parameters("@company_name", tbCompanyName.Text.Trim());
                handler.Parameters("@etc", tbEtc.Text.Trim()); 
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
            strUserId = "";
            tbUserId.ReadOnly = false;
            tbUserId.Text = "";
            tbPasswd.Text = "";
            rbUserTypeAdmin.Checked = true;
            
            tbEmail.Text = "";
            tbMobile.Text = "";
            tbPhone.Text = "";
            tbCompanyName.Text = "";
            tbEtc.Text = "0";
            tbCreateDate.Text = "";
            tbUpdateDate.Text = "";
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

            if (tbUserId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "사용자ID를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbPasswd.Text.Trim().Equals("")) 
            {
                MessageBox.Show(this, "비번을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbEmail.Text.Trim().Equals("")) 
            {
                MessageBox.Show(this, "이메일을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check data
            if (ValidateData())
            {
                if (strUserId == null || strUserId.Trim().Equals(""))
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
            if (tbUserId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "사용자ID를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbPasswd.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "비번을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            strUserId = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            
            tbUserId.ReadOnly = true;
            tbUserId.Text = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            tbPasswd.Text = dgUserInfo.Rows[rowIdx].Cells[1].Value.ToString();
            String userType = dgUserInfo.Rows[rowIdx].Cells[2].Value.ToString();
            if (userType.Equals("C"))
            {
                rbUserTypeCust.Checked = true;
            }
            else
            {
                rbUserTypeAdmin.Checked = true;
            }
            tbEmail.Text = dgUserInfo.Rows[rowIdx].Cells[3].Value.ToString();
            tbMobile.Text = dgUserInfo.Rows[rowIdx].Cells[4].Value.ToString();
            tbPhone.Text = dgUserInfo.Rows[rowIdx].Cells[5].Value.ToString();
            tbCompanyName.Text = dgUserInfo.Rows[rowIdx].Cells[6].Value.ToString();
            tbEtc.Text = dgUserInfo.Rows[rowIdx].Cells[7].Value.ToString();

            tbCreateDate.Text = dgUserInfo.Rows[rowIdx].Cells[8].Value.ToString();
            tbUpdateDate.Text = dgUserInfo.Rows[rowIdx].Cells[9].Value.ToString();

        }

        private void tbMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CalendarPageControls_VisibleChanged(object sender, EventArgs e)
        {
        }

        public override void InitData()
        {
            initData();
            refreshData();
        }
    }
}
