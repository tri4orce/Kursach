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
            //Указать Cust для 6 задания/PhisCust для 7го задания 
            //CustController<PhisCust> contr = new CustController<PhisCust>();
            //contr.Start();
            Invoker invoker = new Invoker();
            Console.WriteLine("Выберите тип арендатора (классы Cust или PhisCust)");
            //var command = Console.ReadKey();
            Ofice<Cust> _ofice = new Ofice<Cust>();
            invoker.SetOnStart(new AddCommand(_ofice));
            invoker.Do();
            Console.WriteLine(_ofice.GetAll())
            //var type = CustType.CUST;
            //if (command.ToString() == "1") type = CustType.CUST;
            //else if (command.ToString() == "2") type = CustType.PHIS_CUST;
            
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
    public class Viewer
    {
        private IController controller;
        public void Init(IController controller)
        {
            this.controller = controller;
            Console.WriteLine("Здравствуйте! Выберите команду из предложенных");
        }

        public void MainMenu()
        {
            Console.WriteLine("1. Добавить арендатора 2. Вывести всех арендаторов списком 3. Вывести всех арендаторов таблицей");
            Console.WriteLine("e - выход из программы");
            controller.Command("MainMenu");
        }
    }
}

