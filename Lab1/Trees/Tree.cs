using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Trees
{
    public class Tree
    {
        public int Number { get; set; }

        public int Level { get; set; }

        public Tree Left { get; set; }

        public Tree Right { get; set; }

        public Tree()
        {
            SetRandomNumber();

            Level = 0;
        }

        public Tree(int level)
        {
            const int OneLevelDown = -1;

            Number = SetRandomNumber();

            Level = level;

            if (level > 0)
            {
                Left = new Tree(level + OneLevelDown);

                Right = new Tree(level + OneLevelDown);
            }
        }

        private int SetRandomNumber()
        {
            var rnd = new Random();

            return rnd.Next(0, 100);
        }
    }
}
