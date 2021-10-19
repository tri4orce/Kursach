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
            CustController<PhisCust> contr = new CustController<PhisCust>();
            contr.Start();
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

