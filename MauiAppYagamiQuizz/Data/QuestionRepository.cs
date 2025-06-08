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

    public static List<Question> GetAll()
    {
        using var db = new AppDbContext();
        return db.Questions.ToList();
    }

    public static Question? GetById(int id)
    {
        using var db = new AppDbContext();
        return db.Questions.Find(id);
    }

    public static void Add(Question question)
    {
        using var db = new AppDbContext();
        db.Questions.Add(question);
        db.SaveChanges();
    }

    public static void Update(Question question)
    {
        using var db = new AppDbContext();
        db.Questions.Update(question);
        db.SaveChanges();
    }

    public static void Delete(int id)
    {
        using var db = new AppDbContext();
        var question = db.Questions.Find(id);
        if (question != null)
        {
            db.Questions.Remove(question);
            db.SaveChanges();
        }
    }
}
