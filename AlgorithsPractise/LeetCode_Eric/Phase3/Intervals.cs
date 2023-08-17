using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase3
{
    public class Intervals
    {
    }

    public class MergeIntervals
    {
        public int[][] Intervals { get; set; }

        public MergeIntervals()
        {
            Intervals = new[]
            {
                new[] { 1, 3 },
                new[] { 8, 10 },
                new[] { 2, 6 },
                new[] { 15, 18 }
            };
        }

        public void Algorithmn()
        {
            QuickSort(0, Intervals.Length - 1);
            var answerListOfIntervals = new List<int[]>();

            answerListOfIntervals.Add(Intervals[0]);
            var temp = Intervals[0];
            for (int i = 1; i < Intervals.Length; i++)
            {
                var firstend = answerListOfIntervals[^1][1];
                var secStart = Intervals[i][0];

                if (secStart <= firstend)
                {
                    answerListOfIntervals[^1][1] = Math.Max(firstend, Intervals[i][1]);
                    //answerListOfIntervals[^1][1] = (firstend > Intervals[i][1]) ? firstend : Intervals[i][1];
                }
                else
                {
                    answerListOfIntervals.Add(Intervals[i]);
                }
            }
        }

        private void QuickSort(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            var getpartition = GetPartition(startIndex, endIndex);
            QuickSort(startIndex, getpartition);
            QuickSort(getpartition, endIndex);
        }

        private int GetPartition(int startIndex, int endIndex)
        {
            var lastone = Intervals[endIndex - 1];
            var valueofTheLast = lastone[0];
            var partitionIndex = startIndex;
            for (int i = 0; i < endIndex; i++)
            {
                var vlueAtPartition = Intervals[partitionIndex][0];
                var valueatI = Intervals[i][0];
                if (valueatI < vlueAtPartition)
                {
                    //swap
                    var vAtP = Intervals[partitionIndex];
                    Intervals[partitionIndex] = Intervals[i];
                    Intervals[i] = vAtP;

                    partitionIndex += 1;
                }
            }
            return partitionIndex;
        }
    }

    //assume already sorted as I already did quicksort up 
    public class InsertInterval
    {
        public int[][] ArrayOfIntervals { get; set; }
        public int[] TobeInserted { get; set; }
        public InsertInterval()
        {
            ArrayOfIntervals = new[]
            {
                new[] { 1, 3 },
                new[] { 6, 9 }
            };
            TobeInserted = new[] { 2, 5 };
        }

        public void Algorithmn()
        {
            var output = new List<int[]>();
            //output.Add(ArrayOfIntervals[0]);
            var (startToInsert, endToInsert, length) = 
                (TobeInserted[0], TobeInserted[1], ArrayOfIntervals.Length);

            for (int i = 0; i < ArrayOfIntervals.Length; i++)
            {
                var (starti, endi) = (ArrayOfIntervals[i][0], ArrayOfIntervals[i][1]);

                if (startToInsert < endi)
                {
                    //add or merge
                    if (endToInsert < starti)
                    {
                        //insert before
                        output.Add(TobeInserted);
                        var remaining = ArrayOfIntervals[1..length];
                        output.AddRange(remaining);
                        break;
                    }
                    //commented out because that's the only scenario
                    //else if (endToInsert >= starti && startToInsert <= endi)
                    else
                    {
                        output.Add(new []
                        {
                            Math.Min(starti, startToInsert),
                            Math.Max(endi, endToInsert)
                        });
                    }
                    
                }
                else
                {
                  output.Add(ArrayOfIntervals[i]);
                }
            }
        }
    }

    //leetcode 435
    //https://www.youtube.com/watch?v=nONCGxWoUfM&t=561s
    public class NonOverlappingInterval
    {
        public int[][] Intervals { get; set; }

        public NonOverlappingInterval()
        {
        }
        public void Algorithmn()
        {
            QuickSort(0, Intervals.Length - 1);
            var output = new List<int[]>();
            var prevToCompare = Intervals[0];

            for (int i = 1; i < Intervals.Length; i++)
            {
                //see if it overlapping with prev one
                if (prevToCompare[1] < Intervals[i][0])
                {
                    //remove bigger one.
                    var bigger = (prevToCompare[1] > Intervals[i][1]) ? prevToCompare : Intervals[i];
                    var smaller = (prevToCompare[1] < Intervals[i][1]) ? prevToCompare : Intervals[i];
                    output.Add(bigger);
                    prevToCompare = smaller;
                }
                else
                {
                    prevToCompare = Intervals[i];
                }
            }

        }
        private void QuickSort(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            var getpartition = GetPartition(startIndex, endIndex);
            QuickSort(startIndex, getpartition);
            QuickSort(getpartition, endIndex);
        }

        private int GetPartition(int startIndex, int endIndex)
        {
            var lastone = Intervals[endIndex - 1];
            var valueofTheLast = lastone[0];
            var partitionIndex = startIndex;
            for (int i = 0; i < endIndex; i++)
            {
                var vlueAtPartition = Intervals[partitionIndex][0];
                var valueatI = Intervals[i][0];
                if (valueatI < vlueAtPartition)
                {
                    //swap
                    var vAtP = Intervals[partitionIndex];
                    Intervals[partitionIndex] = Intervals[i];
                    Intervals[i] = vAtP;

                    partitionIndex += 1;
                }
            }
            return partitionIndex;
        }

    }

    //https://www.youtube.com/watch?v=PaJxqZVPhbg&t=348s
    //leecode 252
    public class MeetingRoomI
    {
        public int[][] GivenArrayOfStartEnd { get; set; }

        public MeetingRoomI()
        {
            
        }

        //Assuming sorted
        public void Algorithmn()
        {
            var i =  1;
            var canAttendAll = true;
            while (canAttendAll && i < GivenArrayOfStartEnd.Length)
            {
                var iteratingS = GivenArrayOfStartEnd[i];
                var endF = GivenArrayOfStartEnd[i - 1][1];
                var startS = GivenArrayOfStartEnd[i][0];
                if (startS < endF)
                {
                    canAttendAll = false;
                }
            }
            
        }
    }

    //https://www.youtube.com/watch?v=FdzJmTCVyJU&t=24s
    //leetcode 253 
    public class MeetingRoomII
    {
        public int[][] GivenMeetingStartAndEnd { get; set; }
        public int[] StartTimes { get; set; }
        public int[] EndTimes { get; set; }
        public MeetingRoomII()
        {
            
        }
        public void Algorithmn()
        {
            //var (maxmeetingRoom, currentMeetingRoom, prev) = (1, 1, GivenMeetingStartAndEnd[0]);
            //for (int i = 1; i < GivenMeetingStartAndEnd.Length; i++)
            //{
            //    var (endOfCurr, startofCurr) = (GivenMeetingStartAndEnd[i][1], GivenMeetingStartAndEnd[i][0]);
            //    var (endofprev, startofPrev) = (prev[1], prev[0]);

            //    if (startofCurr < endofprev)
            //    {
            //        currentMeetingRoom += 1;
            //        if (currentMeetingRoom > maxmeetingRoom)
            //        {
            //            maxmeetingRoom = currentMeetingRoom;
            //        }
            //    }

            //    prev = (endOfCurr < endofprev) ? GivenMeetingStartAndEnd[i] : prev;
            //}

           QuickSort(StartTimes, 0, StartTimes.Length - 1);
           QuickSort(EndTimes, 0, EndTimes.Length - 1);

           var (i,j, currentRooms, maxRooms) = (0,0,0,0);

           while (i < StartTimes.Length)
           {
               if (StartTimes[i] < EndTimes[j])
               {
                   currentRooms += 1;
                   if (maxRooms < currentRooms)
                   {
                       maxRooms = currentRooms;
                   }

                   i += 1;
               }
               else
               {
                   currentRooms -= 1;
                   j += 1;
               }
           }

        }

        private void QuickSort(int[] arrayTosort, int startIndex, int endIndex)
        {
            var partIndex = GetPartitionIndex(arrayTosort, startIndex, endIndex);
            QuickSort(arrayTosort, startIndex, partIndex);
            QuickSort(arrayTosort, partIndex, endIndex);
        }

        private int GetPartitionIndex(int[] arrayToSort, int startindex, int endIndex)
        {
            var lastOne = arrayToSort[endIndex];
            var partIndex = startindex;
            for (int i = startindex; i < endIndex; i++)
            {
                var valueAtPart = arrayToSort[partIndex];
                var valueAtI = arrayToSort[i];
                if (valueAtI < valueAtPart)
                {
                    //swap
                    var temp = valueAtPart;
                    arrayToSort[partIndex] = arrayToSort[i];
                    arrayToSort[i] = temp;
                    partIndex += 1;
                }
            }

            return partIndex;
        }
    }

    public class IntervalListIntersections
    {
        public int[][] FirstIntervals { get; set; }
        public int[][] SecondIntervals { get; set; }
        public IntervalListIntersections()
        {
            
        }

        public void Algorithmn()
        {
            var (i, j, output) = (0, 0, new List<int []>());

            while (i < FirstIntervals.Length && j < SecondIntervals.Length)
            {
                var (startF, endF) = (FirstIntervals[i][0], FirstIntervals[i][1]);
                var (startS, endS) = (SecondIntervals[i][0], SecondIntervals[i][1]);
                //see if they are intersected
                if (startS <= endF && startF >= endS)
                {
                    //get the bnetween values
                    var (maxLeft, minRight) = (Math.Max(startS, startF), Math.Min(endS, endF));
                    output.Add(new []{maxLeft, minRight});

                    if (endF <= endS)
                    {
                        i += 1;
                    }
                    else
                    {
                        j += 1;
                    }
                }

            }
        }
    }
}
