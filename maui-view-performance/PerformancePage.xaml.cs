


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

				switch (i % 5)
				{
					case 0:
					default:
						var label = new Label
						{
							Text = $"{i},{j}",
							VerticalTextAlignment = TextAlignment.Center,
							HorizontalTextAlignment = TextAlignment.Center,
						};
						view = label;
						break;
					case 1:
						var button = new Button
						{
							Text = $"{i},{j}",
						};
						view = button;
						break;
					case 2:
						var check = new CheckBox();
						view = check;
						break;
					case 3:
						var radio = new RadioButton();
						view = radio;
						break;
					case 4:
						var entry = new Entry
						{
							Text = $"{i},{j}",
						};
						view = entry;
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