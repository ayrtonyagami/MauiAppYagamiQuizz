using MauiAppYagamiQuizz.Data;
using MauiAppYagamiQuizz.Models;
using System.Timers;

namespace MauiAppYagamiQuizz;

public partial class QuizPage : ContentPage
{
    private System.Timers.Timer _timer;
    private int _timeInSeconds = 180;
    private string _selectedAnswer = "";
    private int _categoryId;
    private List<Question> _questions;
    private int _currentQuestionIndex = 0;
    private int _correctAnswers = 0;

    public QuizPage(int categoryId)
    {
        InitializeComponent();
        _categoryId = categoryId;

        CategoryLabel.Text = CategoryRepository.GetCategoryNameById(_categoryId);

        LoadQuestion();
        StartTimer();
    }

    private void LoadQuestion()
    {
        _questions ??= QuestionRepository.GetQuestionsByCategory(_categoryId);

        if (_currentQuestionIndex >= _questions.Count)
        {
            EndQuiz();
            return;
        }

        ResetAllOptions();

        var question = _questions[_currentQuestionIndex];
        QuestionLabel.Text = question.QuestionText;
        OptionALabel.Text = question.OptionA;
        OptionBLabel.Text = question.OptionB;
        OptionCLabel.Text = question.OptionC;
        OptionDLabel.Text = question.OptionD;
        _selectedAnswer = "";
    }

    private void OnAnswerSelected(object sender, EventArgs e)
    {
        ResetAllOptions();
        var selectedFrame = sender as Frame;
        if (selectedFrame == null) return;

        selectedFrame.BackgroundColor = Color.FromArgb("#E67E22");

        var grid = selectedFrame.Content as Grid;
        if (grid?.Children[1] is Label textLabel)
            textLabel.TextColor = Colors.White;

        if (selectedFrame == OptionA) _selectedAnswer = "A";
        else if (selectedFrame == OptionB) _selectedAnswer = "B";
        else if (selectedFrame == OptionC) _selectedAnswer = "C";
        else if (selectedFrame == OptionD) _selectedAnswer = "D";
    }

    private void ResetAllOptions()
    {
        var options = new[] { OptionA, OptionB, OptionC, OptionD };
        foreach (var option in options)
        {
            option.BackgroundColor = Color.FromArgb("#BDC3C7");
            var grid = option.Content as Grid;
            if (grid?.Children[1] is Label textLabel)
                textLabel.TextColor = Color.FromArgb("#2C3E50");
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_selectedAnswer))
        {
            await DisplayAlert("No Answer Selected", "Please select an answer.", "OK");
            return;
        }

        var currentQuestion = _questions[_currentQuestionIndex];

        // Verifica se a resposta está correta
        if (_selectedAnswer == currentQuestion.CorrectOption)
            _correctAnswers++;

        // Mostra feedback visual
        HighlightCorrectAndWrongAnswers(currentQuestion.CorrectOption, _selectedAnswer);

        // Aguarda 2 segundos antes de avançar
        await Task.Delay(2000);

        _currentQuestionIndex++;
        LoadQuestion();
    }

    private void HighlightCorrectAndWrongAnswers(string correct, string selected)
    {
        Frame correctFrame = GetFrameByOption(correct);
        correctFrame.BackgroundColor = Colors.Green;

        var correctGrid = correctFrame.Content as Grid;
        if (correctGrid?.Children[1] is Label correctLabel)
            correctLabel.TextColor = Colors.White;

        if (selected != correct)
        {
            Frame selectedFrame = GetFrameByOption(selected);
            selectedFrame.BackgroundColor = Colors.Red;

            var selectedGrid = selectedFrame.Content as Grid;
            if (selectedGrid?.Children[1] is Label selectedLabel)
                selectedLabel.TextColor = Colors.White;
        }
    }

    private Frame GetFrameByOption(string option)
    {
        return option switch
        {
            "A" => OptionA,
            "B" => OptionB,
            "C" => OptionC,
            "D" => OptionD,
            _ => throw new ArgumentException("Invalid option letter")
        };
    }

    private async void EndQuiz()
    {
        StopTimer();
        int total = _questions.Count;
        int score = (int)((double)_correctAnswers / total * 100);
        await Navigation.PushAsync(new ResultPage(score, total, _correctAnswers));
    }

    private void StartTimer()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += OnTimerElapsed;
        _timer.Start();
    }

    private void StopTimer()
    {
        _timer?.Stop();
        _timer?.Dispose();
        _timer = null;
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        _timeInSeconds--;
        if (_timeInSeconds <= 0)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Time's Up!", "Quiz time has ended.", "OK");
                EndQuiz();
            });
        }
        else
        {
            var minutes = _timeInSeconds / 60;
            var seconds = _timeInSeconds % 60;
            var timeText = $"{minutes:D2}:{seconds:D2} min";

            MainThread.BeginInvokeOnMainThread(() =>
            {
                TimeLabel.Text = timeText;
            });
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        StopTimer();
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        StopTimer();
        var result = await DisplayAlert("Exit Quiz", "Are you sure you want to exit?", "Yes", "No");
        if (result) await Navigation.PopAsync();
        else StartTimer();
    }
}
