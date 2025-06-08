using MauiAppYagamiQuizz.Data;

namespace MauiAppYagamiQuizz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadCategoryButtons();
        }

        private void LoadCategoryButtons()
        {
            foreach (var category in CategoryRepository.GetAll())
            {
                var button = new Button
                {
                    Text = category.Name,
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
                var categoryName = button?.Text;
                int categoryId = CategoryRepository.GetCategoryIdByName(categoryName);

                if (categoryId > 0)
                {
                    await Navigation.PushAsync(new QuizPage(categoryId));
                }
                else
                {
                    await DisplayAlert("Erro", "Categoria não encontrada.", "OK");
                }
            }
            finally
            {
                _isNavigating = false;
            }
        }

        private async void OnImportClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportPage());
        }
    }

}
