using PizzaStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Kunde
    {
        public string Navn { get; set; }
        public string TelefonNummer { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        private List<Ordre> Ordre { get; set; }

        public Kunde()
        {

        }

        public Kunde(string navn, string telefonNummer, string email, string adresse)
        {
            Navn = navn;
            TelefonNummer = telefonNummer;
            Email = email;
            Adresse = adresse;
            Ordre = new List<Ordre>();
        }

        public void TilføjOrdre(Ordre ordre)
        {
            Ordre.Add(ordre);
        }

        public override string ToString()
        {
            return $"{Navn} - {TelefonNummer} - {Email} - {Adresse}";
        }
    }
}

