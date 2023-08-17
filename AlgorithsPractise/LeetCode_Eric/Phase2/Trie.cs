using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase2
{
    public class Trie
    {

    }

    //tbh I actually went through many videos and understood. I watched tushar's video in youtube
    //to understand trie
    public class MapSum
    {
        public TrieDt RootTree { get; set; }
        public String[] GivenStrings { get; set; }
        public string[][] ArrayOfArrays { get; set; }

        public Dictionary<string, int> AlreadyaddedString { get; set; }
        public MapSum()
        {
            GivenStrings = new[]
            {
                "MapSum",
                "insert",
                "sum",
                "insert",
                "sum"
            };
            AlreadyaddedString = new Dictionary<string, int>();
            ArrayOfArrays = new[]
            {
                Array.Empty<string>(),
                new[]
                {
                    "apple", "3"
                },
                new[]
                {
                    "ap"
                },
                new[]
                {
                    "app", "2"
                },
                new[]
                {
                    "ap"
                }
            };
            RootTree = new TrieDt();

            //ArrayOfArrays = new[] { new[] { "ss", "1" } };
            //ArrayOfArrays = new string[2][];

            //ArrayOfArrays1 = new[]
            //{
            //    new[,]
            //    {
            //        { "1", "2" },
            //        { "3", "5" }
            //    }
            //};
        }


        public void Algorithmn()
        {
            foreach (var arrayOfArray in ArrayOfArrays)
            {
                if (arrayOfArray.Length > 0)
                {

                    if (arrayOfArray.Length == 2)
                    {
                        var value = Convert.ToInt32(arrayOfArray[1]);
                        //add
                        if (AlreadyaddedString.ContainsKey(arrayOfArray[0]))
                        {
                            //update the value
                            Insert(arrayOfArray, true);
                            AlreadyaddedString.Add(arrayOfArray[0], value);
                        }
                        else
                        {
                            //add the value
                            AlreadyaddedString.Add(arrayOfArray[0], value);
                            Insert(arrayOfArray, false);
                        }
                    }
                    else
                    {
                        //find
                        Search(arrayOfArray[0]);
                    }
                }
            }
        }
        public void Insert(string[] addThis, bool doUpdate)
        {
            var subtract = doUpdate ? AlreadyaddedString[addThis[0]] : 0;
            var trieDummy = RootTree;
            var value = Convert.ToInt32(addThis[1]);

            foreach (var eachChar in addThis[0])
            {
                var stringEachChar = eachChar.ToString();
                if (trieDummy.IncludedTre.ContainsKey(stringEachChar))
                {
                    var curVal = trieDummy.IncludedTre[stringEachChar].Value;
                    trieDummy.IncludedTre[stringEachChar].Value = curVal + value - subtract;
                }
                else
                {
                    trieDummy.IncludedTre.Add(stringEachChar, new TrieDt());
                    //trieDummy.Value = value;
                    trieDummy.IncludedTre[stringEachChar].Value = value;
                }

                trieDummy = trieDummy.IncludedTre[stringEachChar];
            }
        }

        public int Search(string searchVal)
        {
            var dummyTrie = RootTree;
            var toReturn = 0;

            foreach (var eachChar in searchVal)
            {
                var charToStr = eachChar.ToString();
                toReturn = dummyTrie.IncludedTre[charToStr].Value;
                dummyTrie = dummyTrie.IncludedTre[charToStr];
            }

            return toReturn;
        }
    }
    public class TrieDt
    {
        public Dictionary<string, TrieDt> IncludedTre { get; set; }
        public int Value { get; set; }

        public TrieDt()
        {
            IncludedTre = new Dictionary<string, TrieDt>();
        }
    }

    public class TrieDtS : TrieDt
    {
        public new Dictionary<string, TrieDtS> IncludedTre { get; set; }

        public new string Value { get; set; }

        public TrieDtS()
        {
            IncludedTre = new Dictionary<string, TrieDtS>();
        }
    }


    //https://www.youtube.com/watch?v=SJmYTJEVa_U
    //tbh I actually went through many videos and understood. I watched tushar's video in youtube
    //to understand trie
    public class DesignInMemoryFileSystem
    {
        public string[][] GivenArrayOfString { get; set; }
        public TrieDtS RootTrie { get; set; }
        public string[] ThingsToDo { get; set; }
        public DesignInMemoryFileSystem()
        {
            GivenArrayOfString = new[]
            {
                Array.Empty<string>(),
                new []{"/"},
                new[] { "/a/b/c" },
                new[] { "/a/b/c/d", "hello" },
                new[] { "/" },
                new[] { "/a/b/c/d" }
            };
            RootTrie = new TrieDtS();
            ThingsToDo = new[]
            {
                "FileSystem",
                "ls",
                "mkdir",
                "addContentToFile",
                "ls",
                "readContentFromFile"
            };

        }
        public void Algorithmn()
        {
            for (int i = 1; i < ThingsToDo.Length; i++)
            {
                switch (ThingsToDo[i])
                {
                    case "ls":
                        GetContentsInDirectory(GivenArrayOfString[i][0]);
                        break;

                    case "mkdir":
                        AddDirectory(GivenArrayOfString[i][0]);
                        break;   
                    
                    case "addContentToFile":
                        AddAndReadContent(GivenArrayOfString[i][0], GivenArrayOfString[i][1]);
                        break;

                    case "readContentFromFile":
                        AddAndReadContent(GivenArrayOfString[i][0]);
                        break;

                }
            }
        }

        private void AddDirectory(string location)
        {
            var split = location.Split("/");
            var dummy = RootTrie;
            for (int i = 1; i < split.Length; i++)
            {
                var value = split[i];
                if (!dummy.IncludedTre.ContainsKey(value))
                {
                    dummy.IncludedTre.Add(value, new TrieDtS());
                }

                dummy = dummy.IncludedTre[value];

            }
        }

        private string[] GetContentsInDirectory(string location)
        {
            var split = location.Split("/");
            var dummy = RootTrie;


            for (int i = 0; i < split.Length; i++)
            {
                var value = split[i];
                dummy = dummy.IncludedTre[value];
            }

            var returnValues = new List<string>();
            foreach (var keyValues in dummy.IncludedTre)
            {
                returnValues.Add(keyValues.Key);
            }

            return returnValues.ToArray();
        }

        private string AddAndReadContent(string location, string valueToAdd = null)
        {
            var split = location.Split("/");
            var dummy = RootTrie;
            for (int i = 0; i < split.Length; i++)
            {
                var value = split[i];
                dummy = dummy.IncludedTre[value];
            }

            if (valueToAdd != null)
            {
                dummy.Value += valueToAdd;
            }

            return dummy.Value;
        }
    }


}
