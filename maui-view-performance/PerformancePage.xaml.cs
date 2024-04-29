


namespace maui_view_performance;

public partial class PerformancePage : ContentPage
{
	public PerformancePage()
	{
		InitializeComponent();

		for (int i = 0; i < _grid.ColumnDefinitions.Count; i++)
		{
			for (int j = 0; j < _grid.RowDefinitions.Count; j++)
			{
				View view;

				switch (i % 4)
				{
					case 0:
					default:
						var label = new Label
						{
							Text = $"Label {i},{j}",
						};
						view = label;
						break;
					case 1:
						var button = new Button
						{
							Text = $"Button {i},{j}",
						};
						view = button;
						break;
					case 2:
						var check = new CheckBox();
						view = check;
						break;
					case 3:
						var radio = new RadioButton
						{
							Content = $"Radio {i},{j}",
						};
						view = radio;
						break;
				}

				Grid.SetColumn(view, i);
				Grid.SetRow(view, j);
				_grid.Children.Add(view);
			}
		}
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		// Allow one frame to render the page
		_ = Dispatcher.DispatchAsync(() => Timing.Stop("NewPage"));
	}
}