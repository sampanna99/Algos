using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class ValidateBST
    {
        public NodeLR Root { get; set; }

        public ValidateBST()
        {
            Root = new NodeLR();
            Initialize();
        }

        private void Initialize()
        {
            Root.Value = 5;
            Root.Left = new NodeLR
            {
                Value = 3,

            };
            Root.Right = new NodeLR
            {
                Value = 7,
                Left = new NodeLR
                {
                    Value = 4
                },
                Right = new NodeLR
                {
                    Value = 8
                }
            };
        }

        public bool IsBST(NodeLR node, int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
        {
            if (node.Value > minValue && node.Value < maxValue)
            {
                
                //var minValueT = node.Value < minValue ? node.Value : minValue;
                //var maxValueT = node.Value > maxValue ? node.Value : maxValue;
                IsBST(node.Left, minValue, node.Value);
                IsBST(node.Right, node.Value, maxValue);
            }

            return false;
        }

    }
}
