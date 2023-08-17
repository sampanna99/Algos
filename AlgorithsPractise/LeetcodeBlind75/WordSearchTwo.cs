using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class WordSearchTwo
    {
        public List<string> ListOfwords { get; set; }
        public NodeHs Root { get; set; }
        public string[,] MatrixofLet { get; set; }
        public WordSearchTwo()
        {
            ListOfwords = new List<string>() { "agile", "lily" };
            MatrixofLet = new string[,]
            {
                { "a", "l", "i", "l" },
                {"g", "e", "g", "a" },
                {"k", "k", "i", "l"}
            };
            Root = new NodeHs();
        }

        public void CreateTrie(NodeHs node, string word)
        {
            if (word == "")
            {
                node.EndOfAWord = true;
                return;
            }
            var firstLet = word[0].ToString();
            var remaining = word[1..];

            if (node.Children.ContainsKey(firstLet))
            {
            }
            else
            {
                var newN = new NodeHs();
                newN.Value = firstLet;
                newN.Children.Add(firstLet, new NodeHs());
            }
            node = node.Children[firstLet];
            CreateTrie(node, word);
        }

        public void DFSOnGraph()
        {
            var listofStringsFound = new List<string>();
            for (int i = 0; i < MatrixofLet.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixofLet.GetLength(1); j++)
                {
                    if (Root.Children.ContainsKey(MatrixofLet[i,j]))
                    {
                        var intermediateVal = MatrixofLet[i, j];
                        MatrixofLet[i, j] = "$";
                        var returnedVal = Charfound(i, j, Root.Children[MatrixofLet[i,j]]);
                        MatrixofLet[i, j] = intermediateVal;
                        if (returnedVal != null)
                        {
                            listofStringsFound.Add(intermediateVal + returnedVal);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private string Charfound(int foundArRow, int foundArCol, NodeHs node)
        {
            if (node.EndOfAWord)
            {
                return node.Value;
            }

            var row = MatrixofLet.GetLength(0);
            var column = MatrixofLet.GetLength(1);
            //top
            //left
            //right
            //bottom
            if (foundArRow - 1 >= 0 && MatrixofLet[foundArRow - 1, foundArCol] != "$" 
                                    && node.Children.ContainsKey(MatrixofLet[foundArRow-1, foundArCol]))
            {
                var valueatPoint = MatrixofLet[foundArRow, foundArCol + 1];

                MatrixofLet[foundArRow - 1, foundArCol] = "$";
                var value =
                    Charfound(foundArRow - 1, foundArCol, node.Children[MatrixofLet[foundArRow - 1, foundArCol]]);
                MatrixofLet[foundArRow, foundArCol + 1] = valueatPoint;
                if (value != null)
                {
                    return valueatPoint + value;
                }
                else
                {
                    return null;
                }
            }
            else if (foundArCol - 1 >= 0 && MatrixofLet[foundArRow, foundArCol - 1] != "$"
             && node.Children.ContainsKey(MatrixofLet[foundArRow, foundArCol - 1]))
            {
                var valueatPoint = MatrixofLet[foundArRow, foundArCol + 1];

                MatrixofLet[foundArRow, foundArCol - 1] = "$";
                var value =
                    Charfound(foundArRow, foundArCol - 1, node.Children[MatrixofLet[foundArRow, foundArCol - 1]]);

                MatrixofLet[foundArRow, foundArCol + 1] = valueatPoint;
                if (value != null)
                {
                    return valueatPoint + value;
                }
                else
                {
                    return null;
                }


            }
            else if (foundArRow + 1 < row && MatrixofLet[foundArRow + 1, foundArCol] != "$"
              && node.Children.ContainsKey(MatrixofLet[foundArRow + 1, foundArCol]))
            {
                var valueatPoint = MatrixofLet[foundArRow, foundArCol + 1];

                MatrixofLet[foundArRow + 1, foundArCol] = "$";
                var value =
                    
                    Charfound(foundArRow + 1, foundArCol, node.Children[MatrixofLet[foundArRow + 1, foundArCol]]);
                MatrixofLet[foundArRow, foundArCol + 1] = valueatPoint;
                if (value != null)
                {
                    return valueatPoint + value;
                }
                else
                {
                    return null;
                }
            }

            else if (foundArCol + 1 < column && MatrixofLet[foundArRow, foundArCol + 1] != "$"
              && node.Children.ContainsKey(MatrixofLet[foundArRow, foundArCol + 1]))
            {
                var valueatPoint = MatrixofLet[foundArRow, foundArCol + 1];
                MatrixofLet[foundArRow, foundArCol + 1] = "$";
                var value =
                    Charfound(foundArRow, foundArCol + 1, node.Children[MatrixofLet[foundArRow, foundArCol + 1]]);
                MatrixofLet[foundArRow, foundArCol + 1] = valueatPoint;
                if (value != null)
                {
                    return valueatPoint + value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
