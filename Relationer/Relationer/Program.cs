using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Relationer.Models;

namespace Relationer
{
    class Program
    {
        static void Main(string[] args)
        {
            RelationContext context = new RelationContext();
            int count = context.Medlemmar.Count();

            if (count == 0)
                AddData(context);

            Console.WriteLine("** Sportklubben **");
            if (context.Medlemmar.Count() > 0)
            {
                Console.WriteLine("Följande medlemmar finns:");
                foreach (MedlemModel m in context.Medlemmar)
                    Console.WriteLine("\t" + m.Namn);
            }
            if (context.Lag.Count() > 0)
            {
                Console.WriteLine("Följande lag finns:");
                foreach (LagModel l in context.Lag)
                    Console.WriteLine("\t" + l.Namn + ", " + l.Sport);
            }
            if (context.Matcher.Count() > 0)
            {
                Console.WriteLine("Följande matcher har spelats:");
                foreach (MatchModel m in context.Matcher)
                    Console.WriteLine("\t" + m.Date.ToShortDateString()
                        + "\t" + m.Lag1.Namn + " mot " + m.Lag2.Namn);
            }

            Console.Write("Program done, press any key to exit");
            Console.ReadKey();
        }
        private static void AddData(RelationContext context)
        {
            MedlemModel m1 = new MedlemModel() { Namn = "Anna" };     // fotboll
            MedlemModel m2 = new MedlemModel() { Namn = "Bertil" };   // fotboll
            MedlemModel m3 = new MedlemModel() { Namn = "Cecilia" };  // biljard
            MedlemModel m4 = new MedlemModel() { Namn = "David" };    // biljard
            LagModel lag1 = new LagModel()
            {
                Namn = "Bara boll",
                Sport = LagModel.SportTyp.Fotboll,
                Medlemmar = new List<MedlemModel>()
            };
            LagModel lag2 = new LagModel()
            {
                Namn = "Rulla rakt",
                Sport = LagModel.SportTyp.Biljard,
                Medlemmar = new List<MedlemModel>()
            };
            MatchModel match1 = new MatchModel() { Date = new DateTime(2016, 4, 30) };
            MatchModel match2 = new MatchModel() { Date = new DateTime(2016, 5, 1) };

            m1.Lag = lag1;
            m2.Lag = lag1;
            m3.Lag = lag2;
            m4.Lag = lag2;
            lag1.Medlemmar.Add(m1);
            lag1.Medlemmar.Add(m2);
            lag2.Medlemmar.Add(m3);
            lag2.Medlemmar.Add(m4);
            match1.Lag1 = lag1;
            match1.Lag2 = lag2;
            match1.Spelare.Add(m1);
            match1.Spelare.Add(m3);
            match2.Lag1 = lag1;
            match2.Lag2 = lag2;
            match2.Spelare.Add(m2);
            match2.Spelare.Add(m4);

            context.Medlemmar.Add(m1);
            context.Medlemmar.Add(m2);
            context.Medlemmar.Add(m3);
            context.Medlemmar.Add(m4);
            context.Lag.Add(lag1);
            context.Lag.Add(lag2);
            context.Matcher.Add(match1);
            context.Matcher.Add(match2);

            context.SaveChanges();

        }
    }
}
