/* Diseña la función public static int Main(string[] args) para que funcione como una utilidad de consola que reciba 3 argumentos: un número, un operador (+, -, *, /) y otro número.
* Si el número de argumentos es diferente de 3, debe mostrar un mensaje de ayuda de uso y finalizar devolviendo el código de error 1.
* Si el operador no es válido o hay división por cero, debe mostrar el error correspondiente y devolver el código 2.
* Si la operación tiene éxito, muestra el resultado y devuelve 0.
*/

using System;
using System.Threading;

class Program
{
    // Muestra el mensaje y el código de salida (verde si es 0, rojo si es error)
    public static void showResult(string message, int code)
    {
        Console.ForegroundColor = (code == 0) ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(message);
        Console.WriteLine("----------------------");
        Console.WriteLine($"Código de salida: {code}");
        Console.ResetColor();
    }

    //Menú interactivo y de ayuda (meramente estético porque me gusta complicarme profesor)
    public static void showMenu()
    {
        Console.WriteLine("======================");
        Console.WriteLine("     CALCULADORA     ");
        Console.WriteLine("======================");
        Console.WriteLine("  [ + ]  Suma");
        Console.WriteLine("  [ - ]  Resta");
        Console.WriteLine("  [ * ]  Multiplicación");
        Console.WriteLine("  [ / ]  División");
        Console.WriteLine("  [ 0 ]  Salir");
        Console.WriteLine("======================");
    }

    // Devuelve true/false según el éxito; el resultado y el error
    public static bool calculate(double a, string op, double b, out double result, out string error)
    {
        result = 0;
        error = "";

        //Operandos (se podría hacer switch y case pero así es más sencillo)
        if (op == "+")
            result = a + b;
        else if (op == "-")
            result = a - b;
        else if (op == "*")
            result = a * b;
        else if (op == "/")
        {
            if (b == 0)
            {
                error = "Error: no se puede dividir entre 0.";
                return false;
            }
            result = a / b;
        }
        else
        {
            //Si metemos cualquier otro operando nos salta este error
            error = "Error: operador no válido.";
            return false;
        }

        return true;
    }

    public static int process(string[] parts)
    {

        //Si no hay 3 argumentos, mostramos la ayuda para que se vea el funcionamiento
        if (parts.Length != 3)
        {
            showResult("Uso incorrecto: número  + operador + número\n" +
                       "Ejemplo: 10 / 2 (separados por espacios)\n" +
                       "Operaciones válidas: + - * /", 1);
            return 1;
        }

        //Control de errores, por si mete una letra en vez de un número
        if (!double.TryParse(parts[0], out double num1) || !double.TryParse(parts[2], out double num2))
        {
            showResult("Error: los dos operandos deben ser números.", 2);
            return 2;
        }

        //Control de errores, operador no válido o división entre 0
        if (!calculate(num1, parts[1], num2, out double result, out string error))
        {
            showResult(error, 2);
            return 2;
        }

        //Todo es correcto e imprime el resultado
        showResult($"{num1} {parts[1]} {num2} = {result}", 0);
        return 0;
    }

    public static int Main(string[] args)
    {
        if (args.Length > 0)
            return process(args);

        Console.WriteLine("Formato para introducir operaciones: 10 / 2");

        while (true)
        {
            showMenu();
            Console.Write("Introduce la operación (0 para salir): ");
            string line = Console.ReadLine();

            if (line == null || line.Trim() == "0")
                break;

            Console.WriteLine("----------------------");

            //Trocea el texto que hemos metido y lo mete en un array
            //Despúes coge ese array y se lo pasa a process
            process(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Thread.Sleep(2000);
            Console.WriteLine();
        }

        Console.WriteLine("¡Cerrando calculadora.......!");
        return 0;
    }

}