using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric.Phase2
{
    public class BinarySearchTree
    {
         

    }
    public class ConvertArrayToBST
    {
        public NodeLR NodeToReturn { get; set; }
        public int[] ArrayGiven { get; set; }
        public ConvertArrayToBST()
        {
            ArrayGiven = new[] { -10, -3, 0, 5, 9 };
            NodeToReturn = new NodeLR();
        }

        public void Algorithmn()
        {

        }

        private NodeLR Recurse(int leftVal, int rightVal)
        {
            //base case
            if (leftVal < rightVal)
            {
                return null;
            }


            //var mid = leftVal + (rightVal)
            var mid = (leftVal + rightVal) / 2;

            var node = new NodeLR()
            {
                Value = ArrayGiven[mid]
            };
            node.Left = Recurse(leftVal, rightVal - 1);
            node.Right = Recurse(mid + 1, rightVal);

            return node;
        }
    }

    //leetcode 285 
    //https://www.youtube.com/watch?v=vo794ruCJnU
    public class InOrderSuccessorInBst
    {
        public NodeLR GivenRoot { get; set; }
        public int ValueGiven { get; set; }

        public InOrderSuccessorInBst()
        {
            GivenRoot = new NodeLR();
        }

        public void Algorithmn()
        {
            var (isFound, node, potential) = (false, GivenRoot, new NodeLR());

            while (!isFound)
            {
                var value = node.Value;
                if (value <= ValueGiven)
                {
                    node = node.Right;
                }
                else
                {

                    potential = node;
                    node = node.Right;
                }

            }
        }
    }

    //leetcode 98
    //https://www.youtube.com/watch?v=s6ATEkipzow
    public class ValidateBinarySearchTree
    {
        public NodeLR GivenNode { get; set; }
        public ValidateBinarySearchTree()
        {
            GivenNode = new NodeLR();
        }
        public void Algorithmn()
        {
            IsBST(GivenNode, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsBST(NodeLR node,int left, int right)
        {
            //base
            if (node == null)
            {
                return true;
            }

            var value = node.Value;

            if (value >= left || value <= right)
            {
                return false;
            }

            var goleft = IsBST(node.Left, left, value);

            if (!goleft)
            {
                return false;
            }
            var goRight = IsBST(node.Right, value, right);
            return goRight;
        }
    }

    public class LowestCommonASncestor
    {
        public int WhoTofindAncestor1 { get; set; } = 7;
        public int WhoTofindAncestor2 { get; set; } = 8;
        public NodeLR GivenNode { get; set; }
        public LowestCommonASncestor()
        {
            GivenNode = new NodeLR();
        }

        public void Algorithmn()
        {
            var (dummy, value, answerNode) = (GivenNode, GivenNode.Value, new NodeLR());

            while (dummy != null)
            {
                value = dummy.Value;
                if (value > WhoTofindAncestor1 && value > WhoTofindAncestor2)
                {
                    //go right
                    dummy = dummy.Right;
                }
                else if (value < WhoTofindAncestor1 && value < WhoTofindAncestor2)
                {
                    //go left
                    dummy = dummy.Left;
                }
                //I don't think you need to check these as these are all the other options
                else if((value > WhoTofindAncestor1 && value < WhoTofindAncestor2) ||
                     (value < WhoTofindAncestor1 && value > WhoTofindAncestor2) ||
                     (value == WhoTofindAncestor2 || value == WhoTofindAncestor1))
                {
                    //found it
                    answerNode = dummy;
                    break;
                }
            }
        }
    }

    //https://www.youtube.com/watch?v=LFzAoJJt92M
    public class DeleteNodeInBST
    {
        public NodeLR GivenNode { get; set; }
        public int ValueToDelete { get; set; }
        public DeleteNodeInBST()
        {
            GivenNode = new NodeLR();
        }

        public void Algorithmn()
        {

        }

        private NodeLR FindTheMinimumInRight(NodeLR node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return FindTheMinimumInRight(node.Left);
        }
        private NodeLR FindAndDelete(NodeLR node, int valueToDelete)
        {
            //base
            if (node == null)
            {
                return null;
            }

            if (node.Value == valueToDelete)
            {
                if (node.Left == null || node.Right == null)
                {
                    return node.Left ?? node.Right;
                }else
                {
                    //find the lowest in right
                    var lowestInRight = FindTheMinimumInRight(node.Right);
                    node.Value = lowestInRight.Value;
                    node.Right = FindAndDelete(node.Right, lowestInRight.Value);
                }
            }

            if (node.Value > valueToDelete)
            {
                node.Left = FindAndDelete(node.Left, valueToDelete);
            }
            else
            {
                node.Right = FindAndDelete(node.Right, valueToDelete);
            }

            return node;
        }
    }

    public class ConvertBinaryTreeToSortedDoublyLinkedList
    {
        public NodeNP LinkedList { get; set; }
        public NodeLR BinaryTree { get; set; }
        public ConvertBinaryTreeToSortedDoublyLinkedList()
        {
            BinaryTree = new NodeLR();
            LinkedList = new NodeNP();
        }

        public void Algorithmn()
        {

        }

        public NodeNP Recurse(NodeLR node)
        {
            //base
            if (node == null)
            {
                return null;
            }


            var left = Recurse(node.Left);

            //if added
            LinkedList = new NodeNP
            {
                Value = node.Value
            };
            LinkedList.Prev = left;
            //LinkedList = LinkedList.Next;

            var right = Recurse(node.Right);
            if (right != null)
            {
                LinkedList.Next = right;
                right.Prev = LinkedList;

                //added
                LinkedList = LinkedList.Next.Next;
            }

            return LinkedList;

        }
    }

    public class NodeNP : NodeH
    {
        public new NodeNP Next { get; set; }
        public new NodeNP Prev { get; set; }
    }
}
