using System;
using System.Collections;

namespace Abstract
{
    public interface IStrategy
    {
        void Add(object obj);

        IEnumerable GetAll();
    }
}