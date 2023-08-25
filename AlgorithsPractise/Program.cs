using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AlgorithsPractise.AbdulBariLecture;
using AlgorithsPractise.LeetcodeBlind75;
using AlgorithsPractise.SomeTests;
using Newtonsoft.Json;

namespace AlgorithsPractise
{
    //shift + alt + C --> to add class. 
    class Program
    {
        static void Main(string[] args)
        {
            SomestupidTest();
            var aaaa = "abc";
            var sfds = aaaa.Substring(3);
            var sfdss = aaaa[3..];

            var arr = new Int32[2][];
            var ds = arr[1];

            var aaa = 8 / 3;
            var x = 0b_0110;
            var z = 0x_9;
            Console.WriteLine(z);
            var y = ~x;
            Console.WriteLine(y);
            Console.WriteLine(x);
            string dec = Convert.ToString(50, 2);
            var dsa = Convert.ToString(25); //will return 25 not the binary 25
            int b = Convert.ToInt32("0110", 2);

            var chec = 10 ^ 6;
            var logicalAnd = 10 & 6;
            //var shiftbyOne = logicalAnd << 1;

            int dds;
            int dds1;
            while (logicalAnd != 0)
            {
                var shiftbyOne = logicalAnd << 1;
                var logicalor = chec ^ shiftbyOne;
                logicalAnd = chec & shiftbyOne;
                chec = logicalor;
            }

            //SomeOther();

            var one = new List<string>();
            one.Add("fdas");
            one.Add("ffdsaas");
            one.Add("fdafdsas");
            var two = new List<string>();

            var abdc = one;
            two.Add("hh");
            two.Add("dfgs");
            two.Add("fdas");
            one.AddRange(two);


            LeetCodeBlind75();
            //var allconstruct = new AllConstructMemo().GetAllConstruct(null);
            var minimumDistance = new MinimumEditDistance().MinimumChangesRequired();
            var aa = new CanConstructMemo().CanConstructThis(null);
            new NQueensBacktracking().NqueensBacktrack();
            new MergeSort().DoMergeSort();
            var wordLadder = new WordLadder().shortestDIstance();
            //var wba = new WordBreakAlgorithm();
            new MatrixRotation().RotateMatrix();
            Console.WriteLine("Hello World!");
        }

        static void SomeOther()
        {
            new JobSequencingWithBB().BFS();

            new hamiltonianCycleBacktracking().Hamiltonian();
            new GraphColoringBackTracking().GraphColoringProblem();
            new SumOfSubsetBacktracking().SubsetSumBactrackingMethod();
            var nQueenSecondTime = new NQueenSecondTime().NQueen();
            var AP = new ArticulationPoint().GetAP();
            var TarjansAlgorithm = new TarjansAlgorithm().GetSCC();
            var lcs = new LCSDynamicProgramming().FindThemaximumSubstring();
            var reliabilityDesign = new ReliabilityDesign().ReliabilityMax();

            //var stack = new Stack<int>();
            //stack.Push(1);
            //new TravellingSalesPersonDynamicProgramming().TravellingSalesMan(stack);
            //-----------------------
            new TravellingSalesPersonDynamicProgramming().TravellingSalesManDynamicP();

            new AllSubsetsCombination().Backtracking();

            //new OptimalBinarySearchTree().FillTheCostMatrix();

            new MatrixChainMultiPlication().CalculateMinimumMultiplication();

            new AllPairsShortestPath().StartWithThis();

            new MinimmumCostSpanTree().StartWEithThis();
            //new MinimumCostSpanTreeKruskals().StartWithThis();

        }
        static void LeetCodeBlind75()
        {
            //var aa = 100 - 'a';
            //var alienDic = new AlienDictionary().CorrectOrder();
            new CombinationSum().CallForAllCombinations();
            new LISAllPossibilites().IncludeOrnoteach();
            //new LISAllPossibilites().DFS();
            var coin = new CoinChangeUnlimited().startWithThis();
            var allintervals = new InsertInterval().AllIntervals();
            var numberofconnected = new NumberOfConnectedComponents().NUmberOfconnected2();
            var validGraph = new GraphValidTree().ValidTree();
        }

