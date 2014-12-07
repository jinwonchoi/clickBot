using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeDoCommon;
using ClickBot.Common;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class MainForm : Form
    {
        public WeDoCommon.MySqlHandler handler = null;

        public MainForm()
        {
            //This call is required by the Windows Form Designer.
            Elegant.Ui.RibbonLicenser.LicenseKey = "E644-DB48-BFFB-CA0C-53D2-4F3F-C938-C3EF";

            SetStyle(
                ControlStyles.UserPaint,
                true);

            InitializeComponent();
            SetMySqlPort();

            //if(SystemFonts.MenuFont.FontFamily.Name == "Segoe UI")
            //    Font = SystemFonts.MenuFont;

            //SkinManager.LoadEmbeddedTheme(EmbeddedTheme.System , Product.Common);
            ProductPageToggleButton.Tag = typeof(ProductPage);
            UserPageToggleButton.Tag = typeof(UserInfoPage);
            PurchasePageToggleButton.Tag = typeof(PurchasePage);
            TaskPageToggleButton.Tag = typeof(TaskPage);
            ServerInfoToggleButton.Tag = typeof(ServerInfoPage);
            SiteLoginInfoToggleButton.Tag = typeof(LoginIdInfoPage);
            IpInfoToggleButton.Tag = typeof(IpInfoPage);
            ControlsNavigationBar.PressedToggleButtonChanged += ControlsNavigationBar_PressedToggleButtonChanged;
            
            ControlsNavigationBar.PerformLayout();

            DisplayCurrentSamplePage();
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
                Logger.error("MySql 서버 접속테스트 에러 : " + e.ToString());
            }
            return result;

        }

        public static void SetMonospaceFont(System.Windows.Forms.Control control)
        {
            const string modernFontName = "Consolas";
            const string classicFontName = "Courier New";

            if (SystemInfo.IsWindowsXPOrHigher && SystemInformation.FontSmoothingType == 2) //AA is on
            {
                Font modernFont = TryToGetFont(modernFontName, control.Font.Size);
                if (modernFont != null)
                {
                    control.Font = modernFont;
                    return;
                }
            }

            Font font = TryToGetFont(classicFontName, control.Font.Size);
            if (font != null)
                control.Font = font;
        }

        private static Font TryToGetFont(string fontName, float size)
        {
            FontFamily[] families = FontFamily.Families;
            Font font = null;

            foreach (FontFamily family in families)
            {
                if (family.Name == fontName)
                {
                    font = new Font(new FontFamily(fontName), size);
                    break;
                }
            }

            return font;
        }


        private readonly Dictionary<Type, SamplePageBase> _controlsSamplePages = new Dictionary<Type, SamplePageBase>();

        private SamplePageBase GetControlsSamplePage(Type type)
        {
            if(type == null)
                throw new ArgumentNullException("type");

            if (!type.IsSubclassOf(typeof(SamplePageBase)))
                return null;

            SamplePageBase samplePage;
            if (_controlsSamplePages.TryGetValue(type, out samplePage))
                return samplePage;

            samplePage = (SamplePageBase)Activator.CreateInstance(type);
            samplePage.SetSqlHandler(handler);
            _controlsSamplePages.Add(type, samplePage);

            return samplePage;
        }

        private void ControlsNavigationBar_PressedToggleButtonChanged(object sender, NavigationBarPressedToggleButtonChangedEventArgs e)
        {
            DisplayCurrentSamplePage();
        }

        private void DisplayCurrentSamplePage()
        {
            SamplePageBase currentSamplePage = null;

            if(ControlsNavigationBar.PressedToggleButton != null)
            {
                Type type = ControlsNavigationBar.PressedToggleButton.Tag as Type;
                if (type != null)
                    currentSamplePage = GetControlsSamplePage(type);
            }
            currentSamplePage.InitData();
            ControlsSamplePageContainer.ControlsSamplePage = currentSamplePage;
        }

     }
}