using System;

public class Calculadora
{
    private double ultimoResultado;

    public double UltimoResultado
    {
        get { return ultimoResultado; }
        private set { ultimoResultado = value; }
    }

    public double Sumar(double a, double b)
    {
        UltimoResultado = a + b;
        return UltimoResultado;
    }

    public double Restar(double a, double b)
    {
        UltimoResultado = a - b;
        return UltimoResultado;
    }

    public double Multiplicar(double a, double b)
    {
        UltimoResultado = a * b;
        return UltimoResultado;
    }

    public double Dividir(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("ERROR: No se puede dividir por cero.");
        }
        UltimoResultado = a / b;
        return UltimoResultado;
    }
}


class Program
{
    static void Main()
    {
        Calculadora calc = new Calculadora();

        Console.WriteLine("Ingrese una operación (Ej: 5 + 3):");
        string input = Console.ReadLine();

        string[] partes = input.Split(' ');

        if (partes.Length != 3 || !double.TryParse(partes[0], out double n1) || !double.TryParse(partes[2], out double n2))
        {
            Console.WriteLine("ERROR: Usa bien la calcualdora.");
            return;
        }

        char op = partes[1][0];

        try
        {
            double resultado = op switch
            {
                '+' => calc.Sumar(n1,n2),
                '-' => calc.Restar(n1,n2),
                '*' => calc.Multiplicar(n1,n2),
                '/' => calc.Dividir(n1,n2),
                _ => throw new ArgumentException("ERROR: Operador no válido.")
            };

            Console.WriteLine("Resultado: " + resultado);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}




