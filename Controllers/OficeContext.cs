using System;
using Abstract;
using Models;

namespace Controllers
{
    public class OficeContext
    {
        private IStrategy _ofice;

        public IStrategy Ofice { get; }

        public OficeContext(CustType TypeCust)
        {
            //_ofice = new Ofice<TypeCust>();
        }
    }
}