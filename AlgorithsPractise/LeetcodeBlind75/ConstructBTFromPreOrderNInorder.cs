using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class ConstructBTFromPreOrderNInorder
    {
        public NodeLR RootNode { get; set; }
        public List<int> PreOrder { get; set; }
        public int[] InOrder { get; set; }

        public ConstructBTFromPreOrderNInorder()
        {
            PreOrder = new List<int>();
            InOrder = new[] { 8, 4, 10, 9, 11, 2, 5, 1, 6, 3, 7 };
            Initialize();
            RootNode = new NodeLR();
        }

        private void Initialize()
        {
            PreOrder.Add(7);
            PreOrder.Add(6);
            PreOrder.Add(3);
            PreOrder.Add(5);
            PreOrder.Add(11);
            PreOrder.Add(10);
            PreOrder.Add(9);
            PreOrder.Add(8);
            PreOrder.Add(4);
            PreOrder.Add(2);
            PreOrder.Add(1);
        }
        private (List<int>, List<int>) LeftAndRight(int valueToTest, List<int> checkInthis)
        {
            var left = new List<int>();
            var right = new List<int>();
            var leftC = true;
            foreach (var checkInthi in checkInthis)
            {
                if (checkInthi == valueToTest)
                {
                    leftC = false;
                }
                if (leftC)
                {
                    left.Add(checkInthi);
                }
                else
                {
                    right.Add(checkInthi);
                }
            }

            return (left, right);
        }

        private int FindTheFirst(List<int> fromThese)
        {
            var returnThis = Int32.MinValue;
            var index = 0;
            foreach (var i in PreOrder)
            {
                if (fromThese.Contains(i))
                {
                    returnThis = i;
                }

                index++;
            }

            PreOrder[index] = Int32.MinValue;
            return returnThis;
        }

        public NodeLR CreateBT(NodeLR node, List<int> toCheck)
        {
            if (toCheck.Count == 0)
            {
                return node;
            }
            //if (toCheck.Count < 2)
            //{
            //    node.Value = FindTheFirst(toCheck);
            //    return node;
            //}
            node.Value = FindTheFirst(toCheck);
            var leftAndRight = LeftAndRight(node.Value, toCheck);
            node.Left = CreateBT(new NodeLR(), leftAndRight.Item1);
            node.Right = CreateBT(new NodeLR(), leftAndRight.Item2);

            return node;

        }

    }
}
