using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public interface IParadigm
    {
        void ParadigmType();
    }

    public class OOP : IParadigm
    {
        public void ParadigmType()
        {
            Console.WriteLine("Object Oriented");
        }
    }
    public class Procedural : IParadigm
    {
        public void ParadigmType()
        {
            Console.WriteLine("Procedural");
        }
    }

    public class Heterogeneous : IParadigm
    {
        List<IParadigm> paradigms;

        public Heterogeneous(List<IParadigm> paradigms)
        {
            Paradigms = paradigms;
        }

        public List<IParadigm> Paradigms { get => paradigms; set => paradigms = value; }

        public void ParadigmType()
        {
            foreach (var paradigm in Paradigms)
            {
                paradigm.ParadigmType();
            }
        }
    }

    public interface IProgLang
    {
        IParadigm Paradigm { get; set; }
        void LanguageType();
    }
    public class C : IProgLang
    {
        public C(IParadigm paradigm)
        {
            Paradigm = paradigm;
        }

        public IParadigm Paradigm { get; set; }
    
        public void LanguageType()
        {
            Console.WriteLine("C is a");
            Paradigm.ParadigmType();
        }
    }

    public class CPP : IProgLang
    {
        public CPP(IParadigm paradigm)
        {
            Paradigm = paradigm;
        }

        public IParadigm Paradigm { get; set; }

        public void LanguageType()
        {
            Console.WriteLine("C++ is a");
            Paradigm.ParadigmType();
        }
    }
    public class Java : IProgLang
    {
        public Java(IParadigm paradigm)
        {
            Paradigm = paradigm;
        }

        public IParadigm Paradigm { get; set; }

        public void LanguageType()
        {
            Console.WriteLine("Java is a");
            Paradigm.ParadigmType();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IParadigm> paradigms = new List<IParadigm>();
            paradigms.Add(new OOP());
            paradigms.Add(new Procedural());
            IParadigm paradigm = new Heterogeneous(paradigms);
            IProgLang progLang = new CPP(paradigm);
            progLang.LanguageType();
            progLang = new C(paradigms[1]);
            progLang.LanguageType();
            Console.ReadLine();
        }
    }
}
