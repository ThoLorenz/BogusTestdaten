using Bogus;
using System;
using System.Collections.Generic;
using Bogus.Extensions;
 
namespace BogusTestdaten
{
    public class Program
    {
        public static List<string> dienstgradeList = new List<string>()
            {"POM", "PM", "PK", "POK", "PHK", "EPHK", "PR", "POR"};
 
        public static List<string> dienststellenList = new List<string>()
            {"Dir 5", "Dir 1", "Dir 2", "Dir 3", "Dir 4", "SE IKT", "PPr"};
 
        public static List<string> DienststelleZusatzList = new List<string>() { " C 41", "B 32", "A 55", "Dir Hu 2" };
 
        private static void Main(string[] args)
        {
            var testDienststellen = new Faker<Dienststelle>()
                .StrictMode(false)
                .RuleFor(x => x.Id, r => r.Random.Int(1, Int32.MaxValue))
                .RuleFor(x => x.IstAktiv, r => r.Random.Bool())
                // Lorem-Text mit Anzahl der Wörter
                .RuleFor(x => x.Bemerkung, f => f.Lorem.Sentence(12))
                .RuleFor(x => x.Name,
                    r => r.PickRandom(dienststellenList) + " " + r.PickRandom(DienststelleZusatzList))
                .RuleFor(x => x.Url, (f, u) => f.Internet.Email(u.Name, string.Empty
                ));
            Dienststelle dst = testDienststellen.Generate();
 
            // Eine Adresse
            var address = new Faker<Adresse>()
                .RuleFor(x => x.Id, r => r.Random.Int())
                .RuleFor(x => x.Latitude, r => r.Address.Latitude())
                .RuleFor(x => x.Longitude, r => r.Address.Longitude())
                 // NaughtyStrings Extension
                .RuleFor(x => x.Bemerkung, r => r.Naughty().SQLInjection())
                .RuleFor(x => x.Stadt, r => r.Address.City());
            Adresse adresse = address.Generate();
            dst.Adresse = adresse;
 
            // Liste von 20 Mitarbeitern
            var idMitarbeiter = 1;
            Random random = new Random();
            int randomNumber = random.Next(6, 12);
            var testMitarbeiterListe = new Faker<Mitarbeiter>()
                // StrictMode : true > alle Properties müssen gefüllt werden
                .StrictMode(false)
                // Erstellt bei jedem Durchlauf die selben Daten
                //.UseSeed(999)
                .RuleFor(x => x.Dienststelle, r => dst)
                // Id soll fortlaufend bei 1 starten (zusätzliche Variable erstellen)
                .RuleFor(x => x.Id, r => idMitarbeiter++)
                .RuleFor(x => x.Gehalt, r => r.Finance.Amount(1000, 4000))
                .RuleFor(x => x.IBAN, r => r.Finance.Iban(true))
                .RuleFor(x => x.Nachname, r => r.Name.LastName())
                .RuleFor(x => x.Vorname, r => r.Name.FirstName())
                // Waffle Extension > HTML
                .RuleFor(x=> x.Zusatz, f=> f.WaffleHtml(1,true))
                .RuleFor(x => x.Mail, (r, u) => r.Internet.Email(u.Vorname, u.Nachname))
                // Nullable : 50% sollen Null sein (Wahrscheinlichkeit)
                .RuleFor(x => x.IstFleißig, r => r.Random.Bool(0.5f))
                .RuleFor(x => x.Personalnummer, r => r.Random.Int(24000000, 24999999))
                .RuleFor(x => x.Telefon, r => r.Phone.PhoneNumber(format: "+49 ## ##########"))
                .RuleFor(x => x.Dienstgrad, r => r.PickRandom(dienstgradeList))
                .RuleFor(x => x.EingestelltAm, r => r.Date.Between(DateTime.Now, DateTime.Now.AddYears(-5)))
                // (r,u) => Dieses Datum wird aufgrund des Einstellungsdatum berechnet.
                // Muss dann aber danach berechnet werden
                // Kann aber auch Null sein !!!!
                .RuleFor(x => x.EntlassenAm, (r, u) => r.Date.Between(u.EingestelltAm, DateTime.Now).OrNull(r, .6f));
 
            // Beim Generieren einer zufälligen Anzahl kann ein eigener Random-Typ verwendet werden.
            List<Mitarbeiter> ma = testMitarbeiterListe.Generate(1);
            dst.Mitarbeiter = ma;
            dst.ShowData(dst);
            Console.ReadLine();
        }
        }
 
    }