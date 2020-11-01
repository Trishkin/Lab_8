using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8.Interfaces
{
    interface IBookEnumerable<T> where T: class
    {
        public void Add(T data)
        {
            Console.WriteLine($"Вы должны передать значение");
        }
        public bool Remove(T data)
        {
            Console.WriteLine($"Вы должны передать значение");
            return false;
        }
        public void Info()
        { }
    }
        
}
