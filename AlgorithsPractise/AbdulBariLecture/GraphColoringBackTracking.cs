using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class GraphColoringBackTracking
    {
        public Dictionary<int, HashSet<int>> AdjacencyList { get; set; }

        public List<int> Colors { get; set; }
        //public List<string> Colors { get; set; }
        public int NumberOfNodes { get; set; } = 4;

        public List<List<string>> Results { get; set; }
        public GraphColoringBackTracking()
        {
            AdjacencyList = new Dictionary<int, HashSet<int>>();
            Colors = new List<int>();
            Results = new List<List<string>>();
        }
        private void Initialize()
        {
            AdjacencyList.Add(1, new HashSet<int>{2, 4});
            AdjacencyList.Add(2, new HashSet<int>{1, 3});
            AdjacencyList.Add(3, new HashSet<int>{2, 4});
            AdjacencyList.Add(4, new HashSet<int>{1, 3});
            Colors.Add(1); // red
            Colors.Add(2); //green 
            Colors.Add(3); //blue
        }

        public void GraphColoringProblem()
        {
            Initialize();
            DFS(1, new Dictionary<int, int>());
        }
        private void DFS(int NodeNum, Dictionary<int, int> ColorNodeTaken)
        //private void DFS(int NodeNum, int ColorIndex, Dictionary<int, int> ColorNodeTaken)
        {
            if (NodeNum > NumberOfNodes)
            //if (NodeNum >= NumberOfNodes || ColorIndex >= Colors.Count)
            {
                return;
            }

            //var nodecolordict = new Dictionary<int, int>();
            var nodes = AdjacencyList[NodeNum];
            var listofColorsThatcannot = new List<int>();

            foreach (var node in nodes)
            {
                if (ColorNodeTaken.ContainsKey(node))
                {
                    listofColorsThatcannot.Add(ColorNodeTaken[node]);
                }
            }

            foreach (var color in Colors)
            {
                //find the neighbour node color.


                if (listofColorsThatcannot.Contains(color))
                {
                    continue;
                }
                ColorNodeTaken.Add(NodeNum, color);
                DFS(NodeNum + 1, ColorNodeTaken);
                //DFS(NodeNum + 1, ColorIndex + 1, ColorNodeTaken);
                if (NodeNum == NumberOfNodes)
                {
                    //
                    Console.WriteLine("This is start");
                    foreach (var i in ColorNodeTaken)
                    {
                        Console.WriteLine($"Node {i.Key} is with color number {i.Value}");
                    }
                    Console.WriteLine("This is end");
                }

                ColorNodeTaken.Remove(NodeNum);
            }

            //bounding functionality
        }

    }
}
