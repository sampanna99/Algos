using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.KeertiPurswani
{
    public class WildCardMatching
    {
        public string GivenString { get; set; } = "albmnc";
        public string Pattern { get; set; } = "a?b*c";

        public bool[,] Matrix { get; set; }

        public WildCardMatching()
        {
            Matrix = new Boolean[GivenString.Length + 1, Pattern.Length + 1];
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            Matrix[i, j] = true;
                        }
                        else
                        {
                            Matrix[i, j] = false;
                        }
                    }
                    else if(i == 0)
                    {
                        if (Pattern[j - 1].ToString() == "*" && Matrix[i, j - 1])
                        {
                            Matrix[i, j] = true;
                        }
                        else
                        {
                            Matrix[i, j] = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void Algorithm()
        {
            for (int i = 1; i < Matrix.GetLength(0); i++)
            {
                for (int j = 1; j < Matrix.GetLength(1); j++)
                {
                    if (Pattern[j-1].ToString() == "*")
                    {
                        //including 
                        if (Matrix[i-1, j] == true || Matrix[i, j-1] == true)
                        {
                            Matrix[i, j] = true;
                        }
                        else
                        {
                            Matrix[i, j] = false;
                        }
                        //excluding
                    }else if (Pattern[j - 1].ToString() == "?")
                    {

                    }
                    else if ((GivenString[i-1] == Pattern[j-1] || Pattern[j - 1].ToString() == "?")
                        && Matrix[i-1, j-1])
                    {
                        Matrix[i, j] = true;
                    }
                    else
                    {
                        Matrix[i, j] = false;
                    }
                }
            }

            Console.WriteLine(Matrix[GivenString.Length, Pattern.Length]);
        }
    }
}
