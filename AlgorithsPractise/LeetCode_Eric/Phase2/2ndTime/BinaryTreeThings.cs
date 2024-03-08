using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric.Phase2._2ndTime
{
    public class BinaryTreeThings
    {
    }

    public class PopulateNextRightPointer
    {
        //public AbdulBariLecture.Node BinaryNodeGiven { get; set; }
        public NodeLRC BinaryNodeGiven { get; set; }

        public void Algorithmn()
        {
            //level order with N as null
            var queue = new Queue<NodeLRC>();
            queue.Enqueue(BinaryNodeGiven);


            var auxiliaryQ = new Queue<NodeLRC>();
            while (queue.Count > 0)
            {
                var deque = queue.Dequeue();

                var left = deque.Prev;
                var right = deque.Next;

                var toPointTo = left;

                if (left != null && right != null)
                {
                    left.Child = right;
                }
                else
                {
                    toPointTo = left ?? right;
                }
                //get the top of auxiliary and point next to left or right;
                if (auxiliaryQ.Count > 0)
                {
                    var dequeC = auxiliaryQ.Peek();
                    dequeC.Child = toPointTo;
                }

                auxiliaryQ.Enqueue(left);
                auxiliaryQ.Enqueue(right);
                //check if queue is empty if emptry change with auxiliary
                if (queue.Count > 0)
                {
                    queue = auxiliaryQ;
                }
            }
        }
    }

    public class ConstructBTFromInOrderPostOrder
    {
        public int[] InOrder { get; set; }
        public int[] PostOrder { get; set; }
        public int indexOfPostOrder { get; set; }
        public ConstructBTFromInOrderPostOrder()
        {
            indexOfPostOrder = PostOrder.Length - 1;
        }
        public void Algorithmn()
        {
            //postOrder last one is the value of the node
            //find that in the inOrder.
            //if present on the right
            var node = new NodeLR()
            {
                Value = PostOrder[^1]
            };
        }

        private NodeLR DFS(int startInd, int endInd)
        {
            //find the value in Inorder
            var index = Int32.MinValue;
            var value = PostOrder[indexOfPostOrder];
            for (int i = startInd; i <= endInd; i++)
            {
                if (InOrder[i] == value)
                {
                    index = i;
                    break;
                }
            }

            if (index == Int32.MinValue)
            {
                return null;
            }
            var node = new NodeLR { Value = value };
            //Right of the index is Right Node
            if (index < endInd)
            {
                indexOfPostOrder -= 1;
                node.Right = DFS(index + 1, endInd);
            }
            //Left of the index is Left Node
            if (index > startInd)
            {
                indexOfPostOrder -= 1;
                node.Left = DFS(startInd, index - 1);
            }
            return node;
        }

    }

    public class LowestCommonAncestor
    {

    }
}
