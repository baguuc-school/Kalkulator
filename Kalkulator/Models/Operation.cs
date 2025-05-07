using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Text;

namespace Kalkulator.Models;

public class Operation : INotifyPropertyChanged
{
	private string expression;
    private float? rawValue;
    private string value;

	public string Expression
	{
		get => expression;
		set {
            expression = value;
            // odswiez wartosc operacji
            this.RawValue = null;
			OnPropertyChanged();
        }
	}

	private float? RawValue
    {
		get => rawValue;
        set
        {
            try
            {
                DataTable dt = new DataTable();
                object v = dt.Compute(Expression, "");

                if (v == DBNull.Value)
                {
                    this.rawValue = null;
                }

                if (v is int)
                {
                    this.rawValue = (float)(int)v;
                }
                else if (v is float)
                {
                    this.rawValue = (float)v;
                }
                else if (v is double)
                {
                    this.rawValue = (float)(double)v;
                }
            }
            catch (SyntaxErrorException)
            {
                this.rawValue = null;
            }

            this.Value = "";
            OnPropertyChanged();
        }
	}

	public string Value
	{
        get => value;
        set {
            this.value = RawValue == null ? "B³¹d sk³adni!" : RawValue.ToString();
            OnPropertyChanged();
        }
	}

	public Operation(string expression)
	{
		this.Expression = expression;
	}

    public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => 
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}