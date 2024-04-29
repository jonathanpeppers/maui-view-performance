namespace maui_view_performance
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnClicked(object sender, EventArgs e)
		{
			Timing.Start("NewPage");

			Navigation.PushAsync(new PerformancePage());
		}
	}
}
