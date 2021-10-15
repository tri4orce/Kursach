using System;
using System.Linq;
using System.Threading.Tasks;
using Abstract;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller<string> = new Controller<string>().Start();
        }
    }

    

    public class Controller<T>: IController
    {
        private List<T> data;
        private Viewer viewer;
        void Init()
        {
            data = new List<T>();
            viewer = new Viewer();
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

        public Command(string command)
        {
            switch(command){
                case "MainMenu": 
                    MainMenuHand(Console.ReadLine());
                    break;
            }
        }

        private void MainMenuHand(string Command)
        {
            switch(command){
                case "1": 
                    Console.WriteLine("вы выбрали пункт 1");
                    break;
            }
        }
    }

    public class Viewer
    {
        private Controller controller;
        public void Init(Controller controller)
        {
            this.controller = controller;
            Console.WriteLine("Здравствуйте! Выберите команду из предложенных");
        }

        public void MainMenu()
        {
            Console.WriteLine("1. Добавить сотрудника, 2. Вывести всех сотрудников");
            Console.WriteLine("e - выход из программы");
            controller.Command("MainMenu");
        }
        public void ComandHand()
        {
            

        }
    }
}

namespace Abstract
{
    public interface IController
    {
        void Init();
        void Start();
    }
}