using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class SumOfSubsetBacktracking
    {
        public List<int> AllGiven { get; set; }
        private int Sum { get; set; }
        public int SumToMake { get; set; } = 30;
        public int NumberOfElements { get; set; }
        public List<List<int>> Answers { get; set; }
        public SumOfSubsetBacktracking()
        {
            AllGiven = new List<int>();
            Answers = new List<List<int>>();
        }

        private void Initialize()
        {
            AllGiven.Add(5);
            AllGiven.Add(10);
            AllGiven.Add(12);
            AllGiven.Add(13);
            AllGiven.Add(15);
            AllGiven.Add(18);
            NumberOfElements = AllGiven.Count;

            Sum = AllGiven.Sum();
        }

        public void SubsetSumBactrackingMethod()
        {
            Initialize();
            var included = DFS(0, Sum, 0, true);

            //foreach (var vas in included)
            //{
            //    if (!vas.Contains(0))
            //    {
            //        vas.Add(indexOfCurrentIteration);
            //    }
            //}

            var notIncluded = DFS(0, Sum, 0, false);


        }

        private List<List<int>> DFS(int currentSum, int AllsumRemaining, int indexOfCurrentIteration, bool IncludeOrN)
        {
            if (indexOfCurrentIteration == NumberOfElements)
            {
                return null;
            }

            if (IncludeOrN)
            {
                currentSum += AllGiven[indexOfCurrentIteration];
            }

            AllsumRemaining -= AllGiven[indexOfCurrentIteration];

            if (currentSum == SumToMake)
            {
                if (IncludeOrN)
                {
                    var newtoadd = new List<int> { indexOfCurrentIteration};
                    var ret = new List<List<int>>();
                    ret.Add(newtoadd);
                    return ret;
                    Answers.Add(newtoadd);
                }
                //return currentSum;
            }else if (currentSum > SumToMake)
            {
                //return -1;
                return null;
            }
            else
            {
                var included = DFS(currentSum, AllsumRemaining, indexOfCurrentIteration + 1, true);

                

                var notincluded = DFS(currentSum, AllsumRemaining, indexOfCurrentIteration + 1, false);


                if (included != null)
                {
                    if (IncludeOrN)
                    {
                        foreach (var vas in included)
                        {
                            if (!vas.Contains(indexOfCurrentIteration))
                            {
                                vas.Add(indexOfCurrentIteration);
                            }
                        }
                    }
                }
                if (notincluded != null)
                {
                    if (IncludeOrN)
                    {
                        foreach (var vas in notincluded)
                        {
                            if (!vas.Contains(indexOfCurrentIteration))
                            {
                                vas.Add(indexOfCurrentIteration);
                            }
                        }
                    }
                }

                if (included != null)
                {
                    if (notincluded != null)
                    {
                        included.AddRange(notincluded);
                    }
                    return included;
                }else if (notincluded != null)
                {
                    if (included != null)
                    {
                        notincluded.AddRange(included);
                    }

                    return notincluded;
                }
                else
                {
                    return null;
                }

                //if (included == SumToMake || notincluded == SumToMake)
                //{
                //    //Add it to the list
                //    if (IncludeOrN)
                //    {
                //        foreach (var answer in Answers)
                //        {
                //            if (!answer.Contains(indexOfCurrentIteration))
                //            {
                //                answer.Add(indexOfCurrentIteration);
                //            }
                //        }
                //    }
                //}

                //if (included == SumToMake || notincluded == SumToMake)
                //{
                //    return SumToMake;
                //}

            }

            return null;
        }
    }
}
