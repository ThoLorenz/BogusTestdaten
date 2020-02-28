using System;
 
namespace BogusTestdaten
{
    public class Mitarbeiter
    {
        public int Id { get; set; }
        public Dienststelle Dienststelle { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Dienstgrad { get; set; }
        public int Personalnummer { get; set; }
        public DateTime EingestelltAm { get; set; }
        public DateTime?  EntlassenAm { get; set; }
        public string Telefon { get; set; }
        public string IBAN { get; set; }
        public Decimal Gehalt { get; set; }
        public string Mail { get; set; }
        public bool? IstFleißig { get; set; }
 
        public string Zusatz { get; set; }
 
 
        public void ToString(Mitarbeiter ma)
        {
            Console.WriteLine($"        Id: {ma.Id}");
            Console.WriteLine($"        Name: {ma.Nachname}");
            Console.WriteLine($"        Vorname: {ma.Vorname}");
            Console.WriteLine($"        Personalummer: {ma.Personalnummer}");
            Console.WriteLine($"        Telefon: {ma.Telefon}");
            Console.WriteLine($"        Dienststelle: {ma.Dienststelle.Name}");
            Console.WriteLine($"        Dienstgrad: {ma.Dienstgrad}");
            Console.WriteLine($"        Eingestellt: {ma.EingestelltAm.ToShortDateString()}");
            if (ma.EntlassenAm.HasValue)
            {
                Console.WriteLine($"        Entlassen: {ma.EntlassenAm.Value.ToShortDateString()}");
 
            }
            else
            {
                Console.WriteLine($"        Entlassen: {ma.EntlassenAm}");
            }
 
            Console.WriteLine($"        IBAN: {ma.IBAN}");
            Console.WriteLine($"        Gehalt: {ma.Gehalt}");
            Console.WriteLine($"        eMail: {ma.Mail}");
            Console.WriteLine($"        IstFleißig: {ma.IstFleißig}");
            Console.WriteLine($"       Zusatz: {ma.Zusatz} ");
            Console.WriteLine("--------------------------------------------------------------------");
        }
    }
}