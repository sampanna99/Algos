using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class TrieDataStructure
    {
        public NodeHs MyProperty { get; set; }
        public NodeHs Root { get; set; }
        public TrieDataStructure()
        {
            Root = new NodeHs();
        }
        public void Insert(string wordToInsert)
        {
            var nodeToCh = Root;
            foreach (var letter in wordToInsert)
            {
                var lts = letter.ToString();
                if (nodeToCh.Children.ContainsKey(lts))
                {
                     //nodeToCh = nodeToCh.Children[lts];
                }
                else
                {
                    var newNode = new NodeHs
                    {
                        Value = lts
                    };
                    nodeToCh.Children.Add(lts, newNode);
                }
                nodeToCh = nodeToCh.Children[lts];
            }

            nodeToCh.EndOfAWord = true;
        }

        //wrong I think
        public void Delete(string wordToDelete)
        {
            var nodeToCh = Root;

            foreach (var letter in wordToDelete)
            {
                var lts = letter.ToString();

                if (nodeToCh.Children.ContainsKey(lts))
                {
                    nodeToCh = nodeToCh.Children[lts];
                }
                else
                {
                    Console.WriteLine("Cannot delete as the word can't be found");
                    return;
                }
            }

            if (nodeToCh.Children.Count == 0)
            {
                nodeToCh = null;
            }
            else
            {
                nodeToCh.EndOfAWord = false;
            }

        }

        public NodeHs Delete(string wordToDelete, NodeHs node)
        {
            if (wordToDelete.Length == 0)
            {
                if (node.Children.Count > 0)
                {
                    node.EndOfAWord = false;
                    return node;
                }
                else
                {
                    return null;
                }
            }
            {
                
            }
            var first = wordToDelete[0].ToString();
            if (node.Children.ContainsKey(first))
            {
                //fix here 1.. may throw errors
                //var deletedNode = Delete(wordToDelete[1..], node.Children[first]);
                var deletedNode = Delete(wordToDelete.Substring(1), node.Children[first]);
                if (deletedNode == null)
                {
                    if (node.Children.Count < 2)
                    {
                        return null;
                    }
                    else
                    {
                        return node;
                    }
                }
                else
                {
                    return node;
                }
            }
            else
            {
                //something wrong
            }
            return Root;
        }
    }

    public class NodeHs
    {
        public NodeHs()
        {
            Children = new Dictionary<string, NodeHs>();
        }
        public string Value { get; set; }
        public Dictionary<string, NodeHs> Children { get; set; }
        //public List<NodeHs> Children { get; set; }
        //public HashSet<string> JustChildrenVal { get; set; } //so that no need to iterate over
        public bool EndOfAWord { get; set; } = false;
    }
}
