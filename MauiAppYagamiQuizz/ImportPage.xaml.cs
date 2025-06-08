using MauiAppYagamiQuizz.Data;
using MauiAppYagamiQuizz.Models;
using Newtonsoft.Json;

namespace MauiAppYagamiQuizz;

public partial class ImportPage : ContentPage
{
	public ImportPage()
	{
		InitializeComponent();
	}

    private async void OnImportClicked(object sender, EventArgs e)
    {
        var json = JsonEditor.Text;

        if (string.IsNullOrWhiteSpace(json))
        {
            await DisplayAlert("Erro", "O campo de texto está vazio.", "OK");
            return;
        }

        try
        {
            var importData = JsonConvert.DeserializeObject<ImportCategoryModel>(json);

            if (importData == null || string.IsNullOrWhiteSpace(importData.Category) || !importData.Questions.Any())
            {
                await DisplayAlert("Erro", "Formato JSON inválido ou dados incompletos.", "OK");
                return;
            }

            // Verifica se categoria já existe
            var existing = CategoryRepository.GetAll()
                .FirstOrDefault(c => c.Name.Equals(importData.Category, StringComparison.OrdinalIgnoreCase));

            int categoryId;

            if (existing == null)
            {
                var category = new Category { Name = importData.Category };
                CategoryRepository.Add(category);
                categoryId = category.Id; // pode atualizar via GetAll ou retornar ID no Add
                var inserted = CategoryRepository.GetAll().FirstOrDefault(c => c.Name == importData.Category);
                categoryId = inserted?.Id ?? 0;
            }
            else
            {
                categoryId = existing.Id;
            }

            foreach (var q in importData.Questions)
            {
                q.CategoryId = categoryId;
                QuestionRepository.Add(q);
            }

            await DisplayAlert("Sucesso", "Importação realizada com sucesso!", "OK");
            JsonEditor.Text = "";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao importar: {ex.Message}", "OK");
        }
    }
}