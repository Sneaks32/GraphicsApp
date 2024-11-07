using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

public abstract class SceneObject : UserControl
{
	private bool isDragging;
	private Point mousePosition;

	protected SceneObject()
	{
		this.MouseLeftButtonDown += OnMouseLeftButtonDown;
		this.MouseMove += OnMouseMove;
		this.MouseLeftButtonUp += OnMouseLeftButtonUp;
		this.MouseRightButtonDown += OnMouseRightButtonDown;
	}

	private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		isDragging = true;
		mousePosition = e.GetPosition(Parent as Canvas);

		// Захватываем мышь, чтобы отслеживать её перемещение при перетаскивании
		this.CaptureMouse();
	}

	private void OnMouseMove(object sender, MouseEventArgs e)
	{
		if (isDragging && Parent is Canvas canvas)
		{
			Point currentPosition = e.GetPosition(canvas);
			double offsetX = currentPosition.X - mousePosition.X;
			double offsetY = currentPosition.Y - mousePosition.Y;

			// Проверяем и инициализируем начальные позиции, если они не заданы
			if (double.IsNaN(Canvas.GetLeft(this)))
				Canvas.SetLeft(this, 0);
			if (double.IsNaN(Canvas.GetTop(this)))
				Canvas.SetTop(this, 0);

			Canvas.SetLeft(this, Canvas.GetLeft(this) + offsetX);
			Canvas.SetTop(this, Canvas.GetTop(this) + offsetY);

			mousePosition = currentPosition; // Обновляем позицию мыши для следующего перемещения
		}
	}

	private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		// Завершаем перетаскивание
		isDragging = false;
		this.ReleaseMouseCapture();
	}

	protected virtual void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
	{
		// Удаляем объект из `Canvas`
		if (Parent is Canvas canvas)
		{
			canvas.Children.Remove(this);
		}
	}
}
