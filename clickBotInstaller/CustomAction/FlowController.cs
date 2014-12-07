using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;
using System.Configuration.Install;
using System.Windows.Forms;

namespace CustomAction
{
    public class FlowController
    {
        InstallController ctr = new InstallController();
        WindowWrapper wrapper;
        InstallContext context;

        public FlowController(WindowWrapper wrapper, InstallContext context)
        {
            this.wrapper = wrapper;
            this.context = context;
        }

        #region 메인 함수
        /// <summary>
        /// installer1에서 호출하여 
        /// </summary>
        public void DoMain()
        {
            FlowInfo flowInfo = new FlowInfo();
            while (true) {
                switch (flowInfo.NextStep)
                {
                    case Step.CHECK_CHROME_INSTALLED:
                        Logger.info("Step.CHECK_CHROME_INSTALLED");
                        flowInfo = doCheckChromeInstalled(flowInfo);
                        break;
                    case Step.INSTALL_CHROME:
                        Logger.info("Step.INSTALL_CHROME");
                        flowInfo = doInstallChrome(flowInfo);
                        break;

                    case Step.CHECK_FIREFOX_INSTALLED:
                        Logger.info("Step.CHECK_FIREFOX_INSTALLED");
                        flowInfo = doCheckFireFoxInstalled(flowInfo);
                        break;
                    case Step.INSTALL_FIREFOX:
                        Logger.info("Step.INSTALL_FIREFOX");
                        flowInfo = doInstallFireFox(flowInfo);
                        break;

                    case Step.CHECK_JDK_INSTALLED:
                        Logger.info("Step.CHECK_JDK_INSTALLED");
                        flowInfo = doCheckJDKInstalled(flowInfo);
                        break;
                    case Step.INSTALL_JDK:
                        Logger.info("Step.INSTALL_JDK");
                        flowInfo = doInstallJDK(flowInfo);
                        break;

                    case Step.EXTRACT_JAR:
                        Logger.info("Step.EXTRACT_JAR");
                        flowInfo = doExtractJarFile(flowInfo);
                        break;

                    case Step.REGISTER_FIREWALL:
                        Logger.info("Step.REGISTER_FIREWALL");
                        flowInfo = doRegisterFirewall(flowInfo);
                        break;
                    case Step.NO_MORE_STEP:
                        Logger.info("Step.NO_MORE_STEP");
                        break;
                    case Step.NONE:
                        Logger.info("Step.NONE");
                        break;
                }
                if (flowInfo != null && flowInfo.NextStep == Step.NO_MORE_STEP)
                {
                    Logger.info("DoMain Exit.");
                    break;
                }
            }
        }
        #endregion 
           
        #region /* Chrome설치 확인 */
        /// <summary>
        /// WinpCap을 설치했는지 확인하고 
        /// 설치되었으면 디비설치, 안되었으면 WinpCap설치를 한다.
        /// </summary>
        /// <param name="flowInfo"></param>
        /// <returns></returns>
        private FlowInfo doCheckChromeInstalled(FlowInfo flowInfo)
        {

            if (!ctr.CheckChromeInstalled())
            {
                Logger.error("Chrome 미설치 상태");
                flowInfo.PrevStep = Step.CHECK_CHROME_INSTALLED;
                flowInfo.NextStep = Step.INSTALL_CHROME;
            }
            else
            {
                Logger.info("Chrome 이미 설치 상태");
                flowInfo.PrevStep = Step.CHECK_CHROME_INSTALLED;
                flowInfo.NextStep = Step.CHECK_FIREFOX_INSTALLED;
            }

            return flowInfo;
        }
        #endregion

        #region/* Chrome설치 */
        private FlowInfo doInstallChrome(FlowInfo flowInfo)
        {

            FrmWinpcapInstall frmChromeInstall = new FrmWinpcapInstall(this.context, "크롬 브라우저");

            if (frmChromeInstall.ShowDialog(wrapper) == DialogResult.OK)
            {
                if (frmChromeInstall.NeedInstall())
                {
                    ctr.InstallChrome();
                }
            }
            else
            {
                Logger.error("Chrome설치중 설치취소");
                throw new Exception("Chrome설치중 설치취소");
            }
            frmChromeInstall.Dispose();

            flowInfo.PrevStep = Step.INSTALL_CHROME;
            flowInfo.NextStep = Step.CHECK_FIREFOX_INSTALLED;

            return flowInfo;
        }
        #endregion


        #region /* FireFox설치 확인 */
        /// <summary>
        /// WinpCap을 설치했는지 확인하고 
        /// 설치되었으면 디비설치, 안되었으면 WinpCap설치를 한다.
        /// </summary>
        /// <param name="flowInfo"></param>
        /// <returns></returns>
        private FlowInfo doCheckFireFoxInstalled(FlowInfo flowInfo)
        {

            if (!ctr.CheckFireFoxInstalled())
            {
                Logger.error("FireFox 미설치 상태");
                flowInfo.PrevStep = Step.CHECK_FIREFOX_INSTALLED;
                flowInfo.NextStep = Step.INSTALL_FIREFOX;
            }
            else
            {
                Logger.info("FireFox 이미 설치 상태");
                flowInfo.PrevStep = Step.CHECK_FIREFOX_INSTALLED;
                flowInfo.NextStep = Step.CHECK_JDK_INSTALLED;
            }
            return flowInfo;
        }
        #endregion

