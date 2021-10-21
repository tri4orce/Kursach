using System;
using Models;
using Abstract;
using System.Collections;
using System.Collections.Generic;

namespace Controllers
{
    public class Ofice<T> : IStrategy
        where T : class
    {
        public CustType typeCust;
        List<T> listCust;

        public Ofice()
        {
            listCust = new List<T>();
        }

        public void Add(object obj)
        {
            listCust.Add(obj as T);
        }

        public IEnumerable GetAll()
        {
            return listCust;
        }
    }
}