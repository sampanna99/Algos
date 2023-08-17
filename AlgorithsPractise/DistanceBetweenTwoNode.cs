using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node NextNodeRight { get; set; }
        public Node ParentNode { get; set; }

    }
    public class DistanceBetweenTwoNode
    {
        public Node root { get; set; }
        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public DistanceBetweenTwoNode()
        {
            
        }

        public Node FindTheCommonNode(Node root, int FirstValue, int SecondValue)
        {
            if (root.Value == FirstValue || root.Value == SecondValue)
            {
                return root;
            }

            var goLeft = FindTheCommonNode(root.NextNode, FirstValue, SecondValue);
            var goRight = FindTheCommonNode(root.NextNodeRight, FirstValue, SecondValue);

            if (goLeft != null && goRight != null)
            {
                return root;
            }

            return goLeft ?? goRight;
        }

        public int DistanceBetweenTwoNodeCalc()
        {

            var lCA = FindTheCommonNode(root, FirstValue, SecondValue);


            return 0;
        }
    }
}
 