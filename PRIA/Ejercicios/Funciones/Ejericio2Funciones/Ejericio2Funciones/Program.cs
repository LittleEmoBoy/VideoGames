
/*  Enunciado: Implementa dos funciones específicas:
void Intercambiar(ref double a, ref double b): Recibe dos variables de tipo real por referencia (ref) y permuta sus valores.
bool Dividir(int dividendo, int divisor, out int cociente, out int resto): Calcula la división entera. Pasa el cociente y el resto mediante parámetros de salida (out). La función debe devolver false si el divisor es 0 (evitando el fallo) y true si la operación fue exitosa.
En el Main: Prueba ambas funciones solicitando datos por teclado y mostrando los valores antes y después de cada llamada.
*/

using System;
using System.Threading;

class Program
{

    static void trade(ref double a, ref double b)
    {
        double temp = a;
        a = b;
        b = temp;
    }

    static bool divide(int divid, int divis, out int coc, out int rest)
    {
        coc = 0;
        rest = 0;
        if (divis == 0)
            return false;

        coc = divid / divis;
        rest = divid % divis;
        return true;
    }

   

    static void Main()
    {
        Console.Write("");
        Console.WriteLine("----------------------");
        Console.Write("Introduce el primer número : ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Introduce el segundo número : ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine($"Antes a era = {a}, y b = {b}");
        trade(ref a, ref b);
        Console.WriteLine($"Ahora a es = {a}, y b = {b}");

        Thread.Sleep(2000);

        Console.WriteLine("");
        Console.WriteLine("----------------------");
        Console.Write("Introduce el dividendo: ");
        int dividendo = int.Parse(Console.ReadLine());
        Console.Write("Introduce el divisor: ");
        int divisor = int.Parse(Console.ReadLine());

        int c, r;
        if (divide(dividendo, divisor, out c, out r))
            Console.WriteLine($"El cociente es {c}, y el resto es {r}");
        else
            Console.WriteLine("Error: no se puede dividir entre 0.");
    }





}