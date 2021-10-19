using System;

namespace Abstract
{
    public interface IController
    {
        void Init();
        void Start();
        void Command(string command);
    }
}