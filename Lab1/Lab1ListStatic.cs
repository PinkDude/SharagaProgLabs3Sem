using Lab1.MyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Lab1ListStatic : Lab1List
    {
        /// <summary>
        /// Инициализация листа
        /// </summary>
        /// <returns></returns>
        protected override MyList<int> InitList()
        {
            var list = new MyListStatic<int>((int)ValueCount);

            for (var i = 0; i < ValueCount; i++)
                list.Add(RandomValue());

            return list;
        }
    }
}
