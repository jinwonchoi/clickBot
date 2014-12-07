using System.Drawing;

namespace Elegant.Ui.Samples.ControlsSample
{
    public class GalleryContainerPanel : Panel
    {
        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs levent)
        {
            if(Controls.Count != 1)
                return;

            Gallery gallery = Controls[0] as Gallery;
            if(gallery == null)
                return;

            GalleryInformativeness informativeness = gallery.Informativeness as GalleryInformativeness;
            if(informativeness == null)
                return;

            Rectangle displayRectangle = DisplayRectangle;

            GalleryInformativenessLevel level = (GalleryInformativenessLevel) informativeness.Level;
            if(level == GalleryInformativenessLevel.Expanded)
            {
                gallery.Bounds = displayRectangle;
                return;
            }

            Size size = gallery.PreferredSize;

            gallery.Bounds = new Rectangle(
                new Point(displayRectangle.Left + (displayRectangle.Width - size.Width)/2,
                          displayRectangle.Top + (displayRectangle.Height - size.Height)/2),
                size);
        }
    }
}
