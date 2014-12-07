using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using WeDoCommon;
using ClickBot.Common;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class ProductPage : SamplePageBase
    {
        String strProductId;

        public ProductPage()
        {
            InitializeComponent();
        }

        private void initData()
        {
            rbDeviceTypeWeb.Checked = true;
            rbSiteTypeNaver.Checked = true;
            CodeUtils.InitCBTaskType(CBTaskType);
        }

        private void refreshData()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                Logger.info("회사코드 확인.");
                handler.Open();

                //t_company
                sql = "select a.product_id, a.product_name,a.price,a.device_type,a.site_type,a.task_type"
                      + " ,a.create_date, a.update_date from product a";
                handler.SetQuery(sql);
                Logger.info("실행쿼리문:" + sql);

                dt = handler.DoQuery();
                dgProduct.DataSource = dt;
            }
            catch (Exception e)
            {
                Logger.error("회사코드 확인 에러 : " + e.ToString());
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
                Logger.debug("상품삭제 확인.");
                handler.Open();
                String sql = "delete from product "
                  + " where product_id = @product_id";
                handler.SetQuery(sql);
                handler.Parameters("@product_id", tbProductId.Text.Trim());
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
                Logger.debug("상품수정 확인.");
                handler.Open();
                String sql = "update product "
                  + " set product_name = @product_name "
                  + ",price = @price"
                  + ",device_type = @device_type"
                  + ",site_type = @site_type"
                  + ",task_type = @task_type"
                  + ",update_date = date_format(sysdate(),'%Y%m%d%H%i%s')"
                +" where product_id = @product_id";
                handler.SetQuery(sql);
                handler.Parameters("@product_id", tbProductId.Text.Trim());
                handler.Parameters("@product_name", tbProductName.Text.Trim());
                handler.Parameters("@price", tbPrice.Text.Trim());
                handler.Parameters("@device_type", rbDeviceTypeWeb.Checked ? "W" : "M");
                handler.Parameters("@site_type", rbSiteTypeNaver.Checked ? "N" : "D");
                handler.Parameters("@task_type", (CBTaskType.SelectedItem as ClickBot.ValueObject.ComboPair).Key);
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
                Logger.debug("상품등록 확인.");
                handler.Open();
                String sql = "insert into product "
                  + " (product_id, product_name,price,device_type,site_type,task_type,create_date, update_date)"
                  + " values (@product_id, @product_name,@price,@device_type,@site_type,@task_type,date_format(sysdate(),'%Y%m%d%H%i%s'), date_format(sysdate(),'%Y%m%d%H%i%s'))";
                handler.SetQuery(sql);
                handler.Parameters("@product_id", tbProductId.Text.Trim());
                handler.Parameters("@product_name", tbProductName.Text.Trim());
                handler.Parameters("@price", tbPrice.Text.Trim());
                handler.Parameters("@device_type", rbDeviceTypeWeb.Checked ? "W" : "M");
                handler.Parameters("@site_type", rbSiteTypeNaver.Checked ? "N" : "D");
                handler.Parameters("@task_type", (CBTaskType.SelectedItem as ClickBot.ValueObject.ComboPair).Key);
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

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            EmptyForm();
            SetButton(0);
        }


        private void EmptyForm()
        {
            strProductId = "";
            tbProductId.ReadOnly = false;
            tbProductId.Text = "";
            tbProductName.Text = "";
            tbPrice.Text = "0";
            rbDeviceTypeWeb.Checked = true;
            rbSiteTypeNaver.Checked = true;
            tbCreateDate.Text = "";
            tbUpdateDate.Text = "";
            CBTaskType.SelectedIndex = -1;
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

            if (tbProductId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "상품코드를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbProductName.Text.Trim().Equals("")) 
            {
                MessageBox.Show(this, "상품이름을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbPrice.Text.Trim().Equals("")) 
            {
                MessageBox.Show(this, "가격을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check data
            if (ValidateData())
            {
                if (strProductId == null || strProductId.Trim().Equals(""))
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
            if (tbProductId.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "상품코드를 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbProductName.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "상품이름을 작성하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.RowIndex < 0 || dgProduct.Rows[e.RowIndex].Cells[0].Value == null) return;

            if (dgProduct.Rows[e.RowIndex].Cells[0].Value.ToString() != ""){
                fillData(e.RowIndex);
            }
            SetButton(1);
        }

        private void dgProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || dgProduct.Rows[e.RowIndex].Cells[0].Value == null) return;

            if (dgProduct.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                fillData(e.RowIndex);
            }
            SetButton(1);
        }

        private void fillData(int rowIdx)
        {
            strProductId = dgProduct.Rows[rowIdx].Cells[0].Value.ToString();
            tbProductId.ReadOnly = true;
            tbProductId.Text = dgProduct.Rows[rowIdx].Cells[0].Value.ToString();
            tbProductName.Text = dgProduct.Rows[rowIdx].Cells[1].Value.ToString();
            tbPrice.Text = dgProduct.Rows[rowIdx].Cells[2].Value.ToString();
            String deviceType = dgProduct.Rows[rowIdx].Cells[3].Value.ToString();
            if (deviceType.Equals("M"))
            {
                rbDeviceTypeMobile.Checked = true;
            }
            String siteType = dgProduct.Rows[rowIdx].Cells[4].Value.ToString();
            if (siteType.Equals("N"))
            {
                rbSiteTypeNaver.Checked = true;
            }
            string taskType = dgProduct.Rows[rowIdx].Cells[5].Value.ToString();
            int selTaskTypeIdx = 0;
            foreach (ClickBot.ValueObject.ComboPair cpTaskType in CBTaskType.Items)
            {
                if (cpTaskType.Key.Equals(taskType))
                {
                    CBTaskType.SelectedIndex = selTaskTypeIdx;
                }
                selTaskTypeIdx++;
            }
            tbCreateDate.Text = dgProduct.Rows[rowIdx].Cells[6].Value.ToString();
            tbUpdateDate.Text = dgProduct.Rows[rowIdx].Cells[7].Value.ToString();

        }

        public override void InitData() 
        {
            initData();
            refreshData();
        }

    }
}
