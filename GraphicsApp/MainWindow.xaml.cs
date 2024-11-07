using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace GraphicsApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void AddTriangle_Click(object sender, RoutedEventArgs e)
		{
			TriangleObject triangle = new TriangleObject();
			Canvas.SetLeft(triangle, 100);
			Canvas.SetTop(triangle, 100);
			sceneCanvas.Children.Add(triangle);
		}

		private void AddText_Click(object sender, RoutedEventArgs e)
		{
			TextObject text = new TextObject();
			Canvas.SetLeft(text, 100);
			Canvas.SetTop(text, 150);
			sceneCanvas.Children.Add(text);
		}

		private void AddImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Image Files|*.jpg;*.png;*.bmp"
			};

			if (openFileDialog.ShowDialog() == true)
			{
				ImageObject image = new ImageObject(openFileDialog.FileName);
				Canvas.SetLeft(image, 200);
				Canvas.SetTop(image, 200);
				sceneCanvas.Children.Add(image);
			}
		}
	}
}


