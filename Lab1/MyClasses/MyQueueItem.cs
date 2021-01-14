using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MyClasses
{
    public class MyQueueItem<T>
    {
        public MyQueueItem(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public MyQueueItem<T> Next { get; set; }
    }
}
