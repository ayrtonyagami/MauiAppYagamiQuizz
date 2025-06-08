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


        public static List<Category> GetAll()
        {
            using var db = new AppDbContext();
            return db.Categories.ToList();
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



        public static Category? GetById(int id)
        {
            using var db = new AppDbContext();
            return db.Categories.Find(id);
        }



        public static void Add(Category category)
        {
            using var db = new AppDbContext();
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public static void Update(Category category)
        {
            using var db = new AppDbContext();
            db.Categories.Update(category);
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            using var db = new AppDbContext();
            var category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }



    }

}
