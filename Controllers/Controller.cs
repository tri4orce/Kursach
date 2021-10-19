using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract;
using Models;
using test;

namespace Controllers
{
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
}