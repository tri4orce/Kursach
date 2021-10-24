using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract;
using Models;
using Controllers;
using Commands;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 150;

            Invoker invoker = new Invoker();
            IStrategy _ofice = Initial();
            while (true) 
            {
                Console.WriteLine(@"1. Добавить арендатора 2. Вывести всех арендаторов");
                Console.WriteLine("e - выход из программы");
                var command = Console.ReadKey().KeyChar.ToString();
                Console.Clear();
                switch (command) 
                {
                    case "1":
                        invoker.SetOnStart(new AddCommand(_ofice));
                        invoker.Do();
                        break;
                    case "2":
                        invoker.SetOnStart(new PrintListCommand(_ofice));
                        invoker.Do();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Выход из программы");
                        return;
                }
            }
            
        }

        static IStrategy Initial() 
        {
            while (true) 
            {
                Console.WriteLine("Выберите тип арендатора: ");
                Console.WriteLine("1. Cust; 2. PhisCust");
                var command = Console.ReadKey().KeyChar.ToString();
                Console.Clear();

                if (command == "1")
                {
                    return new Ofice<Cust>();
                }
                else if (command == "2")
                {
                    return new Ofice<PhisCust>();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введена неверная комманда");
                }
            }
            
        }
    }
    class Invoker
    {
        private ICommand OnStart;

        public void SetOnStart(ICommand command)
        {
            this.OnStart = command;
        }

        public void Do()
        {
            if (this.OnStart is ICommand)
            {
                this.OnStart.Execute();
            }
        }
    }
}

