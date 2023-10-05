using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;


namespace PizzaStore
{
    class Program
    {
        static void Main(string[] args) {

            //first take the customer's info (Kunde class)
            Kunde kunde = new Kunde();
            Console.WriteLine("Velkommen til BigMamma pizzzria :), venligst start med at indtaste dit fulde navn");
            kunde.Navn = Console.ReadLine();

            Console.WriteLine("Venligst indtast dit telefonnummer");
            kunde.TelefonNummer = Console.ReadLine();

            string email = "";
            while (true)
            {
                Console.Write("Venligst indtast din e-mail: ");
                email = Console.ReadLine();
                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    break;
                }
                Console.WriteLine("Ugyldig e-mailadresse, prøv igen.");
            }
            kunde.Email = email;

            Console.WriteLine("Venligst indtast din adresse");
            kunde.Adresse = Console.ReadLine();


            Console.WriteLine();

            //create a new order
            Ordre ordre = new Ordre();
            //(PizzaMenu class)
            PizzaMenu pizzaMenu = new PizzaMenu();

            Console.WriteLine("Hvilken pizza vil du gerne tilføje til din ordre?");

            // The customer enters a number 
            int choice = int.Parse(Console.ReadLine());

            // The order that corresponds to that number is printed out and viewed for the customer
            Pizza pizzaChoice = pizzaMenu.pizzaer[choice];
            Console.WriteLine("Du har valgt denne pizza: " + pizzaChoice.Navn);

            Console.WriteLine("Venligst vælg størrelsen, du vil have på din pizza");
            Console.WriteLine("1. Almindelig");
            Console.WriteLine("2. Deep Pan");
            Console.WriteLine("3. Familie");

            int størrelse;
            while (!int.TryParse(Console.ReadLine(), out størrelse) || størrelse < 1 || størrelse > 3)
            {
                Console.WriteLine("Ugyldigt valg. Venligst vælg en gyldig størrelse.");
                Console.WriteLine("1. Almindelig");
                Console.WriteLine("2. Deep Pan");
                Console.WriteLine("3. Familie");
            }

            pizzaChoice.SetSize((PizzaStørrelse)størrelse);
            // Create a new pizza object with the chosen pizza and size
            Pizza myPizza = new Pizza(pizzaChoice.Navn, størrelse.ToString());
            ordre.Pizzaer = new List<Pizza>();

            //Ask the customer if they want to add extra toppings 

            List<string> toppings = new List<string>();

            int maxToppings = 7; // maximum number of toppings allowed
            int numToppings = 0; // counter for the number of toppings added

            while (true)
            {
                Console.WriteLine($"Vil du gerne tilføje ekstra toppings til din pizza? (max {maxToppings})");
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nej");

                int input;
                if (!int.TryParse(Console.ReadLine(), out input) || (input != 1 && input != 2))
                {
                    Console.WriteLine("Ugyldigt valg. Venligst vælg et gyldigt valg.");
                    continue;
                }

                else if (input == 2)
                {
                    break;
                }

                if (numToppings == maxToppings)
                {
                    Console.WriteLine($"Du kan kun tilføje {maxToppings} ekstra toppings. Vil du fortsætte med at tilføje toppings?");
                    Console.WriteLine("1. Ja");
                    Console.WriteLine("2. Nej");

                    if (!int.TryParse(Console.ReadLine(), out input) || (input != 1 && input != 2))
                    {
                        Console.WriteLine("Ugyldigt valg. Venligst vælg et gyldigt valg.");
                        continue;
                    }

                    if (input == 2)
                    {
                        break;
                    }
                }

                Toppings.AddToppings(myPizza);
                numToppings++;
            }

            //The drinks part
            // ask customer if they want to add any drinks
            Console.WriteLine("Vil du gerne tilføje nogle drikkevarer til din ordre? (Ja/Nej)");

            // read the customer's response
            string drinkResponse = Console.ReadLine();

            if (drinkResponse.Equals("Ja", StringComparison.OrdinalIgnoreCase))
            {
                // show the drink menu

                DrikkeVareMenu drinkMenu = new DrikkeVareMenu();
                Console.WriteLine("Her er vores drikkevarer:");

                // print the drink menu options
                for (int i = 0; i < drinkMenu.drikkeVarer.Count; i++)
                {
                    Console.WriteLine($"{i}. {drinkMenu.drikkeVarer[i].Name} ({drinkMenu.drikkeVarer[i].Pris} kr)");
                }

                // ask the customer to choose a drink by entering a number
                Console.Write("Indtast nummeret for den drikkevare, du vil have: ");
                int drinkIndex = int.Parse(Console.ReadLine());

                // get the chosen drink from the menu
                DrikkeVare chosenDrink = drinkMenu.drikkeVarer[drinkIndex];

                // add the chosen drink to the order
                ordre.AddDrikkeVare(chosenDrink);

                // display the chosen drink to the customer
                Console.WriteLine($"Du har valgt {chosenDrink.Name} ({chosenDrink.Pris} kr)");
            }
            else
            {
                Console.WriteLine("OK, ingen drikkevarer tilføjet til ordren.");
            }



            //Ask the customer for card information 
            Console.WriteLine("Indtast dine kortoplysninger for at fuldføre betalingen:");
            Console.WriteLine();

            //Bed om kortejerens fornavn og efternavn
            Console.Write("Fornavn og efternavn: ");
            string kortejerensnavn = Console.ReadLine();

            //Bed om kortnummeret (16 cifre)
            Console.Write("Kortnummer (16 cifre): ");
            string kortnummer = Console.ReadLine();

            //Bed om kortetsudløbsdato (format: mm/yy)
            Console.Write("Udløbsdato (mm/yy): ");
            string Kontrolcifre = Console.ReadLine();

            //Prompt the customer to enter the three control digits 
            Console.Write("Venligst indtast de 3 kontrol cifre:");
            string kontrolCifreInput = Console.ReadLine();
            Console.WriteLine(kontrolCifreInput);

            //Validere kort  oplysninger (Kortnummeret skal bestå af 16 tal, kontrol cifre skal bestå af kun 3 tal)
            if (kortnummer.Length == 16 && kontrolCifreInput.Length == 3)
            {
                //Betaling Udført
                Console.WriteLine("Betaling gennemført.");
                Console.WriteLine();

                // Beregn den samlede pris
                ordre.BeregnTotalPris();

                // Udskriv kvitteringen
                Console.WriteLine("Kvittering");
                Console.WriteLine("Pizzaer:");
                foreach (var pizza in ordre.Pizzaer)
                {
                    Console.WriteLine(pizza.GetPizzaInfo());
                    Console.WriteLine("Toppings: " + string.Join(", ", pizza.Toppings));
                }
                Console.WriteLine("Drikkevarer: " + string.Join(", ", ordre.DrikkeVarer.Select(d => d.Name)));
                Console.WriteLine("Total pris: " + ordre.Pris + " kr");
            }
            else
            {
                //Betaling mislykkedes på grund af ugyldige kortoplysninger
                Console.WriteLine("Betalingsfejl: Ugyldige Kortoplysninger.");
            }

            // Resten af din eksisterende kode for at vise ordreoplysninger

            Console.WriteLine("Færdig");

            Console.WriteLine(kunde.ToString());
            Console.WriteLine(myPizza.ToString());
            Console.WriteLine(myPizza.Beskrivelse);
            Console.WriteLine(myPizza.Toppings);
            Console.WriteLine(ordre.ToString());

            Console.ReadLine();

        }
    }
}