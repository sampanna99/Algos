 using System;
using System.Collections.Generic;
 using System.Security.Cryptography.X509Certificates;
 using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class OptimalBinarySearchTree
    {
        public List<Tuple<string, double>> KeyAndProbability { get; set; }

        public double[,] Probabilitymatrix { get; set; }

        public Node Root { get; set; }

        //this is root index
        public int[,] ProbabilitymatrixRootTable { get; set; }
        public int Number { get; set; }
        public OptimalBinarySearchTree()
        {
            KeyAndProbability = new List<Tuple<string, double>>();
            //ProbabilitymatrixRootTable = new List<Tuple<string, double>>();
            Initialize();
        }

        private void Initialize()
        {
            KeyAndProbability.Add(new Tuple<string, double>("A", 0.213));
            KeyAndProbability.Add(new Tuple<string, double>("B", 0.020));
            KeyAndProbability.Add(new Tuple<string, double>("C", 0.547));
            KeyAndProbability.Add(new Tuple<string, double>("D", 0.100));
            KeyAndProbability.Add(new Tuple<string, double>("E", 0.120));
            Number = KeyAndProbability.Count;

            Probabilitymatrix = new Double[Number + 1, Number + 1];
            ProbabilitymatrixRootTable = new int[Number + 1, Number + 1];

            for (int i = 0; i < Probabilitymatrix.GetLength(1); i++)
            {

                Probabilitymatrix[i, i] = 0;
                if (i == Probabilitymatrix.GetLength(1) - 1)
                {
                    continue;
                }
                Probabilitymatrix[i, i + 1] = KeyAndProbability[i].Item2;
                ProbabilitymatrixRootTable[i, i + 1] = i + 1;
                //ProbabilitymatrixRootTable[i, i + 1] = i;


                //for (int j = 1; j <= Probabilitymatrix.GetLength(0); j++)
                //{
                //    if (i - j == -1)
                //    {
                //        Probabilitymatrix[j, i] = 0;
                //    }else if (i - j == 0)
                //    {
                //        Probabilitymatrix[j, i] = KeyAndProbability[j - 1].Item2;
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //}
            }
        }

        ///I complicated myself by making row index 0 as first and column index 0 as null
        /// also it's the probability not the value or else it won't be a BST
        /// I changed the value of matrix to denote the number rather than index as 0 meaning was arbitary
        /// as it could mean nothing or thje first index
        private Node ConstructBinarySearchTree(int startnumber = 1, int number = 5)
        {

            var findTheValue = ProbabilitymatrixRootTable[startnumber - 1, number];
            if (findTheValue == 0)
            {
                return null;
            }


            var Node = new Node
            {
                Value = findTheValue
            };


            //if (findTheValue == startnumber)
            //{
            //    return Node;
            //}

            //if (findTheValue == number)
            //{
            //    return Node;
            //}


            Node.LeftSubtree = ConstructBinarySearchTree(startnumber, findTheValue - 1);
            Node.RightSubtree = ConstructBinarySearchTree(findTheValue + 1, number);

            return Node;

        }

        public void FillTheCostMatrix()
        {
            
            for (int i = 1; i < Number; i++)
            {
                for (int j = i + 1; j <= Number; j++)
                //for (int j = 2; j <= Number; j++)
                {
                    //find
                    var startindex = j - (i + 1);
                    var minimum = FindMinimum(startindex, j);
                    Probabilitymatrix[startindex, j] = minimum;

                }
            }

            Console.WriteLine(Probabilitymatrix[Number,Number]);
            Root = ConstructBinarySearchTree();

            Console.WriteLine(Root.Value);
        }

        private double FindMinimum(int startIndex, int endIndex)
        {
            //startIndex = startIndex + 1;
            if (endIndex <= startIndex)
            {
                return 0;
            }

            var initializedValue = Double.MaxValue;
            //for (int i = startIndex; i < endIndex; i++)
            ////for (int i = startIndex; i < endIndex - 1; i++)
            //{
            //    double addedValue = 0;
            //    if (i - 1 >= 0)
            //    {
            //        addedValue = Probabilitymatrix[startIndex, i - 1];
            //    }
            //    var value = addedValue + Probabilitymatrix[i + 1, endIndex];
            //    if (value < initializedValue)
            //    {
            //        initializedValue = value;
            //    }
            //}

            //second time
            for (int i = startIndex; i < endIndex; i++)
            {
                var iforrow = i;
                var lvalueForcolumn = i + 1;
                var value = Probabilitymatrix[startIndex, i] +
                            Probabilitymatrix[i + 1, endIndex];
                //var value = Probabilitymatrix[startIndex, lvalueForcolumn - 1] +
                //            Probabilitymatrix[i + 1, endIndex];

                if (value < initializedValue)
                {
                    ProbabilitymatrixRootTable[startIndex, endIndex] = i + 1;
                    initializedValue = value;
                }
            }

            double summationOfFirstToLast = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                //var character = ((char)(i + 65)).ToString();
                summationOfFirstToLast = summationOfFirstToLast + KeyAndProbability[i].Item2;
            }
            return initializedValue + summationOfFirstToLast;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node RightSubtree { get; set; }
        public Node LeftSubtree { get; set; }
    }
}
