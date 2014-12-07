using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using WeDoCommon;
using ClickBot.Common;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class LoginIdInfoPage : SamplePageBase
    {
        public event EventHandler<StringEventArgs> LogWriteHandler;
        String strLoginId;

        public LoginIdInfoPage()
        {
            InitializeComponent();
        }

        private void initData()
        {
            RBIdTypeNaver.Checked = true;
        }

        private void refreshData()
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
                String sql = "delete from loginid "
                  + " where login_id = @login_id";
                handler.SetQuery(sql);
                handler.Parameters("@login_id", TBLoginId.Text.Trim());
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
                String sql = "update loginid "
                  + " set passwd = @passwd "
                  + ",id_type = @id_type"
                  + ",userid = @userid"
                  + ",update_date = date_format(sysdate(),'%Y%m%d%H%i%s')"
                + " where login_id = @login_id";
                handler.SetQuery(sql);
                handler.Parameters("@login_id", TBLoginId.Text.Trim());
                handler.Parameters("@passwd", TBPasswd.Text.Trim());
                handler.Parameters("@id_type", RBIdTypeNaver.Checked ? "N" : "D");
                handler.Parameters("@userid", TBUserID.Text.Trim());
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
                String sql = "insert into loginid "
                  + " (login_id,passwd,id_type,userid,create_date,update_date)"
                  + " values (@login_id, @passwd,@id_type,@userid,date_format(sysdate(),'%Y%m%d%H%i%s'), date_format(sysdate(),'%Y%m%d%H%i%s'))";
                handler.SetQuery(sql);
                handler.Parameters("@login_id", TBLoginId.Text.Trim());
                handler.Parameters("@passwd", TBPasswd.Text.Trim());
                handler.Parameters("@id_type", RBIdTypeNaver.Checked ? "N" : "D");
                handler.Parameters("@userid", TBUserID.Text.Trim());
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
            strLoginId = "";
            TBLoginId.ReadOnly = false;
            TBLoginId.Text = "";
            TBPasswd.Text = "";
            RBIdTypeNaver.Checked = true;
            
            TBUserID.Text = "";
            TBCreateDate.Text = "";
            TBUpdateDate.Text = "";
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

            if (TBLoginId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "사이트사용자ID를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (TBPasswd.Text.Trim().Equals("")) 
            {
                MessageBox.Show(this, "비번을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (TBLoginId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "사이트사용자ID를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBPasswd.Text.Trim().Equals(""))
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
            strLoginId = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            
            TBLoginId.ReadOnly = true;
            TBLoginId.Text = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            TBPasswd.Text = dgUserInfo.Rows[rowIdx].Cells[1].Value.ToString();
            String userType = dgUserInfo.Rows[rowIdx].Cells[2].Value.ToString();
            if (userType.Equals("D"))
            {
                RBIdTypeDaum.Checked = true;
            }
            else
            {
                RBIdTypeNaver.Checked = true;
            }
            TBUserID.Text = dgUserInfo.Rows[rowIdx].Cells[3].Value.ToString();
            TBCreateDate.Text = dgUserInfo.Rows[rowIdx].Cells[4].Value.ToString();
            TBUpdateDate.Text = dgUserInfo.Rows[rowIdx].Cells[5].Value.ToString();

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
