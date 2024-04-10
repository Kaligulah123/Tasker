using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
	private MainViewModel mainViewModel = new MainViewModel();
	
	public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		//Creo una instancia de la pagina a la cual vamos a navegar (NewTaskView)
		var taskView = new NewTaskView
		{
			//Esta pagina NewTaskView tendra su BindingContext como NewTskViewModel para poder acceder
			//a las propiedades creadas en esa pagina, Task y Categories.
			//De esta forma paso la informacion de la pagina principal a la pagina secundaria.
			BindingContext = new NewTaskViewModel
			{
				Tasks = mainViewModel.Tasks,
				Categories = mainViewModel.Categories
			}
		};

		//Navego a esta nueva vista
		Navigation.PushAsync(taskView);
    }
}