using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            MostrarMenu();

            try
            {
                int opcion = ObtenerOpcion();

                if (opcion == 5)
                {
                    Console.WriteLine("Saliendo... Good bye");
                    break;
                }

                decimal numero1 = ObtenerNumero("Por favor, ingrese el primer número:");
                decimal numero2 = ObtenerNumero("Por favor, ingrese el segundo número:");

                decimal resultado = RealizarOperacion(opcion, numero1, numero2);
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Seleccione una operación:");
        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Resta");
        Console.WriteLine("3. Multiplicación");
        Console.WriteLine("4. División");
        Console.WriteLine("5. Salir");
        Console.WriteLine("------------------------------------------------------------");
    }

    static int ObtenerOpcion()
    {
        if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 5)
        {
            throw new ArgumentException("Opción no válida. Debe ser un número entre 1 y 5.");
        }
        return opcion;
    }

    static decimal ObtenerNumero(string mensaje)
    {
        Console.WriteLine(mensaje);
        if (!decimal.TryParse(Console.ReadLine(), out decimal numero))
        {
            throw new ArgumentException("Entrada no válida. Debe ingresar un número.");
        }
        return numero;
    }

    static decimal RealizarOperacion(int opcion, decimal numero1, decimal numero2)
    {
        return opcion switch
        {
            1 => numero1 + numero2,
            2 => numero1 - numero2,
            3 => numero1 * numero2,
            4 => Dividir(numero1, numero2),
            _ => throw new InvalidOperationException("Operación no válida.")
        };
    }

    static decimal Dividir(decimal numero1, decimal numero2)
    {
        if (numero2 == 0)
        {
            throw new DivideByZeroException("No se puede dividir por cero.");
        }
        return numero1 / numero2;
    }
}