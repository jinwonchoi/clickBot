using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public class SamplePageBase : UserControl
    {
        public WeDoCommon.MySqlHandler handler = null;

        public SamplePageBase() 
        {
            SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);
        }

        public void SetSqlHandler(WeDoCommon.MySqlHandler handler)
        {
            this.handler = handler;
        }
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style |= WinApi.WS_CLIPSIBLINGS | WinApi.WS_CLIPSIBLINGS;
                return createParams;
            }
        }
    
        virtual public void InitData() {}
    }
}