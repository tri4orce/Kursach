using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract;
using Models;

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

    

    public abstract class Controller<T>: IController
        where T: class, new()
    {
        protected List<T> data;
        private Viewer viewer;

        public void Init()
        {
            data = new List<T>();
            viewer = new Viewer();
            viewer.Init(this);
        }

        public void Start()
        {
            if (data == null) Init();
            View("Init");
        }

        private void View(string comand)
        {
            switch(comand){
                case "Init": 
                    viewer.MainMenu();
                    break;
            }
        }

        public void Command(string command)
        {
            switch(command){
                case "MainMenu": 
                    MainMenuHand();
                    break;
            }
        }

        private void MainMenuHand()
        {
            var command = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            switch(command){
                case "1": 
                    Add();
                    viewer.MainMenu();
                    break;
                case "2":
                    GetAll();
                    viewer.MainMenu();
                    break;
                case "3":
                    PrintTable();
                    viewer.MainMenu();
                    break;
            }
        }

        protected virtual void Add()
        {
            data.Add(new T());
        }

        protected virtual void GetAll()
        {
            if (data != null)
            {
                foreach(var item in data)
                {
                    Console.WriteLine(item.ToString());    
                }
            }
            else Console.WriteLine("Список пуст!");
        }

        public abstract void PrintTable();
    }

    public class CustController<T> : Controller<T>
    where T : Cust, new()
    {
        protected override void Add()
        {
            uint result;

            Console.WriteLine("Введите ИНН арендатора: ");
            while(!uint.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Неверный формат ИНН...");
                Console.WriteLine("Введите ИНН арендатора: ");
            }
            var id = result;

            Console.WriteLine("Введите название арендатора: ");
            var name = Console.ReadLine();

            Console.WriteLine("Введите адресс арендатора: ");
            var address = Console.ReadLine();

            Console.WriteLine("Введите фамилию начальника: ");
            var chief = Console.ReadLine();

            Console.WriteLine("Введите номер кабинета начальника: ");
            while(!uint.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Неверный формат кабинета...");
                Console.WriteLine("Введите номер кабинета начальника: ");
            }
            var room = result;

            if (typeof(T).Name == "PhisCust")
            {
                Console.WriteLine("Введите паспорт арендатора: ");
                var passport = Console.ReadLine();

                Console.WriteLine("Введите снилс арендатора: ");
                var snils = Console.ReadLine();

                var a = new PhisCust(id, room, name, address, chief, passport, snils) as T;

                data.Add(a);
            }
            else 
            {
                data.Add(new Cust(id, room, name, address, chief) as T);
            }
            
            Console.Clear();
        }

        public override void PrintTable()
        {
            T columns = data.FirstOrDefault();
            string row = "";
            for (int i = 0; i < columns.ToColumn().Length; i++)
            {
                row += "*";
            }
            Console.WriteLine(row);
            Console.WriteLine(columns.ToColumn());
            Console.WriteLine(row);
            foreach(var item in data)
            {
                Console.WriteLine(item.ToRow());
                Console.WriteLine(row);
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

namespace Abstract
{
    public interface IController
    {
        void Init();
        void Start();
        void Command(string command);
    }
}