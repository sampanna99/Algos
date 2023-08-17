using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue.SomeRandomInterviewSampling
{
    public class BaseClass
    {

        public virtual void DoWork()
        {
            Console.WriteLine("do work base");
        }
        public virtual int WorkProperty
        {
            get { return 0; }
        }

        //public void DoWork() { WorkField++;
        //    Console.WriteLine(WorkField);
        //}
        //public int WorkField;
        //public int WorkProperty
        //{
        //    get { return 0; }
        //}
    }
    public class DerivedClass : BaseClass
    {

        public override void DoWork()
        {
            Console.WriteLine("do work DerivedClass");

        }
        public override int WorkProperty
        {
            get { return 0; }
        }

        //public new void DoWork()
        //{
        //    WorkField++;
        //    Console.WriteLine(WorkField);

        //}
        //public new int WorkField;
        //public new int WorkProperty
        //{
        //    get { return 0; }
        //}
    }
    public class DerivedClass2 : DerivedClass
    {

        public override void DoWork()
        {
            base.DoWork();
            Console.WriteLine("do work DerivedClass");

        }
        public override int WorkProperty
        {
            get { return 0; }
        }

        //public new void DoWork()
        //{
        //    WorkField++;
        //    Console.WriteLine(WorkField);

        //}
        //public new int WorkField;
        //public new int WorkProperty
        //{
        //    get { return 0; }
        //}
    }
}
