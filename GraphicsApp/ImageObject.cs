using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

public class ImageObject : SceneObject
{
	public ImageObject(string imagePath)
	{
		Image image = new Image
		{
			Source = new BitmapImage(new Uri(imagePath)),
			Width = 50,
			Height = 50
		};
		this.Content = image;
	}
}
