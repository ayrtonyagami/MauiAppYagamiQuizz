using Android.Webkit;
using MauiAppYagamiQuizz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppYagamiQuizz.Data
{
    public static class CategoryRepository
    {
        public static List<Question> GetQuestionsByCategory(int categoryId)
        {
            using var db = new AppDbContext();
            return db.Questions
                .Where(q => q.CategoryId == categoryId)
                .ToList();
        }

        public static List<string> GetAll()
        {
            using var db = new AppDbContext();
            return db.Categories.Select(c=>c.Name).ToList();
        }
        public static int GetCategoryIdByName(string name)
        {
            using var db = new AppDbContext();
            return db.Categories.FirstOrDefault(c => c.Name == name)?.Id ?? -1;
        }

        public static string GetCategoryNameById(int id)
        {
            using var db = new AppDbContext();
            return db.Categories.FirstOrDefault(c => c.Id == id)?.Name ?? "Desconhecida";
        }
    }

}
