using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class MinimmumCostSpanTree
    {
        public int[,] Graph { get; set; }

        //public int[] testint { get; set; }
        public List<string> Vertexs { get; set; }
        public int NumbersInAHeap { get; set; }
        public HeapOfThisThing[] HeapOfVertexs { get; set; }
        public Dictionary<string, List<string>> ConnectedVertexs { get; set; }
        public Dictionary<string, int> MapVertexToIndex { get; set; }
        public Dictionary<string, string> VertexIntroducedByEdge { get; set; }

        public Dictionary<string, int> EdgeValuesDictionary { get; set; }
        public List<string> Results { get; set; }
        public MinimmumCostSpanTree()
        {
            //not used
            Graph = new int[,] { { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 } };

            Vertexs = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F"
            };
            HeapOfVertexs = new HeapOfThisThing[Vertexs.Count];
            MapVertexToIndex = new Dictionary<string, int>();
            ConnectedVertexs = new Dictionary<string, List<string>>();
            VertexIntroducedByEdge = new Dictionary<string, string>();
            EdgeValuesDictionary = new Dictionary<string, int>();
            Results = new List<string>();
            NumbersInAHeap = Vertexs.Count;
            Initialize();

            int[] aa = { 3, 4, 5, 9 }; //works


            //HeapOfVertexs = new HeapOfThisThing[] {new HeapOfThisThing
            //{
            //    VertexName = "s",
            //    Value = 1
            //}};
            //HeapOfVertexs = new [] {new HeapOfThisThing
            //{
            //    VertexName = "s",
            //    Value = 1
            //},
            //new HeapOfThisThing
            //{
            //    VertexName = "c",
            //    Value = 3
            //}
            //}
            //;

            //testint = {1, 2, 3, 5}; //no work as testint is decalred up

            //HeapOfVertexs = new HeapOfThisThing[Vertexs.Count];
            //HeapOfVertexs = new List<HeapOfThisThing>();
            //Graph = new int[5, 2]; //either dimensions or the actual values
        }

        public void Initialize()
        {
            for (int i = 0; i < Vertexs.Count; i++)
            {
                var heapOfVertex = new HeapOfThisThing
                {
                    VertexName = Vertexs[i]

                };
                HeapOfVertexs[i] = heapOfVertex;

            }

            ConnectedVertexs.Add("A", new List<string> { "B", "D" });
            ConnectedVertexs.Add("B", new List<string> { "A", "D" });
            ConnectedVertexs.Add("C", new List<string> { "B", "D", "E", "F" });
            ConnectedVertexs.Add("D", new List<string> { "A", "B", "C", "E" });
            ConnectedVertexs.Add("E", new List<string> { "D", "C", "F" });
            ConnectedVertexs.Add("F", new List<string> { "E", "C"});

            MapVertexToIndex.Add("A", 0);
            MapVertexToIndex.Add("B", 1);
            MapVertexToIndex.Add("C", 2);
            MapVertexToIndex.Add("D", 3);
            MapVertexToIndex.Add("E", 4);
            MapVertexToIndex.Add("F", 5);

            EdgeValuesDictionary.Add("AD", 1);
            EdgeValuesDictionary.Add("AB", 3);
            EdgeValuesDictionary.Add("BC", 1);
            EdgeValuesDictionary.Add("CD", 1);
            EdgeValuesDictionary.Add("DE", 6);
            EdgeValuesDictionary.Add("CE", 5);
            EdgeValuesDictionary.Add("CF", 4);
            EdgeValuesDictionary.Add("EF", 2);
            EdgeValuesDictionary.Add("BD", 3);
        }

        //todo:
        ///need kind of a hashmap/set to put the position of all because we need to
        /// add the edge value in heap plus map data structure and to find the exact position
        /// of the vertex we need to use hashset
        public void MakeHeapAsItIs()
        {
            var temp = HeapOfVertexs[0];
            MapVertexToIndex[temp.VertexName] = Int32.MaxValue;

            HeapOfVertexs[0] = HeapOfVertexs[NumbersInAHeap - 1];
            MapVertexToIndex[HeapOfVertexs[NumbersInAHeap - 1].VertexName] = 0;
            HeapOfVertexs[NumbersInAHeap - 1] = null; //may not need this but let's keep it
            NumbersInAHeap--;

            //now check with it's children
            //2i + 1, 2i + 2, (i - 1 / 2)
            var exitIfBiggerThan = 0;
            while (exitIfBiggerThan < NumbersInAHeap - 1)
            {
                if (2 * exitIfBiggerThan + 1 > NumbersInAHeap - 1)
                {
                    exitIfBiggerThan = NumbersInAHeap;
                    continue;
                }

                var leftchildAt = 2 * exitIfBiggerThan + 1;
                var rightchildAt = 2 * exitIfBiggerThan + 2;

                if (rightchildAt < NumbersInAHeap)
                {
                    //check with both of them
                    var lowestBetweenThem = HeapOfVertexs[leftchildAt].Value < HeapOfVertexs[rightchildAt].Value
                        ? HeapOfVertexs[leftchildAt]
                        : HeapOfVertexs[rightchildAt];
                    var whichisLowest = HeapOfVertexs[leftchildAt].Value < HeapOfVertexs[rightchildAt].Value
                        ? leftchildAt
                        : rightchildAt;

                    if (HeapOfVertexs[exitIfBiggerThan].Value < lowestBetweenThem.Value)
                    {
                        //great
                        break;
                    }
                    else
                    {
                        var temp1 = MapVertexToIndex[HeapOfVertexs[whichisLowest].VertexName];
                        MapVertexToIndex[HeapOfVertexs[whichisLowest].VertexName] =
                            MapVertexToIndex[HeapOfVertexs[exitIfBiggerThan].VertexName];
                        MapVertexToIndex[HeapOfVertexs[exitIfBiggerThan].VertexName] = temp1;
                        //(MapVertexToIndex[HeapOfVertexs[whichisLowest].VertexName], MapVertexToIndex[HeapOfVertexs[exitIfBiggerThan].VertexName]) = (MapVertexToIndex[HeapOfVertexs[exitIfBiggerThan].VertexName], MapVertexToIndex[HeapOfVertexs[whichisLowest].VertexName]);


                        (HeapOfVertexs[exitIfBiggerThan], HeapOfVertexs[whichisLowest]) = (lowestBetweenThem, HeapOfVertexs[exitIfBiggerThan]);

                        exitIfBiggerThan = whichisLowest;
                        //https://stackoverflow.com/questions/63027597/swap-two-numbers-without-using-temp-variable
                        //exactly like above
                        //var temp = HeapOfVertexs[exitIfBiggerThan];
                        //HeapOfVertexs[exitIfBiggerThan] = lowestBetweenThem;
                        //lowestBetweenThem = temp;
                    }
                }
                else
                {
                    //check with just the left one. And maybe break afterwards
                    if (HeapOfVertexs[leftchildAt].Value < HeapOfVertexs[exitIfBiggerThan].Value)
                    {
                        //now do the swap and break
                        var temp1 = MapVertexToIndex[HeapOfVertexs[leftchildAt].VertexName];
                        MapVertexToIndex[HeapOfVertexs[leftchildAt].VertexName] =
                            MapVertexToIndex[HeapOfVertexs[exitIfBiggerThan].VertexName];
                        MapVertexToIndex[HeapOfVertexs[exitIfBiggerThan].VertexName] = temp1;

                        (HeapOfVertexs[exitIfBiggerThan], HeapOfVertexs[leftchildAt]) = (HeapOfVertexs[leftchildAt], HeapOfVertexs[exitIfBiggerThan]);

                        //var temp = HeapOfVertexs[exitIfBiggerThan];
                        //HeapOfVertexs[exitIfBiggerThan] = HeapOfVertexs[leftchildAt];
                        //HeapOfVertexs[leftchildAt] = temp;

                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        public void StartWEithThis()
        {
            if (NumbersInAHeap == 0)
            {
                return;
            }
            var startwithThisNode = HeapOfVertexs[0];
            if (VertexIntroducedByEdge.Count != 0)
            {
                Results.Add(VertexIntroducedByEdge[startwithThisNode.VertexName]);
                Console.WriteLine(startwithThisNode.VertexName);
            }
            printMST(startwithThisNode);
            StartWEithThis();
        }
        public void printMST(HeapOfThisThing startwithThisNode)
        {

            //take the first of out of the heap which is an array
            //kind of like taking it out
            //var startwithThisNode = HeapOfVertexs[0];


            var allconnected = ConnectedVertexs[startwithThisNode.VertexName];
            var queue = new Queue<string>();
            foreach (var eachconnected in allconnected)
            {
                queue.Enqueue(eachconnected);
            }

            MakeHeapAsItIs();
            while (queue.Count > 0)
            {
                var dequed = queue.Dequeue();

                if (MapVertexToIndex[dequed] > Vertexs.Count - 1)
                {
                    continue;
                }

                var getIndexOfDeque = MapVertexToIndex[dequed];
                var getVertexHeapOfDequed = HeapOfVertexs[getIndexOfDeque];
                var actualvalueOfVertex = getVertexHeapOfDequed.Value;

                var first = startwithThisNode.VertexName + dequed;
                var secondValue = dequed + startwithThisNode.VertexName;
                var edgeValue = EdgeValuesDictionary.ContainsKey(first);
                var edgeValue2 = EdgeValuesDictionary.ContainsKey(secondValue);
                var value = edgeValue ? EdgeValuesDictionary[first] : EdgeValuesDictionary[secondValue];

                if (value < actualvalueOfVertex)
                {
                    //Now add it to the dictionary. Also I think could be first or second any
                    VertexIntroducedByEdge.Add(dequed, first);

                    //Now value of heap is change so update the heap structure.
                    UpdateHeap(dequed, value);

                }
            }

        }
        public void UpdateHeap(string whichvertextIsUpdated, int updatedToValue)
        {
            var findTheIndexWhereVertexIs = MapVertexToIndex[whichvertextIsUpdated];
            HeapOfVertexs[findTheIndexWhereVertexIs].Value = updatedToValue;

            var parent = (findTheIndexWhereVertexIs - 1) / 2;
            var parentValue = HeapOfVertexs[parent];

            var (child1, child2) = (findTheIndexWhereVertexIs + 1, findTheIndexWhereVertexIs + 2);
            //check if it is smaller or equal than child && larger and equal than parent.
            var (child1Value, child2Value) = (HeapOfVertexs[child1], HeapOfVertexs[child2]);
            if (updatedToValue > child1 && updatedToValue > child2)
            {
                //then move down
                while (updatedToValue > child1Value.Value && updatedToValue > child2Value.Value)
                {
                    //now update the index map and heap and map
                    var indexToReplaceWith = child1 < child2 ? child1 : child2;
                    UpdateIndexAndHeapAndMap(whichvertextIsUpdated, indexToReplaceWith);
                    (child1, child2) = (child1 + 1, child2 + 2);
                    (child1Value, child2Value) = (HeapOfVertexs[child1], HeapOfVertexs[child2]);
                }
            }else if (updatedToValue < parentValue.Value)
            {
                //then move up.
                while (updatedToValue < parentValue.Value)
                {
                    UpdateIndexAndHeapAndMap(whichvertextIsUpdated, parent);
                    if (parent == 0)
                    {
                        break;
                    }
                    parent = parent / 2;
                    parentValue = HeapOfVertexs[parent];
                }
            }

            //Now check if heap is destructured.

        }

        private void UpdateIndexAndHeapAndMap(string whichvertextIsUpdated, int indexToreplaceWith)
        {
            var findTheindexofThevertexBeingReplaced = MapVertexToIndex[whichvertextIsUpdated];
            var vertexBeingReplaced = HeapOfVertexs[indexToreplaceWith].VertexName;

            //update heap and map
            var temp = HeapOfVertexs[indexToreplaceWith];
            HeapOfVertexs[indexToreplaceWith] = HeapOfVertexs[findTheindexofThevertexBeingReplaced];
            HeapOfVertexs[findTheindexofThevertexBeingReplaced] = temp;

            //update index to vertex
            var temp2 = MapVertexToIndex[whichvertextIsUpdated];
            MapVertexToIndex[whichvertextIsUpdated] = indexToreplaceWith;
            MapVertexToIndex[vertexBeingReplaced] = temp2;
        }

    }
    public class EdgeAndWeight
    {
        public string EdgeStartAndEnd { get; set; }
        public int Weight { get; set; }

    }

    public class HeapOfThisThing
    {
        public string VertexName { get; set; }

        public int Value { get; set; } = Int32.MaxValue;
        //public int Value { get; set; } = -1;

    }

}
