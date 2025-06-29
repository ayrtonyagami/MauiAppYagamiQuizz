﻿using MauiAppYagamiQuizz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppYagamiQuizz.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Id = 1, Name = "Matemática" },
                    new Category { Id = 2, Name = "História" },
                    new Category { Id = 3, Name = "Ciências" },
                    new Category { Id = 4, Name = "Geografia" }
                );
            }

            if (!context.Questions.Any())
            {
                var questions = GetQuestions();
                context.Questions.AddRange(questions);
            }

            context.SaveChanges();
        }

        private static List<Question> GetQuestions()
        {
            #region Questoes
            List<Question> questions = new List<Question>
            {
                // Matemática
                new Question
                {
                    Id = 1,
                    CategoryId = 1,
                    QuestionText = "Quanto é 2 + 2?",
                    OptionA = "3",
                    OptionB = "4",
                    OptionC = "5",
                    OptionD = "6",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 2,
                    CategoryId = 1,
                    QuestionText = "Qual é o valor de PI (aproximado)?",
                    OptionA = "2.14",
                    OptionB = "3.14",
                    OptionC = "4.14",
                    OptionD = "5.14",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 3,
                    CategoryId = 1,
                    QuestionText = "Qual é a raiz quadrada de 81?",
                    OptionA = "7",
                    OptionB = "8",
                    OptionC = "9",
                    OptionD = "10",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 4,
                    CategoryId = 1,
                    QuestionText = "Quanto é 7 x 6?",
                    OptionA = "42",
                    OptionB = "36",
                    OptionC = "48",
                    OptionD = "40",
                    CorrectOption = "A"
                },

                // História
                new Question
                {
                    Id = 5,
                    CategoryId = 2,
                    QuestionText = "Quem descobriu o Brasil?",
                    OptionA = "Pedro Álvares Cabral",
                    OptionB = "Dom Pedro I",
                    OptionC = "Tiradentes",
                    OptionD = "Machado de Assis",
                    CorrectOption = "A"
                },
                new Question
                {
                    Id = 6,
                    CategoryId = 2,
                    QuestionText = "Em que ano ocorreu a independência do Brasil?",
                    OptionA = "1500",
                    OptionB = "1822",
                    OptionC = "1889",
                    OptionD = "1945",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 7,
                    CategoryId = 2,
                    QuestionText = "Quem foi o primeiro imperador do Brasil?",
                    OptionA = "Dom Pedro II",
                    OptionB = "Getúlio Vargas",
                    OptionC = "Dom Pedro I",
                    OptionD = "Juscelino Kubitschek",
                    CorrectOption = "C"
                },

                // Ciências
                new Question
                {
                    Id = 8,
                    CategoryId = 3,
                    QuestionText = "Qual é o estado da água em temperatura ambiente?",
                    OptionA = "Sólido",
                    OptionB = "Líquido",
                    OptionC = "Gasoso",
                    OptionD = "Plasma",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 9,
                    CategoryId = 3,
                    QuestionText = "Qual órgão do corpo humano é responsável por bombear o sangue?",
                    OptionA = "Pulmão",
                    OptionB = "Cérebro",
                    OptionC = "Fígado",
                    OptionD = "Coração",
                    CorrectOption = "D"
                },
                new Question
                {
                    Id = 10,
                    CategoryId = 3,
                    QuestionText = "Qual é o planeta mais próximo do Sol?",
                    OptionA = "Terra",
                    OptionB = "Vênus",
                    OptionC = "Marte",
                    OptionD = "Mercúrio",
                    CorrectOption = "D"
                },

                // Geografia
                new Question
                {
                    Id = 11,
                    CategoryId = 4,
                    QuestionText = "Qual é o maior país do mundo em extensão territorial?",
                    OptionA = "Canadá",
                    OptionB = "China",
                    OptionC = "Estados Unidos",
                    OptionD = "Rússia",
                    CorrectOption = "D"
                },
                new Question
                {
                    Id = 12,
                    CategoryId = 4,
                    QuestionText = "Qual é o rio mais extenso do mundo?",
                    OptionA = "Amazonas",
                    OptionB = "Nilo",
                    OptionC = "Yangtzé",
                    OptionD = "Mississipi",
                    CorrectOption = "A"
                },
                new Question
                {
                    Id = 13,
                    CategoryId = 4,
                    QuestionText = "Qual é a capital da França?",
                    OptionA = "Londres",
                    OptionB = "Paris",
                    OptionC = "Berlim",
                    OptionD = "Roma",
                    CorrectOption = "B"
                }
            };
            #endregion Questoes
            return questions;
        }
    }

}
