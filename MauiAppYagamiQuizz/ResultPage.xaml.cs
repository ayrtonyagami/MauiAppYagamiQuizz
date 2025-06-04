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
        ScoreLabel.Text = $"{_scorePercentage}% Score";
        QuestionsAttemptedLabel.Text = $"{_totalQuestions} questions";
        CorrectAnswersLabel.Text = $"{_correctAnswers} answer";
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
            var message = $"Just scored {_scorePercentage}% on the Quiz App! Got {_correctAnswers} out of {_totalQuestions} questions correct. 🎉";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = message,
                Title = "Quiz Results"
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
            var message = $"Just scored {_scorePercentage}% on the Quiz App! Got {_correctAnswers} out of {_totalQuestions} questions correct. 🎉";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = message,
                Title = "Quiz Results"
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
            var message = $"Just scored {_scorePercentage}% on the Quiz App! Got {_correctAnswers} out of {_totalQuestions} questions correct. 🎉";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = message,
                Title = "Quiz Results"
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Unable to share to WhatsApp", "OK");
        }
    }





}