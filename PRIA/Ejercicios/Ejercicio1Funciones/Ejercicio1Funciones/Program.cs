/*  Enunciado: Crea un programa que contenga dos funciones independientes:
    bool EsPrimo(int n): Recibe un entero positivo y devuelve true si es primo o false en caso contrario.
    int ContarPrimosEnRango(int inicio, int fin): Utiliza la función EsPrimo dentro de un bucle para contar y devolver cuántos números primos existen en un intervalo dado.

    En el Main: Solicita al usuario el inicio y fin de un rango (por ejemplo, entre 1 y 100) y muestra cuántos números primos existen en dicho intervalo.
*/


using System;

class Program
{
    static bool isPrime(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    //Método de Java pero aquí se le llama función
    static int countPrimeOnRange(int begin, int end)
    {
        int count = 0;
        for (int i = begin; i <= end; i++)
        {
            if (isPrime(i))
                count++;
        }
        return count;
    }

    static void Main()
    {
        Console.Write("");
        Console.WriteLine("----------------------");
        Console.Write("Introduce un número para el inicio del rango: ");
        int begin = int.Parse(Console.ReadLine());

        Console.Write("Introduce el número para el final del rango: ");
        int end = int.Parse(Console.ReadLine());

        int amount = countPrimeOnRange(begin, end);

        Console.Write("");
        Console.WriteLine("----------------------");
        Console.WriteLine($"\nEn el rango del [{begin}, al {end}] hay {amount} números primos." );
    }





}