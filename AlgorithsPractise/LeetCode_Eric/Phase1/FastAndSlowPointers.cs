using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric.Phase1
{
    public class FastAndSlowPointers
    {

    }

    public class LinkedListCycle
    {
        //Tortoise and hare

        public NodeH LinkedList { get; set; }
        public LinkedListCycle()
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

        //leetcode 141
        public void Algorithmn()
        {
            var (fastPointer, slowPointer, i, ans) = (LinkedList, LinkedList, 0, false);

            while (fastPointer != slowPointer || i == 0)
            {
                if (i != 0)
                {
                    if (fastPointer == slowPointer)
                    {
                        //cycle
                        ans = true;
                    }
                }

                i = 1;
            }

            Console.WriteLine($" The cycle exists statement is {ans}");
        }

        //leetcode 142
        public void Algorithmn2()
        {
            var (fastPointer, slowPointer, cycle, start) = (LinkedList, LinkedList, 
                false, new NodeH());

            while (fastPointer != null || fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;

                if (slowPointer == fastPointer && cycle)
                {
                    break;
                    start = slowPointer;
                }

                if (slowPointer == fastPointer)
                {
                    //break;
                    cycle = true;
                    slowPointer = LinkedList;
                }
            }
        }
    }
}

public class RemoveLinkedList
{
    public NodeH LinkedList { get; set; }
    public int ValueToDel { get; set; } = 1;
    public RemoveLinkedList()
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
        var (prev, curr) = (new NodeH{Next = LinkedList}, LinkedList);

        while (curr != null)
        {
            if (curr.Value == ValueToDel)
            {
                //delete
                prev.Next = curr.Next;
                curr = curr.Next;
            }
            else
            {
                prev = curr;
                curr = curr.Next;
            }
        }
    }
}

//https://www.youtube.com/watch?v=Q68Lwd_IpXw&list=PL1MJrDFRFiKYx7MnBqfXSRbeQYG-GnTLP&index=5
public class PalindromeLinkedList
{
    public NodeH LinkedList { get; set; }

    public PalindromeLinkedList()
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
        //base case
        //define pointers
        var (slow, fast) = (LinkedList, LinkedList);
        //move pointers
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        //reverse half of it
        var reverse = Reverse(slow);
        var first = LinkedList;
        var ans = true;
        //check for palindrome
        while (reverse != null)
        {
            if (reverse.Value != first.Value)
            {
                ans = false;
                break;
            }

            reverse = reverse.Next;
            first = first.Next;
        }
    }

    private NodeH Reverse(NodeH reversee)
    {
        //define curr and prev pointers
        var (curr, prev) = (reversee, new NodeH());
        prev = null;
        //modify curr.next to previous
        while (curr != null)
        {
            var temp = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = temp;
        }

        return prev;
    }
}

public class ReorderList
{
    public NodeH LinkedList { get; set; }
    public ReorderList()
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
        //base conditions

        //pointers
        var (slow, fast) = (LinkedList, LinkedList);

        //Reverse half and get first half
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        //Reverse
        var reversee = Reverse(slow);
        slow.Next = null;
        var (reversed, firstHalf) = (reversee, LinkedList);
        //do the thing
        var ans = new NodeH();
        var justForPointer = ans;
        while (reversed != null && firstHalf != null)
        {
            ans.Next = firstHalf.Next;
            ans = ans.Next;
            ans.Next = reversed.Next;
            ans = ans.Next;
            reversed = reversed.Next;
            firstHalf = firstHalf.Next;
        }

        if (reversed != null)
        {
            ans.Next = reversed;
        }
        if (firstHalf != null)
        {
            ans.Next = firstHalf.Next;
        }

        Console.WriteLine($"Ans is {justForPointer.Next}");
    }
    private NodeH Reverse(NodeH reversee)
    {
        //define curr and prev pointers
        var (curr, prev) = (reversee, new NodeH());
        prev = null;
        //modify curr.next to previous
        while (curr != null)
        {
            var temp = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = temp;
        }

        return prev;
    }

}
