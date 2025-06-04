using SQLite;

namespace MauiAppYagamiQuizz.Models
{
    [Table("Questions")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(500)]
        public string QuestionText { get; set; }

        [MaxLength(200)]
        public string OptionA { get; set; }

        [MaxLength(200)]
        public string OptionB { get; set; }

        [MaxLength(200)]
        public string OptionC { get; set; }

        [MaxLength(200)]
        public string OptionD { get; set; }

        [MaxLength(1)]
        public string CorrectAnswer { get; set; } // A, B, C, or D

        public int DifficultyLevel { get; set; } // 1-Easy, 2-Medium, 3-Hard

        public DateTime CreatedAt { get; set; }
    }
}
