using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class DesignAddAndSearch
    {
        public NodeHs Root { get; set; }
        public DesignAddAndSearch()
        {
            Root = new NodeHs();
        }

        public void Insert(string word)
        {
            var nod = Root;
            foreach (var letter in word)
            {
                var letToW = letter.ToString();
                if (!nod.Children.ContainsKey(letToW))
                {
                    nod.Children.Add(letToW, new NodeHs
                    {
                        Value = letToW,
                    });
                }
                
                nod = nod.Children[letToW];
            }

            nod.EndOfAWord = true;
        }

        public bool Search(string word, NodeHs node)
        {

            var first = word[0].ToString();
            var second = word[1..];


            if (node.Children.ContainsKey(first) || first == ".")
            {
                var nodetoPass = node;
                if (first == ".")
                {
                    var returnVal = false;
                    foreach (var allch in node.Children)
                    {
                        nodetoPass = allch.Value;
                        if (second.Length == 1)
                        {
                            if (nodetoPass.EndOfAWord)
                            {
                                returnVal = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            returnVal = Search(second, nodetoPass);

                        }
                        if (returnVal)
                        {
                            break;
                        }
                    }

                    return returnVal;
                }
                else
                {
                    nodetoPass = node.Children[first];
                    if (second.Length == 1)
                    {
                        if (nodetoPass.EndOfAWord)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return Search(second, nodetoPass);
                    }
                }

            }
            else
            {
                return false;
            }

        }
    }
}
