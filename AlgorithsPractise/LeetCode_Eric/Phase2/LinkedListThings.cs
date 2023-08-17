using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric.Phase2
{
    public class LinkedListThings
    {

    }

    public class AddTwoNumbers
    {
        public NodeH FirstNode { get; set; }
        public NodeH SecondNode { get; set; }

        public AddTwoNumbers()
        {
            FirstNode = new NodeH
            {
                Value = 5,
                Next = new NodeH
                {
                    Value = 6,
                    Next = new NodeH
                    {
                        Value = 4,
                        
                    }
                }
            }; 
            SecondNode = new NodeH
            {
                Value = 2,
                Next = new NodeH
                {
                    Value = 4,
                    Next = new NodeH
                    {
                        Value = 3,
                        Next = new NodeH
                        {
                            Value = 3
                        }
                    }
                }
            };
        }

        public void Algorithmn()
        {
            var (AnswerNode, carryOver) = (new NodeH(), 0);
            var dummy = AnswerNode;
            while (FirstNode != null || SecondNode != null || carryOver != 0)
            {
                var firstVal = FirstNode?.Value ?? 0;
                var secondVal = SecondNode?.Value ?? 0;

                var added = firstVal + secondVal + carryOver;
                var realVal = added % 10;
                var forCarry = added / 10;

                carryOver = forCarry;
                AnswerNode.Next = new NodeH
                {
                    Value = realVal
                };
            }
        }
    }

    public class OddEvenLinkedList
    {
        //I am doing it a weird way
        //because there is better way of having two pointers for odd and even and
        //then connecting them. It's the first approach from TechDose

        public NodeH LinkedList { get; set; }

        public OddEvenLinkedList()
        {
            LinkedList = new NodeH
            {
                Value = 1,
                Next = new NodeH
                {
                    Value = 2,
                    Next = new NodeH
                    {
                        Value = 3,
                        Next = new NodeH
                        {
                            Value = 4
                        }
                    }
                }
            };
        }

        public void Algorithmn()
        {
            var (firstPointer, lastPointer, number) = (LinkedList, LinkedList, 0);

            while (firstPointer.Next != null)
            {
                firstPointer = firstPointer.Next;
                number += 1;
            }

            lastPointer = firstPointer;
            var firstAgain = LinkedList;

            var numberAll = number % 2 == 0 ? (number / 2) + 1  : number / 2;
            for (int i = 0; i < numberAll; i++)
            {
                var second = firstAgain.Next;
                firstAgain.Next = second.Next;
                lastPointer.Next = second;

                firstAgain = firstAgain.Next;
                lastPointer = lastPointer.Next;
            }
        }
    }

    public class IntersectionOfLinkedList
    {
        public NodeH FirstNode { get; set; }
        public NodeH SecondNode { get; set; }
        public IntersectionOfLinkedList()
        {
            FirstNode = new NodeH
            {
                Value = 5,
                Next = new NodeH
                {
                    Value = 6,
                    Next = new NodeH
                    {
                        Value = 4,

                    }
                }
            };

            SecondNode = new NodeH
            {
                Value = 2,
                Next = new NodeH
                {
                    Value = 4,
                    Next = new NodeH
                    {
                        Value = 3,
                        Next = new NodeH
                        {
                            Value = 3
                        }
                    }
                }
            };
        }

        public void Algorithmn()
        {
            var (firstPointer, secondPointer) = (FirstNode, SecondNode);

            while (firstPointer != secondPointer)
            {
                firstPointer = firstPointer == null ? SecondNode : firstPointer.Next;
                secondPointer = secondPointer == null ? FirstNode : secondPointer.Next;
            }
        }
    }

    public class NodeLRC
    {
        public NodeLRC Prev { get; set; }
        public NodeLRC Next { get; set; }
        public NodeLRC Child { get; set; }
        public int Value { get; set; }
    }

    public class NodeRandom
    {
        public int Value { get; set; }
        public NodeRandom Next { get; set; }
        public NodeRandom Random { get; set; }
    }

    public class FlattenDoublyLinkedList
    {
        public NodeLRC DoublyLinkedList { get; set; }
        public FlattenDoublyLinkedList()
        {
            //Fill this with sth
            DoublyLinkedList = new NodeLRC
            {
                Value = 1,
                Next = new NodeLRC
                {
                    Value = 2,
                    Prev = new NodeLRC()
                }
            };
        }

        public void Algorithmn()
        {
            var node = DoublyLinkedList;

            while (node != null)
            {
                if (node.Child != null)
                {
                    var next = node.Next;
                    node.Next = node.Child;
                    //node.Next.Prev = node;
                    var findPrev = FindPrev(node.Next);

                }
                else
                {
                    
                }
            }
        }

        private NodeLRC FindPrev(NodeLRC node)
        {
            //base case

            if (node.Child == null && node.Next == null)
            {
                return node;
            }
            //recurse
            if (node.Child != null)
            {
                var nextToChange = node.Next;
                node.Next = node.Child;
                var finding = FindPrev(node.Next);

                if (nextToChange != null)
                {
                    nextToChange.Prev = finding;
                    finding.Next = nextToChange;
                }
                //now go to the next. Even though we went to the next above it was the child which is already
                //flattened
                var gotoTheRight = FindPrev(nextToChange);
            }
            else
            {
                //go child and go. go next
                FindPrev(node.Next);
            }

            return node;

            //if (node.Next == null)
            //{
            //    return node;
            //}

            //var nodeFound =  FindPrev(node.Next);
        }
    }

    public class InserInASortedCircularLinkedList
    {
        public NodeH LinkedList { get; set; }
        public int ValueToInsert { get; set; }
        public InserInASortedCircularLinkedList()
        {
            //todo: create the linked list here. I am not doing it now as it doesn't matter.
            LinkedList = new NodeH();
            ValueToInsert = 3;
        }

        public void Algorithmn()
        {
            var (prev, nextOne, addAfterThis) = (LinkedList, LinkedList.Next, 
                new NodeH());
            while (nextOne != LinkedList)
            {
                var prevVal = LinkedList.Value;
                var currVal = nextOne.Value;

                if (ValueToInsert >= prevVal && ValueToInsert <= currVal)
                {
                    //insert right after prev.
                    addAfterThis = prev;
                    break;
                }

                //circular
                if (currVal < prevVal)
                {
                    //if (currVal >= ValueToInsert && prevVal >= ValueToInsert)
                    //{
                        
                    //}

                    if (ValueToInsert >= prevVal || ValueToInsert <= currVal)
                    {
                        addAfterThis = prev;
                        break;
                    }
                }

                prev = nextOne;
                nextOne = nextOne.Next;
            }

            var temp = addAfterThis.Next;
            addAfterThis.Next = new NodeH()
            {
                Value = ValueToInsert,
                Next = temp
            };
        }
    }
    public class CopyListWithRandomPointer
    {
        public Dictionary<NodeRandom, NodeRandom> Dictionary { get; set; }
        public NodeRandom LinkedList { get; set; }
        public CopyListWithRandomPointer()
        {
            Dictionary = new Dictionary<NodeRandom, NodeRandom>();

            //todo: initialize it with data.
            LinkedList = new NodeRandom();
        }

        public void Algorithmn()
        {
            var pointer = LinkedList;
            while (pointer != null)
            {
                var val = pointer.Value;
                Dictionary.Add(pointer, new NodeRandom{Value = val});
                pointer = pointer.Next;
            }

            var pointer2 = LinkedList;
            while (pointer2 != null)
            {
                var getValue = Dictionary[pointer2];
                var pointer2Next = Dictionary[pointer2.Next];
                var pointer2Random = Dictionary[pointer2.Random];

                getValue.Next = pointer2Next;
                getValue.Random = pointer2Random;
                pointer2 = pointer2.Next;
            }
        }
    }

    public class MergeKSortedList
    {
        public List<NodeH> ListOfLinkedLists { get; set; }

        public MergeKSortedList()
        {
            //todo: add the linked list here.
            ListOfLinkedLists = new List<NodeH>();
        }

        public void Algorithmn()
        {
            var createList = ListOfLinkedLists;

            while (createList.Count < 2)
            {
                var dummyCreateList = new List<NodeH>();
                for (int i = 0; i < createList.Count; i += 2)
                {
                    var first = i;
                    var second = i + 1;
                    NodeH mergeTwoIntoOne = new NodeH();
                    if (ListOfLinkedLists.Count < second)
                    {
                        //both
                        mergeTwoIntoOne = MergeTwo(ListOfLinkedLists[first], ListOfLinkedLists[second]);
                    }
                    else
                    {
                        //just that
                        mergeTwoIntoOne = ListOfLinkedLists[first];
                    }

                    dummyCreateList.Add(mergeTwoIntoOne);
                }

                createList = dummyCreateList;
            }
        }

        private NodeH MergeTwo(NodeH first, NodeH second)
        {
            var head = new NodeH();
            var dummy = head;
            while (first != null && second != null)
            {
                if (first.Value < second.Value)
                {
                    dummy.Value = first.Value;
                    first = first.Next;
                }
                else
                {
                    dummy.Value = second.Value;
                    second = second.Next;
                }

                dummy = dummy.Next;
            }

            if (first != null)
            {
                dummy = first;
            }else if (second != null)
            {
                dummy = second;
            }

            return head;
        }
    }
    public class PartitionLinkedList
    {
        public NodeH LinkedList { get; set; }
        public int ValueGiven { get; set; }

        public PartitionLinkedList()
        {
            LinkedList = new NodeH();
            ValueGiven = 3;
        }
        public void Algorithmn()
        {
            var (firstPointer, secondPointer) = (new NodeH(), new NodeH());
            var (dummyA, dummyB) = (firstPointer, secondPointer);

            while (LinkedList != null)
            {
                var value = LinkedList.Value;
                if (value < ValueGiven)
                {
                    firstPointer.Next = LinkedList;
                    firstPointer = firstPointer.Next;
                }
                else
                {
                    secondPointer.Next = LinkedList;
                    secondPointer = secondPointer.Next;
                }
                LinkedList = LinkedList.Next;
            }

            firstPointer.Next = dummyB.Next;
            secondPointer.Next = null;
        }
    }

    public class SortList
    {
        public NodeH LinkedList { get; set; }
        public SortList()
        {
            LinkedList = new NodeH();
        }

        public void Algorithmn()
        {
            //var (slow, fast) = (LinkedList, LinkedList.Next);

            //while (fast != null && fast.Next != null)
            //{
            //    slow = slow.Next;
            //    fast = fast.Next.Next;
            //}

            //var right = slow.Next;
            //slow.Next = null;
            //var sortItLeft = SortIT(LinkedList);
            //var sortItRight = SortIT(right);

            var sortedList = SortIT(LinkedList);
        }

        private NodeH SortIT(NodeH node)
        {
            if (node.Next == null)
            {
                return node;
            }

            var (slow, fast) = (node, node.Next);
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            var right = slow.Next;
            node.Next = null;
            var left = node;

            var leftSort = SortIT(left);
            var rightSort = SortIT(right);

            var (makeOneL, makeOneR, nodeToR) = (leftSort, rightSort, new NodeH());
            var dummyR = nodeToR;

            while (makeOneL != null || makeOneR != null)
            {
                var valA = makeOneL.Value;
                var valB = makeOneR.Value;

                if (valA < valB)
                {
                    dummyR.Next = makeOneL;
                    makeOneL = makeOneL.Next;
                }
                else
                {
                    dummyR.Next = makeOneR;
                    makeOneR = makeOneR.Next;
                }
            }

            return nodeToR.Next;
        }
    }

}
