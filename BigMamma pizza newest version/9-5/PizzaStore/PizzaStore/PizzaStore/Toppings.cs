using System;
using System.Collections.Generic;

namespace PizzaStore
{
    public class Toppings
    {
        public static List<string> AvailableToppings = new List<string> {
            "Pepperoni",
            "Champignons",
            "Løg",
            "Ananas",
            "Skinke",
            "Bacon",
            "Paprika",
            "Oregano",
            "Kylling",
            "Oksekød",
            "Ansjoser",
            "Chilli",
            "Gorgonzola",
            "Pepperfrugt",
            "Tun"
        };

        public static void AddToppings(Pizza pizza) {
            List<string> toppings = new List<string>();

            Console.WriteLine("Tilføj toppings fra listen (skriv numrene adskilt af komma):");

            foreach (string topping in AvailableToppings)
            {
                Console.WriteLine($"{AvailableToppings.IndexOf(topping)} - {topping}");
            }

            string input;
            do
            {
                Console.WriteLine($"Tilføj toppings ({toppings.Count + 1} af 7):");

                input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }

                string[] choices = input.Split(',');
                foreach (string choice in choices)
                {
                    int index;
                    if (int.TryParse(choice, out index) && index >= 0 && index < AvailableToppings.Count)
                    {
                        string topping = AvailableToppings[index];
                        if (!toppings.Contains(topping))
                        {
                            toppings.Add(topping);
                        }
                        else
                        {
                            Console.WriteLine("Denne topping er allerede tilføjet. Venligst vælg en anden topping.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt valg. Venligst vælg et gyldigt valg.");
                    }
                }
            }
            while (toppings.Count < 7 && input != "0");

            pizza.Toppings = toppings;
            pizza.Pris += toppings.Count * pizza.ToppingsPris; // Opdater pizzaens pris med toppingsprisen
        }
    }
}
 