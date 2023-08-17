using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric.Phase2
{
    public class LinkedListReversal
    {
    }

    public class ReverseLinkedList
    {
        public NodeH LinkedList { get; set; }

        public ReverseLinkedList()
        {
            LinkedList = new NodeH();
        }

        public void Algorithmn()
        {
            var (prev, current) = (LinkedList, LinkedList);
            prev = null;

            while (current != null)
            {
                var temp = current.Next;
                current.Next = prev;
                prev = current;
                current = temp;
            }
        }
    }

    public class ReverseLinkedList2
    {
        public NodeH LinkedList { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }

        public ReverseLinkedList2()
        {
            Left = 2;
            Right = 4;
            LinkedList = new NodeH();
        }
        public void Algorithmn()
        {
            var(pre, curr, i, lp) = (new NodeH(), LinkedList, 0, new NodeH());
            pre.Next = LinkedList;
            lp = null;
            var ans = pre;

            if (i < Left)
            {
                i = i + 1;
                lp = pre;
                pre = pre.Next;
                curr = curr.Next;
            }

            var pres = pre;

            for (int j = 0; j < Right - Left; j++)
            {
                var temp = curr.Next;
                curr.Next = temp;
                curr = temp;
                pre = curr;
            }

            lp.Next = pre;
            pres.Next = curr;
        }
    }

    public class ReverseNodesinKGroup
    {
        public int KGroup { get; set; }
        public NodeH LinkedList { get; set; }
        public ReverseNodesinKGroup()
        {
            LinkedList = new NodeH();
            KGroup = 2;
        }

        public void Algorithmn()
        {
            var (pre, curr, nextO) = (LinkedList, LinkedList, LinkedList.Next);
            pre = null;


            while (curr != null && curr.Next != null)
            {
                var next = curr.Next;
                var nextNext = next.Next;
                curr.Next = nextNext;
                if (pre != null)
                {
                    pre.Next = next;
                }
                pre = curr;
                curr = nextNext;
            }
        }
    }


    public class RotateLinkedList
    {
        public NodeH LinkedList { get; set; }
        public int RotationTimes { get; set; }
        public RotateLinkedList()
        {
            LinkedList = new NodeH();
            RotationTimes = 2;
            LinkedList = new NodeH();
        }

        public void Algorithmn()
        {
            var (head, length) = (LinkedList, 1);

            while (head.Next != null)
            {
                length += 1;
                head = head.Next;
            }

            var lengthAtBreak = length - RotationTimes;
            var (head2, length2) = (LinkedList, 1);
            while (length2 < lengthAtBreak)
            {
                length2 += 1;

                head2 = head2.Next;
            }

            head2.Next = null;
            head.Next = LinkedList;
        }
    }

    public class SwapNodesInPairs
    {

    }
}
