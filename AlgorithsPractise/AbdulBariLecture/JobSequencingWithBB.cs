using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class JobSequencingWithBB
    {
        public Dictionary<string, int[]> JobAndCorrosponding { get; set; }
        public Queue<List<string>> QueueForBFS { get; set; }

        public JobSequencingWithBB()
        {
            JobAndCorrosponding = new Dictionary<string, int[]>();
            QueueForBFS = new Queue<List<string>>();
            Initialize();
        }

        private void Initialize()
        {
            JobAndCorrosponding.Add("j1", new []{5,1,1});
            JobAndCorrosponding.Add("j2", new []{10,3,2});
            JobAndCorrosponding.Add("j3", new []{6,2,1});
            JobAndCorrosponding.Add("j4", new []{3,1,1});
        }

        public void BFS()
        {
            var uppervalue = Int32.MaxValue; //sum of all penalties except that one
            var cost = 0;

            for (int i = 0; i < JobAndCorrosponding.Count; i++)
            {
                var (val, key) = ((i + 1), "j" + (i + 1).ToString());
                //for (int j = 0; j < JobAndCorrosponding.Count; j++)
                //{
                //    QueueForBFS.Enqueue();
                //}

                var upperAndCost = GetUpperAndeCost(val, key, new List<string>());
                if (upperAndCost.Item2 < uppervalue)
                {
                    uppervalue = upperAndCost.Item2;
                }

                if (upperAndCost.Item1 > uppervalue)
                {
                    continue;
                }

                QueueForBFS.Enqueue(new List<string>{key});
            }

            while (QueueForBFS.Count > 0)
            {
                var dequeTop = QueueForBFS.Dequeue();
                var findTheLastOne = dequeTop.Count;

                var keyValue = dequeTop[findTheLastOne - 1];
                var timeneededForAllUpto = FindTimeNeededUpto(dequeTop);
                //we don't wanna do j4 as that's thge last
                //var dsfa = keyValue[1];
                var number = Convert.ToInt32(keyValue[1].ToString());
                if (number < JobAndCorrosponding.Count)
                {
                    for (int i = number + 1; i <= JobAndCorrosponding.Count; i++)
                    {
                        //gotta check with the upper and cost and see if it is worth persuing.
                        //maybe upper and cost value should be dealt with above
                        //THEN add another one to the  dequeTop variable
                        var keyA = "j" + i;
                        //check for deadline here.
                        //Ex: if j3 and j1 and j2 are already there and j3 deadline is 2. It doesn't go through
                        var timeNeededForTheNewOne = JobAndCorrosponding[keyA][2] + timeneededForAllUpto;
                        //checking with the deadline
                        if (timeNeededForTheNewOne > JobAndCorrosponding[keyA][1])
                            //if (valueTocheck > findTheLastOne && valueTocheck)
                        {
                            continue;
                        }

                        var upperAndCostA = GetUpperAndeCost(i, keyA, dequeTop);
                        if (upperAndCostA.Item2 < uppervalue)
                        {
                            uppervalue = upperAndCostA.Item2;
                        }

                        if (upperAndCostA.Item1 > uppervalue)
                        {
                            continue;
                        }

                        var dequeCopy = new List<string>(dequeTop);
                        dequeCopy.Add(keyA); 
                        QueueForBFS.Enqueue(dequeCopy);
                    }
                }
            }
        }

        private int FindTimeNeededUpto(List<string> timeNeeded)
        {
            var timeNeededAll = 0;
            foreach (var each in timeNeeded)
            {
                timeNeededAll += JobAndCorrosponding[each][2];
            }

            return timeNeededAll;
        }
        //val is keyval ex: j2 would be 2.
        private (int, int) GetUpperAndeCost(int val, string key, List<string> keysIncluded)
        {
            var findJobCorrosp = JobAndCorrosponding[key];
            var cost = 0;
            var allpenaltiesexceptincluded = 0;
            for (int i = 1; i <= JobAndCorrosponding.Count; i++)
            //for (int i = 1; i <= val; i++)
            {
                var keytoFind = "j" + i;
                if (i <= val)
                {
                    if (i == val)
                    {
                        continue;
                    }
                    if (!keysIncluded.Contains(keytoFind))
                    {
                        cost += JobAndCorrosponding[keytoFind][0];
                        allpenaltiesexceptincluded += JobAndCorrosponding[keytoFind][0];
                    }

                }
                else
                {
                    //no need ti check if keysincluded or not as it would be the last one
                    allpenaltiesexceptincluded += JobAndCorrosponding[keytoFind][0];

                }

            }

            return (cost, allpenaltiesexceptincluded);
        }
    }
}
