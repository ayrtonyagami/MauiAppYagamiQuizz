using SQLite;

namespace MauiAppYagamiQuizz.Models
{
    [Table("UserStats")]
    public class UserStats
    {
        [PrimaryKey]
        public int Id { get; set; } = 1; // Single row for user stats

        public int TotalQuestionsAnswered { get; set; }

        public int TotalCorrectAnswers { get; set; }

        public int CurrentRanking { get; set; }

        public int BestScore { get; set; }

        public string FavoriteCategory { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
