using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Text;

namespace Kalkulator.Models;

public class Operation : INotifyPropertyChanged
{
	private string expression;

	public string Expression
	{
		get => expression;
		set {
            expression = value;
			OnPropertyChanged(nameof(Expression));
        }
	}

	public Operation(string expression)
	{
		this.expression = expression;
	}

    public void Clear()
    {
        this.expression = "";
        OnPropertyChanged(nameof(Expression));
    }

    public void Calculate()
    {
        try
        {
            if(expression.Contains("/0"))
            {
                // u¿ytkownik chce podzieliæ przez zero
                throw new DivideByZeroException();
            }

            DataTable dt = new DataTable();
            object v = dt.Compute(expression, "");

            if (v == DBNull.Value || v == null)
            {
                this.expression = "Pusta wartoœæ";
            }
            else
            {
                this.expression = v.ToString();
            }
        }
        catch (SyntaxErrorException)
        {
            this.expression = "B³¹d sk³adni";
        }
        catch(DivideByZeroException)
        {
            this.expression = "Podzia³ przez 0";
        }
        
        OnPropertyChanged(nameof(Expression));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => 
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}