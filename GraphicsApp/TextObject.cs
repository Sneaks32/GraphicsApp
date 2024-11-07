using System.Windows.Controls;
using System.Windows.Media;

public class TextObject : SceneObject
{
	public TextObject()
	{
		TextBlock text = new TextBlock
		{
			Text = "Капибара",
			FontSize = 16,
			Foreground = Brushes.Black
		};
		this.Content = text;
	}
}
