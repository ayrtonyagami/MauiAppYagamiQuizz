using MauiAppYagamiQuizz.Data;

namespace MauiAppYagamiQuizz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var context = new AppDbContext();
            DbSeeder.Seed(context);

            MainPage = new AppShell();
        }
    }
}
