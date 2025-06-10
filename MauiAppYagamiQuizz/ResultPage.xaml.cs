namespace MauiAppYagamiQuizz;

public partial class ResultPage : ContentPage
{

    private int _scorePercentage;
    private int _totalQuestions;
    private int _correctAnswers;

    public ResultPage(int scorePercentage, int totalQuestions, int correctAnswers)
    {
        InitializeComponent();

        _scorePercentage = scorePercentage;
        _totalQuestions = totalQuestions;
        _correctAnswers = correctAnswers;

        UpdateResultDisplay();
    }

    private void UpdateResultDisplay()
    {
        ScoreLabel.Text = $"{_scorePercentage}% Pontos";
        QuestionsAttemptedLabel.Text = $"{_totalQuestions} questões";
        CorrectAnswersLabel.Text = $"{_correctAnswers} respostas";
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        // Navigate back to main page
        await Navigation.PopToRootAsync();
    }

    private async void OnInstagramShare(object sender, EventArgs e)
    {
        try
        {
            var message = $"Acabei de pontuar {_scorePercentage}% na aplicação Quiz! Acertei {_correctAnswers} de {_totalQuestions} perguntas. 🎉";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = message,
                Title = "Resultados"
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Unable to share to Instagram", "OK");
        }
    }

    private async void OnFacebookShare(object sender, EventArgs e)
    {
        try
        {
            var message = $"Acabei de pontuar {_scorePercentage}% na aplicação Quiz! Acertei {_correctAnswers} de {_totalQuestions} perguntas. 🎉";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = message,
                Title = "Resultados"
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Unable to share to Facebook", "OK");
        }
    }

    private async void OnWhatsAppShare(object sender, EventArgs e)
    {
        try
        {
            var message = $"Acabei de pontuar {_scorePercentage}% na aplicação Quiz! Acertei {_correctAnswers} de {_totalQuestions} perguntas. 🎉";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = message,
                Title = "Resultados"
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Unable to share to WhatsApp", "OK");
        }
    }





}