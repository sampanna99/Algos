using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class SerializeAndDeserializeBinaryTree
    {
        public NodeLR RootNode { get; set; }
        public StringBuilder SerializedStrin { get; set; }
        public List<string> SplittedChars { get; set; }

        public SerializeAndDeserializeBinaryTree()
        {
            SplittedChars = new List<string>();
        }
        public void Serialize(NodeLR node)
        {
            if (node == null)
            {
                SerializedStrin.Append("N,");
                return;
            }
            SerializedStrin.Append(node.Value + ",");
            Serialize(node.Left);
            Serialize(node.Right);
        }

        public void Deserialize()
        {
            var valueModified = SerializedStrin.ToString().TrimEnd(',');
            var array = valueModified.Split(',');
            SplittedChars = array.ToList();
        }

        private void CreateTree(int indexOfArray, NodeLR node)
        {
            int val;
            if (SplittedChars.Count >= indexOfArray ||
                !Int32.TryParse(SplittedChars[indexOfArray], out val))
            {
                return;
            }
            node.Value = val;
            CreateTree(indexOfArray + 1, node.Left);
            CreateTree(indexOfArray + 1, node.Right);
        }
    }
}
