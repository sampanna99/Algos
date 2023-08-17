using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class AllPairsShortestPath
    {
        public int[,] Matrix { get; set; }
        public Dictionary<string, int> EdgeValues { get; set; }
        public int LengthofVertex { get; set; }

        public AllPairsShortestPath()
        {
            Matrix = new int[4, 4];
            EdgeValues = new Dictionary<string, int>();
            LengthofVertex = 4;
        }

        public void Initialize()
        {
            EdgeValues.Add("12", 3);
            EdgeValues.Add("14", 7);
            EdgeValues.Add("21", 8);
            EdgeValues.Add("31", 5);
            EdgeValues.Add("41", 2);
            EdgeValues.Add("23", 2);
            EdgeValues.Add("34", 1);

        }

        public void CreateMatrix(int[,] Matrix)
        {
            for (int i = 0; i < LengthofVertex; i++)
            {
                for (int j = 0; j < LengthofVertex; j++)
                {
                    if (i == j)
                    {
                        Matrix[j, i] = 0;
                        continue;
                    }
                    var key = (j + 1).ToString() + (i + 1).ToString();
                    Matrix[j, i] = EdgeValues.ContainsKey(key) ? EdgeValues[key] : Int32.MaxValue;
                }
            }

            //foreach (var edgeValue in EdgeValues)
            //{
            //    var firstValue = Convert.ToInt32(edgeValue.Key[0]);
            //    var secondValue = Convert.ToInt32(edgeValue.Key[1]);

            //    Matrix[firstValue - 1, secondValue - 1] = edgeValue.Value;
            //}
        }

        public void StartWithThis()
        {
            Initialize();
            CreateMatrix(Matrix);
            AllPairsShortestPathFindMatrix(0);

            Console.WriteLine("Done");
        }
        public void AllPairsShortestPathFindMatrix(int whichToKeepConstant)
        {
            if (whichToKeepConstant >= LengthofVertex)
            {
                return;
            }
            for (int i = 0; i < LengthofVertex; i++)
            {
                if (i == whichToKeepConstant)
                {
                    continue;
                }
                for (int j = 0; j < LengthofVertex; j++)
                {
                    if (j == whichToKeepConstant)
                    {
                        continue;
                    }

                    if (j == i)
                    {
                        continue;
                    }

                    var axilary1 = Matrix[j, whichToKeepConstant];
                    var axilary2 = Matrix[whichToKeepConstant, i];

                    if (axilary1 != Int32.MaxValue && axilary2 != Int32.MaxValue)
                    {
                        var oldValue = Matrix[j, i];
                        var newvalue = axilary1 + axilary2;
                        if (oldValue > newvalue)
                        {
                            Matrix[j, i] = newvalue;
                        }
                    }
                }
            }
            
            //i++ won't work here as it returns value before it is incremented. has to be ++i
            AllPairsShortestPathFindMatrix(++whichToKeepConstant);
        }
    }
}
