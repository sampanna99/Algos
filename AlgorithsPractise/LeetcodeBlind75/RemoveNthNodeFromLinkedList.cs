using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class RemoveNthNodeFromLinkedList
    {
        public NodeH Head { get; set; }

        public RemoveNthNodeFromLinkedList()
        {
            Head = new NodeH();
            Initialize();
        }

        public void Initialize()
        {
            Head.Value = 1;
            Head.Next = new NodeH
            {
                Value = 2, Next = new NodeH
                {
                    Value = 3,
                    Next = new NodeH
                    {
                        Value = 4,
                        Next = new NodeH
                        {
                            Value = 5,
                            Next = null
                        }

                    }
                }
            };
        }

        public NodeH RemoveNthFromLast()
        {
            var dummyPointer = new NodeH { Value = Int32.MinValue, Next = Head };
            var twoPointsLater = Head.Next.Next;

            var OneToRemove = dummyPointer;
            while (twoPointsLater != null)
            {
                twoPointsLater = twoPointsLater.Next;
                OneToRemove = OneToRemove.Next;
            }

            OneToRemove.Next = OneToRemove.Next.Next;
            return dummyPointer.Next;
        }

    }

    public class NodeH
    {
        public int Value { get; set; }
        public NodeH Next { get; set; }
    }
}
