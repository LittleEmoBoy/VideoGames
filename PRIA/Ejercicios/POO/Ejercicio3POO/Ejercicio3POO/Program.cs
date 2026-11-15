using System;
using System.Collections.Generic;


namespace Ejercicio3POO
{

    //Clase Cliente
    class Client
    {
        public string Name;
        public string Email; 
        
        public Client(string name, string email)
        {
            Name = name;
            Email = email;

        }
    }

    //Clase LineaPedidos
    class OrderLine
    {
        public string Product;
        public int Amount;
        public decimal UnitPrice;


        public OrderLine (string product, int amount, decimal unitprice)
        {
            Product = product;
            Amount = amount;
            UnitPrice = unitprice;
        }

        //Metódo para calcular el subtotal
        public decimal CalculateSubtotal()
        {
            return Amount * UnitPrice;
        }
    }


    //Clase Pedido
    class Order
    {
        //El cliente ya está creado por lo que aquí solo lo instanciamos
        private Client client;

        //Aquí creamos la lista, al ser privado no se puede acceder desde ningún  otro lado
        private List<OrderLine> orders = new List<OrderLine>();

        //Constructor
        public Order(Client client)
        {
            this.client = client;
        }

        //Método para añadir los productoos a la lista
        public void AddProduct(string product, int amount, decimal unitprice)
        {
            orders.Add(new OrderLine(product, amount, unitprice));
        }

        //Método para calcular el total
        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (OrderLine order in orders)
                total += order.CalculateSubtotal();
            return total;
        }

        public void ShowInvoice()
        {
            Console.WriteLine("======================");
            Console.WriteLine("       FACTURA");
            Console.WriteLine("======================");
            Console.WriteLine($"Cliente: {client.Name}");
            Console.WriteLine($"Email:   {client.Email}");
            Console.WriteLine("----------------------");

            foreach (OrderLine linea in orders)
            {
                Console.WriteLine($"{linea.Product,-10} {linea.Amount} x {linea.UnitPrice:F2} = {linea.CalculateSubtotal():F2} €");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"TOTAL: {CalculateTotal():F2} €");
            Console.WriteLine("======================");
        }

    }

    class Program
    {
        static void Main()
        {
            Client client1 = new Client("Raúl","ragarzpe@gmail.com");

            Order order1 = new Order(client1);
            order1.AddProduct("Laptop", 1, 25.50m);
            order1.AddProduct("RJ45", 3, 12.99m);
            order1.ShowInvoice();

            Console.WriteLine();

            Order order2 = new Order(client1);
            order2.AddProduct("HDMI Cable", 1, 20.00m);
            order2.ShowInvoice();

            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine($"El cliente {client1.Name} sigue existiendo y es compartido por ambos pedidos.");
            Console.WriteLine("Las líneas de cada pedido, en cambio, pertenecen solo a su pedido.");
            Console.WriteLine("----------------------");
        }
    }


}
