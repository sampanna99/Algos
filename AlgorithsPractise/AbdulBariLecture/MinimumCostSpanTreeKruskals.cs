using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    //completed and tested. Works.
    public class MinimumCostSpanTreeKruskals
    {

        public int Vertexes { get; set; }
        public List<string> ResultsList { get; set; }
        public Dictionary<string, int> EdgeValuesDictionary { get; set; }
        public Dictionary<string, HashSet<string>> DictionaryWithParent { get; set; }
        public Dictionary<string, string> DictionaryToTrackParent { get; set; }

        public MinimumCostSpanTreeKruskals()
        {
            ResultsList = new List<string>();
            DictionaryWithParent = new Dictionary<string, HashSet<string>>();
            DictionaryToTrackParent =  new Dictionary<string, string>();
            EdgeValuesDictionary = new Dictionary<string, int>();
            Initialize();
        }
        public void Initialize()
        {
            EdgeValuesDictionary.Add("AD", 1);
            EdgeValuesDictionary.Add("BC", 1);
            EdgeValuesDictionary.Add("CD", 1);
            EdgeValuesDictionary.Add("EF", 2);
            EdgeValuesDictionary.Add("BD", 3);
            EdgeValuesDictionary.Add("AB", 3);
            EdgeValuesDictionary.Add("CF", 4);
            EdgeValuesDictionary.Add("CE", 5);
            EdgeValuesDictionary.Add("DE", 6);


            DictionaryToTrackParent.Add("A", "A");
            DictionaryToTrackParent.Add("B", "B");
            DictionaryToTrackParent.Add("C", "C");
            DictionaryToTrackParent.Add("D", "D");
            DictionaryToTrackParent.Add("E", "E");
            DictionaryToTrackParent.Add("F", "F");
        }

        public void StartWithThis()
        {
            foreach (var eachAscendingEdge in EdgeValuesDictionary)
            {
                //track parent

                var (firstacVertex, secondacVertex) = (eachAscendingEdge.Key[0].ToString(),
                eachAscendingEdge.Key[1].ToString());


                //needs a while here
                var (firstVertex, secondVertex) = (DictionaryToTrackParent[firstacVertex],
                    DictionaryToTrackParent[secondacVertex]);
                while (DictionaryToTrackParent[firstVertex] != firstVertex || 
                       DictionaryToTrackParent[secondVertex] != secondVertex)
                {
                    firstVertex = DictionaryToTrackParent[firstVertex];
                    secondVertex = DictionaryToTrackParent[secondVertex];

                    DictionaryToTrackParent[firstacVertex] = firstVertex;
                    DictionaryToTrackParent[secondacVertex] = secondVertex;
                }

                if (firstVertex == secondVertex)
                {
                    continue;
                }

                if (eachAscendingEdge.Key == "BD")
                {
                    Console.WriteLine("stop here");
                }

                var containFirstVertex = DictionaryWithParent.ContainsKey(firstVertex);
                var containSecondVertex = DictionaryWithParent.ContainsKey(secondVertex);

                if (containFirstVertex && containSecondVertex)
                {
                    var lengthofFirst = DictionaryWithParent[firstVertex].Count;
                    var lengthofSecond = DictionaryWithParent[secondVertex].Count;
                    if (lengthofFirst > lengthofSecond)
                    {
                        var hashsetofsecond = DictionaryWithParent[secondVertex];
                        DictionaryWithParent[firstVertex] = new HashSet<string>
                            (hashsetofsecond.Union(DictionaryWithParent[firstVertex]));
                        DictionaryWithParent.Remove(secondVertex);
                        DictionaryToTrackParent[secondVertex] = firstVertex;
                        //DictionaryToTrackParent[secondacVertex] = firstVertex;
                        //DictionaryWithParent[firstVertex] =
                        //    DictionaryWithParent[firstVertex].UnionWith(hashsetofsecond);

                        //DictionaryWithParent[firstVertex] = DictionaryWithParent[firstVertex].UnionWith();
                    }
                    else
                    {
                        var hashsetofsecond = DictionaryWithParent[firstVertex];
                        DictionaryWithParent[secondVertex] = new HashSet<string>
                            (hashsetofsecond.Union(DictionaryWithParent[secondVertex]));
                        DictionaryWithParent.Remove(firstVertex);

                        DictionaryToTrackParent[firstVertex] = secondVertex;
                        //DictionaryToTrackParent[firstacVertex] = secondVertex;
                    }
                }
                else if(containFirstVertex || containSecondVertex)
                {
                    //one of them
                    var (whichvertex, notwhichvertex) = containFirstVertex
                        ? (eachAscendingEdge.Key[0].ToString(), eachAscendingEdge.Key[1].ToString())
                        : (eachAscendingEdge.Key[1].ToString(), eachAscendingEdge.Key[0].ToString());

                    DictionaryWithParent[DictionaryToTrackParent[whichvertex]].Add(notwhichvertex);
                    //DictionaryWithParent[whichvertex].Add(notwhichvertex);

                    //DictionaryToTrackParent[firstacVertex] = secondVertex;

                    //DictionaryToTrackParent[DictionaryToTrackParent[notwhichvertex]] = 
                    //    DictionaryToTrackParent[whichvertex];

                    DictionaryToTrackParent[DictionaryToTrackParent[notwhichvertex]] = 
                        DictionaryToTrackParent[whichvertex];

                }
                else
                {
                    //no vertex. just add on anyone.
                    //DictionaryWithParent[firstVertex].Add(secondVertex);
                    DictionaryWithParent.Add(firstVertex, new HashSet<string>{secondVertex});
                    DictionaryToTrackParent[secondVertex] = firstVertex;
                    //DictionaryToTrackParent[secondacVertex] = firstacVertex;
                }
                ResultsList.Add(eachAscendingEdge.Key);
            }

            foreach (var VARIABLE in ResultsList)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
