using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PizzaStore
{
    public enum PizzaStørrelse
    {
        Almindelig,
        DeepPan,
        Familie
    }

    public class Pizza
    {
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public List<string> Toppings { get; set; }
        public int ToppingsCount { get { return Toppings.Count; } }
        public PizzaStørrelse Størrelse { get; set; }
        public decimal Pris { get; internal set; }

        public decimal _almindeligPris = 0m;
        public decimal _deepPanPris = 0m;
        public decimal _familiePris = 0m;

        //ToppingsPris variabel 
        public decimal ToppingsPris = 3m;

        public Pizza() {
            Toppings = new List<string>();
        }

        public Pizza(string navn, string beskrivelse, decimal almindeligPris = 0m, decimal deepPanPris = 0m, decimal familiePris = 0m) {
            Navn = navn;
            Beskrivelse = beskrivelse;
            _almindeligPris = almindeligPris;
            _deepPanPris = deepPanPris;
            _familiePris = familiePris;
            Toppings = new List<string>();
        }

        public void SetSize(PizzaStørrelse størrelse) {
            Størrelse = størrelse;

            switch (størrelse)
            {
                case PizzaStørrelse.Almindelig:
                    Pris = _almindeligPris;
                    break;
                case PizzaStørrelse.DeepPan:
                    Pris = _deepPanPris;
                    break;
                case PizzaStørrelse.Familie:
                    Pris = _familiePris;
                    break;
                default:
                    throw new ArgumentException("Ugyldig størrelse");
            }
        }

        public void AddToppings(string topping) {
            if (Toppings.Contains(topping))
            {
                Console.WriteLine($"Pizza har allerede {topping}");
            }
            else if (Toppings.Count >= 7)
            {
                Console.WriteLine("Pizza har allerede det maksimale antal toppings");
            }
            else if (!Toppings.Contains(topping) && Toppings.Count < 7 && Toppings.Count >= 0)
            {
                Toppings.Add(topping);
                Pris += ToppingsPris;
            }
        }

        public decimal GetTotalPris(PizzaStørrelse størrelse) {
            decimal totalPris = Pris;

            switch (størrelse)
            {
                case PizzaStørrelse.Almindelig:
                    totalPris += _almindeligPris;
                    break;
                case PizzaStørrelse.DeepPan:
                    totalPris += _deepPanPris;
                    break;
                case PizzaStørrelse.Familie:
                    totalPris += _familiePris;
                    break;
                default:
                    throw new ArgumentException("Ugyldig størrelse");
            }

            totalPris += Toppings.Count * ToppingsPris;
            return totalPris;
        }

        public string GetPizzaInfo() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Navn} - {Beskrivelse}");
            sb.AppendLine($"Størrelse: {Størrelse}");
            Pris += GetTotalPris((PizzaStore.PizzaStørrelse)Enum.Parse(typeof(PizzaStore.PizzaStørrelse), Størrelse.ToString())) + 40;
            sb.AppendLine("Toppings:");

            foreach (string topping in Toppings)
            {
                sb.AppendLine(topping);
            }

            return sb.ToString();
        }


        public override string ToString() {
            return $"{Navn} - {Beskrivelse} ({Størrelse}: {Pris} kr)";
        }
    }
}