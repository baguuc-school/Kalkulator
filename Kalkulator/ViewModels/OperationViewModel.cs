using System.Windows.Input;
using Kalkulator.Models;

namespace Kalkulator.ViewModels;

public class OperationViewModel
{
	public Operation Operation { get; set; }

	public OperationViewModel(Operation deflt)
	{
		this.Operation = deflt;
	}
}