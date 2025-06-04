using SQLite;

namespace MauiAppYagamiQuizz.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int CategoryId { get; set; } // Usar ID da categoria, em vez do nome

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
        public string CorrectAnswer { get; set; } // A, B, C ou D

        public int DifficultyLevel { get; set; } // 1-Fácil, 2-Médio, 3-Difícil

        public DateTime CreatedAt { get; set; }
    }

}
