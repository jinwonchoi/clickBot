using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeDoCommon;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace JinnonsCode
{
    /// <summary>
    /// 1. 브라우저 설치여부
    /// 2. jdk설치여부
    /// 3. db접속여부
    /// 4. server id리스트
    /// </summary>
    public partial class FrmStartBiral : Form
    {
        WeDoCommon.MySqlHandler handler;
        public event EventHandler<StringEventArgs> LogWriteHandler;

        public FrmStartBiral(Action<string> method)
        {
            InitializeComponent();
            this.delSetData = method;
        }

        private void FrmStartBiral_Load(object sender, EventArgs e)
        {
            if (Utils.IsBrowserInstalled(ConstDef.CHROME))
            {
                LabelChrome.Text = "크롬 사용가능";
                LinkLabelChrome.Visible = false;
            }
            else
            {
                LabelChrome.Text = "아래 링크를 통해 크롬을 설치하세요.";
                LinkLabelChrome.Visible = true;
                ButtonNext.Enabled = false;
            }
            if (Utils.IsBrowserInstalled(ConstDef.FIREFOX)) 
            {
                LabelFireFox.Text = "파이어폭스 사용가능" ;
                LinkLabelFireFox.Visible = false;
            } 
            else 
            {
                LabelFireFox.Text = "아래 링크를 통해 파이어폭스를 설치하세요.";
                LinkLabelFireFox.Visible = true;
                ButtonNext.Enabled = false;
            }
            if (Utils.IsBrowserInstalled(ConstDef.IEXPLORER))
            {
                LabelIexplore.Text = "인터넷 익스플로어 사용가능";
                LinkLabelIExplorer.Visible = false;
            } else {
                LabelIexplore.Text = "아래 링크를 통해 인터넷 익스플로어를 설치하세요.";
                LinkLabelIExplorer.Visible = true;
                ButtonNext.Enabled = false;
            }

            executeJDK();

            if (Utils.IsJDKInstalled())
            {
                LabelJDK.Text =  "JDK 사용가능";
                LinkLabelJDK.Visible = false;
            } else {
                LabelJDK.Text =  "아래 링크를 통해 JDK를 설치하세요.";
                LinkLabelJDK.Visible = true;
                ButtonNext.Enabled = false;
            }

            if (!IsProxyProgramRunning())
                LBUseProxy.Visible = true;

            this.CenterToScreen();

            SetMySqlPort();
            RefreshData();
            CheckProperties();
        }

        private void executeJDK()
        {
            if (!Utils.IsJDKInstalled())
            {
                if (MessageBox.Show(string.Format("Java 필수프로그램이 설치되지 않았습니다."
                             + "\n설치하시겠습니까?")
                 , "Java프로그램 설치"
                 , MessageBoxButtons.OKCancel) == DialogResult.OK)
                {   
                    Process P = null;
                    try
                    {
                        P = Process.Start(Application.StartupPath + "\\" + ConstDef.JDK_INSTALLER);
                        P.WaitForExit();
                        OnWriteLog(ConstDef.JDK_INSTALLER + " 설치 완료");
                        Logger.info(ConstDef.JDK_INSTALLER + " 설치 완료");
                    }
                    catch (Exception ex)
                    {
                        OnWriteLog(ConstDef.JDK_INSTALLER + " 파일 생성중 에러발생");
                        Logger.error(ConstDef.JDK_INSTALLER + " 파일 생성중 에러발생 : " + ex.ToString());
                    }

                    if (P.ExitCode != 0)
                    {
                        if (MessageBox.Show(string.Format("Java 필수프로그램이 정상 설치되지 않았습니다."
                                             + "\n프로그램을 종료합니다.")
                                 , "Java프로그램 설치오류"
                                 , MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            return;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }
        }

        private bool CheckProperties()
        {
            string propPath = ConstDef.CLICKBOT_CONF_DIR + "\\main.properties";
            PropertyFileHandler prop = new PropertyFileHandler(propPath);
            //get value whith default value
            TextBoxServerIds.Text = prop.get("server_id");
            string useProxyStr = prop.get("use_proxy");
            string forcedRunningStr = prop.get("forced");
            CBUseProxy.Checked = (useProxyStr != null && useProxyStr.Equals("yes"));
            cbIgnoreHistory.Checked = (forcedRunningStr != null && forcedRunningStr.Equals("yes"));
            return true;
        }

        private bool SaveProperties()
        {
            string propPath = ConstDef.CLICKBOT_CONF_DIR + "\\main.properties";
            PropertyFileHandler prop = new PropertyFileHandler(propPath);
            //set value
            prop.set("server_id", TextBoxServerIds.Text);
            prop.set("use_proxy", CBUseProxy.Checked?"yes":"no");
            prop.set("forced", cbIgnoreHistory.Checked?"yes":"no");
            //save
            prop.Save();
            return true;
        }

        private bool IsProxyProgramRunning()
        {
            Process[] pname = Process.GetProcessesByName("YoungipClient");
            return (pname.Length > 0);;
        }

        public bool SetMySqlPort()
        {
            bool result = false;
            try
            {
                handler = new MySqlHandler(ConstDef.DbIpAddress, ConstDef.DbPort, ConstDef.DbName, ConstDef.DbUser, ConstDef.DbPasswd);
                result = true;
            }
            catch (Exception e)
            {
                OnWriteLog("MySql 서버 접속테스트 에러 : " + e.ToString());
                Logger.error("MySql 서버 접속테스트 에러 : " + e.ToString());
            }
            return result;

        }

        private bool RefreshData()
        {
            bool result = false;
            string sql = null;
            DataTable dt = null;
            try
            {
                OnWriteLog("접속 확인.");
                handler.Open();

                //t_company
                sql = "select server_id from server_info";
                handler.SetQuery(sql);
                OnWriteLog("실행쿼리문:" + sql);
                Logger.info("실행쿼리문:" + sql);
                dt = handler.DoQuery();

                LBServerIdList.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    LBServerIdList.Items.Add(dr["server_id"].ToString());
                }

                result = true;
            }
            catch (Exception e)
            {
                OnWriteLog("실행ID 확인 에러 : " + e.ToString());
                Logger.error("실행ID 확인 에러 : " + e.ToString());
            }
            finally
            {
                handler.Close();
            }
            return result;
        }



        public virtual void OnWriteLog(string msg)
        {
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
            }
        }

        Action<string> delSetData = null;

        private void cbIgnoreHistory_CheckedChanged(object sender, EventArgs e)
        {
            delSetData(cbIgnoreHistory.Checked ? "true" : "false");
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (CBUseProxy.Checked && !IsProxyProgramRunning())
            {
                if (MessageBox.Show(string.Format("\"청춘IP - 프록시 서비스\" 프로그램이 미실행 상태입니다."
                                     + "\n실행 및 로그인해야 마케팅용 IP를 사용할 수 있습니다.")
                                     , "프록시사용 오류"
                                     , MessageBoxButtons.OK) == DialogResult.OK)
                                            {
                    return;
                }
            }
            SaveProperties();
        }

        private void LBServerIdList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBoxServerIds.Text += (string.IsNullOrEmpty(TextBoxServerIds.Text)) ? "" : ",";
            TextBoxServerIds.Text += LBServerIdList.SelectedItem.ToString();
        }

        private void FrmStartBiral_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CBUseProxy.Checked && !IsProxyProgramRunning()) e.Cancel = true;
        }

    }
}
