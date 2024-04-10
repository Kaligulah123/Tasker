using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

    private async void AddTaskClicked(object sender, EventArgs e)
    {
		//Obtengo la referencia del BindingContext
		var vm = BindingContext as NewTaskViewModel;

		//Queremos obtener la categoria que ha sido seleccionada
		//creamos un filtro a traves de Where donde podamos comparar cual es la categoria qu se encuentre seleccionada
		//utilizo firstordefault para obtener la categoria en especifico.
		var selectedCategory = vm.Categories.Where(x=>x.IsSelected == true).FirstOrDefault();

		//comparamos si una categoria ha sido seleccionada
		if (selectedCategory != null)
		{
			var task = new MyTask
			{
				//esta propiedad mantiene cual es el Texto que se está ingresando en el Entry
				TaskName = vm.Task,
				//asociamos esta tarea a un categoria en especifico
				CategoryId = selectedCategory.Id,
			};
			vm.Tasks.Add(task);
			await Navigation.PopAsync();
		}
		else
		{
			await DisplayAlert("Invalid Selection", "You must select a category", "Ok");
		}


    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;

		string category = await DisplayPromptAsync("New Category", "Write the new category name", maxLength: 15, keyboard: Keyboard.Text);

		var r = new Random();//para crear un color aleatorio

		if(!string.IsNullOrEmpty(category))
		{
			vm.Categories.Add(new Category
			{
				Id = vm.Categories.Max(x => x.Id) + 1,//Obtenemos el Id más alto de la categoria y le sumamos 1
				Color = Color.FromRgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)).ToHex(),
				CategoryName=category
			});
		}
    }
}