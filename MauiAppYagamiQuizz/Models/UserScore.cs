using SQLite;

namespace MauiAppYagamiQuizz.Models
{
    [Table("UserScores")]
    public class UserScore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        public int TotalQuestions { get; set; }

        public int CorrectAnswers { get; set; }

        public int ScorePercentage { get; set; }

        public TimeSpan TimeTaken { get; set; }

        public DateTime CompletedAt { get; set; }
    }
}
