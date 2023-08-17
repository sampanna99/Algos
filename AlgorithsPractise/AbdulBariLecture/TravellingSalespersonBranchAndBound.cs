using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{

    //Haven't called and tested. Least cost branch and bound
    public  class TravellingSalespersonBranchAndBound
    {
        public int[,] matrixToDoThings { get; set; }
        public int NumberOfvertex { get; set; } = 5;
        public int InitialReductionCost { get; set; }
        public int Upper { get; set; } = Int32.MaxValue;
        public List<NodeForTSBB> NodeForTsbbs { get; set; }

        public TravellingSalespersonBranchAndBound()
        {
            matrixToDoThings = new int[,]
            {
                { Int32.MaxValue, 20,30,10,11},
                { 15, Int32.MaxValue, 16,4,2 },
                { 3,5, Int32.MaxValue,2,4 },
                { 19,6,18, Int32.MaxValue, 3 },
                { 16,4,7,16, Int32.MaxValue }
            };
            NodeForTsbbs = new List<NodeForTSBB>();
            Initialize();
        }

        private void Initialize()
        {
            var redCost1 = ChangeTheMatrix(true, matrixToDoThings);
            var redCost2 = ChangeTheMatrix(false, matrixToDoThings);
            InitialReductionCost = redCost1 + redCost2;

            //start is 1 i.e. index  = 0;
            for (int i = 1; i < NumberOfvertex; i++)
            {
                var node = new NodeForTSBB();
                node.StartVertex = 0;
                node.EndVertex = i;
                node.AllVertex = new List<int> { 0, i };
                var matrixCopy = (int[,])matrixToDoThings
                    .Clone();
                MakeMatrixLargestInt(matrixCopy, 0, node.EndVertex);
                var reductionCostRow = ChangeTheMatrix(true, matrixCopy);
                var reductionCostColumn = ChangeTheMatrix(false, matrixCopy);
                node.Cost = InitialReductionCost + reductionCostRow + reductionCostColumn + matrixToDoThings[0,i];
                NodeForTsbbs.Add(node);
            }
        }

        private void MakeMatrixLargestInt(int [,] matrix, int row, int column)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[row,i] = Int32.MaxValue;
                matrix[i, column] = Int32.MaxValue;
            }
            matrix[column, row] = Int32.MaxValue;
        }

        private NodeForTSBB GetTheleaseCostOne(int startToNull = 0, int endToNull = 0)
        {
            NodeForTSBB returnThis;
            returnThis = null;

            for (int i = 0; i < NodeForTsbbs.Count; i++)
            {
                var nodeForTsbb = NodeForTsbbs[i];
                if (nodeForTsbb == null)
                {
                    continue;
                }
                else if (nodeForTsbb.Cost > Upper)
                {
                    NodeForTsbbs[i] = null;
                    continue;
                }
                else
                {
                    if (returnThis == null)
                    {
                        returnThis = NodeForTsbbs[i];
                    }
                    else
                    {
                        if (startToNull == nodeForTsbb.StartVertex &&
                            endToNull == nodeForTsbb.EndVertex)
                        {
                            NodeForTsbbs[i] = null;
                        }
                        else if (nodeForTsbb.Cost < returnThis.Cost)
                        {
                            returnThis = NodeForTsbbs[i];
                        }
                    }
                }
            }

            //foreach (var nodeForTsbb in NodeForTsbbs)
            //{
            //    if (nodeForTsbb == null)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        if (returnThis == null)
            //        {
            //            returnThis = nodeForTsbb;
            //        }
            //        else
            //        {
            //            if (startToNull == nodeForTsbb.StartVertex &&
            //                endToNull == nodeForTsbb.EndVertex)
            //            {
            //                nodeForTsbb = null;
            //            }
            //            if (nodeForTsbb.Cost < returnThis.Cost)
            //            {
            //                returnThis = nodeForTsbb;
            //            }
            //        }
            //    }
            //}

            return returnThis;
        }
        private int ChangeTheMatrix(bool isRow, int[,] matrixToDoThingsTO)
        {
            var first = 0;
            var second = 1;
            if (!isRow)
            {
                first = 1;
                second = 0;

            }

            var reductionCost = 0;

            for (int i = 0; i < matrixToDoThingsTO.GetLength(first); i++)
            {
                var gottaChangeIt = true;
                var minValue = Int32.MaxValue;
                for (int j = 0; j < matrixToDoThingsTO.GetLength(second); j++)
                {
                    var adjValue = isRow ? matrixToDoThingsTO[i, j] : matrixToDoThingsTO[j, i];
                    if (adjValue == Int32.MaxValue)
                    {
                        continue;
                    }
                    if (adjValue == 0)
                    {
                        gottaChangeIt = false;
                        break;
                    }
                    else
                    {
                        if (minValue > adjValue)
                        {
                            minValue = adjValue;
                        }
                    }
                }

                if (gottaChangeIt)
                {
                    for (int j = 0; j < matrixToDoThingsTO.GetLength(second); j++)
                    {
                        var adjValue = isRow ? matrixToDoThingsTO[i, j] : matrixToDoThingsTO[j, i];
                        if (adjValue == Int32.MaxValue)
                        {
                            continue;
                        }
                        else
                        {
                            reductionCost += minValue;
                            if (isRow)
                            {
                                matrixToDoThingsTO[i, j] -= minValue;

                            }
                            else
                            {
                                matrixToDoThingsTO[j, i] -= minValue;

                            }
                        }
                    }
                }
            }

            return reductionCost;
        }
        public void TSBranchAndBound()
        {
            var theLeastCostOne = GetTheleaseCostOne();


            while (theLeastCostOne != null)
            {
                var atLeastOneNewAdded = false;
                for (int i = 0; i < NumberOfvertex; i++)
                {
                    if (theLeastCostOne.AllVertex.Contains(i))
                    {
                        continue;
                    }

                    atLeastOneNewAdded = true;
                    var nodeToAdd = new NodeForTSBB();
                    nodeToAdd.StartVertex = theLeastCostOne.EndVertex;
                    nodeToAdd.EndVertex = i;
                    nodeToAdd.AllVertex = new List<int>(theLeastCostOne.AllVertex) { i };

                    var matrixCopy = (int[,])theLeastCostOne.AdjacencyMatrix
                        .Clone();

                    var reductionCostRow = ChangeTheMatrix(true, matrixCopy);
                    var reductionCostColumn = ChangeTheMatrix(false, matrixCopy);
                    nodeToAdd.Cost = InitialReductionCost + reductionCostRow + reductionCostColumn 
                                     + matrixToDoThings[theLeastCostOne.StartVertex, i];
                    NodeForTsbbs.Add(nodeToAdd);
                }

                if (atLeastOneNewAdded)
                {
                    theLeastCostOne = GetTheleaseCostOne(theLeastCostOne.StartVertex, theLeastCostOne.EndVertex);
                }
                else
                {
                    if (Upper > theLeastCostOne.Cost)
                    {
                        Upper = theLeastCostOne.Cost;
                    } 
                    theLeastCostOne = GetTheleaseCostOne();

                }
            }
        }
    }

    public class NodeForTSBB
    {
        public int StartVertex { get; set; }
        public int EndVertex { get; set; }
        public List<int> AllVertex { get; set; }
        public int[,] AdjacencyMatrix { get; set; }
        public int Cost { get; set; }

        public NodeForTSBB()
        {
            AllVertex = new List<int>();
            AdjacencyMatrix = new int[5,5];
        }

    }
}
