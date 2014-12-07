using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui
{
    public class FontComboBox : ComboBox
    {
        public FontComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
			ItemHeight = ContentScale.ScaleHeight(30);
            DisplayMember = "Name";
            DropDownHeight = 400;
            DropDownWidth = 200;
            InitializeItems();
        }

        private void CacheVisibleFonts()
        {
            int visibleItemCount = DropDownHeight / ItemHeight;
            using (Bitmap bmp = new Bitmap(100, 100))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    for (int i = 0; i < visibleItemCount; i++)
                    {
                        using (Font font = CreateSampleFont((FontFamily)Items[i], 12))
                            g.DrawString(font.FontFamily.Name, font, SystemBrushes.Control, 0, 0);
                    }
                }
            }
        }

        protected override void OnDropDown()
        {
            CacheVisibleFonts();
            base.OnDropDown();
        }

        private void InitializeItems()
        {
            DataSource = FontFamily.Families;
        }

        protected override void OnDrawItem(DrawComboBoxItemEventArgs e)
        {
            if (e.IsSelected)
                e.PaintSelectedBackground();
            else
                e.PaintNormalBackground();

            FontFamily fontFamily = (FontFamily)Items[e.ItemIndex];
            using (Font font = CreateSampleFont(fontFamily, 12))
            {
                using (Brush b = new SolidBrush(e.TextColor))
                {
                    using (StringFormat sf = new StringFormat(StringFormat.GenericDefault))
                    {
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Center;
                        sf.FormatFlags = StringFormatFlags.NoWrap;

                        e.Graphics.DrawString(
                            fontFamily.Name,
                            font,
                            b,
                            e.Bounds,
                            sf);
                    }
                }
            }
        }

        private Font CreateSampleFont(FontFamily fontFamily, float size)
        {
            FontStyle[] availableStyles = (FontStyle[])Enum.GetValues(typeof(FontStyle));

            FontStyle? supportedStyle = null;
            foreach (FontStyle fontStyle in availableStyles)
            {
                if (fontFamily.IsStyleAvailable(fontStyle))
                {
                    supportedStyle = fontStyle;
                    break;
                }
            }

            if (supportedStyle == null)
                return new Font(Font.FontFamily, size);

            return new Font(fontFamily, size, supportedStyle.Value);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ComboBoxItemCollection Items
        {
            get { return base.Items; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return base.AutoCompleteCustomSource; }
            set { base.AutoCompleteCustomSource = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int ItemHeight
        {
            get
            {
                return base.ItemHeight;
            }
            set { base.ItemHeight = value; }
        }
    }
}
