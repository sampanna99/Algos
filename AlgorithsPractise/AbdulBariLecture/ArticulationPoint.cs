using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class ArticulationPoint
    {
        public Dictionary<int, HashSet<int>> AdjacencyList { get; set; }
        public int[] DiscoveryArray { get; set; }
        public int[] LowestPointer { get; set; }
        public int[] Parent { get; set; }
        //public bool[] StackValues { get; set; }
        public int NumberOfVertex { get; set; } = 6;
        //public Stack<int> InTheStack { get; set; }
        public int Timer { get; set; } = 0;

        public ArticulationPoint()
        {
            AdjacencyList = new Dictionary<int, HashSet<int>>();
            DiscoveryArray = new int[NumberOfVertex];
            LowestPointer = new int[NumberOfVertex];
            Parent = new int[NumberOfVertex];
            //StackValues = new bool[NumberOfVertex];
            //InTheStack = new Stack<int>();
        }

        private void Initialize()
        {
            Array.Fill(DiscoveryArray, -1);
            Array.Fill(LowestPointer, -1);
            Array.Fill(Parent, -1);
            //Array.Fill(StackValues, false);

            AdjacencyList.Add(0, new HashSet<int> { 1, 2, 3 });
            AdjacencyList.Add(1, new HashSet<int> { 2, 0 });
            AdjacencyList.Add(2, new HashSet<int> { 1, 0});
            AdjacencyList.Add(3, new HashSet<int> { 4, 5, 0 });
            AdjacencyList.Add(4, new HashSet<int> { 3 });
            AdjacencyList.Add(5, new HashSet<int> { 3 });
        }

        public string GetAP()
        {
            Initialize();
            DFS(0, -1);
            return "OK";
        }

        private int DFS(int startNode, int parent)
        {
            DiscoveryArray[startNode] = Timer;
            LowestPointer[startNode] = Timer;
            var low = Timer;

            Timer = Timer + 1;
            var all = AdjacencyList[startNode];

            var childCount = 0;
            //look in video from 25 minute mark.
            var isAPNonRoot = false;

            foreach (var each in all)
            {
                if (each == parent)
                {
                    continue;
                }

                //if (DiscoveryArray[each] != -1)
                //{
                //    continue;
                //}

                //Parent[each] = startNode;

                if (DiscoveryArray[each] != -1)
                {
                    //may be check if it is back edge or cross edge (stack). Maybe cross edge doesn't apply here
                    if (DiscoveryArray[each] < low)
                    {
                        low = DiscoveryArray[each];
                    }
                }
                else
                {
                    Parent[each] = startNode;
                    childCount = childCount + 1;
                    var lowest = DFS(each, startNode);

                    if ((DiscoveryArray[startNode] < lowest) && !isAPNonRoot)
                    {
                        isAPNonRoot = true;
                    }

                    if (lowest < low)
                    {
                        low = lowest;
                    }
                }
            }

            //if (low == LowestPointer[startNode])
            //{
            //    doesBackedgeContain = true;
            //}

            if (parent == -1)
            {
                if (childCount > 1)
                {
                    Console.WriteLine("This is the AP " + startNode);
                }
            }
            else
            {
                if (isAPNonRoot)
                {
                    Console.WriteLine("This is the AP " + startNode);
                }
            }
            //else
            //{
            //    if (!doesBackedgeContain)
            //    {
            //        Console.WriteLine("This is the AP");
            //    }
            //}

            LowestPointer[startNode] = low;
            return low;
        }
        public void FindAP()
        {

        }

    }
}
