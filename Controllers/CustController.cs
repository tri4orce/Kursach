using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract;
using Models;
using test;

namespace Controllers
{
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
}