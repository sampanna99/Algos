using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue
{

    //https://stackoverflow.com/questions/184710/what-is-the-difference-between-a-deep-copy-and-a-shallow-copy

    ///todo I like this definition of shadow and deep copy below
    /// I haven't seen a short, easy to understand answer here--so I'll give it a try.
    /// 
    /// With a shallow copy, any object pointed to by the source is also pointed to by the destination (so that no referenced objects are copied).
    /// 
    /// With a deep copy, any object pointed to by the source is copied and the copy is pointed to by the destination (so there will now be 2 of each referenced object).
    /// This recurses down the object tree.
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person Next { get; set; }
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.Age = this.Age;
            //other.Age = new IdInfo(IdInfo.IdNumber);
            ////This is actually a good case to use this deepcopy method. BUt if it doesn't have nested use shallow copy instead
            other.Name = this.Name;
            //other.Name = String.Copy(Name);
            return other;
        }

    }
}
