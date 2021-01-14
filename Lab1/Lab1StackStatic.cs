using Lab1.MyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Lab1StackStatic : Lab1Stack
    {
        /// <summary>
        /// Инициализация стека
        /// </summary>
        /// <returns></returns>
        protected override MyStack<int> InitStack()
        {
            var stack = new MyStackStatic<int>((int)ValueCount);

            for (var i = 0; i < ValueCount; i++)
                stack.Push(RandomValue());

            return stack;
        }
    }
}
