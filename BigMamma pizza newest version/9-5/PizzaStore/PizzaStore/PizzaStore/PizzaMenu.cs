using PizzaStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaStore.Pizza;

namespace PizzaStore
{
    public class PizzaMenu
    {
        public List<Pizza> pizzaer;

        public PizzaMenu() {
            pizzaer = new List<Pizza>();
            AddPizzasFromLink();
        }

        private void AddPizzasFromLink() {
            // Adding pizzas from the provided link
            pizzaer.Add(new Pizza("Margherita", "Tomatsauce og ost", 60, 80, 105));
            pizzaer.Add(new Pizza("Vesuvio", "Tomatsauce, ost og skinke", 65, 85, 110));
            pizzaer.Add(new Pizza("Capricciosa", "Tomatsauce, ost, skinke, champignon og oregano", 65, 85, 110));
            pizzaer.Add(new Pizza("Calzone", "Tomatsauce, ost, skinke og champignon", 60, 80, 105));
            pizzaer.Add(new Pizza("Quatro Stagioni", "Tomatsauce, ost, skinke, champignon, rejer og peberfrugt", 55, 75, 100));
            pizzaer.Add(new Pizza("Marinara", "Tomatsauce, ost, rejer, muslinger og hvidløg", 70, 90, 115));
            

            Console.WriteLine("Her er pizzamenuen:\n");

            for (int i = 0; i < pizzaer.Count; i++)
            {
                Pizza pizza = pizzaer[i];
                string pizzaDetails = $"{i}) {pizza.Navn} - {pizza.Beskrivelse}";
                string pizzaSizes = $"(Almindelig: {pizza._almindeligPris} kr, Deep Pan: {pizza._deepPanPris} kr, Familie: {pizza._familiePris} kr)";
                Console.WriteLine($"{pizzaDetails,-50}{pizzaSizes}");
            }
        }
    }
}