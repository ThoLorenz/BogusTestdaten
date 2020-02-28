using System;
using System.Collections.Generic;
 
namespace BogusTestdaten
{
    public class Dienststelle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Adresse Adresse { get; set; }
        public List<Mitarbeiter> Mitarbeiter { get; set; }
 
        public string Bemerkung { get; set; }
 
        public bool? IstAktiv { get; set; }
 
        public string Url { get; set; }
 
        public void ShowData(Dienststelle dst)
        {
            Console.WriteLine(" Dienstelle : ");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Url}");
            Console.WriteLine($"Bemerkung: {Bemerkung}");
            Console.WriteLine($"Aktiv: {IstAktiv}");
            Console.WriteLine($"        Adresse/ Latitude: {Adresse.Latitude}");
            Console.WriteLine($"        Adresse/ Longitude: {Adresse.Longitude}");
            Console.WriteLine($"        Adresse/ Stadt: {Adresse.Stadt}");
            Console.WriteLine($"        Adresse/ Bemerkung: {Adresse.Bemerkung}");
            Console.WriteLine($" **** Liste Mitarbeiter ***");
            foreach (var ma in Mitarbeiter)
            {
                ma.ToString(ma);
            }
            Console.WriteLine("******************************************************************");
        }
 
    }
}