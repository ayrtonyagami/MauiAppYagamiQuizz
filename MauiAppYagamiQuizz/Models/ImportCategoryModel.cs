using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppYagamiQuizz.Models
{
    public class ImportCategoryModel
    {
        public string Category { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = new();
    }

}
