using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.BarikZone
{
    public class AllBarikZoneVideosInYoutube
    {
    }

    //DYnamic programming. Could do caching.
    public class RegularExpressionMatching
    {
        public string GivenString { get; set; }
        public string Pattern { get; set; }
        public RegularExpressionMatching()
        {
            
        }

        public void Algorithmn()
        {

        }
        private bool DFS(int indexInString, int indexInPattern)
        {
            //base case
            var lengthStr = GivenString.Length;
            var lengthPatt = Pattern.Length;
            if (indexInString >= lengthStr && indexInPattern >= lengthPatt)
            {
                return true;
            }
            if (indexInPattern >= lengthPatt)
            //if (indexInString >= lengthStr || indexInPattern >= lengthPatt)
            {
                return false;
            }

            //todo: 
            //for scenario where indexInString is out of bound but indexInPattern isn't
            //ex a and a*b*
            var valueHereForPattern = Pattern[indexInPattern];
            var nextValueifPossible = indexInPattern <= Pattern.Length ?
                Pattern[indexInPattern + 1].ToString() : null;
            if (indexInString >= lengthStr && nextValueifPossible == "*")
            {
                return DFS(indexInString, indexInPattern + 2);
            }

            var valueHereForWord = GivenString[indexInString];
            if (nextValueifPossible == "*")
            {
                var isItPossible = false;
                if (valueHereForPattern == valueHereForWord)
                {
                    //take the value
                    isItPossible = DFS(indexInString + 1, indexInPattern);
                }

                if (isItPossible) return true;

                return DFS(indexInString, indexInPattern + 2);
            }
            if (valueHereForPattern == '.')
            {
                return DFS(indexInString + 1, indexInPattern + 1);
            }

            if (valueHereForPattern == valueHereForWord)
            {
                return DFS(indexInString + 1, indexInPattern + 1);
            }
            return false;
        }
    }

    public class LowestAncestorOfBinaryTree
    {
        public NodeLR BinaryTree { get; set; }
        public int NodeValA { get; set; }
        public int NodeValB { get; set; }

        public LowestAncestorOfBinaryTree()
        {
            
        }

        public void Algorithmn()
        {

        }


        //I don't think this is right
        private int? DFS(NodeLR node, int? valParent=null)
        {
            //base case
            if (node == null)
            {
                return null;
            }
            //node itself
            var valhere = node.Value;
            if (valhere == NodeValA || valhere == NodeValB)
            {
                if (valParent != null)
                {
                    return (int)valParent;
                }
                var dfsLeft = DFS(node.Left, valhere);
                if (dfsLeft != null)
                {
                    return dfsLeft;
                }
                var dfsRight = DFS(node.Right, valhere);
                if (dfsRight != null)
                {
                    return dfsRight;
                }
            }
            else
            {
                var dfsLeft = DFS(node.Left, valParent);
                if (dfsLeft != null)
                {
                    return dfsLeft;
                }

                var dfsRight = DFS(node.Right, valParent);
                if (dfsRight != null)
                {
                    return dfsRight;
                }
            }

            return null;
            //go left,
            //go right

        }

        private int? DFSToFInd(NodeLR node)
        {
            //base case
            if (node == null)
            {
                return null;
            }

            if (node.Value == NodeValA || node.Value == NodeValB)
            {
                return node.Value;
            }
            var goLeft = DFSToFInd(node.Left);
            var goRight = DFSToFInd(node.Right);
            if (goLeft != null && goRight != null)
            {
                return node.Value;
            }

            if (goLeft != null)
            {
                return goLeft;
            }
            if (goRight != null)
            {
                return goRight;
            }

            return null;
        }
    }

    public class PascalSTriangle
    {
        public int InoutNum { get; set; }

        public PascalSTriangle()
        {
            
        }

        public void Algorithmn()
        {
            //go from 1 to that number
            //put it in the list
            //for next number use the number above that

            var list = new List<List<int>>();
            for (int i = 1; i < InoutNum; i++)
            {
                //check if 1
                if (i == 1)
                {
                    var newList = new List<int> { 1 };
                    list.Add(newList);
                }
                else
                {
                    var nList = new List<int>();

                    var listBeforeThis = list[i - 2];
                    for (int j = 1; j <= i; j++)
                    {
                        
                        var valueToAddInTheList = 0;

                        var oneMinus = j - 2;
                        var actualj = j - 1;
                        if (oneMinus > 0)
                        {
                            valueToAddInTheList += listBeforeThis[oneMinus];
                        }

                        if (actualj < listBeforeThis.Count)
                        {
                            valueToAddInTheList += listBeforeThis[actualj];
                        }
                        nList.Add(valueToAddInTheList);
                    }
                }
            }
        }
    }

    public class AddTwoNumbers
    {
        public NodeH LinkeDListA { get; set; }
        public NodeH LinkeDListB { get; set; }

        public AddTwoNumbers()
        {
            
        }

        public void Algorithmn()
        {
            var carry = 0;
            var ans = new NodeH();
            var (pointerA, pointerB, dummy) = (LinkeDListA, LinkeDListB, ans);

            while (pointerA != null && pointerB != null)
            {
                var valueAtA = pointerA.Value;
                var valueAtB = pointerB.Value;

                var addedVal = carry + valueAtA + valueAtB;
                var stringOfVal = addedVal.ToString();
                var length = stringOfVal.Length;
                if (length > 1)
                {
                    dummy.Next = new NodeH() { Value = Convert.ToInt32(stringOfVal[0]) };
                    carry = Convert.ToInt32(stringOfVal[1]);
                }
                else
                {
                    dummy.Next = new NodeH() { Value = addedVal };
                }

                pointerA = pointerA.Next;
                pointerB = pointerB.Next;
            }

            if (pointerA != null || pointerB != null)
            {
                var whichIsNotNull = pointerA ?? pointerB;
                dummy.Next = whichIsNotNull;
            }

            //Now reverse the ans.Next

            var (dumm, curr, next) = (ans.Next, ans.Next, ans.Next.Next);

            curr.Next = null;
            while (next != null)
            {
                var auxNext = next.Next;
                next.Next = curr;
                //curr.Next = null;
                curr = next;
                next = auxNext;
            }
        }
    }
}