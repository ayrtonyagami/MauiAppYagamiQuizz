using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppYagamiQuizz.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int CategoryId { get; set; } // Usar ID da categoria, em vez do nome
        public string QuestionText { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;

        [MaxLength(1)]
        public string CorrectOption { get; set; } = string.Empty; // "A", "B", "C", "D"
    }
}
