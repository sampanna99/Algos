using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class LowestCommonAncestor
    {
        public NodeLR RootNode { get; set; }
        public int NodeValA { get; set; }
        public int NodeValB { get; set; }

        public LowestCommonAncestor()
        {
            RootNode = new NodeLR();
            Initialize();
            NodeValA = 7;
            NodeValB = 6;
        }

        private void Initialize()
        {
            RootNode.Value = 6;
            RootNode.Left = new NodeLR
            {
                Value = 2,
                Left = new NodeLR
                {
                    Value = 0,

                },
                Right = new NodeLR
                {
                    Value = 4,
                    Left = new NodeLR
                    {
                        Value = 3
                    },
                    Right = new NodeLR
                    {
                        Value = 5
                    }
                }
            };
            RootNode.Right = new NodeLR
            {
                Value = 8,
                Left = new NodeLR
                {
                    Value = 7
                },
                Right = new NodeLR
                {
                    Value = 9
                }
            };

        }

        public int LCA(NodeLR node)
        {
            if (node.Value < NodeValA && node.Value < NodeValB)
            {
                return LCA(node.Right);
            }else if (node.Value > NodeValA && node.Value > NodeValB)
            {
                return LCA(node.Left);
            }
            else
            {
                //this is the node to return.
                return node.Value;
            }
        }
    }
}
