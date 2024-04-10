namespace Tasker.MVVM.Views;

public partial class Varios : ContentPage
{
	public Varios()
	{
		InitializeComponent();
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		if (e.Value)
		{
            label1.TextDecorations = TextDecorations.Strikethrough;
        }
		else
		{
			label1.TextDecorations = TextDecorations.None;
        }
		
    }
}