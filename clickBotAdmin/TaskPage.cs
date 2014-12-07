using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using WeDoCommon;
using System.Collections.Generic;
using ClickBot.ValueObject;
using ClickBot.Common;
using System.Text;
using System.Reflection;
using ClickBot.Controls;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class TaskPage : SamplePageBase
    {
        String strTaskId;

        List<IpInfo> ipInfoList = new List<IpInfo>();
        List<LoginIdInfo> loginIdList = new List<LoginIdInfo>();
        List<LoginIdInfo> loginIdDaumList = new List<LoginIdInfo>();
        List<LoginIdInfo> loginIdNaverList = new List<LoginIdInfo>();


        public TaskPage()
        {
            InitializeComponent();
        }

        private void initData()
        {
            DTPickerStartDate.CustomFormat = "yyyyMMdd";
            DTPickerEndDate.CustomFormat = "yyyyMMdd";

            NumUDHour00.Value = 0; NumUDHour00.Tag = NumUDHour00.Value;
            NumUDHour01.Value = 0; NumUDHour01.Tag = NumUDHour01.Value;
            NumUDHour02.Value = 0; NumUDHour02.Tag = NumUDHour02.Value;
            NumUDHour03.Value = 0; NumUDHour03.Tag = NumUDHour03.Value;
            NumUDHour04.Value = 0; NumUDHour04.Tag = NumUDHour04.Value;
            NumUDHour05.Value = 0; NumUDHour05.Tag = NumUDHour05.Value;
            NumUDHour06.Value = 0; NumUDHour06.Tag = NumUDHour06.Value;
            NumUDHour07.Value = 0; NumUDHour07.Tag = NumUDHour07.Value;
            NumUDHour08.Value = 0; NumUDHour08.Tag = NumUDHour08.Value;
            NumUDHour09.Value = 0; NumUDHour09.Tag = NumUDHour09.Value;
            NumUDHour10.Value = 0; NumUDHour10.Tag = NumUDHour10.Value;
            NumUDHour11.Value = 0; NumUDHour11.Tag = NumUDHour11.Value;
            NumUDHour12.Value = 0; NumUDHour12.Tag = NumUDHour12.Value;
            NumUDHour13.Value = 0; NumUDHour13.Tag = NumUDHour13.Value;
            NumUDHour14.Value = 0; NumUDHour14.Tag = NumUDHour14.Value;
            NumUDHour15.Value = 0; NumUDHour15.Tag = NumUDHour15.Value;
            NumUDHour16.Value = 0; NumUDHour16.Tag = NumUDHour16.Value;
            NumUDHour17.Value = 0; NumUDHour17.Tag = NumUDHour17.Value;
            NumUDHour18.Value = 0; NumUDHour18.Tag = NumUDHour18.Value;
            NumUDHour19.Value = 0; NumUDHour19.Tag = NumUDHour19.Value;
            NumUDHour20.Value = 0; NumUDHour20.Tag = NumUDHour20.Value;
            NumUDHour21.Value = 0; NumUDHour21.Tag = NumUDHour21.Value;
            NumUDHour22.Value = 0; NumUDHour22.Tag = NumUDHour22.Value;
            NumUDHour23.Value = 0; NumUDHour23.Tag = NumUDHour23.Value;

            PanelHour00.Width = 0;
            PanelHour01.Width = 0;
            PanelHour02.Width = 0;
            PanelHour03.Width = 0;
            PanelHour04.Width = 0;
            PanelHour05.Width = 0;
            PanelHour06.Width = 0;
            PanelHour07.Width = 0;
            PanelHour08.Width = 0;
            PanelHour09.Width = 0;
            PanelHour10.Width = 0;
            PanelHour11.Width = 0;
            PanelHour12.Width = 0;
            PanelHour13.Width = 0;
            PanelHour14.Width = 0;
            PanelHour15.Width = 0;
            PanelHour16.Width = 0;
            PanelHour17.Width = 0;
            PanelHour18.Width = 0;
            PanelHour19.Width = 0;
            PanelHour20.Width = 0;
            PanelHour21.Width = 0;
            PanelHour22.Width = 0;
            PanelHour23.Width = 0;
        }

        private void refreshData()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                handler.Open();

                //t_company
                sql = "select task_id,purchase_id,device_type,site_type,task_type,start_date,end_date"
                    + ",target_url,target_name,page_id,keyword1,keyword2,keyword3,keyword4"
                    + ",blog_like_count,daily_hit_count"
                    + ",hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count"
                    + ",hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count"
                    + ",hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count"
                    + ",hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count"
                    + ",create_date,update_date"
                + " from task";
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
                String sql = "delete from task "
                  + " where task_id = @task_id";
                handler.SetQuery(sql);
                handler.Parameters("@task_id", TBTaskId.Text.Trim());
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
                String sql = "update task "
                            + "set purchase_id     =@purchase_id      "
                            + ",device_type     =@device_type      "
                            + ",site_type       =@site_type        "
                            + ",start_date      =@start_date       "
                            + ",end_date        =@end_date         "
                            + ",task_type       =@task_type        "
                            + ",target_url      =@target_url       "
                            + ",target_name     =@target_name      "
                            + ",page_id         =@page_id          "
                            + ",keyword1        =@keyword1         "
                            + ",keyword2        =@keyword2         "
                            + ",keyword3        =@keyword3         "
                            + ",keyword4        =@keyword4         "
                            + ",blog_like_count =@blog_like_count  "
                            + ",daily_hit_count =@daily_hit_count  "
                            + ",hour00_hit_count=@hour00_hit_count "
                            + ",hour01_hit_count=@hour01_hit_count "
                            + ",hour02_hit_count=@hour02_hit_count "
                            + ",hour03_hit_count=@hour03_hit_count "
                            + ",hour04_hit_count=@hour04_hit_count "
                            + ",hour05_hit_count=@hour05_hit_count "
                            + ",hour06_hit_count=@hour06_hit_count "
                            + ",hour07_hit_count=@hour07_hit_count "
                            + ",hour08_hit_count=@hour08_hit_count "
                            + ",hour09_hit_count=@hour09_hit_count "
                            + ",hour10_hit_count=@hour10_hit_count "
                            + ",hour11_hit_count=@hour11_hit_count "
                            + ",hour12_hit_count=@hour12_hit_count "
                            + ",hour13_hit_count=@hour13_hit_count "
                            + ",hour14_hit_count=@hour14_hit_count "
                            + ",hour15_hit_count=@hour15_hit_count "
                            + ",hour16_hit_count=@hour16_hit_count "
                            + ",hour17_hit_count=@hour17_hit_count "
                            + ",hour18_hit_count=@hour18_hit_count "
                            + ",hour19_hit_count=@hour19_hit_count "
                            + ",hour20_hit_count=@hour20_hit_count "
                            + ",hour21_hit_count=@hour21_hit_count "
                            + ",hour22_hit_count=@hour22_hit_count "
                            + ",hour23_hit_count=@hour23_hit_count "
                            + ",update_date = date_format(sysdate(),'%Y%m%d%H%i%s') "
                + " where task_id = @task_id";
                handler.SetQuery(sql);
                handler.Parameters("@task_id", strTaskId);
                handler.Parameters("@purchase_id", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).PurchaseId.ToString());
                handler.Parameters("@device_type", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).DeviceType);
                handler.Parameters("@site_type", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).SiteType);
                handler.Parameters("@start_date", DTPickerStartDate.Text.Trim());
                handler.Parameters("@end_date", DTPickerEndDate.Text.Trim());
                handler.Parameters("@task_type", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).TaskType);
                handler.Parameters("@target_url", TBTargetUrl.Text.Trim());
                handler.Parameters("@target_name", TBTargetName.Text.Trim());
                handler.Parameters("@page_id", TBPageId.Text.Trim());
                handler.Parameters("@keyword1", TBKeyword1.Text.Trim());
                handler.Parameters("@keyword2", TBKeyword2.Text.Trim());
                handler.Parameters("@keyword3", TBKeyword3.Text.Trim());
                handler.Parameters("@keyword4", TBKeyword4.Text.Trim());
                handler.Parameters("@blog_like_count", NumericUDBlogLikeCnt.Value.ToString());
                handler.Parameters("@daily_hit_count", NumericUDDailyHitCnt.Value.ToString());
                handler.Parameters("@hour00_hit_count", NumUDHour00.Value.ToString());
                handler.Parameters("@hour01_hit_count", NumUDHour01.Value.ToString());
                handler.Parameters("@hour02_hit_count", NumUDHour02.Value.ToString());
                handler.Parameters("@hour03_hit_count", NumUDHour03.Value.ToString());
                handler.Parameters("@hour04_hit_count", NumUDHour04.Value.ToString());
                handler.Parameters("@hour05_hit_count", NumUDHour05.Value.ToString());
                handler.Parameters("@hour06_hit_count", NumUDHour06.Value.ToString());
                handler.Parameters("@hour07_hit_count", NumUDHour07.Value.ToString());
                handler.Parameters("@hour08_hit_count", NumUDHour08.Value.ToString());
                handler.Parameters("@hour09_hit_count", NumUDHour09.Value.ToString());
                handler.Parameters("@hour10_hit_count", NumUDHour10.Value.ToString());
                handler.Parameters("@hour11_hit_count", NumUDHour11.Value.ToString());
                handler.Parameters("@hour12_hit_count", NumUDHour12.Value.ToString());
                handler.Parameters("@hour13_hit_count", NumUDHour13.Value.ToString());
                handler.Parameters("@hour14_hit_count", NumUDHour14.Value.ToString());
                handler.Parameters("@hour15_hit_count", NumUDHour15.Value.ToString());
                handler.Parameters("@hour16_hit_count", NumUDHour16.Value.ToString());
                handler.Parameters("@hour17_hit_count", NumUDHour17.Value.ToString());
                handler.Parameters("@hour18_hit_count", NumUDHour18.Value.ToString());
                handler.Parameters("@hour19_hit_count", NumUDHour19.Value.ToString());
                handler.Parameters("@hour20_hit_count", NumUDHour20.Value.ToString());
                handler.Parameters("@hour21_hit_count", NumUDHour21.Value.ToString());
                handler.Parameters("@hour22_hit_count", NumUDHour22.Value.ToString());
                handler.Parameters("@hour23_hit_count", NumUDHour23.Value.ToString());
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
                String sql = "insert into task "
                    + "(purchase_id,device_type,site_type,start_date,end_date"
                    + ",task_type,target_url,target_name,page_id,keyword1,keyword2,keyword3,keyword4"
                    + ",blog_like_count,daily_hit_count"
                    + ",hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count"
                    + ",hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count"
                    + ",hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count"
                    + ",hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count"
                    + ",create_date,update_date)"
                    + " values (@purchase_id,@device_type,@site_type,@start_date,@end_date"
                    + ",@task_type,@target_url,@target_name,@page_id,@keyword1,@keyword2,@keyword3,@keyword4"
                    + ",@blog_like_count,@daily_hit_count"
                    + ",@hour00_hit_count,@hour01_hit_count,@hour02_hit_count,@hour03_hit_count,@hour04_hit_count,@hour05_hit_count"
                    + ",@hour06_hit_count,@hour07_hit_count,@hour08_hit_count,@hour09_hit_count,@hour10_hit_count,@hour11_hit_count"
                    + ",@hour12_hit_count,@hour13_hit_count,@hour14_hit_count,@hour15_hit_count,@hour16_hit_count,@hour17_hit_count"
                    + ",@hour18_hit_count,@hour19_hit_count,@hour20_hit_count,@hour21_hit_count,@hour22_hit_count,@hour23_hit_count"
                    + ",date_format(sysdate(),'%Y%m%d%H%i%s'), date_format(sysdate(),'%Y%m%d%H%i%s'))";
                handler.SetQuery(sql);
                handler.Parameters("@purchase_id", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).PurchaseId.ToString());
                handler.Parameters("@device_type", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).DeviceType);
                handler.Parameters("@site_type", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).SiteType);
                handler.Parameters("@start_date", DTPickerStartDate.Text.Trim());
                handler.Parameters("@end_date", DTPickerEndDate.Text.Trim());
                handler.Parameters("@task_type", (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase).TaskType);
                handler.Parameters("@target_url", TBTargetUrl.Text.Trim());
                handler.Parameters("@target_name", TBTargetName.Text.Trim());
                handler.Parameters("@page_id", TBPageId.Text.Trim());
                handler.Parameters("@keyword1", TBKeyword1.Text.Trim());
                handler.Parameters("@keyword2", TBKeyword2.Text.Trim());
                handler.Parameters("@keyword3", TBKeyword3.Text.Trim());
                handler.Parameters("@keyword4", TBKeyword4.Text.Trim());
                handler.Parameters("@blog_like_count", NumericUDBlogLikeCnt.Value.ToString());
                handler.Parameters("@daily_hit_count", NumericUDDailyHitCnt.Value.ToString());
                handler.Parameters("@hour00_hit_count", NumUDHour00.Value.ToString());
                handler.Parameters("@hour01_hit_count", NumUDHour01.Value.ToString());
                handler.Parameters("@hour02_hit_count", NumUDHour02.Value.ToString());
                handler.Parameters("@hour03_hit_count", NumUDHour03.Value.ToString());
                handler.Parameters("@hour04_hit_count", NumUDHour04.Value.ToString());
                handler.Parameters("@hour05_hit_count", NumUDHour05.Value.ToString());
                handler.Parameters("@hour06_hit_count", NumUDHour06.Value.ToString());
                handler.Parameters("@hour07_hit_count", NumUDHour07.Value.ToString());
                handler.Parameters("@hour08_hit_count", NumUDHour08.Value.ToString());
                handler.Parameters("@hour09_hit_count", NumUDHour09.Value.ToString());
                handler.Parameters("@hour10_hit_count", NumUDHour10.Value.ToString());
                handler.Parameters("@hour11_hit_count", NumUDHour11.Value.ToString());
                handler.Parameters("@hour12_hit_count", NumUDHour12.Value.ToString());
                handler.Parameters("@hour13_hit_count", NumUDHour13.Value.ToString());
                handler.Parameters("@hour14_hit_count", NumUDHour14.Value.ToString());
                handler.Parameters("@hour15_hit_count", NumUDHour15.Value.ToString());
                handler.Parameters("@hour16_hit_count", NumUDHour16.Value.ToString());
                handler.Parameters("@hour17_hit_count", NumUDHour17.Value.ToString());
                handler.Parameters("@hour18_hit_count", NumUDHour18.Value.ToString());
                handler.Parameters("@hour19_hit_count", NumUDHour19.Value.ToString());
                handler.Parameters("@hour20_hit_count", NumUDHour20.Value.ToString());
                handler.Parameters("@hour21_hit_count", NumUDHour21.Value.ToString());
                handler.Parameters("@hour22_hit_count", NumUDHour22.Value.ToString());
                handler.Parameters("@hour23_hit_count", NumUDHour23.Value.ToString());

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

        private void GetPurchaseDetailList()
        {
            string sql = null;
            DataTable dt = null;
            try
            {
                handler.Open();

                //t_company
                sql = "select a.purchase_id "
                    + ",b.company_name, a.user_id"
                    + ",c.product_name, a.product_id"
                    + ",a.device_type,a.site_type, a.task_type, purchase_date,purchase_amount"
                    + ",purchase_type,used_flag,a.create_date,a.update_date"
                    + " FROM purchase a left join user_info b on a.user_id = b.user_id  "
                    + "  left join product c  on a.product_id = c.product_id "; 
                handler.SetQuery(sql);
                Logger.debug("실행쿼리문:" + sql);

                dt = handler.DoQuery();
                CBPurchaseDetail.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ClickBot.ValueObject.Purchase purchase = new ClickBot.ValueObject.Purchase();
                    purchase.PurchaseId = Int32.Parse(dr["purchase_id"].ToString());
                    purchase.CompanyName = dr["company_name"].ToString();
                    purchase.UserId = dr["user_id"].ToString();
                    purchase.ProductName = dr["product_name"].ToString();
                    purchase.ProductId = dr["product_id"].ToString();
                    purchase.DeviceType = dr["device_type"].ToString();
                    purchase.SiteType = dr["site_type"].ToString();
                    purchase.TaskType = dr["task_type"].ToString();
                    purchase.PurchaseDate = dr["purchase_date"].ToString();
                    purchase.PurchaseAmount = Int32.Parse(dr["purchase_amount"].ToString());
                    purchase.PurchaseType = dr["purchase_type"].ToString();
                    purchase.UsedFlag = dr["used_flag"].ToString();
                    purchase.CreateDate = dr["create_date"].ToString();
                    purchase.UpdateDate = dr["update_date"].ToString();

                    CBPurchaseDetail.Items.Add(purchase);
                    Logger.info("CBPurchaseDetail 추가" + purchase.ToString());
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            EmptyForm();
            SetButton(0);
        }


        private void EmptyForm()
        {
            strTaskId = "";
            TBTaskId.ReadOnly = true;
            TBTaskId.Text = "";

            TBTaskType.Text = "";
            CBPurchaseDetail.SelectedIndex = -1;
            TBSiteType.Text = "";
            TBDeviceType.Text = "";

            for (int i = 0; i < 24; i++)
            {
                string panelName = "PanelHour" + i.ToString("D2");
                System.Windows.Forms.Panel panel = (this.Controls.Find(panelName, true)[0] as System.Windows.Forms.Panel);
                panel.Width = 0;
            }

            DTPickerStartDate.Text = "";
            DTPickerEndDate.Text = "";

            TBTargetUrl.Text = "";
            TBTargetName.Text = "";
            TBPageId.Text = "";
            TBKeyword1.Text = "";
            TBKeyword2.Text = "";
            TBKeyword3.Text = "";
            TBKeyword4.Text = "";

            NumericUDBlogLikeCnt.Value = 0;
            NumericUDDailyHitCnt.Value = 0;
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

            if (CBPurchaseDetail.SelectedIndex == -1)
            {
                MessageBox.Show(this, "구매번호를 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check data
            if (ValidateData())
            {
                if (strTaskId == null || strTaskId.Trim().Equals(""))
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
            if (CBPurchaseDetail.SelectedIndex == -1)
            {
                MessageBox.Show(this, "구매번호를 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            strTaskId = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();
            
            TBTaskId.ReadOnly = true;
            TBTaskId.Text = dgUserInfo.Rows[rowIdx].Cells[0].Value.ToString();

            string purchaseId = dgUserInfo.Rows[rowIdx].Cells[1].Value.ToString();
            int selPurchaseIdx = 0;
            foreach (ClickBot.ValueObject.Purchase purchase in CBPurchaseDetail.Items)
            {
                if (purchase.PurchaseId.Equals(purchaseId))
                {
                    CBPurchaseDetail.SelectedIndex = selPurchaseIdx;
                    break;
                }
                selPurchaseIdx++;
            }


            String deviceType = dgUserInfo.Rows[rowIdx].Cells[2].Value.ToString();
            TBDeviceType.Text = (deviceType.Equals(ConstDef.DEVICE_TYPE_WEB))?"웹":"모바일";

            String siteType = dgUserInfo.Rows[rowIdx].Cells[3].Value.ToString();
            TBSiteType.Text = (siteType.Equals(ConstDef.SITE_TYPE_NAVER))?"네이버":"다음";

            string taskType = dgUserInfo.Rows[rowIdx].Cells[4].Value.ToString();
            TBTaskType.Text = CodeUtils.TaskTypeName(taskType);

            string startDate = dgUserInfo.Rows[rowIdx].Cells[5].Value.ToString();
            DTPickerStartDate.Value = Utils.GetDateTimeByYYYYMMDD(startDate);

            string endDate = dgUserInfo.Rows[rowIdx].Cells[6].Value.ToString();
            DTPickerEndDate.Value = Utils.GetDateTimeByYYYYMMDD(endDate);

            TBTargetUrl.Text = dgUserInfo.Rows[rowIdx].Cells[7].Value.ToString();
            TBTargetName.Text = dgUserInfo.Rows[rowIdx].Cells[8].Value.ToString();
            TBPageId.Text = dgUserInfo.Rows[rowIdx].Cells[9].Value.ToString();
            TBKeyword1.Text = dgUserInfo.Rows[rowIdx].Cells[10].Value.ToString();
            TBKeyword2.Text = dgUserInfo.Rows[rowIdx].Cells[11].Value.ToString();
            TBKeyword3.Text = dgUserInfo.Rows[rowIdx].Cells[12].Value.ToString();
            TBKeyword4.Text = dgUserInfo.Rows[rowIdx].Cells[13].Value.ToString();

            if (NumericUDBlogLikeCnt.Maximum < Int32.Parse(dgUserInfo.Rows[rowIdx].Cells[14].Value.ToString()))
            {
                MessageBox.Show(this, "like목표건이 너무 많습니다..", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumericUDBlogLikeCnt.Value = NumericUDBlogLikeCnt.Maximum;
            }
            else
            {
                NumericUDBlogLikeCnt.Value = Int32.Parse(dgUserInfo.Rows[rowIdx].Cells[14].Value.ToString());
            }
            if (NumericUDDailyHitCnt.Maximum < Int32.Parse(dgUserInfo.Rows[rowIdx].Cells[15].Value.ToString()))
            {
                MessageBox.Show(this, "작업목표건이 너무 많습니다..", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumericUDDailyHitCnt.Value = NumericUDDailyHitCnt.Maximum;
            }
            else
            {
                NumericUDDailyHitCnt.Value = Int32.Parse(dgUserInfo.Rows[rowIdx].Cells[15].Value.ToString());
            }

            for (int i = 0; i < 24; i++)
            {
                string idx = i.ToString("D2");
                string numericUDName = "NumUDHour" + idx;

                System.Windows.Forms.NumericUpDown numeric = ((this as TaskPage).Controls.Find(numericUDName, true)[0] as System.Windows.Forms.NumericUpDown);
                numeric.Value = Int32.Parse(dgUserInfo.Rows[rowIdx].Cells[16+i].Value.ToString());
                numeric.Tag = numeric.Value;
                string panelName = "PanelHour" + idx;
                System.Windows.Forms.Panel panel = ((this as TaskPage).Controls.Find(panelName, true)[0] as System.Windows.Forms.Panel);
                panel.Width = 120 * (int)numeric.Value / 15;
            }

            TBCreateDate.Text = dgUserInfo.Rows[rowIdx].Cells[40].Value.ToString();
            TBUpdateDate.Text = dgUserInfo.Rows[rowIdx].Cells[41].Value.ToString();
        }

        public override void InitData()
        {
            initData();
            refreshData();
            GetPurchaseDetailList();
        }

        private void NumericUDHour_ValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.NumericUpDown numeric = (sender as System.Windows.Forms.NumericUpDown);
            string numericUDName = numeric.Name;
            string idx = numericUDName.Substring(numericUDName.Length - 2);
            string panelName = "PanelHour"+idx;
            System.Windows.Forms.Panel panel = ((this as TaskPage).Controls.Find(panelName, true)[0] as System.Windows.Forms.Panel);
            panel.Width = 120 * (int)numeric.Value / 15;
        }

        private void CBPurchaseDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClickBot.ValueObject.Purchase purchase = (CBPurchaseDetail.SelectedItem as ClickBot.ValueObject.Purchase);

            if (purchase == null) return;
            TBDeviceType.Text = (purchase.DeviceType.Equals(ConstDef.DEVICE_TYPE_WEB)) ? "웹" : "모바일";
            TBSiteType.Text = (purchase.SiteType.Equals(ConstDef.SITE_TYPE_NAVER)) ? "네이버" : "다음";
            TBTaskType.Text = CodeUtils.TaskTypeName(purchase.TaskType);
        }

        private void ButtonPeriodShuffle_Click(object sender, EventArgs e)
        {
            Period targetPeriod = Period.Second;
            if (RBPeriod01.Checked) targetPeriod = Period.First;
            if (RBPeriod02.Checked) targetPeriod = Period.Second;
            if (RBPeriod03.Checked) targetPeriod = Period.Third;
            if (RBPeriod04.Checked) targetPeriod = Period.Fourth;

            ScheduleMaker maker = new ScheduleMaker();
            Dictionary<string, int> hourList = maker.GenerateSchedule((int)NumericUDDailyHitCnt.Value, targetPeriod);

            foreach (KeyValuePair<string, int> pair in hourList)
            {
                string idx = pair.Key;
                string numericUDName = "NumUDHour" + idx;

                System.Windows.Forms.NumericUpDown numeric = ((this as TaskPage).Controls.Find(numericUDName, true)[0] as System.Windows.Forms.NumericUpDown);
                numeric.Value = pair.Value;
                string panelName = "PanelHour" + idx;
                System.Windows.Forms.Panel panel = ((this as TaskPage).Controls.Find(panelName, true)[0] as System.Windows.Forms.Panel);
                panel.Width = 120 * (int)numeric.Value / 15;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control ctrl in (this as TaskPage).Controls.Find("NumUDHour00", true))
            {
                Console.WriteLine(ctrl.Name + "=================");
            }

        }

        private void NumUDHour00_KeyUp(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.NumericUpDown numeric = (sender as System.Windows.Forms.NumericUpDown);
            object tag = numeric.Tag;

            if (NumericUDDailyHitCnt.Value + ((int)numeric.Value - Int32.Parse(tag.ToString())) <= NumericUDDailyHitCnt.Maximum
             && NumericUDDailyHitCnt.Value + ((int)numeric.Value - Int32.Parse(tag.ToString())) >= NumericUDDailyHitCnt.Minimum)
            {
                NumericUDDailyHitCnt.Value += ((int)numeric.Value - Int32.Parse(tag.ToString()));
                numeric.Tag = numeric.Value;
            }
        }

        private void NumUDHour00_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.NumericUpDown numeric = (sender as System.Windows.Forms.NumericUpDown);
            object tag = numeric.Tag;

            if (NumericUDDailyHitCnt.Value + ((int)numeric.Value - Int32.Parse(tag.ToString())) <= NumericUDDailyHitCnt.Maximum
             && NumericUDDailyHitCnt.Value + ((int)numeric.Value - Int32.Parse(tag.ToString())) >= NumericUDDailyHitCnt.Minimum)
            {
                NumericUDDailyHitCnt.Value += ((int)numeric.Value - Int32.Parse(tag.ToString()));
                numeric.Tag = numeric.Value;
            }
        }

    }
}
