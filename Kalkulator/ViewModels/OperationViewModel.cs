using System.Windows.Input;
using Kalkulator.Models;

namespace Kalkulator.ViewModels;

public class OperationViewModel
{
	public Operation Operation { get; set; }

	public Command Add0Command { get; set; }
    public Command Add1Command { get; set; }
    public Command Add2Command { get; set; }
    public Command Add3Command { get; set; }
    public Command Add4Command { get; set; }
    public Command Add5Command { get; set; }
    public Command Add6Command { get; set; }
    public Command Add7Command { get; set; }
    public Command Add8Command { get; set; }
    public Command Add9Command { get; set; }

    public Command AddAdditionCommand { get; set; }
    public Command AddSubtractionCommand { get; set; }
    public Command AddMultiplicationCommand { get; set; }
    public Command AddDivisionCommand { get; set; }

    public Command CalculateCommand { get; set; }
    public Command ClearCommand { get; set; }

    public OperationViewModel(Operation deflt)
	{
		this.Operation = deflt;

        this.Add0Command = new Command(() => this.Operation.Expression += "0");
        this.Add1Command = new Command(() => this.Operation.Expression += "1");
        this.Add2Command = new Command(() => this.Operation.Expression += "2");
        this.Add3Command = new Command(() => this.Operation.Expression += "3");
        this.Add4Command = new Command(() => this.Operation.Expression += "4");
        this.Add5Command = new Command(() => this.Operation.Expression += "5");
        this.Add6Command = new Command(() => this.Operation.Expression += "6");
        this.Add7Command = new Command(() => this.Operation.Expression += "7");
        this.Add8Command = new Command(() => this.Operation.Expression += "8");
        this.Add9Command = new Command(() => this.Operation.Expression += "9");

        this.AddAdditionCommand = new Command(() => this.Operation.Expression += "+");
        this.AddSubtractionCommand = new Command(() => this.Operation.Expression += "-");
        this.AddMultiplicationCommand = new Command(() => this.Operation.Expression += "*");
        this.AddDivisionCommand = new Command(() => this.Operation.Expression += "/");

        this.CalculateCommand = new Command(() =>
        {
            this.Operation.Value = "";
        });
        this.ClearCommand = new Command(() => this.Operation.Expression = "");
    }
}