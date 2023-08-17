using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue
{
    public class Calling
    {
        public Person callperson()
        {
            Console.WriteLine("Inside Class");
            var abc = new Person
            {
                Age = 28,
                Name = "Sam"
            };
            var str = "Mynameissam";

            Console.WriteLine("abc" + abc.Age + abc.Name);
            var str1 = str;
            str1 = "teeee";

            Console.WriteLine(str);
            Console.WriteLine(str1);
            //doesn't work'
            Person def = (Person)this.MemberwiseClone();

            def.Age = 29;
            def.Name = "Rich boy";

            Console.WriteLine("abc" + abc.Age + abc.Name);
            Console.WriteLine("def" + def.Age + def.Name);

            return null;
        }
    }
}
