using System;
using System.Collections.Generic;
using System.Text;
using Abstract;
using Controllers;
using Models;

namespace Commands
{
    class PrintListCommand : ICommand
    {
        private IStrategy ofice;
        public PrintListCommand(IStrategy ofice) 
        {
            this.ofice = ofice;
        }
        void PrintCust() 
        {
            foreach (Cust item in ofice.GetAll())
            {
                string value = $@"Инн: {item.Id}, имя: {item.Name}, адрес: {item.Address}, кабинет: {item.Room}, директор: {item.Chief}, этаж: {item.GetFloor}";
                Console.WriteLine(value);
            }
        }
        void PrintPhisCust() 
        {
            foreach(PhisCust item in ofice.GetAll()) 
            {
                string value = $@"Инн: {item.Id}, имя: {item.Name}, паспорт: {item.Passport}, снилс: {item.Snils}, адрес: {item.Address}, кабинет: {item.Room}, директор: {item.Chief}, этаж: {item.GetFloor}";
                Console.WriteLine(value);
            }
        }
        public void Execute()
        {
            var type = ofice.GetType().GetGenericArguments()[0];

            if (ofice.GetCount() > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (type == typeof(PhisCust)) PrintPhisCust();
                if (type == typeof(Cust)) PrintCust();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Список пуст");
                Console.ResetColor();
            }
        }

    }

    class AddCommand : ICommand
    {
        private IStrategy ofice;
        public AddCommand(IStrategy ofice)
        {
            this.ofice = ofice;
        }

        string input()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var str = Console.ReadLine();
            Console.ResetColor();
            return str;
        }

        void Add()
        {
            Console.Write("Введите инн: ");
            var id = Convert.ToUInt32(input());
            Console.Write("Введите имя: ");
            var name = input();
            Console.Write("Введите адресс: ");
            var address = input();
            Console.Write("Введите номер кабинета: ");
            var room = Convert.ToUInt32(input());
            Console.Write("Введите имя директора: ");
            var chief = input();
            
            if (ofice.GetType().GetGenericArguments()[0] == typeof(PhisCust))
            {
                Console.Write("Введите паспорт: ");
                var passport = input();
                Console.Write("Введите снилс: ");
                var snils = input();
                PhisCust cust = new PhisCust(id, room, name, address, chief, passport, snils);
                ofice.Add(cust);
            }
            else 
            {
                Cust cust = new Cust(id, room, name, address, chief);
                ofice.Add(cust);
            }
            Console.Clear();
        }
        public void Execute()
        {
            Add();
        }
    }
}