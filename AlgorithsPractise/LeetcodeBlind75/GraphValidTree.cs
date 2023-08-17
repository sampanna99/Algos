using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class Node
    {
        public int ValueOfNode { get; set; }
        public Node PrevNode { get; set; }
        public List<Node> ConnectValues { get; set; }

        public Node()
        {
            ConnectValues = new List<Node>();
        }
    }

    public class GraphValidTree
    {
        public Dictionary<int, HashSet<int>> AdjacencyList { get; set; }
        public int[][] ArrayOfEdges { get; set; }
        public HashSet<int> NodeValuesVisited { get; set; }
        public GraphValidTree()
        {
            AdjacencyList = new Dictionary<int, HashSet<int>>();
            NodeValuesVisited = new HashSet<int>();
            ArrayOfEdges = new int[][]
            {
                //new int[] { 0, 1 },
                //new int[] { 0, 2 },
                //new int[] { 0, 3 },
                //new int[] { 1, 4 }

                new int[] {0,1},
                new int[] {1,2},
                new int[] {2,3},
                new int[] {1,3},
                new int[] {1,4}
            };
        }

        public void InitiliazeComponent()
        {
            foreach (var arrayOfEdge in ArrayOfEdges)
            {


                if(AdjacencyList.ContainsKey(arrayOfEdge[0]))
                {
                    AdjacencyList[arrayOfEdge[0]].Add(arrayOfEdge[1]);
                }
                else
                {
                    AdjacencyList.Add(arrayOfEdge[0], new HashSet<int>{ arrayOfEdge[1] });

                }

                if(AdjacencyList.ContainsKey(arrayOfEdge[1]))
                {
                    AdjacencyList[arrayOfEdge[1]].Add(arrayOfEdge[0]);
                }
                else
                {
                    AdjacencyList.Add(arrayOfEdge[1], new HashSet<int>{ arrayOfEdge[0] });
                }
            }
        }

        public bool dfs(Node startwithThis)
        {

            //add the node to visited set
            if (NodeValuesVisited.Contains(startwithThis.ValueOfNode))
            {
                return false;
            }

            NodeValuesVisited.Add(startwithThis.ValueOfNode);
            var values = AdjacencyList[startwithThis.ValueOfNode];

            foreach (var value in values)
            {
                if (value == startwithThis.PrevNode?.ValueOfNode)
                {
                    continue;
                }

                var node = new Node
                {
                    PrevNode = startwithThis,
                    ValueOfNode = value
                };
                var valueReturned = dfs(node);

                if (valueReturned == false)
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidTree()
        {
            InitiliazeComponent();

            var startwith = AdjacencyList[0].First();
            return dfs(new Node { ValueOfNode = startwith, PrevNode = null });

            return true;
        }
    }
}
