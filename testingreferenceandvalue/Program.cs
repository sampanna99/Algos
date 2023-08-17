using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using testingreferenceandvalue.Algos;
using testingreferenceandvalue.CopiedFromSolutionTounderstand;
using testingreferenceandvalue.MycodeSchool;
using testingreferenceandvalue.Someproblems;
using testingreferenceandvalue.SomeRandomInterviewSampling;
using testingreferenceandvalue.Sorts;

namespace testingreferenceandvalue
{
    class Program
    {
        static void Main(string[] args)
        {

            //test
            int[,] aa = new int[5,5];
            Console.WriteLine(aa[1, 1]);
            
            //test

            var array = new int[]{1,5,2,6,9,7,8};
            var merge = Merge.mergeSort(array);



            int[,] a = new int[5, 2] { { 0, 0 }, { 1, 2 }, { 2, 4 }, { 3, 6 }, { 4, 8 } };
            new leetcode().rotate(a);
            var sss = a.Length;
            
            linkedListReferenceTest();
            //TestBinaryTree();

            //polymorphism();
            //shallowdeep();

            //Stack<int> stk = new Stack<int>();
            //bool[,] array = new bool[1, 3];
            //stk.Push(-1);
            //TODO: Inorder predecessor and successor for a given key in BST
            //InorderPredecessorAndSuccessor.Main1PreorderSucc(null);
            //TODO: Inorder predecessor and successor for a given key in BST

            //callAllcopiedfromhere();
            //Todo: Testing Binary tree
            //http://csharpexamples.com/c-binary-search-tree-implementation/
            TestingLinkedlistandstuff();
            //Todo: Testing Binary tree
            MedianofTwosortedArrays();
            Console.WriteLine("Hello World!");
            TestingLinkedlistandstuff();


            //var aa = new Calling().callperson();


        }

        //For new things
        static void Main2()
        {
            //circular array algos.
            int[] array = { 12,14,18,21,3,6,8,9};
            var circular = new CircularArray().CircularArraySearch(array, array.Length, 3);
            //FYI don't work in duplicate values in arrays.
            Console.WriteLine(circular); // this is finding the elemen t in a circullar sorted array.

        }
        static void shallowdeep()
        {
            var abc = new Person
            {
                Age = 28,
                Name = "Sam"
            };
            var str = "Mynameissam";
            var abc2 = abc;

            Console.WriteLine("abc" + abc.Age + abc.Name);
            var str1 = str;
            str1 = "teeee";

            Console.WriteLine(str);
            Console.WriteLine(str1);
            //Person def = abc;
            Person def = abc.DeepCopy();
            Person ghi = abc.ShallowCopy();

            abc.Age = 700;
            abc.Name = "Testing";

            def.Age = 29;
            def.Name = "Rich boy";

            ghi.Age = 30;
            ghi.Name = "happy";

            Console.WriteLine("abc" + abc.Age + abc.Name);
            Console.WriteLine("abc2" + abc2.Age + abc2.Name);
            Console.WriteLine("def" + def.Age + def.Name);
            Console.WriteLine("ghi" + ghi.Age + ghi.Name);

        }

        static void polymorphism()
        {
            DerivedClass2 D2 = new DerivedClass2();
            D2.DoWork();

            DerivedClass B = new DerivedClass();
            B.DoWork();  // Calls the new method.

            BaseClass A = B; //This and below is the same.
            //BaseClass A = (BaseClass)B;
            A.DoWork();  // Calls the old method. for new keyword 
        }
        static void somefunc(out int insidevar)
        {
            insidevar = 20;
            insidevar = insidevar + 10;
        }


        static void MedianofTwosortedArrays()
        {
            int[] A = { 900 };
            int[] B = { 5, 8, 10, 20 };

            int N = A.Length;
            int M = B.Length;

            Console.WriteLine(MedianOfTwoSorted.findMedian(A, N, B, M));
        }
        static void TestBinaryTree()
        {

            TestBinaryTree binaryTree = new TestBinaryTree();

            //binaryTree.Add(1);
            //binaryTree.Add(2);
            binaryTree.Add(3);
            binaryTree.Add(2);
            binaryTree.Add(1);
            binaryTree.Add(7);
            //binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);

            Node node = binaryTree.Find(5);
            int depth = binaryTree.GetTreeDepth();

            Console.WriteLine("PreOrder Traversal:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:");
            binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:");
            binaryTree.TraversePostOrder(binaryTree.Root);
            Console.WriteLine();

            binaryTree.Remove(7);
            binaryTree.Remove(8);

            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.ReadLine();
        }
        static void TestingLinkedlistandstuff()
        {
            var abc = new Person
            {
                Age = 29,
                Name = "Sampanna"
            };
            var abc2 = new Person
            {
                Age = 28,
                Name = "Sam2",
                Next = abc
                
            };
            var abc3 = new Person
            {
                Age = 29,
                Name = "Sam3"
            };

            abc3.Next = abc2.Next; //abc

            abc2.Next = abc3; //abc
            //abc2.Next = null;

            var tes = abc.Age;

            var abcd = abc;

            abcd.Age = 500;
            abc.Age = 45;
            //abc = null;
            outvariabletest(abcd);

            abc.Age = 35;

            Console.WriteLine(tes);

        }

        static void FuncChnage(Person ds)
        {
            ds = new Person();
            ds.Age = 5000;
            //var dsfa = ds;
            //dsfa.Age = 09;
            //ds.Age = 8000;
        }
        static void linkedListReferenceTest()
        {
            var abc = new Person
            {
                Age = 29,
                Name = "Sampanna"
            };
            FuncChnage(abc);
            var abc2 = new Person
            {
                Age = 28,
                Name = "Sam2",
                Next = abc

            };
            var abcprev = new Person
            {
                Age = 30,
                Name = "Sam2",
                Next = abc

            };
            var abc3 = new Person
            {
                Age = 29,
                Name = "Sam3"
            };
            var abc4 = new Person
            {
                Name = "df",
                Age = 88
            };


            abc4.Age = abc3.Age;

            abc3.Age = 90;

            var name = "dfa";

            var abc333 = new Person
            {
                Age = 30,
                Name = name
            };
            name = "changed";

            Console.WriteLine(abc333.Name);


            abc4 = abc2.Next; //abc
            abc2.Next = abcprev;
            abc = abc2;
            abc2 = abc4;
        }
        static void outvariabletest(Person outreftest)
        {
            outreftest.Age = 100;
        }
        static void callAllcopiedfromhere()
        {
            //int[] A = { 2, 5, 3, 7, 11, 8, 10, 13, 6 };
            //int n = A.Length;
            //Console.Write("Length of Longest "
            //              + "Increasing Subsequence is " + AscendingLargetSubarrayNLogn.LongestIncreasingSubsequenceLength(A, n));


            //Second one

            int[] X = { 3, 1, 5, 0, 6, 4, 9, 10, 7, 20, 13, 11, 12 };
            //int[] X = { 3, 1, 5, 0, 6, 4, 9, 10, 7, 0, 20, 13, 11, 12 };
            //int[] X = { 3, 1, 5, 0, 6, 4, 9 };
            AscendingLargetSubarrayNLogn.Myself(X);
            //AscendingLargetSubarrayNLogn.LIS(X);

        }
    }
}
