using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Ordre
    {
        public Kunde Kunde { get; set; }
        public string Navn { get; set; }
        public string TelefonNummer { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public List<Pizza> Pizzaer { get; set; }
        public string Størrelse { get; set; }
        public decimal Pris { get; set; }
        public string Status { get; set; }
        public List<DrikkeVare> DrikkeVarer { get; set; }

        public Ordre() {
            Pizzaer = new List<Pizza>();
            DrikkeVarer = new List<DrikkeVare>(); // Initialize DrikkeVarer
        }

        public Ordre(Kunde kunde, Pizza pizza, string størrelse) {
            Kunde = kunde;
            Pizzaer = new List<Pizza> { pizza };
            Størrelse = størrelse;
            pizza.SetSize((PizzaStørrelse)Enum.Parse(typeof(PizzaStørrelse), størrelse));
            Pris = pizza.GetTotalPris((PizzaStore.PizzaStørrelse)Enum.Parse(typeof(PizzaStore.PizzaStørrelse), størrelse)) + pizza.Pris;
            Status = "Ikke leveret"; // Set default status to "Ikke leveret"
            DrikkeVarer = new List<DrikkeVare>();
        }

        public void AddPizza(Pizza pizza) {
            Pizzaer.Add(pizza);

            // Tjek om leveringsgebyret allerede er blevet tilføjet
            bool isLeveringsgebyrAdded = Pizzaer.Count == 1; // Hvis der kun er én pizza i ordren, er leveringsgebyret endnu ikke blevet tilføjet

            if (isLeveringsgebyrAdded)
            {
                // Tilføj gebyret på 40 kr til pris
                Pris += 40;
            }

            // Beregn totalprisen for pizzaen
            Pris += pizza.GetTotalPris((PizzaStore.PizzaStørrelse)Enum.Parse(typeof(PizzaStore.PizzaStørrelse), pizza.Størrelse.ToString())) + 40;
        }

        public void AddDrikkeVare(DrikkeVare drikkeVare) {
            DrikkeVarer.Add(drikkeVare);
            Pris += drikkeVare.Pris;
        }

        public void BeregnTotalPris() {
            Pris = 0; // Nulstil prisen, så vi kan beregne den igen

            // Beregn prisen for hver pizza i ordren
            foreach (var pizza in Pizzaer)
            {
                Pris += pizza.GetTotalPris((PizzaStore.PizzaStørrelse)Enum.Parse(typeof(PizzaStore.PizzaStørrelse), pizza.Størrelse.ToString()));
            }

            // Tilføj prisen for drikkevarer
            foreach (var drikkeVare in DrikkeVarer)
            {
                Pris += drikkeVare.Pris;
            }

            // Tilføj leveringsgebyret (hvis relevant)
            if (Pizzaer.Count > 0)
            {
                Pris += 40; // Leveringsgebyr tilføjes én gang, hvis der er mindst én pizza i ordren
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Kunde: {Kunde}");
            foreach (var pizza in Pizzaer)
            {
                sb.AppendLine($"Pizza: {pizza}");
                sb.AppendLine($"Toppings: {string.Join(", ", pizza.Toppings)}");
            }
            sb.AppendLine("Drikkevarer:");
            foreach (var drikkeVare in DrikkeVarer)
            {
                sb.AppendLine(drikkeVare.ToString());
            }
            sb.AppendLine($"Status: {Status}");
            return sb.ToString();
        }
    }
}