        static string SomestupidTest()
        {

            // dictionary test
            var dictOfChar = new Dictionary<int, List<string>>();
            dictOfChar[1] = new List<string>();
            dictOfChar[1].Add("c");
            // dictionary test

            //------------------------------------hashset dupes
            var hashset = new HashSet<NodeH>();
            var abc = new NodeH { Value = 5 };
            var ghi = new NodeH { Value = 5 };
            var def = abc;
            hashset.Add(abc);
            hashset.Add(def); //does not add 
            hashset.Add(ghi);
            //------------------------------------hashset dupes
            var stringSplit = "/a/b/c";
            var splitIt = stringSplit.Split("/");

            var aan = new int[] { 1, 2, 3, 4 };
            var leng = aan.Length;
            var someportion = aan[0..4]; //4 works but not 5 as array has the last value as sth.


            //-----------modify while iterating the list----------------------------------------
            var len = new List<string>() { "abc", "defg", "dsa" };

            for (int i = 0; i < len.Count; i++)
            {
                len[i] = "dasfdas";
            }
            //-----------modify while iterating the list----------------------------------------

            char a = 'a';
            int c = a;
            var s = 90;
            char sa = (char)s;

            char A = 'A';
            var Matrix = new Int32[2, 2];
            Console.WriteLine(Matrix[0,1]);

            var Dictionary = new Dictionary<Tuple<int, int>, bool>();

            var tup1 = new Tuple<int, int>(1, 1);
            Dictionary.Add(tup1, true);

            var tup2 = new Tuple<int, int>(1, 1);
            var tup3 = new Tuple<int, int>(2, 1);
            if (Dictionary.ContainsKey(tup2))
            {
                Console.WriteLine("Yay");
            }
            else
            {
                Console.WriteLine("Nay");
            }
            if (Dictionary.ContainsKey(tup3))
            {
                Console.WriteLine("Yay");
            }
            else
            {
                Console.WriteLine("Nay");
            }

            var dict2 = new Node() { Value = 2 };
            var dict3 = new Node() { Value = 2 };
            var dict4 = new Node() { Value = 3 };

            var dict5 = new Dictionary<Node, bool>();

            dict5.Add(dict2, true);

            if (dict5.ContainsKey(dict3))
            {
                Console.WriteLine("yay");

            }
            if (dict5.ContainsKey(dict4))
            {
                Console.WriteLine("yay");
            }
            if (dict5.ContainsKey(dict2))
            {
                Console.WriteLine("yay");
            }

            

            var Listfd = new List<string>();
            Listfd.Add("daf");
            Listfd.Add("dafs");
            Listfd.Add("dafe");
            Listfd.Add("dafh");


            while (0 == 0)
            {
                return "fff";
            }
            foreach (var var in Listfd)
            {
                if (var == "dafe")
                {
                    return "found";
                }
            }

            return "nope";
        }
    }
}

//var abcd = new NodeHere();
//abcd = null;
//var abcde = new NodeHere();
//abcde = null;
//if (JsonConvert.SerializeObject(abcd) == JsonConvert.SerializeObject(abcde))
//{
//    Console.WriteLine("They are equal.");
//}

//when you point a variable to an object and change that variable that object is changed
//when you change that variable to point to a new object or null, it will change just that variable the original 
//will remain the same.
//var abcfdsa = new List<NodeHere>();
//for (int i = 0; i < 4; i++)
//{
//    var addThois = new NodeHere
//    {
//        Cost = 10 + i,
//        Upper = 10 - i,
//        ArrayOfAddedThings = new int[i + 1]

//    };
//    abcfdsa.Add(addThois);
//}

//var abcdsa = new NodeHere
//{
//    Cost = 500
//};
//var ghh = abcdsa;
//ghh.Cost = 900;
//ghh = null;

//var l = 0;
//var getValue = abcfdsa[l];
//while (l < 4)
//{

//    if (getValue.Cost < 12)
//    {
//        getValue.Cost = 1000; //it changes to 1000 for the first object.
//        getValue = new NodeHere();

//    }

//    if (getValue == null)
//    {
//        getValue = abcfdsa[l + 1];
//    }
//    l++;
//}



//var aaa = new HeapOfThisThing { VertexName = "a" };
//var bbb = new HeapOfThisThing { VertexName = "z" };

//var gg = aaa;
//aaa = bbb;
//var ss = gg.VertexName; // ss still has the value as "a"



//int das = 10;
//int ddd = das;
//das = 9;


//for (char letter = 'A'; letter <= 'Z'; letter++)
//{
//    Console.WriteLine(letter);
//    Debug.WriteLine(letter);
//    //Debug.WriteLine(letter);
//}

//for (char i = 'a'; i < 'z'; i++)
//{
//    Console.WriteLine(i);
//}

//for (char letter = 'A'; letter <= 'Z'; letter++)
//{
//    Console.WriteLine(letter);
//    Console.WriteLine(letter - 64);
//    Console.WriteLine((int)char.ToLower(letter));
//    Console.WriteLine((int)letter);
//}

//char c = (char)65;
//Console.WriteLine(c);
//char ca = Convert.ToChar(65);
//Console.WriteLine(ca);


//var stack = new Stack<string>();
//stack.Push("a");
//stack.Push("b");
//stack.Push("c");

//var str = stack.ToArray();
//Array.Reverse(str);