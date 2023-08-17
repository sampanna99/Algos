using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric
{
    public class BinaryTreeStuffs
    {
    }

    public class NodeWithNext
    {
        public NodeWithNext Left { get; set; }
        public NodeWithNext Right { get; set; }
        public NodeWithNext Next { get; set; }
        public int Value { get; set; }
    }
    public class PreOrderTraversalRecursive
    {
        public NodeLR HeadNode { get; set; }
        public List<int> AnswerArray { get; set; }
        public PreOrderTraversalRecursive()
        {
            HeadNode = new NodeLR();
            AnswerArray = new List<int>();
        }

        public void AlgorithmnRec(NodeLR head)
        {
            var nodeVal = head.Value;
            AnswerArray.Add(nodeVal);
            AlgorithmnRec(head.Left);
            AlgorithmnRec(head.Right);
        }

    }

    //leetcode 116
    public class PopulatingNextRightPointers
    {
        public NodeWithNext NodeGiven { get; set; }
        public PopulatingNextRightPointers()
        {
            NodeGiven = new NodeWithNext();
        }
        public void Algorithmn()
        {
            //my thinking way
            //var (curr, next) = (NodeGiven, NodeGiven.Left);

            //while (next != null)
            //{
            //    NodeWithNext rightChildNext = new NodeWithNext();
            //    while (curr != null)
            //    {
            //        var leftChild = curr.Left;
            //        if (rightChildNext != null)
            //        {
            //            rightChildNext.Next = leftChild;
            //        }
            //        var rightChild = curr.Right;
            //        leftChild.Next = rightChild;
            //        rightChildNext = rightChild;
            //        curr = curr.Next;
            //    }
            //    rightChildNext = null;
            //    curr = next;
            //    next = curr.Left;
            //}
            //my thinking way

            //neetcode way
            var (curr, next) = (NodeGiven, NodeGiven.Left);
            while (curr != null && next != null)
            {
                curr.Left.Next = curr.Right;

                if (curr.Next != null)
                {
                    curr.Right.Next = curr.Next.Left;
                }

                curr = curr.Next;

                if (curr == null)
                {
                    curr = next;
                    next = curr.Left;
                }
            }
            //neetcode way
        }
    }

    //leetcode 117
    public class PopulatingNextRightPointers2
    {
        public NodeWithNext NodeGiven { get; set; }
        public PopulatingNextRightPointers2()
        {
            NodeGiven = new NodeWithNext();
        }

        public void Algorithmn()
        {
            var (curr, next) = (NodeGiven, NodeGiven.Left ?? NodeGiven.Right);

            while (curr != null && next != null)
            {
                var twoJoiningPoint = new NodeWithNext();
                twoJoiningPoint = null;
                if (curr.Left != null)
                {
                    if (curr.Right != null)
                    {
                        curr.Left.Next = curr.Right;
                        twoJoiningPoint = curr.Right;
                    }

                    twoJoiningPoint = curr.Left;
                }else if (curr.Right != null)
                {
                    twoJoiningPoint = curr.Right;
                }

                if (curr.Next != null)
                {
                    if (curr.Next.Left != null)
                    {
                        if (twoJoiningPoint != null)
                        {
                            twoJoiningPoint.Next = curr.Next.Left;
                        }
                    }else if (curr.Next.Right != null)
                    {
                        if (twoJoiningPoint != null)
                        {
                            twoJoiningPoint.Next = curr.Next.Right;
                        }
                    }
                }

                curr = curr.Next;

                if (curr == null)
                {
                    curr = next;
                    next = curr.Left;
                }

            }
        }
    }

    public class ConstructBinaryTreeFromPreAndInOrderTraversal
    {
        public int[] PreOrder { get; set; }
        public int[] InOrder { get; set; }
        public ConstructBinaryTreeFromPreAndInOrderTraversal()
        {
            //PreOrder = new NodeH();
            //InOrder = new NodeH();
        }
        public void Algorithmn()
        {
            BuildTree(PreOrder, InOrder);
        }

        public NodeLR BuildTree(int[] pre, int[] inor)
        {
            //base
            if (pre.Length == 0)
            {
                return null;
            }


            var preF = pre[0];
            var indexOf = Array.IndexOf(inor, preF);
            var indexOf1 = indexOf + 1;
            var length = pre.Length;
            var lengthRemovedOne = length - 1;

            var root = new NodeLR() { Value = preF };
            root.Left = BuildTree(pre[1..indexOf1], inor[..indexOf1]);
            root.Right = BuildTree(pre[indexOf1..], inor[indexOf1..]);
            return root;
        }
    }

    public class SymettricTree
    {
        public NodeLR Root { get; set; }
        public SymettricTree()
        {
            Root = new NodeLR();
        }

        public void Algorithmn()
        {
            var isMirror = IsMirror(Root.Left, Root.Right);
        }

        public bool IsMirror(NodeLR nodeLeft, NodeLR nodeRight)
        {
            //edge case
            if (nodeLeft == null && nodeRight == null)
            {
                return true;
            }
            if (nodeLeft == null || nodeRight == null)
            {
                return false;
            }


            var nodelVal = nodeLeft.Value;
            var nodeRVal = nodeRight.Value;

            if (nodeRVal != nodelVal)
            {
                return false;
            }

            if (nodeLeft.Left != null)
            {
                var left = IsMirror(nodeLeft.Left, nodeRight.Right);
                if (!left)
                {
                    return false;
                }
            }

            return IsMirror(nodeLeft.Right, nodeRight.Left);

        }
    }

    public class ConstructBinaryTreeFromPostAndInOrderTraversal
    {
        public int[] PreOrder { get; set; }
        public int[] InOrder { get; set; }
        public ConstructBinaryTreeFromPostAndInOrderTraversal()
        {
            //PreOrder = new NodeH();
            //InOrder = new NodeH();
        }

        public void Algorithmn()
        {

        }

        public NodeLR BuildTree(int[] post, int[] inorder)
        {
            //edge case
            if (post == null || inorder == null || post.Length == 0 || inorder.Length == 0)
            {
                return null;
            }

            //other
            var lengthMinusTwo = post.Length - 2;
            var value = post[^1];
            var node = new NodeLR { Value = value };

            var indexof = Array.IndexOf(inorder, value);
            var indexOfPlusOne = indexof + 1;

            if (indexof == inorder.Length - 1)
            {
                //no right nodes
            }
            else
            {
                node.Right = BuildTree(post[..lengthMinusTwo], inorder[indexOfPlusOne..]);
            }

            node.Left = BuildTree(post[..lengthMinusTwo], inorder[..indexof]);

            return node;
        }
    }

    public class LowestCommonAncestor
    {
        public NodeLR Root { get; set; }
        public int firstOne { get; set; }
        public int secondOne { get; set; }
        public LowestCommonAncestor()
        {
            Root = new NodeLR();
        }
        public void Algorithmn()
        {
            Recurse(Root);
        }

        public NodeLR Recurse(NodeLR node)
        {
            var value = node.Value;
            if (value == firstOne || value == secondOne)
            {
                return node;
            }
            if ((value < firstOne && value > secondOne) || (value > firstOne && value < secondOne))
            {
                return node;
            }

            if (value < firstOne && value < secondOne)
            {
                return Recurse(node.Left);
            }
            else
            {
                return Recurse(node.Right);
            }
        }
    }

    public class SerializeAndDeserialize
    {
        public NodeLR GivenNode { get; set; }
        public SerializeAndDeserialize()
        {
            GivenNode = new NodeLR();
        }
        public void Algorithmn()
        {
            var recurse = RecurseSerialize(GivenNode);
        }

        private string RecurseSerialize(NodeLR node)
        {
            //base case.
            if (node == null)
            {
                return "N";
            }

            var actualVal = node.Value.ToString();
            var val = RecurseSerialize(node.Left);
            var val2 = RecurseSerialize(node.Right);
            return actualVal + val + val2;
        }

        private NodeLRS RecurseDeserialize(string givenString)
        //private NodeLRS RecurseDeserialize(string givenString, string side = "L")
        {
            //base case.
            var value = givenString[0].ToString();
            if (givenString.Length == 0)
            {
                return null;
            }
            if (value == "N")
            {
                return null;
                //side = side == "L" ? "R" : "L";
            }





            var nodeCreated = new NodeLRS { Value = value };
            var remainingLeft = givenString[1..];

            nodeCreated.Left = RecurseDeserialize(remainingLeft);
            var remainingLeft2 = givenString[2..];
            nodeCreated.Right = RecurseDeserialize(remainingLeft2);


            //if (side == "L")
            //{
            //    nodeCreated.Left = RecurseDeserialize(remainingLeft, side);
            //}
            //else
            //{
            //    nodeCreated.Right = RecurseDeserialize(remainingLeft, "L");
            //}

            return nodeCreated;
        }
    }



    public class FindDuplicateSubtrees
    {
        public NodeLRS GivenNode { get; set; }
        public Dictionary<string, List<NodeLRS>> DictionaryPreOrder { get; set; }
        public HashSet<string> Answers { get; set; }
        public FindDuplicateSubtrees()
        {
            GivenNode = new NodeLRS();
            DictionaryPreOrder = new Dictionary<string, List<NodeLRS>>();
            Answers = new HashSet<string>();
        }
        public void Algorithmn()
        {
            DFS(GivenNode);
        }

        private string DFS(NodeLRS node)
        {
            //base case.

            //preorder
            var value = node.Value;
            var left = DFS(node.Left);
            var right = DFS(node.Right);
            var alltogether = value + left + right;
            if (DictionaryPreOrder.ContainsKey(alltogether))
            {
                //boom ther's there.
                DictionaryPreOrder[alltogether].Add(node);
                Answers.Add(alltogether);
            }
            else
            {
                DictionaryPreOrder[alltogether] = new List<NodeLRS> { node };
            }

            return alltogether;
        }
    }

    public class DiameterOfBinary
    {
        public NodeLR GivenNode { get; set; }
        public int maxDiameter { get; set; } = Int32.MinValue;
        public DiameterOfBinary()
        {
            GivenNode = new NodeLR();
        }

        private void Algorithmn()
        {

        }

        private int DFS(NodeLR node)
        {
            if (node == null)
            {
                return -1;
            }


            var leftHeight = DFS(node.Left);
            var rightHeight = DFS(node.Right);

            var diameter = 2 + leftHeight + rightHeight;
            if (diameter > maxDiameter)
            {
                maxDiameter = diameter;
            }
            var maxHeight = 1 + Math.Max(leftHeight, rightHeight);
            return maxHeight;
        }
    }

    public class PathSum2
    {
        public NodeLR GivenNode { get; set; }
        public int SumToMake { get; set; } = 22;
        public List<List<int>> AllCombinations { get; set; }
        public PathSum2()
        {
            GivenNode = new NodeLR();
            AllCombinations = new List<List<int>>();
        }

        private void Algorithmn()
        {

        }

        //no negative values would be easier but I am thinking there could be negative values
        private void Recurse(NodeLR node, Stack<int> allStackValues, int sumUpUntil)
        {
            allStackValues.Push(node.Value);
            sumUpUntil += node.Value;

            //base

            if (node.Left != null && node.Right != null && sumUpUntil == SumToMake)
            {
                var list = new List<int>(allStackValues);
                AllCombinations.Add(list);
            }
            else
            {
                if (node.Left != null)
                {
                    Recurse(node.Left, allStackValues, sumUpUntil);
                }
                if (node.Right != null)
                {
                    Recurse(node.Right, allStackValues, sumUpUntil);
                }
            }

            allStackValues.Pop();
        }

    }

    public class Path3
    {
        public NodeLR GivenNode { get; set; }
        public int SumToMake { get; set; } = 22;
        public Path3()
        {
            GivenNode = new NodeLR();
        }

        public void AlgorithmnNSquare()
        {

        }

        private int NotIncludeCurrentNode(NodeLR node, int sum)
        {
            //base case
            if (node == null)
            {
                return 0;
            }


            var value = node.Value;
            var newSum = sum - value;
            var count = 0;
            if (newSum == 0)
            {
                count += 1;
            }


            var goLeft = NotIncludeCurrentNode(node.Left, sum);
            var goRight = NotIncludeCurrentNode(node.Right, sum);
            //var include = IncludeCurrentNode(node, sum);

            var valueLeft = NotIncludeCurrentNode(node.Left, newSum);
            var valueRight = NotIncludeCurrentNode(node.Right, newSum);
            count = count + valueRight + valueLeft;


            return goLeft + goRight + count;
        }

        //private int IncludeCurrentNode(NodeLR node, int sum)
        //{
        //    //base case


        //    var value = node.Value;
        //    var newSum = sum - value;
        //    var count = 0;
        //    if (newSum == 0)
        //    {
        //        count += 1;
        //    }

        //    var valueLeft = IncludeCurrentNode(node.Left, newSum);
        //    var valueRight = IncludeCurrentNode(node.Right, newSum);

        //    count = count + valueRight + valueLeft;
        //    return count;
        //}


    }

    //leetcode
    //https://www.youtube.com/watch?v=QfJsau0ItOY
    public class BalancedBinaryTree
    {
        public NodeLR GivenNode { get; set; }
        public bool IsBalanced { get; set; } = true;
        public BalancedBinaryTree()
        {
            GivenNode = new NodeLR();
        }

        private void Algorithmn()
        {

        }

        private int Recurse(NodeLR node)
        {
            //base
            if (!IsBalanced)
            {
                return 0;
            }

            if (node == null)
            {
                return 0;
            }

            var leftHeight = Recurse(node.Left);
            var rightHeight = Recurse(node.Right);

            var diffrence = Math.Abs(leftHeight - rightHeight);

            if (diffrence > 1)
            {
                IsBalanced = false;
            }

            return 1 + Math.Max(leftHeight, rightHeight);

        }
    }

    public class BinaryTreeMaximumPathSum
    {
        public int BiggestUpUntilNow { get; set; } = Int32.MinValue;
        public NodeLR GivenNode { get; set; }
        public BinaryTreeMaximumPathSum()
        {
            GivenNode = new NodeLR();
        }
        public void Algorithmn()
        {

        }

        private int Recurse(NodeLR node)
        {
            //base case
            if (node == null)
            {
                return 0;
            }

            var notSplitPointL = Recurse(node.Left);
            var notSplitPointR = Recurse(node.Right);

            var biggerOne = Math.Max(notSplitPointR, notSplitPointL);

            var biggestWithBeingSplit = node.Value + notSplitPointR + notSplitPointL;

            return biggerOne + node.Value;
        }
    }


    //tricky for me to understand
    //https://www.youtube.com/watch?v=hS0d0jnyToQ&list=PL1MJrDFRFiKZa3VQCUeKIREAV7nbgGCWs&index=18
    public class ConstructBinaryTreeFromPreOrderAndsPostOrder
    {
        public int[] Preorder { get; set; }
        public int Index { get; set; } = 0;
        public int[] PostOrder { get; set; }
        public NodeWithNext DummyNode { get; set; }
        public Dictionary<int, int> ValueIndex { get; set; }
        public ConstructBinaryTreeFromPreOrderAndsPostOrder()
        {
            Preorder = new[] { 1, 2, 4, 5, 3, 6, 7 };
            PostOrder = new[] { 4, 5, 2, 6, 7, 3, 1 };
            DummyNode = new NodeWithNext();
            ValueIndex = new Dictionary<int, int>();
            CreateDict();
        }

        private void CreateDict()
        {
            for (int i = 0; i < PostOrder.Length; i++)
            {
                ValueIndex.Add(PostOrder[i], i);
            }
        }
        private NodeWithNext Recurse(int parentIndex)
        {
            //base case
            if (Index >= Preorder.Length)
            {
                return null;
            }


            var value = Preorder[Index];
            var indexFromPost = PostOrder[value];
            if (indexFromPost > parentIndex)
            {
                Index = Index + 1;
                var node = new NodeWithNext { Value = value };
                //var valueWithOneAdded = indexFromPre + 1;
                node.Left = Recurse(indexFromPost);
                node.Right = Recurse(indexFromPost);
                return node;
            }

            return null;
            //return node;

        }
    }
    public class NodeLRS : NodeLR
    {
        public new string Value;
        public new NodeLRS Left { get; set; }
        public new NodeLRS Right { get; set; }
    }


}
