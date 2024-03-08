using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric.Phase2._2ndTime
{
    public class LinkedListThings
    {

    }

    public class NodeLinked
    {
        public int Value { get; set; }
        public NodeLinked Next { get; set; }
    }
    public class OddEvenLinkedList
    {
        public NodeH LinkedListGiven { get; set; }

        public void Algorithmn()
        {
            //both's next
            var insertHere = LinkedListGiven;
            var takeFrom = LinkedListGiven.Next;

            while (takeFrom != null)
            {
                var takeThis = takeFrom.Next;
                if (takeThis == null)
                {
                    break;
                }

                var insertHereOriginalNext = insertHere.Next;
                insertHere.Next = takeThis;

                //takeFrom = takeFrom.Next = takeThis.Next; //Coolsyntax; check if it works

                takeFrom.Next = takeThis.Next;
                takeFrom = takeFrom.Next;
                //takeFrom = takeThis.Next;
                takeThis.Next = insertHereOriginalNext;
            }
        }
    }

    public class FlattenMultiLevelDoublyLinkedList
    {
        public NodeLRC GivenNode { get; set; }
        public NodeLRC AnsNode { get; set; }
        public NodeLRC AnsNodeDum { get; set; }
        public FlattenMultiLevelDoublyLinkedList()
        {
            AnsNodeDum = AnsNode;
        }

        public void Algorithmn()
        {
            
        }

        private NodeLRC DFS(NodeLRC node)
        {
            //base case
            var nextNode = node.Next;
            var childNode = node.Child;
            NodeLRC dfsReturnFromChild = null;
            if (childNode != null)
            {
                node.Next = childNode;
                childNode.Prev = node;
                dfsReturnFromChild = DFS(childNode);
                dfsReturnFromChild.Next = nextNode;
            }

            if (dfsReturnFromChild != null)
            {
                dfsReturnFromChild.Next = nextNode;
                nextNode.Prev = dfsReturnFromChild;
            }
            else
            {
                node.Next = nextNode;
                nextNode.Prev = node;
            }

            return DFS(nextNode);
        }
    }


    public class CopyListRandomPointer
    {
        public NodeLRC Node { get; set; }
        public CopyListRandomPointer()
        {
            
        }
        public void Algorithmn()
        {
            var head = Node;
            var dict = new Dictionary<NodeLRC, NodeLRC>();
            while (head != null)
            {
                var childNew = new NodeLRC
                {
                    Value = head.Value
                };

                dict.Add(head, childNew);
                head = head.Next;
            }
            //now do the linkage
            head = Node;
            while (head != null)
            {
                var next = head.Next;
                var random = head.Child;
                NodeLRC nextC = null;
                NodeLRC randomC = null;
                if (next != null)
                {
                    nextC = dict[next];
                }

                if (random != null)
                {
                    randomC = dict[random];
                }

                var findTheCorrespondingChild = dict[head];
                findTheCorrespondingChild.Next = nextC;
                findTheCorrespondingChild.Child = randomC;
                head = head.Next;
            }

        }

    }

    public class MergeKLinkedList
    {
        public List<NodeLinked> AllNodes { get; set; }

        public MergeKLinkedList()
        {
            AllNodes = new List<NodeLinked>();
        }

        public void Algorithmn()
        {
            var numberOfLinked = AllNodes.Count;

            while (numberOfLinked >= 2)
            {
                var auxiliaryNode = new List<NodeLinked>();
                for (int i = 0; i < numberOfLinked; i++)
                {
                    var first = AllNodes[i];

                    var second = (i + 1 < numberOfLinked) ? AllNodes[i + 1] : null;

                    var linkedList = new NodeLinked();
                    var (headA, headB) = (first, second);
                    if (second != null)
                    {
                        while (headA != null || headB != null)
                        {
                            var valA = headA.Value;
                            var valB = headB.Value;

                            if (valA > valB)
                            {
                                linkedList = headA;
                                headA = headA.Next;
                            }
                            else
                            {
                                linkedList = headB;
                                headB = headB.Next;
                            }
                            linkedList = linkedList.Next;
                        }

                        var remaining = headA == null ? headB : headA;

                        linkedList = remaining;
                    }
                    else
                    {
                        linkedList = first;
                    }
                    
                    auxiliaryNode.Add(linkedList);
                    i += 2;
                }

                AllNodes = auxiliaryNode;
                numberOfLinked = AllNodes.Count;
            }
        }
    }

    public class PartitionList
    {
        public NodeLinked GivenNode { get; set; }
        public int ValueToCheck { get; set; }
        public PartitionList()
        {
            
        }

        public void Algorithmn()
        {
            //find place to insert keep a reference
            //find prev, next from which you will pull

            var dummy = GivenNode;
            NodeLinked placeToInsert = null;
            NodeLinked prev = null;
            NodeLinked next = null;


            while (dummy != null)
            {
                var valHere = dummy.Value;
                next = dummy.Next;
                if (valHere < ValueToCheck)
                {
                    
                    //if (placeToInsert != null)
                    //{
                    //}
                    //else
                    //{
                        
                    //}

                    var originalnext = placeToInsert?.Next ?? dummy.Next;
                    placeToInsert = dummy;
                    placeToInsert.Next = originalnext;
                    placeToInsert = originalnext;
                    if (prev != null) prev.Next = next;
                    //previous remains the same
                    dummy = next;
                }
                else
                {
                    prev = dummy;
                    dummy = dummy.Next;
                }
            }

        }
    }

    public class SortList
    {
        public NodeLinked GivenNode { get; set; }
        public SortList()
        {
            
        }

        public void Algorithmn()
        {
            //find length, start and end
            //Go from start to end
            //break after end aka null

        }

        private NodeLinked DFS(NodeLinked startNode, NodeLinked endNode, int length)
        {
            //base case
            if (startNode == endNode)
            {
                return startNode;
            }

            //first half
            var half = length / 2;
            var start = startNode;
            var end = startNode;
            for (int i = 0; i < 2; i++)
            {
                end = end.Next;
            }

            var auxiliaryEndNext = end.Next;
            end.Next = null;
            //left half
            var leftOne = DFS(startNode, end, half);
            //right half
            var rightOne = DFS(auxiliaryEndNext, endNode, length - half);

            //merge two of them
            var returnThis = (NodeLinked)null;

            while (leftOne != null && rightOne != null)
            {
                var leftVal = leftOne.Value;
                var rightVal = rightOne.Value;

                if (leftVal > rightVal)
                {
                    returnThis = leftOne;
                    leftOne = leftOne.Next;
                }
                else
                {
                    returnThis = rightOne;
                    rightOne = rightOne.Next;
                }

                returnThis = returnThis.Next;
            }

            return returnThis;
        }
    }
}
