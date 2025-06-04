namespace MauiAppYagamiQuizz
{
    public partial class MainPage : ContentPage
    {
        private readonly List<string> categories = new()
        {

            "🧪 Science & Nature",
            "🌍 Geography"
        };
        public MainPage()
        {
            InitializeComponent();
            LoadCategoryButtons();
        }

        private void LoadCategoryButtons()
        {
            foreach (var category in categories)
            {
                var button = new Button
                {
                    Text = category,
                    BackgroundColor = Color.FromArgb("#34495E"),
                    TextColor = Colors.White,
                    FontSize = 16,
                    HeightRequest = 60,
                    CornerRadius = 15,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                button.Clicked += OnCategorySelected;
                CategoryButtonsStack.Children.Add(button);
            }
        }
        private bool _isNavigating = false;

        private async void OnCategorySelected(object sender, EventArgs e)
        {
            if (_isNavigating) return;
            _isNavigating = true;

            try
            {
                var button = sender as Button;
                var category = button?.Text?.Split(' ', 2)[1];

                await Navigation.PushAsync(new QuizPage(category));
            }
            finally
            {
                _isNavigating = false;
            }
        }

        private async void OnUpgradeClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Upgrade", "Upgrade functionality would be implemented here.", "OK");
        }
    }

}
