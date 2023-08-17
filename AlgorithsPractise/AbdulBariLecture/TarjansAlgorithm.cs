using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class TarjansAlgorithm
    {
        public Dictionary<int, HashSet<int>> AdjacencyList { get; set; }
        public int[] DiscoveryArray { get; set; }
        public int[] LowestPointer { get; set; }
        public bool[] StackValues { get; set; }
        public int NumberOfVertex { get; set; } = 7;
        public Stack<int> InTheStack { get; set; }
        public int Timer { get; set; } = 0;

        public TarjansAlgorithm()
        {
            AdjacencyList = new Dictionary<int, HashSet<int>>();
            DiscoveryArray = new int[NumberOfVertex];
            LowestPointer = new int[NumberOfVertex];
            StackValues = new bool[NumberOfVertex];
            InTheStack = new Stack<int>();
        }
        private void Initialize()
        {
            Array.Fill(DiscoveryArray, -1);
            Array.Fill(LowestPointer, -1);
            Array.Fill(StackValues, false);

            AdjacencyList.Add(0, new HashSet<int>{1});
            AdjacencyList.Add(1, new HashSet<int>{2, 3});
            AdjacencyList.Add(2, new HashSet<int>{});
            AdjacencyList.Add(3, new HashSet<int>{4});
            AdjacencyList.Add(4, new HashSet<int>{0, 5, 6});
            AdjacencyList.Add(5, new HashSet<int>{6, 2});
            AdjacencyList.Add(6, new HashSet<int>{5});
        }

        public int GetSCC()
        {
            Initialize();
            return DFS(0);
            return 0;
        }

        private int DFS(int node)
        {
            DiscoveryArray[node] = Timer;
            LowestPointer[node] = Timer;
            var lowestToReturn = Timer;

            Timer += 1;
            InTheStack.Push(node);
            StackValues[node] = true;
            var allList = AdjacencyList[node];

            if (allList.Count == 0)
            {
                StackValues[node] = false;


                if (DiscoveryArray[node] == LowestPointer[node])
                {
                    Console.WriteLine("This is SCC " + node);
                    var valuePopped = InTheStack.Pop(); 
                    Console.WriteLine("Value popped: " + valuePopped);
                    while (valuePopped != node)
                    {
                        valuePopped = InTheStack.Pop();
                        Console.WriteLine("Value popped: " + valuePopped);

                    }
                }
                else
                {
                    //InTheStack.Pop();
                }

                //if (DiscoveryArray[node] == LowestPointer[node])
                //{
                //    Console.WriteLine("This is SCC " + node);
                //}
                return LowestPointer[node];
            }

            foreach (var eachList in allList)
            {
                if (DiscoveryArray[eachList] != -1 && StackValues[eachList] == true)
                {
                    lowestToReturn = DiscoveryArray[eachList];
                }
                else if (DiscoveryArray[eachList] != -1)
                {
                    continue;
                }
                else
                {
                    //InTheStack.Push(eachList);
                    //StackValues[eachList] = true;
                    //DiscoveryArray[eachList] = Timer;
                    //LowestPointer[eachList] = Timer;
                    //Timer += 1;

                    var callDFS = DFS(eachList);
                    if (callDFS < lowestToReturn)
                    {
                        lowestToReturn = callDFS;
                    }
                }
            }

            StackValues[node] = false;
            LowestPointer[node] = lowestToReturn;

            if (DiscoveryArray[node] == LowestPointer[node])
            {
                Console.WriteLine("This is SCC " + node);
                var valuePopped = InTheStack.Pop();
                Console.WriteLine("Value popped: " + valuePopped);
                while (valuePopped != node)
                {
                    valuePopped = InTheStack.Pop();
                    Console.WriteLine("Value popped: " + valuePopped);

                }
            }
            else
            {
                //InTheStack.Pop();
            }

            return lowestToReturn;
        }
    }
}
