using Kalkulator.Models;
using Kalkulator.ViewModels;

namespace Kalkulator.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new OperationViewModel(new Operation("1+1"));
    }
}