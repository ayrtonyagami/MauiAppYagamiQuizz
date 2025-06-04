using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppYagamiQuizz.Models;

namespace MauiAppYagamiQuizz.Data;

public static class QuestionRepository
{

    public static List<Question> GetQuestionsByCategory(int categoryId)
    {
        using var db = new AppDbContext();
        return db.Questions
            .Where(q => q.CategoryId == categoryId)
            .ToList();
    }
}
