using System;
using System.Threading;

class Program
{

    static long Exponent(int numBase, int numExponent)
    {
        if(numExponent == 0)
        {
            return 1;
        }
        else
        {
            return numBase * Exponent(numBase, numExponent - 1);
        }
    }

    static void Main()
    {
        Console.Write("");
        Console.WriteLine("----------------------");
        Console.Write("Introduce la base: ");
        int numBase = int.Parse(Console.ReadLine());

        int exponent;

        do
        {
            Console.Write("");
            Console.Write("Introduce el exponente: ");
            exponent = int.Parse(Console.ReadLine());
        }
        while (exponent < 0);

        Console.WriteLine("----------------------");
        for (int i = exponent; i >= 1; i--)
        {
            Console.WriteLine($"{numBase}^{i} = {Exponent(numBase, i)}");
        }

        Console.Write("");
        Console.WriteLine("----------------------");
        Console.WriteLine($"Resultado final: {numBase}^{exponent} = {Exponent(numBase, exponent)}");

    }

}