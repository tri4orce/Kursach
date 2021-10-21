using System;
using Abstract;
using Controllers;
using Models;

namespace Commands
{
    class TestCommand : ICommand
    {
        private string _payload = string.Empty;
        public TestCommand(string payload)
        {
            _payload = payload;
        }
        public void Execute()
        {
            Console.WriteLine("Комманда выполнена " + _payload);
        }
    }

    class AddCommand : ICommand
    {
        private IStrategy ofice;
        public AddCommand(IStrategy ofice)
        {
            this.ofice = ofice;
        }

        void AddCust()
        {
            Cust p = new Cust();
            p.Name = "test";
            ofice.Add(p);
        }
        void AddPhisCust()
        {
            PhisCust p = new PhisCust()
            {
                Name = "test2"
            };
            //p.Name = "test2";
            ofice.Add(p);
        }
        public void Execute()
        {
            if (ofice.GetType() == typeof(Cust)) AddCust();
            else AddPhisCust();
        }
    }
}