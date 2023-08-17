using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class ReliabilityDesign
    {
        public List<Item> Items { get; set; }
        public int TotalMoney { get; set; } = 105;
        public int NeededToBuyAllAtLeastOnce { get; set; }
        public ReliabilityDesign()
        {
            Items = new List<Item>();
            Initialize();
        }

        private void Initialize()
        {
            Items.Add(new Item{ItemName = "1", Probability = 0.9f, Cost = 30});
            Items.Add(new Item{ItemName = "2", Probability = 0.8f, Cost = 15});
            Items.Add(new Item{ItemName = "3", Probability = 0.5f, Cost = 20});
        }

        //string being comma separated for 1, 2, 3
        public Tuple<float, string> ReliabilityMax()
        {
            ModifyToaccomodateMax();

            var hs = new HashSet<References>();
            //could add many times.
            //hs.Add(new References { Reliability = 1, Cost = 1 });
            //hs.Add(new References { Reliability = 1, Cost = 1 });
            //hs.Add(new References { Reliability = 1, Cost = 1 });
            //hs.Add(new References { Reliability = 1, Cost = 1 });
            //three diffrent;
            //var hs = new HashSet<Tuple<float, int>>();
            //hs.Add(Tuple.Create(1, "sad"));
            //hs.Add(Tuple.Create(2, "sad"));
            //hs.Add(Tuple.Create(1, "sasd"));
            //hs.Add(Tuple.Create(1f, 0));
            hs.Add(new References { Cost = 0, Reliability = 1, ItemId = 0});

            foreach (var item in Items)
            {
                var NameToInt = Convert.ToInt32(item.ItemName);
                
                //had to do ToList() as adding to hs wasn't supported while on Ienumerable
                var allprevious = hs.Where(a => a.ItemId == NameToInt - 1).ToList();
                for (int i = 1; i <= item.MaximumThereCouldBe; i++)
                {
                    //check if it isviable.
                    foreach (var allpreviou in allprevious)
                    {
                        var isViable = IsViabvle(NameToInt, i, allpreviou.Cost);

                        if (isViable)
                        {
                            hs.Add(new References
                            {
                                Cost = allpreviou.Cost + i * Items[NameToInt - 1].Cost,
                                Reliability = CalculateReliability(i, Items[NameToInt - 1].Probability)
                                              * allpreviou.Reliability,
                                ItemId = NameToInt,
                                WhichOneIsMultiplied = allpreviou
                            });
                        }
                    }
                }
            }



            var whichisSmallest = hs.Where(a => a.ItemId == 3)
                .OrderByDescending(a => a.Reliability).FirstOrDefault();

            //Loop through whichisSmallest's whichOneisMultipliedproperty to get all the multiplied ones.
            return new Tuple<float, string>(whichisSmallest.Reliability, whichisSmallest.ItemId.ToString());
            return null;
        }

        private float CalculateReliability(int number, float reliability)
        {
            var value =  1 - Math.Pow(1 - reliability, number);
            return (float)value;
        }

        private bool IsViabvle(int CheckAfterThis, int numberOfThis, int numberBefore)
        {
            var remainingMoney = TotalMoney - (numberBefore + numberOfThis * Items[CheckAfterThis - 1].Cost);

            for (int i = CheckAfterThis; i < Items.Count; i++)
            {
                remainingMoney -= Items[i].Cost;
            }
            
            return remainingMoney >= 0 ? true : false;
        }

        private void ModifyToaccomodateMax()
        {
            var allOnce = Items.Select(a => a.Cost).Sum();
            NeededToBuyAllAtLeastOnce = allOnce;
            var remainingMoney = TotalMoney - allOnce;
            for (int i = 0; i < Items.Count; i++)
            {
                var remainingInsideMoney = remainingMoney;
                while (remainingInsideMoney > Items[i].Cost)
                {
                    Items[i].MaximumThereCouldBe += 1;
                    remainingInsideMoney -= Items[i].Cost;
                }
            }
        }

    }

    public class References
    {
        public int ItemId { get; set; }
        public float Reliability { get; set; }
        public int Cost { get; set; }
        public References WhichOneIsMultiplied { get; set; }
    }
    public class Item
    {
        public string ItemName { get; set; }
        public float Probability { get; set; }
        public int Cost { get; set; }
        public int MaximumThereCouldBe { get; set; } = 1;
    }
}
