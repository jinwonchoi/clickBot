namespace Elegant.Ui.Samples.ControlsSample
{
	public class ShapeTypeItem
	{
		public ShapeTypeItem(string name, ShapeType shapeType)
		{
			_name = name;
			_shapeType = shapeType;
		}

		private string _name;
		private ShapeType _shapeType;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public ShapeType ShapeType
		{
			get { return _shapeType; }
			set { _shapeType = value; }
		}

		public override string ToString()
		{
			return Name;
		}
	}
}