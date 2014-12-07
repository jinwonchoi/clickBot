using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public class ControlsSampleGroupBox : GroupBox
    {
        public ControlsSampleGroupBox()
        {
            SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);
            
            UpdateTextColor();

            SkinManager.ThemeChanged += SkinManager_ThemeChanged;
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

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                SkinManager.ThemeChanged -= SkinManager_ThemeChanged;
            }

            base.Dispose(disposing);
        }

        private void UpdateTextColor()
        {
            ForeColor = SkinManager.GetSkin("Label", typeof(LabelSkin)).ForegroundColor;
        }

        public bool ShouldSerializeForeColor()
        {
            return false;
        }

        private void SkinManager_ThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            if (e.Product == Product.Common)
                UpdateTextColor();
        }

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				UpdateTextColor();
			}
		}
    }
}
