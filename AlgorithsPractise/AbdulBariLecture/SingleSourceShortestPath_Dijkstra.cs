using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class SingleSourceShortestPath_Dijkstra
    {

        public Dictionary<string, int> EdgeValuesDictionary { get; set; }
        public Dictionary<string, HashSet<string>> AdjacencyListForVertex  { get; set; }

        public Dictionary<string, int> CostToReach { get; set; }
        public HashSet<string> UsedVertex { get; set; }
        public string ReachThisVertex { get; set; }
        public SingleSourceShortestPath_Dijkstra()
        {
            EdgeValuesDictionary = new Dictionary<string, int>();
            UsedVertex = new HashSet<string>();
            AdjacencyListForVertex = new Dictionary<string, HashSet<string>>();
            CostToReach = new Dictionary<string, int>();
        }


        public void Initialize()
        {
            ReachThisVertex = "F";
            EdgeValuesDictionary.Add("AB", 50);
            EdgeValuesDictionary.Add("BC", 10);

            //todo: directed
            EdgeValuesDictionary.Add("AD", 10);
            EdgeValuesDictionary.Add("DA", 10);
            //todo: directed

            EdgeValuesDictionary.Add("BD", 15);
            EdgeValuesDictionary.Add("EB", 20);
            EdgeValuesDictionary.Add("DE", 15);
            EdgeValuesDictionary.Add("FE", 3);

            //todo: directed
            EdgeValuesDictionary.Add("CE", 30);
            EdgeValuesDictionary.Add("EC", 35);
            //todo: directed

            EdgeValuesDictionary.Add("AC", 45);

            AdjacencyListForVertex.Add("A", new HashSet<string>{"B", "C", "D"});
            AdjacencyListForVertex.Add("B", new HashSet<string>{"C", "D"});
            AdjacencyListForVertex.Add("C", new HashSet<string>{"E"});
            AdjacencyListForVertex.Add("D", new HashSet<string>{"A", "E"});
            AdjacencyListForVertex.Add("E", new HashSet<string>{"B", "C"});
            AdjacencyListForVertex.Add("F", new HashSet<string>());
        }

        public void startWithThis(string startVertex = "A", int valueTostartWith = 0)
        {
            if (startVertex == "G" || startVertex == ReachThisVertex)
            {
                return;
            }
            UsedVertex.Add(startVertex);
            var connectedVertex = AdjacencyListForVertex[startVertex];

            foreach (var eachV in connectedVertex)
            {
                if (CostToReach.ContainsKey(eachV))
                {
                    var totalCostNew = valueTostartWith + EdgeValuesDictionary[startVertex + eachV];

                    if (totalCostNew < CostToReach[eachV])
                    {
                        CostToReach[eachV] = totalCostNew;
                    }
                }
                else
                {
                    CostToReach[eachV] = valueTostartWith + EdgeValuesDictionary[startVertex + eachV];
                }
            }

            KeyValuePair<string, int> forsmallest = new KeyValuePair<string, int>
            (
                "G",
                int.MaxValue
            );
            //maybe a min heap here.
            foreach (var kvp in CostToReach)
            {
                if (forsmallest.Value > kvp.Value && !UsedVertex.Contains(kvp.Key))
                {
                    forsmallest = kvp;
                }
            }

            startWithThis(forsmallest.Key, forsmallest.Value);
            
        }
    }


}
