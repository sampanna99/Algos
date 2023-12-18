using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.NotAlgo
{
    public class SomeInheritanceTest
    {
    }

    public class BaseClass
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
    }

    public class DerivedClass : BaseClass
    {
        public string Middlename { get; set; }
    }
}
