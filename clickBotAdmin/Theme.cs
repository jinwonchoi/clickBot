using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Elegant.Ui.Samples.ControlsSample
{
	public class Theme
	{
		public Theme(string name, Image image)
		{
			themeImage = image;
			themeName = name;
		}

		string themeName = string.Empty;

		public string Name
		{
			get { return themeName; }
		}

		Image themeImage;

		public Image Image
		{
			get { return themeImage; }
		}
	}
}
