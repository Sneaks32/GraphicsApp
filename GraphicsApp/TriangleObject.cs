using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

public class TriangleObject : SceneObject
{
	public TriangleObject()
	{
		Polygon triangle = new Polygon
		{
			Fill = Brushes.Green,
			Points = new PointCollection
			{
				new Point(0, 30),
				new Point(15, 0),
				new Point(30, 30)
			}
		};
		this.Content = triangle;
		Width = 30;
		Height = 30;
	}
}
