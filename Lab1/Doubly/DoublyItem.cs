using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Doubly
{
    public class DoublyItem<T>
    {
        public T Data { get; set; }
        public DoublyItem<T> Previous { get; set; }
        public DoublyItem<T> Next { get; set; }

        public DoublyItem(T data)
        {
            Data = data;
        }
    }
}
