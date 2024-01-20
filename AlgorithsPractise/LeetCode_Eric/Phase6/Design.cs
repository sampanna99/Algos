using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase6
{
    public class Design
    {

        public Design()
        {

        }
    }


    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }

    public class NodeB : Node
    {
        public int Frequency { get; set; }
        public new NodeB Next { get; set; }
        public new NodeB Prev { get; set; }

    }
    public class DoublyLinkedList : NodeB
    {
        public NodeB Head { get; set; }
        public NodeB Tail { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }
    }

    public class NewNode : Node
    {
        public new string Value;
        public new NewNode Next;
        public new NewNode Prev;
    }
    public class LRUCache
    {
        public string[] Names { get; set; }
        public int[][] ArrayOfArrays { get; set; }
        public int NumberOfCacheAtATime { get; set; }
        public LRUCache()
        {
            
        }


        private void UpdateHeadAndTail()
        {

        }
        public void Algorithmn()
        {
            //Need doubly linked list
            Node head = null;
            Node tail = null;

            var ans = new int?[ArrayOfArrays.Length];

            var dictionary = new Dictionary<int, Node>();
            for (int i = 0; i < Names.Length; i++)
            {
                switch (Names[i].ToUpper())
                {
                    case "PUT":
                        var valueInPlay = ArrayOfArrays[i][1];
                        var keyInPlay = ArrayOfArrays[i][1];
                        ans[i] = valueInPlay;
                        if (dictionary.Count >= NumberOfCacheAtATime)
                        {
                            //find the tail and remove it; delete from Dictionary as well;
                            //new head with This value; next of head is what head is now;
                            if (!dictionary.ContainsKey(keyInPlay))
                            {
                                var nodeToAdd = new Node { Value = valueInPlay };
                                var tailVal = tail.Value;

                                var tailPrev1 = tail.Prev;
                                tail = tailPrev1 ?? nodeToAdd;
                                dictionary.Remove(tailVal);

                                nodeToAdd.Next = head;
                                if (head != null)
                                {
                                    head.Prev = nodeToAdd;
                                }
                                head = nodeToAdd;

                                dictionary.Add(keyInPlay, nodeToAdd);
                            }
                            else
                            {
                                //update the first value
                                var nodeToMoveFirst = dictionary[keyInPlay];

                                var prev = nodeToMoveFirst.Prev;
                                var next = nodeToMoveFirst.Next;

                                //somewhere in the middle
                                if (next != null && prev != null)
                                {
                                    next.Prev = prev;
                                    prev.Next = next;
                                }
                                //means at the end or first
                                else
                                {
                                    //issa tail. next is auto null
                                    if (prev != null)
                                    //if (prev != null && next == null)
                                    {
                                        prev.Next = next;
                                    }
                                    tail = prev ?? nodeToMoveFirst;
                                }
                                //now make it first
                                if (head != null && head != nodeToMoveFirst)
                                {
                                    head.Prev = nodeToMoveFirst;
                                    nodeToMoveFirst.Next = head;
                                }

                                //just the update part
                                nodeToMoveFirst.Value = valueInPlay;
                                //just the update part
                                head = nodeToMoveFirst;
                            }
                        }
                        else
                        {
                            //create a node and head is that
                            var node = new Node { Value = valueInPlay };
                            if (head != null)
                            {
                                node.Next = head;
                                head.Prev = node;
                            }

                            head = node;
                            //this means if tail == null then tail = node
                            tail ??= node;
                        }
                        break;
                    case "GET":
                        var keyInPlay1 = ArrayOfArrays[i][1];

                        //same as putting when value is present
                        if (!dictionary.ContainsKey(keyInPlay1))
                        {
                            ans[i] = -1;
                            continue;
                        }
                        var getTheNBode = dictionary[keyInPlay1];
                        //middle or at the extreme
                        var prevG = getTheNBode.Prev;
                        var nextG = getTheNBode.Next;

                        if (prevG != null && nextG != null)
                        {
                            prevG.Next = nextG;
                            nextG.Prev = prevG;
                        }
                        else
                        {
                            //automatically means next is null. AKA last
                            if (prevG != null)
                            {
                                prevG.Next = null;
                                tail = prevG;
                            }
                        }

                        if (head != getTheNBode)
                        {
                            head.Prev = getTheNBode;
                            getTheNBode.Next = head;
                        }

                        ans[i] = getTheNBode.Value;
                        break;
                    case "LRUCACHE":
                        NumberOfCacheAtATime = ArrayOfArrays[i][0];
                        ans[i] = null;
                        break;
                }
            }

        }
    }

    public class InsertDeleteGetRandom
    {
        public string[] GivenInputs { get; set; }
        public int[][] GivenArrayofArrays { get; set; }

        public InsertDeleteGetRandom()
        {
            
        }

        public void Algorithmn()
        {
            //go through each GivenInputs
            //get in o1, insert in o1, remove in o1. AKA dictionary

            var answerArray = new List<dynamic>();
            var list = new List<int>();
            //answerArray.Add(1);
            //answerArray.Add(true);
            //answerArray.Add("das");
            var hashset = new Dictionary<int, int>();
            //var hashset = new HashSet<int>();
            
            for (int i = 0; i < GivenInputs.Length; i++)
            {
                switch (GivenInputs[i].ToUpper())
                {
                    case "INSERT":
                        var length = GivenArrayofArrays[i].Length;

                        if (length > 0)
                        {
                            var value = GivenArrayofArrays[i][0];
                            if (hashset.ContainsKey(value))
                            {
                                answerArray.Add(false);
                            }
                            else
                            {
                                list.Add(value);
                                hashset.Add(value, list.Count - 1);
                                answerArray.Add(true);
                            }
                        }
                        break;
                    case "REMOVE":
                        var valueToRemove = GivenArrayofArrays[i][0];
                        if (hashset.ContainsKey(valueToRemove))
                        {
                            //value to remove
                            //get index of the list (value to remove)
                            //get last value of the list
                            //remove from dictionary
                            //in the index(value removed) add the lst value 
                            //remove last value
                            //update the dictionary for that value to point at the position

                            var indexForTheList = hashset[valueToRemove];
                            var lastValue = list[^1];
                            hashset.Remove(valueToRemove);
                            list[indexForTheList] = lastValue;
                            list.RemoveAt(list.Count - 1);
                            if (hashset.ContainsKey(lastValue))
                            {
                                hashset[lastValue] = indexForTheList;
                            }
                            answerArray.Add(true);
                        }
                        else
                        {
                            answerArray.Add(false);
                        }
                        break;
                    case "GETRANDOM":
                        var random = new Random();
                        var valueOnRandomIndex = random.Next(0, list.Count - 1);
                        var valueAct = list[valueOnRandomIndex];
                        answerArray.Add(valueAct);
                        break;

                }
            }
        }
    }

    public class DesignBrowserHistory
    {
        public NewNode Head { get; set; }
        public NewNode Tail { get; set; }
        public NewNode Current { get; set; }
        public DesignBrowserHistory()
        {
            Head = new NewNode();
            Current = Head;
            Tail = Head;
        }

        private void BrowserHistory(string homepage)
        {
            Head = new NewNode()
            {
                Value = homepage
            };
            Tail = Head;
            Current = Head;
        }

        private void Visit(string url)
        {
            var newNode = new NewNode
            {
                Value = url
            };
            var currentNode = Current;
            Current = newNode;
            if (currentNode.Next != null)
            {
                currentNode.Next.Prev = null;
            }

            currentNode.Next = Current;
            Current.Prev = currentNode;
            Tail = Current;
        }

        private void MoveForward(int steps)
        {
            var currNode = Current;

            for (int i = 0; i < steps; i++)
            {
                if (currNode.Next == null)
                {
                    break;
                }
                currNode = currNode.Next;
            }

            Current = currNode;
        }

        private void MoveBackWard(int steps)
        {
            var currentNode = Current;

            for (int i = 0; i < steps; i++)
            {
                if (currentNode.Prev == null)
                {
                    break;
                }
                currentNode = currentNode.Prev;
            }

            Current = currentNode;
        }
        public void Algorithmn()
        {
            //when visit head points to a new Node
            //when forward it points to a child and child pojts back to parent. Also need tail and current.

           
        }
    }

    public class LFUCache
    {
        public string[] Operations { get; set; }
        public int[][] Items { get; set; }
        public int MaximumAllowed { get; set; }
        public Dictionary<int, NodeB> KeyToNodeMap { get; set; }
        public Dictionary<int, DoublyLinkedList> FrequencyToDoublyLiked { get; set; }

        public void Algorithmns()
        {
            //dictionary for the key --> (val, numberOfTimes)
        }

        private void Put(int key, int value)
        {
            //deletes one and add or updates the frequency
            if (KeyToNodeMap.ContainsKey(key))
            {
                //Means we gotta update the frequency
                KeyToNodeMap[key].Frequency += 1;
                KeyToNodeMap[key].Value = value;
            }
            else
            {
                //TODO: DO check to see if the maximum amount that is given is used or not first
                //Means delete the least occuring frequency. And add this to the 1 frequency

                if (KeyToNodeMap.Count >= MaximumAllowed)
                {
                    var smallest = FrequencyToDoublyLiked.Min(a => a.Key);

                    var doublyOne = FrequencyToDoublyLiked[smallest];
                    DeleteNode(doublyOne, key, smallest);
                    var node = new NodeB()
                    {
                        Value = value,
                        Frequency = 1
                    };
                    KeyToNodeMap.Add(key, node);
                    CreateFrequencyNode(node, 1);
                    //Add it in frequency As well
                }
                else
                {
                    var node = new NodeB()
                    {
                        Value = value,
                        Frequency = 1
                    };
                    KeyToNodeMap.Add(key, node);
                    CreateFrequencyNode(node, 1);
                }
            }
        }

        private int Get(int key)
        {
            //
            if (KeyToNodeMap.ContainsKey(key))
            {
                var findNode = KeyToNodeMap[key];

                var findItFromFrequencymap = FrequencyToDoublyLiked[findNode.Frequency];
                DeleteNode(findItFromFrequencymap, key, findItFromFrequencymap.Frequency);
                KeyToNodeMap.Add(key, findNode);
                findNode.Frequency += 1;
                CreateFrequencyNode(findNode, findNode.Frequency);
                return findNode.Value;
            }
            else
            {
                return -1;
            }
        }

        private void DeleteNode(DoublyLinkedList dL, int key, int keyForDoubly)
        {
            //prev should point to next

            var dummyPointer = dL;
            //if prev is null and next is null just delete the whole thing
            if (dummyPointer.Next == null && dummyPointer.Prev == null)
            {
                //delete from KeyToNodeMap
                FrequencyToDoublyLiked.Remove(keyForDoubly);
            }
            //if just prev is null; Head = next and next.prev = null
            else if (dummyPointer.Prev == null)
            {
                dummyPointer.Head = dummyPointer.Next;
                dummyPointer.Next.Prev = dummyPointer.Head;
            }
            else if (dummyPointer.Next == null)
            {
                //if just next is null; prev.Next = curr.Next
                dummyPointer.Prev.Next = dummyPointer.Next;
                dummyPointer.Tail = dummyPointer.Prev;
            }
            else
            {
                dummyPointer.Prev.Next = dummyPointer.Next;
                dummyPointer.Next.Prev = dummyPointer.Prev;
            }
            KeyToNodeMap.Remove(key);
        }


        //Create a doubly Linked List with frequency of 1
        //and create a map in Key to node as well. the frequency is 1;
        private void CreateFrequencyNode(NodeB node, int frequency)
        {
            var doubly = new DoublyLinkedList();
            if (FrequencyToDoublyLiked.ContainsKey(frequency))
            {
                doubly = FrequencyToDoublyLiked[frequency];
                
            }
            else
            {
                FrequencyToDoublyLiked.Add(frequency, doubly);
            }

            var currHead = doubly.Head;

            if (currHead != null)
            {
                doubly.Head = node;
                node.Next = currHead;
                currHead.Prev = node;
            }
            else
            {
                doubly.Head = node;
                doubly.Tail = node;
            }
        }
    }
}