        #region/* FireFox설치 */
        private FlowInfo doInstallFireFox(FlowInfo flowInfo)
        {

            FrmWinpcapInstall frmFireFoxInstall = new FrmWinpcapInstall(this.context, "파이어폭스 브라우저");

            if (frmFireFoxInstall.ShowDialog(wrapper) == DialogResult.OK)
            {
                if (frmFireFoxInstall.NeedInstall())
                {
                    ctr.InstallFireFox();
                }
            }
            else
            {
                Logger.error("FireFox설치중 설치취소");
                throw new Exception("FireFox설치중 설치취소");
            }
            frmFireFoxInstall.Dispose();

            flowInfo.PrevStep = Step.INSTALL_FIREFOX;
            flowInfo.NextStep = Step.CHECK_JDK_INSTALLED;

            return flowInfo;
        }
        #endregion

        #region /* JDK설치 확인 */
        /// <summary>
        /// WinpCap을 설치했는지 확인하고 
        /// 설치되었으면 디비설치, 안되었으면 WinpCap설치를 한다.
        /// </summary>
        /// <param name="flowInfo"></param>
        /// <returns></returns>
        private FlowInfo doCheckJDKInstalled(FlowInfo flowInfo)
        {

            if (!ctr.CheckJDKInstalled())
            {
                Logger.error("JDK 미설치 상태");
                flowInfo.PrevStep = Step.CHECK_JDK_INSTALLED;
                flowInfo.NextStep = Step.INSTALL_JDK;
            }
            else
            {
                Logger.info("JDK 이미 설치 상태");
                flowInfo.PrevStep = Step.CHECK_JDK_INSTALLED;
                flowInfo.NextStep = Step.EXTRACT_JAR;
            }
            return flowInfo;
        }
        #endregion

        #region/* JDK설치 */
        private FlowInfo doInstallJDK(FlowInfo flowInfo)
        {

            FrmWinpcapInstall frmJDKInstall = new FrmWinpcapInstall(this.context, "자바(JDK)");

            if (frmJDKInstall.ShowDialog(wrapper) == DialogResult.OK)
            {
                if (frmJDKInstall.NeedInstall())
                {
                    ctr.InstallJDK();
                }
            }
            else
            {
                Logger.error("JDK설치중 설치취소");
                throw new Exception("JDK설치중 설치취소");
            }
            frmJDKInstall.Dispose();

            flowInfo.PrevStep = Step.INSTALL_JDK;
            flowInfo.NextStep = Step.EXTRACT_JAR;

            return flowInfo;
        }
        #endregion

        #region /* jar파일 */
        private FlowInfo doExtractJarFile(FlowInfo flowInfo)
        {
            FrmStatus frmStatusFirewall = new FrmStatus(this.context, ConstDef.mainTitle
                                                       , "java 필수파일을 설치합니다.", ctr.InstallJarFile);

            if (frmStatusFirewall != null)
            {
                ctr.LogWriteHandler += frmStatusFirewall.OnStatusWrite;
                if (frmStatusFirewall.ShowDialog(wrapper) == DialogResult.OK)
                {
                    Logger.info("java 필수파일 설치완료");
                }
                else
                {
                    Logger.error("java 필수파일 설치취소");
                    throw new Exception("java 필수파일 설치취소");
                }
                ctr.LogWriteHandler -= frmStatusFirewall.OnStatusWrite;
                frmStatusFirewall.Dispose();
            }
            flowInfo.PrevStep = Step.EXTRACT_JAR;
            flowInfo.NextStep = Step.REGISTER_FIREWALL;

            return flowInfo;
        }
        #endregion
        
        #region /* 방화벽 등록 */
        private FlowInfo doRegisterFirewall(FlowInfo flowInfo) {
            FrmStatus frmStatusFirewall = new FrmStatus(this.context, ConstDef.mainTitle
                                                       , "방화벽설정을 등록합니다.", ctr.RegisterFirewall);

            if (frmStatusFirewall != null)
            {
                ctr.LogWriteHandler += frmStatusFirewall.OnStatusWrite;
                if (frmStatusFirewall.ShowDialog(wrapper) == DialogResult.OK)
                {
                    Logger.info("방화벽등록 완료");
                }
                else
                {
                    Logger.error("방화벽등록중 설치취소");
                    throw new Exception("방화벽등록중 설치취소");
                }
                ctr.LogWriteHandler -= frmStatusFirewall.OnStatusWrite;
                frmStatusFirewall.Dispose();
            }
            flowInfo.PrevStep = Step.REGISTER_FIREWALL;
            flowInfo.NextStep = Step.NO_MORE_STEP;

            return flowInfo;
        }
        #endregion
    }

    public class FlowInfo
    {
        Step prevStep = Step.NONE;
        public Step PrevStep
        {
            get { return prevStep; }
            set { prevStep = value; }
        }
        Step nextStep = Step.CHECK_CHROME_INSTALLED;
        public Step NextStep
        {
            get { return nextStep; }
            set { nextStep = value; }
        }
    }

    public enum Step
    {
        CHECK_CHROME_INSTALLED, /* Chrome설치 확인 */
        INSTALL_CHROME,         /* Chrome설치 */
        CHECK_FIREFOX_INSTALLED, /* FireFox설치 확인 */
        INSTALL_FIREFOX,         /* FireFox설치 */
        CHECK_JDK_INSTALLED, /* Jdk설치 확인 */
        INSTALL_JDK,         /* Jdk설치 */
        EXTRACT_JAR,             /* jar 파일 설치 */
        REGISTER_FIREWALL,       /* 방화벽 등록 */
        NO_MORE_STEP,            /* 추가 진행없음 */
        NONE                     /* 미설정 */
    }

    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }

        private IntPtr _hwnd;
    }

}
