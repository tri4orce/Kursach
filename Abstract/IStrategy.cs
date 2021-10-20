using System;

namespace Abstract
{
    public interface IStrategy
    {
        void Add();

        IEnumerable GetAll();
    }
}