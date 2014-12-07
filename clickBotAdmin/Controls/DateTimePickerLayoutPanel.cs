using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public class DateTimePickerLayoutPanel : Panel
    {
		public DateTimePickerLayoutPanel()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

        protected override void OnLayout(LayoutEventArgs levent)
        {
            if(Controls.Count < 1)
                return;

            DateTimePicker dateTimePicker = (DateTimePicker)Controls[0];

            Size preferredSize = dateTimePicker.PreferredSize;

			dateTimePicker.Bounds = new Rectangle(
				new Point(0, (Height - preferredSize.Height) / 2),
                preferredSize);
        }
    }
}
