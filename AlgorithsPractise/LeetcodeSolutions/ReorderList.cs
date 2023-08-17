using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class ReorderList
    {
        public NodeH GivenLinkedList { get; set; }
        public int LengthOfLinked { get; set; }

        public ReorderList()
        {
            GivenLinkedList = new NodeH();
        }

        public void Algorithmn()
        {
            var reversedNode = RecurseThis(GivenLinkedList);


            var givenLinkeedList = GivenLinkedList;
            var reversedOne = reversedNode;
            var returnActualThis = new NodeH();
            var returnThis = returnActualThis;

            //I think both should work;
            //var returnThis = new NodeH();
            //var returnActualThis = returnThis;

            for (int i = 1; i <= LengthOfLinked / 2; i++)
            {
                returnThis.Value = givenLinkeedList.Value;
                returnThis.Next = reversedOne;

                reversedOne = reversedOne.Next;
                givenLinkeedList = givenLinkeedList.Next;
                returnThis = returnThis.Next;
            }

            if (LengthOfLinked % 2 == 1)
            {
                returnThis.Value = reversedOne.Value;
                returnThis.Next = null;
            }
            else
            {
                returnThis.Next = null;
            }


        }

        private NodeH RecurseThis(NodeH node)
        {
            if (node.Next == null)
            {
                LengthOfLinked += 1;
                return new NodeH { Value = node.Value };
                //return node;
            }

            LengthOfLinked += 1;
            var returnedVal = RecurseThis(node);
            returnedVal.Next = new NodeH{Value = node.Value};
            //returnedVal.Next = node;
            return returnedVal.Next;
        }
    }
}
