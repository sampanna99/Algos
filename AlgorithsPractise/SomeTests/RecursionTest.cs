using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.SomeTests
{
    public class RecursionTest
    {
        public List<int> ReturnThis { get; set; }
        public int StartingInt { get; set; } = 5;
        public RecursionTest()
        {
            ReturnThis = new List<int>();
        }

        public void StartWithThis()
        {
            Recurs();
            Console.WriteLine("Completed");
        }
        public void Recurs()
        {
            if (StartingInt == 0)
            {
                return;
            }

            Console.WriteLine(StartingInt);
            StartingInt--;
            Recurs();
        }
    }
}
