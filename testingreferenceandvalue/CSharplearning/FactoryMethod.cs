using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue.CSharplearning
{

    //https://www.dofactory.com/net/factory-method-design-pattern
    //instead of Document
    abstract class FactoryMethod
    {
        private List<Page> _pages = new List<Page>();
        // Constructor calls abstract Factory method
        public FactoryMethod()
        {
            this.CreatePages();
        }
        public List<Page> Pages
        {
            get { return _pages; }
        }
        // Factory Method
        public abstract void CreatePages();
    }

    abstract class Page
    {
    }

    class Resume : FactoryMethod
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }


    class SkillsPage : Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class EducationPage : Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ExperiencePage : Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class IntroductionPage : Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ResultsPage : Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConclusionPage : Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class SummaryPage : Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class BibliographyPage : Page
    {
    }

}
