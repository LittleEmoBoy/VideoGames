using System;
using System.Collections.Generic;
using System.Threading;

namespace Ejercicio4POO
{
    interface IAttackable
    {
        void Attack(Character target);
    }

    abstract class Character
    {
        public string Name;
        public int Health;

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        // Indica si el personaje sigue con vida
        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    class Warrior : Character, IAttackable
    {
        public Warrior(string name, int health) : base(name, health) { }

        public void Attack(Character target)
        {
            int damage = 15;
            Console.WriteLine($"{Name} golpea con su espada a {target.Name} (-{damage} vida)");
            target.TakeDamage(damage);
        }
    }

    class Mage : Character, IAttackable
    {
        public int Mana;

        public Mage(string name, int health, int mana) : base(name, health)
        {
            Mana = mana;
        }

        public void Attack(Character target)
        {
            int manaCost = 30;
            int damage = 35;

            if (Mana < manaCost)
            {
                Console.WriteLine($"{Name} no tiene maná suficiente para lanzar el hechizo");
                return;
            }

            Mana -= manaCost;
            Console.WriteLine($"{Name} lanza una bola de fuego a {target.Name} (-{damage} vida, maná restante: {Mana})");
            target.TakeDamage(damage);
        }
    }

    class Program
    {
        static void Main()
        {
            Warrior enemy = new Warrior("Sauron", 100);

            List<IAttackable> attackers = new List<IAttackable>();
            attackers.Add(new Warrior("Aragorn", 100));
            attackers.Add(new Mage("Gandalf", 80, 50));

            int round = 1;

            // Bucle para que continue, hasta que Sauron muera
            while (enemy.IsAlive())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"RONDA {round}");
                Console.WriteLine("----------------------");

                foreach (IAttackable attacker in attackers)
                {
                    attacker.Attack(enemy);

                    // Si muere a mitad de ronda, los Warrios dejan de atacar
                    if (!enemy.IsAlive())
                        break;
                }

                Console.WriteLine($"Vida de {enemy.Name}: {enemy.Health}");
                Console.WriteLine("");

                Thread.Sleep(2000);
                round++;
            }

            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine($"¡{enemy.Name} ha sido derrotado en la ronda {round - 1}!");
            Console.WriteLine("----------------------");
        }
    }
}