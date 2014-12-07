using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using WeDoCommon;
using ClickBot.Common;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class PurchasePage : SamplePageBase
    {
        public event EventHandler<StringEventArgs> LogWriteHandler;
        String strPurchaseId;

        public PurchasePage()
        {
            InitializeComponent();
        }

        private void initData()
        {
            rbPurchaseTypeCard.Checked = true;
            rbUseFlagN.Checked = true;
            DTPickerPurchaseDate.CustomFormat = "yyyyMMdd";
        }

        private void refreshData()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                handler.Open();

                sql = "select a.purchase_id "
                    + ",concat(b.company_name, '(',a.user_id,')') user_detail "
                    + ",concat(c.product_name, '(',a.product_id,')') product_detail"
                    + ",a.device_type,a.site_type, a.task_type, purchase_date,purchase_amount"
                    + ",purchase_type,used_flag,a.create_date,a.update_date"
                    + " FROM purchase a left join user_info b on a.user_id = b.user_id  "
                    + "  left join product c  on a.product_id = c.product_id ";
                handler.SetQuery(sql);
                Logger.debug("실행쿼리문:" + sql);

                dt = handler.DoQuery();
                DGPurchase.DataSource = dt;
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
                Logger.debug("구매이력삭제 확인.");
                handler.Open();
                String sql = "delete from purchase "
                  + " where purchase_id = @purchase_id";
                handler.SetQuery(sql);
                handler.Parameters("@purchase_id", tbPurchaseId.Text.Trim());
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
                Logger.debug("구매수정 확인.");
                handler.Open();
                String sql = "update purchase "
                  + " set user_id = @user_id"
                  + ",product_id = @product_id"
                  + ",device_type = @device_type"
                  + ",site_type = @site_type"
                  + ",task_type = @task_type"
                  + ",purchase_date = @purchase_date"
                  + ",purchase_amount = @purchase_amount"
                  + ",purchase_type = @purchase_type"
                  + ",used_flag = @used_flag"
                  + ",update_date = date_format(sysdate(),'%Y%m%d%H%i%s')"
                + " where purchase_id = @purchase_id";
                handler.SetQuery(sql);
                handler.Parameters("@purchase_id", tbPurchaseId.Text.Trim());
                handler.Parameters("@user_id", (CBUserDetail.SelectedItem as ClickBot.ValueObject.UserInfo).UserId);
                handler.Parameters("@product_id", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).ProductId);
                handler.Parameters("@device_type", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).DeviceType);
                handler.Parameters("@site_type", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).SiteType);
                handler.Parameters("@task_type", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).TaskType);
                handler.Parameters("@purchase_date", DTPickerPurchaseDate.Text.Trim());
                handler.Parameters("@purchase_amount", tbPurchaseAmount.Text.Trim());
                handler.Parameters("@purchase_type", rbPurchaseTypeCard.Checked ? "C" : "B");
                handler.Parameters("@used_flag", rbUseFlagN.Checked?"N":"Y");
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
                Logger.info("사용자등록 확인.");
                handler.Open();
                String sql = "insert into purchase "
                  + " ( user_id,product_id,device_type,site_type,task_type,purchase_date,purchase_amount,purchase_type,used_flag,create_date,update_date )"
                  + " values (@user_id,@product_id,@device_type,@site_type,@task_type,@purchase_date,@purchase_amount,@purchase_type,@used_flag,date_format(sysdate(),'%Y%m%d%H%i%s'), date_format(sysdate(),'%Y%m%d%H%i%s'))";
                handler.SetQuery(sql);
                handler.Parameters("@user_id", (CBUserDetail.SelectedItem as ClickBot.ValueObject.UserInfo).UserId);
                handler.Parameters("@product_id", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).ProductId);
                handler.Parameters("@device_type", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).DeviceType);
                handler.Parameters("@site_type", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).SiteType);
                handler.Parameters("@task_type", (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product).TaskType);
                handler.Parameters("@purchase_date", DTPickerPurchaseDate.Text.Trim());
                handler.Parameters("@purchase_amount", tbPurchaseAmount.Text.Trim());
                handler.Parameters("@purchase_type", rbPurchaseTypeCard.Checked ? ConstDef.PURCHASE_TYPE_CARD : ConstDef.PURCHASE_TYPE_BANK);
                handler.Parameters("@used_flag", rbUseFlagY.Checked ? "Y" : "N");

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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            EmptyForm();
            SetButton(0);
        }


        private void EmptyForm()
        {
            strPurchaseId = "";
            tbPurchaseId.ReadOnly = true;
            tbPurchaseId.Text = "";
            CBUserDetail.SelectedIndex = -1;
            CBProductDetail.SelectedIndex = -1;
            TBDeviceType.Text = "";
            TBSiteType.Text = "";
            TBTaskType.Text = "";
            DTPickerPurchaseDate.Text = "";
            tbPurchaseAmount.Text = "";
            rbPurchaseTypeCard.Checked = true;
            rbUseFlagN.Checked = true;
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

            if (CBUserDetail.SelectedIndex == -1)
            {
                MessageBox.Show(this, "고객을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CBProductDetail.SelectedIndex == -1)
            {
                MessageBox.Show(this, "상품을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check data
            if (ValidateData())
            {
                if (strPurchaseId == null || strPurchaseId.Trim().Equals(""))
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
            if (CBUserDetail.SelectedIndex == -1)
            {
                MessageBox.Show(this, "고객을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CBProductDetail.SelectedIndex == -1)
            {
                MessageBox.Show(this, "상품을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.RowIndex < 0 || DGPurchase.Rows[e.RowIndex].Cells[0].Value == null) return;
            if (DGPurchase.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                fillData(e.RowIndex);
            }
            SetButton(1);
        }

        private void dgProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || DGPurchase.Rows[e.RowIndex].Cells[0].Value == null) return;
            if (DGPurchase.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                fillData(e.RowIndex);
            }
            SetButton(1);
        }

        private void fillData(int rowIdx)
        {
            strPurchaseId = DGPurchase.Rows[rowIdx].Cells[0].Value.ToString();
            
            tbPurchaseId.ReadOnly = true;
            tbPurchaseId.Text = DGPurchase.Rows[rowIdx].Cells[0].Value.ToString();
            string userId = DGPurchase.Rows[rowIdx].Cells[1].Value.ToString();
            int selUserIdx = 0;
            foreach (ClickBot.ValueObject.UserInfo userInfo in CBUserDetail.Items)
            {
                if (userInfo.ToString().Equals(userId))
                {
                    CBUserDetail.SelectedIndex = selUserIdx;
                }
                selUserIdx++;
            }

            string productId = DGPurchase.Rows[rowIdx].Cells[2].Value.ToString();
            int selProductIdx = 0;
            foreach (ClickBot.ValueObject.Product product in CBProductDetail.Items)
            {
                if (product.ToString().Equals(productId))
                {
                    CBProductDetail.SelectedIndex = selProductIdx;
                }
                selProductIdx++;
            }

            string deviceType = DGPurchase.Rows[rowIdx].Cells[3].Value.ToString();
            TBDeviceType.Text = (deviceType.Equals(ConstDef.DEVICE_TYPE_WEB))?"웹":"모바일";
            
            String siteType = DGPurchase.Rows[rowIdx].Cells[4].Value.ToString();
            TBSiteType.Text = (siteType.Equals(ConstDef.SITE_TYPE_NAVER))?"네이버":"다음";

            String taskType = DGPurchase.Rows[rowIdx].Cells[5].Value.ToString();
            TBTaskType.Text = CodeUtils.TaskTypeName(taskType);

            string purchaseDate =  DGPurchase.Rows[rowIdx].Cells[6].Value.ToString();

            DateTime dt = new DateTime(Int32.Parse(purchaseDate.Substring(0, 4)), 
                Int32.Parse(purchaseDate.Substring(4, 2)), 
                Int32.Parse(purchaseDate.Substring(6, 2)));
            DTPickerPurchaseDate.Value = dt;
            tbPurchaseAmount.Text = DGPurchase.Rows[rowIdx].Cells[7].Value.ToString();
            String purchaseType = DGPurchase.Rows[rowIdx].Cells[8].Value.ToString();
            if (purchaseType.Equals(ConstDef.PURCHASE_TYPE_CARD))
                rbPurchaseTypeCard.Checked = true;
            else
                rbPurchaseTypeCash.Checked = true;
            
            String useFlag = DGPurchase.Rows[rowIdx].Cells[9].Value.ToString();
            if (useFlag.Equals("N"))
                rbUseFlagN.Checked = true;
            else
                rbUseFlagY.Checked = true;

            tbCreateDate.Text = DGPurchase.Rows[rowIdx].Cells[10].Value.ToString();
            tbUpdateDate.Text = DGPurchase.Rows[rowIdx].Cells[11].Value.ToString();
        }

        private void tbMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void GetProductInfo()
        {
            try
            {
                handler.Open();
                handler.SetQuery("select product_id,product_name,price,device_type "
                    +",site_type,task_type,create_date,update_date from product");
                DataTable dt = null;
                dt = handler.DoQuery();
                CBProductDetail.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ClickBot.ValueObject.Product product = new ClickBot.ValueObject.Product();
                    product.ProductId = dr["product_id"].ToString();
                    product.ProductName = dr["product_name"].ToString();
                    product.Price = Int32.Parse(dr["price"].ToString());
                    product.DeviceType = dr["device_type"].ToString();
                    product.SiteType = dr["site_type"].ToString();
                    product.TaskType = dr["task_type"].ToString();
                    product.CreateDate = dr["create_date"].ToString();
                    product.UpdateDate = dr["update_date"].ToString();

                    CBProductDetail.Items.Add(product);
                    Logger.info("CBProductDetail 추가" + product.ToString());
                }
            }
            catch (Exception e)
            {
                Logger.error("CBProductDetail 확인 에러 : " + e.ToString());
            }
            finally
            {
                handler.Close();
            }
        }

        public void GetUserInfo()
        {
            try
            {
                handler.Open();
                handler.SetQuery("select user_id,passwd,user_type,email,mobile,phone,company_name "
                    + ",etc,create_date,update_date from user_info");
                DataTable dt = null;
                dt = handler.DoQuery();

                CBUserDetail.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ClickBot.ValueObject.UserInfo userInfo = new ClickBot.ValueObject.UserInfo();
                    userInfo.UserId = dr["user_id"].ToString();
                    userInfo.Passwd= dr["passwd"].ToString();
                    userInfo.UserType = dr["user_type"].ToString();
                    userInfo.Email = dr["email"].ToString();
                    userInfo.Mobile= dr["mobile"].ToString();
                    userInfo.Phone= dr["phone"].ToString();
                    userInfo.CompanyName= dr["company_name"].ToString();
                    userInfo.Etc = dr["etc"].ToString();
                    userInfo.CreateDate = dr["create_date"].ToString();
                    userInfo.UpdateDate = dr["update_date"].ToString();

                    CBUserDetail.Items.Add(userInfo);
                    Logger.info("CBUserDetail 추가" + userInfo.ToString());
                }
            }
            catch (Exception e)
            {
                Logger.error("CBUserDetail 에러 : " + e.ToString());
            }
            finally
            {
                handler.Close();
            }
        }

        private void CBProductDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClickBot.ValueObject.Product product = (CBProductDetail.SelectedItem as ClickBot.ValueObject.Product);
            if (product == null) return;
            TBDeviceType.Text = (product.DeviceType.Equals(ConstDef.DEVICE_TYPE_WEB)) ? "웹" : "모바일";
            TBSiteType.Text = (product.SiteType.Equals(ConstDef.SITE_TYPE_NAVER)) ? "네이버" : "다음";
            TBTaskType.Text = CodeUtils.TaskTypeName(product.TaskType);
            tbPurchaseAmount.Text = product.Price.ToString();
        }

        public override void InitData()
        {
            initData();
            refreshData();
            GetProductInfo();
            GetUserInfo();
        }

    }
}
