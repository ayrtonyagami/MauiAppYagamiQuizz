using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppYagamiQuizz.Models;

namespace MauiAppYagamiQuizz.Data;

public static class QuestionRepository
{
    public static List<QuestionModel> GetQuestionsByCategory(string category)
    {
        return category switch
        {
            "Science and Nature" => new List<QuestionModel>
            {
                new()
                {
                    QuestionText = "What is the chemical symbol for water?",
                    OptionA = "H2O",
                    OptionB = "O2",
                    OptionC = "CO2",
                    OptionD = "NaCl",
                    CorrectOption = "A"
                },
                new()
                {
                    QuestionText = "How many bones are in the human body?",
                    OptionA = "200",
                    OptionB = "206",
                    OptionC = "201",
                    OptionD = "210",
                    CorrectOption = "B"
                }
            },
            "Geography" => new List<QuestionModel>
            {
                new()
                {
                    QuestionText = "What is the capital of France?",
                    OptionA = "Berlin",
                    OptionB = "A autoconfiança, portanto, não é apenas um estado interno; é a força motriz por trás da ousadia que permite enfrentar oposição.",
                    OptionC = "Paris",
                    OptionD = "Rome",
                    CorrectOption = "C"
                }
            },
            _ => new List<QuestionModel>()
        };
    }
}
