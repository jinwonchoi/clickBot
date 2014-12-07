using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Elegant.Ui.Samples.ControlsSample
{
	public class ShapeControl : ToggleButton
	{
		private ShapeType _shapeType = ShapeType.Star;

		public ShapeType ShapeType
		{
			get
			{
				return _shapeType;
			}
			set
			{
				if (_shapeType == value)
					return;

				_shapeType = value;

				Invalidate();
			}
		}

		private static readonly Color DefaultShapeBorderColor = Color.Black;
		private Color _borderColor = DefaultShapeBorderColor;

		public Color BorderColor
		{
			get { return _borderColor; }
			set
			{
				if (_borderColor == value)
					return;

				_borderColor = value;

				Invalidate();
			}
		}

		bool ShouldSerializeBorderColor()
		{
			return _borderColor != DefaultShapeBorderColor;
		}

		void ResetBorderColor()
		{
			_borderColor = DefaultShapeBorderColor;
		}

		private static readonly Color DefaultShapeBackColor = Color.White;
		private Color _backgroundColor = DefaultShapeBackColor;

		public Color BackgroundColor
		{
			get { return _backgroundColor; }
			set
			{
				if (_backgroundColor == value)
					return;

				_backgroundColor = value;

				Invalidate();
			}
		}

		bool ShouldSerializeBackgroundColor()
		{
			return _backgroundColor != DefaultShapeBackColor;
		}

		void ResetBackgroundColor()
		{
			_backgroundColor = DefaultShapeBackColor;
		}

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
		{
			PaintStandardBackground(pevent);
			SmoothingMode smoothingMode = pevent.Graphics.SmoothingMode;

			pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			using (Brush brush = new SolidBrush(BackgroundColor))
			{
				if (ShapeType == ShapeType.Star || ShapeType == ShapeType.Octagon)
				{
					PointF[] pts = GetPolygonPoints(7, DisplayRectangle);

					pevent.Graphics.FillPolygon(brush, pts);

				}
				else if (ShapeType == ShapeType.Circle)
				{
					pevent.Graphics.FillEllipse(brush, DisplayRectangle);
				}
				else if (ShapeType == ShapeType.RoundedRectangle)
				{
					FillRoundedRectangle(pevent.Graphics, DisplayRectangle, 30, brush);
				}
			}

			pevent.Graphics.SmoothingMode = smoothingMode;

			if (Focused || Pressed)
			{
				GraphicsUtilities.DrawOutline(this, pevent.Graphics);
			}
		}

		protected override void OnPaintForeground(System.Windows.Forms.PaintEventArgs e)
		{
			SmoothingMode smoothingMode = e.Graphics.SmoothingMode;

			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			
			using (Pen pen = new Pen(BorderColor, 3))
			{
				if (ShapeType == ShapeType.Star || ShapeType == ShapeType.Octagon)
				{
					PointF[] pts = GetPolygonPoints(7, DisplayRectangle);
					e.Graphics.DrawPolygon(pen, pts);
				}
				else if (ShapeType == ShapeType.Circle)
				{
					e.Graphics.DrawEllipse(pen, DisplayRectangle);
				}
				else if(ShapeType == ShapeType.RoundedRectangle)
				{
					DrawRoundedRectangle(e.Graphics, DisplayRectangle,30, pen);
				}
			}

			e.Graphics.SmoothingMode = smoothingMode;
		}

		private PointF[] GetPolygonPoints(int numPoints, Rectangle bounds)
		{

			if (ShapeType == ShapeType.Star)
			{
				PointF[] pts = new PointF[2 * numPoints];

				double rx1 = bounds.Width / 2;
				double ry1 = bounds.Height / 2;
				double rx2 = rx1 * 0.5;
				double ry2 = ry1 * 0.5;
				double cx = bounds.X + rx1;
				double cy = bounds.Y + ry1;
			
				double theta = -Math.PI / 2;
				double dtheta = Math.PI / numPoints;
				for (int i = 0; i < 2 * numPoints; i += 2)
				{
					pts[i] = new PointF(
						(float)(cx + rx1 * Math.Cos(theta)),
						(float)(cy + ry1 * Math.Sin(theta)));
					theta += dtheta;

					pts[i + 1] = new PointF(
						(float)(cx + rx2 * Math.Cos(theta)),
						(float)(cy + ry2 * Math.Sin(theta)));
					theta += dtheta;
				}

				return pts;
			}

			int x = bounds.Width/2 + Padding.Left;
			int y = bounds.Height / 2 + Padding.Top;
			int r = Math.Min(x, y) - Padding.Horizontal;

			int r2 = (int)(r / (float)Math.Sqrt(2));

			PointF[] pt = new PointF[8];
			pt[0].X = x; pt[0].Y = y - r;
			pt[1].X = x + r2; pt[1].Y = y - r2;
			pt[2].X = x + r; pt[2].Y = y;
			pt[3].X = x + r2; pt[3].Y = y + r2;
			pt[4].X = x; pt[4].Y = y + r;
			pt[5].X = x - r2; pt[5].Y = y + r2;
			pt[6].X = x - r; pt[6].Y = y;
			pt[7].X = x - r2; pt[7].Y = y - r2;

			return pt;
		}

		public void DrawRoundedRectangle(Graphics g, Rectangle r, int d, Pen p)
		{
			g.DrawArc(p, r.X, r.Y, d, d, 180, 90);
			g.DrawLine(p, r.X + d / 2, r.Y, r.X + r.Width - d / 2, r.Y);
			g.DrawArc(p, r.X + r.Width - d, r.Y, d, d, 270, 90);
			g.DrawLine(p, r.X, r.Y + d / 2, r.X, r.Y + r.Height - d / 2);
			g.DrawLine(p, r.X + r.Width, r.Y + d / 2, r.X + r.Width, r.Y + r.Height - d / 2);
			g.DrawLine(p, r.X + d / 2, r.Y + r.Height, r.X + r.Width - d / 2, r.Y + r.Height);
			g.DrawArc(p, r.X, r.Y + r.Height - d, d, d, 90, 90);
			g.DrawArc(p, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
		}

		public static void FillRoundedRectangle(Graphics g, Rectangle r, int d, Brush b)
		{
			SmoothingMode mode = g.SmoothingMode;
			g.SmoothingMode = SmoothingMode.HighSpeed;
			g.FillPie(b, r.X, r.Y, d, d, 180, 90);
			g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90);
			g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90);
			g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
			g.FillRectangle(b, r.X + d / 2, r.Y, r.Width - d, d / 2);
			g.FillRectangle(b, r.X, r.Y + d / 2, r.Width, r.Height - d);
			g.FillRectangle(b, r.X + d / 2, r.Y + r.Height - d / 2, r.Width - d, d / 2);
			g.SmoothingMode = mode;
		}
	}
}