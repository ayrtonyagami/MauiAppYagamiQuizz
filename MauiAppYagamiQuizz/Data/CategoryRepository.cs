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
        public static List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "Matemática" },
            new Category { Id = 2, Name = "História" },
            new Category { Id = 3, Name = "Ciências" },
            new Category { Id = 4, Name = "Geografia" },
        };

        public static List<string> GetAll()
        {
            return Categories.Select(c=>c.Name).ToList();
        }
        public static int GetCategoryIdByName(string name)
        {
            return Categories.FirstOrDefault(c => c.Name == name)?.Id ?? -1;
        }

        public static string GetCategoryNameById(int id)
        {
            return Categories.FirstOrDefault(c => c.Id == id)?.Name ?? "Desconhecida";
        }
    }

}
