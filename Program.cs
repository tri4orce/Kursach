using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract;
using Models;
using Controllers;

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
            Console.WriteLine("Выберите тип арендатора (классы Cust или PhisCust)");
            var command = Console.ReadKey();
            var type = CustType.CUST;
            if (command.ToString() == "1") type = CustType.CUST;
            else if (command.ToString() == "2") type = CustType.PHIS_CUST;
            if (type == CustType.CUST) var Of new Ofice<Cust>() :  new Ofice<PhisCust>();
            
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

