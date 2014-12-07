using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using WeDoCommon;
using ClickBot.Common;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class ServerInfoPage : SamplePageBase
    {
        public event EventHandler<StringEventArgs> LogWriteHandler;
        String strServerId;

        public ServerInfoPage()
        {
            InitializeComponent();
        }

        private void initData()
        {
            RBRunStatusRun.Checked = true;
        }

        private void refreshData()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                handler.Open();

                //t_company
                sql = "select server_id, server_name, real_ip_address, run_status from server_info";
                handler.SetQuery(sql);
                Logger.debug("실행쿼리문:" + sql);

                dt = handler.DoQuery();
                dgUserInfo.DataSource = dt;
            }
            catch (Exception e)
            {
                Logger.error("서버 확인 에러 : " + e.ToString());
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
                Logger.info("서버 삭제 확인.");
                handler.Open();
                String sql = "delete from server_info "
                  + " where server_id = @server_id";
                handler.SetQuery(sql);
                handler.Parameters("@server_id", TBServerId.Text.Trim());
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
                Logger.debug("서버 수정 확인.");
                handler.Open();
                String sql = "update server_info "
                  + " set server_name = @server_name "
                  + ",real_ip_address = @real_ip_address"
                  + ",run_status = @run_status"
                + " where server_id = @server_id";
                handler.SetQuery(sql);
                handler.Parameters("@server_id", TBServerId.Text.Trim());
                handler.Parameters("@server_name", TBServerName.Text.Trim());
                handler.Parameters("@run_status", RBRunStatusRun.Checked ? "R" : "S");
                handler.Parameters("@real_ip_address", TBRealIpAddress.Text.Trim());
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
                Logger.debug("서버 등록 확인.");
                handler.Open();
                String sql = "insert into server_info "
                  + " (server_id, server_name, real_ip_address, run_status)"
                  + " values (@server_id, @server_name,@real_ip_address,@run_status)";
                handler.SetQuery(sql);
                handler.Parameters("@server_id", TBServerId.Text.Trim());
                handler.Parameters("@server_name", TBServerName.Text.Trim());
                handler.Parameters("@run_status", RBRunStatusRun.Checked ? "A" : "C");
                handler.Parameters("@real_ip_address", TBRealIpAddress.Text.Trim());
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
            strServerId = "";
            TBServerId.ReadOnly = false;
            TBServerId.Text = "";
            TBServerName.Text = "";
            RBRunStatusRun.Checked = true;
            
            TBRealIpAddress.Text = "";
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

            if (TBServerId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "장비ID를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (TBServerName.Text.Trim().Equals("")) 
            {
                MessageBox.Show(this, "장비명을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check data
            if (ValidateData())
            {
                if (strServerId == null || strServerId.Trim().Equals(""))
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
            if (TBServerId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "장비ID를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBServerName.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "장비명을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            strServerId = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            
            TBServerId.ReadOnly = true;
            TBServerId.Text = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            TBServerName.Text = dgUserInfo.Rows[rowIdx].Cells[1].Value.ToString();
            TBRealIpAddress.Text = dgUserInfo.Rows[rowIdx].Cells[2].Value.ToString();
            String runStatus = dgUserInfo.Rows[rowIdx].Cells[3].Value.ToString();
            if (runStatus.Equals("S"))
            {
                RBRunStatusStop.Checked = true;
            }
            else
            {
                RBRunStatusRun.Checked = true;
            }
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
