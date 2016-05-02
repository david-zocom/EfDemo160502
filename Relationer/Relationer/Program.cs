using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Relationer.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

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

            Console.WriteLine("** Sportklubben {0} **", count);
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
                {
                    Console.WriteLine("\t" + l.Namn);// + ", " + l.Sport);
                    foreach (MedlemModel mm in l.Medlemmar)
                        Console.WriteLine("\t\t" + mm.Namn);
                }
            }
            if (context.Matcher.Count() > 0)
            {
                Console.WriteLine("Följande matcher har spelats:");
                foreach (MatchModel m in context.Matcher)
                {
                    Console.WriteLine("\t" + m.Date.ToShortDateString()
                        + "\t" + m.Lag1.Namn + " mot "
                        + (m.Lag2 == null ? "ingen" : m.Lag2.Namn));
                    foreach (MedlemModel me in m.Spelare)
                        Console.WriteLine("\t\tSpelare: {0}", me.Namn);
                }
            }

            Console.Write("Program done, press any key to exit  ");
            Console.ReadKey();
        }
        private static void AddData(RelationContext context)
        {
            MedlemModel m1 = new MedlemModel()
            {
                Namn = "Aeris"
            };
            MedlemModel m2 = new MedlemModel()
            {
                Namn = "Barrett"
            };
            MedlemModel m3 = new MedlemModel()
            {
                Namn = "Cloud"
            };
            MedlemModel m4 = new MedlemModel()
            {
                Namn = "Sephiroth"
            };
            LagModel l1 = new LagModel()
            {
                Namn = "alpha",
                Medlemmar = new List<MedlemModel>() { m1, m2, m3 }
            };
            LagModel l2 = new LagModel()
            {
                Namn = "beta",
                Medlemmar = new List<MedlemModel>() { m4 }
            };
            m1.Lag = l1;
            m2.Lag = l1;
            m3.Lag = l1;
            m4.Lag = l2;
            context.Medlemmar.Add(m1);
            context.Medlemmar.Add(m2);
            context.Medlemmar.Add(m3);
            context.Medlemmar.Add(m4);
            context.Lag.Add(l1);
            context.Lag.Add(l2);

            MatchModel mm = new MatchModel()
            {
                Date = new DateTime(2016, 05, 01),
                Lag1 = l1,
                //Lag2 = l2,
                Spelare = new List<MedlemModel>() { m1, m2, m3, m4 },
                AntalMålLag1 = 5,
                AntalMålLag2 = 1
            };
            context.Matcher.Add(mm);
            context.SaveChanges();
        }
        /*
        private static void AddData(RelationContext context)
        {
            KontaktinfoModell k1 = new KontaktinfoModell() { Epost = "a@b.com" };
            KontaktinfoModell k2 = new KontaktinfoModell() { Telefon = "031-12345678" };
            KontaktinfoModell k3 = new KontaktinfoModell() { Epost = "c@d.com" };
            KontaktinfoModell k4 = new KontaktinfoModell() { };

            MedlemModel m1 = new MedlemModel()
            {
                Namn = "Anna",
                Kontaktinfo = k1,
                SpeladeMatcher = new List<MatchModel>()
            };     // fotboll
            MedlemModel m2 = new MedlemModel()
            {
                Namn = "Bertil",
                Kontaktinfo = k2,
                SpeladeMatcher = new List<MatchModel>()
            };   // fotboll
            MedlemModel m3 = new MedlemModel()
            {
                Namn = "Cecilia",
                Kontaktinfo = k3,
                SpeladeMatcher = new List<MatchModel>()
            };  // biljard
            MedlemModel m4 = new MedlemModel()
            {
                Namn = "David",
                Kontaktinfo = k4,
                SpeladeMatcher = new List<MatchModel>()
            };    // biljard

            k1.Medlem = m1;
            k2.Medlem = m2;
            k3.Medlem = m3;
            k4.Medlem = m4;

            LagModel lag1 = new LagModel()
            {
                Namn = "Bara boll",
                Sport = LagModel.SportTyp.Fotboll,
                Medlemmar = new List<MedlemModel>() { m1, m2 }
            };
            LagModel lag2 = new LagModel()
            {
                Namn = "Rulla rakt",
                Sport = LagModel.SportTyp.Biljard,
                Medlemmar = new List<MedlemModel>() { m3, m4 }
            };
            m1.Lag = lag1;
            m2.Lag = lag1;
            m3.Lag = lag2;
            m4.Lag = lag2;

            MatchModel match1 = new MatchModel()
            {
                Date = new DateTime(2016, 4, 30),
                Lag1 = lag1,
                Lag2 = lag2,
                Spelare = new List<Models.MedlemModel> { m1, m3 },
                AntalMålLag1 = 0,
                AntalMålLag2 = 0
            };
            MatchModel match2 = new MatchModel()
            {
                Date = new DateTime(2016, 5, 1),
                Lag1 = lag1,
                Lag2 = lag2,
                Spelare = new List<Models.MedlemModel> { m2, m4 },
                AntalMålLag1 = 2,
                AntalMålLag2 = 1
            };
            //m1.SpeladeMatcher.Add(match1);

            context.Medlemmar.Add(m1);
            context.Medlemmar.Add(m2);
            context.Medlemmar.Add(m3);
            context.Medlemmar.Add(m4);
            context.Kontaktinfo.Add(k1);
            context.Kontaktinfo.Add(k2);
            context.Kontaktinfo.Add(k3);
            context.Kontaktinfo.Add(k4);
            context.Lag.Add(lag1);
            context.Lag.Add(lag2);
            context.Matcher.Add(match1);
            context.Matcher.Add(match2);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                Console.WriteLine("ok");
            }

        }
        */
    }
}
