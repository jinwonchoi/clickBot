using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class CustomPopupChildControl : UserControl
    {
        public CustomPopupChildControl()
        {
            InitializeComponent();
            ControlsPanel.Paint += ControlsPanel_Paint;
        }

        private void ControlsPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.DarkGray))
            {
                Rectangle rect = ControlsPanel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                e.Graphics.DrawRectangle(p, rect);
            }
        }
    }
}
