using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{

    public class Administrator
    {

        private const int adminId = 30708;
        private const int adminKode = 750352;

        private List<Pizza> pizzaMenu;
        private List<string> toppings;
        private List<DrikkeVare> drinkMenu;
        private List<Kunde> kunder;
        private List<Ordre> ordreHistorik;

        public Administrator(List<Pizza> pizzaMenu, List<string> toppings, List<DrikkeVare> drinkMenu, List<Kunde> kunder, List<Ordre> ordreHistorik)
        {
            this.pizzaMenu = pizzaMenu;
            this.toppings = toppings;
            this.drinkMenu = drinkMenu;
            this.kunder = kunder;
            this.ordreHistorik = ordreHistorik;
        }

        public void Login()
        {
            Console.WriteLine("Venligst indtast dit Idnummeret");
            int id = int.Parse(Console.ReadLine());

            if (id == adminId)
            {
                Console.WriteLine("Venligst indtast dit kodeord");
                int code = int.Parse(Console.ReadLine());

                if (code == adminKode)
                {
                    Console.WriteLine("Du er nu logget ind som administrator.");
                    // You can add any additional code you want to run after the administrator logs in here
                }
                else
                {
                    Console.WriteLine("Forket kodeord. Venligst prøv igen");
                }
            }
            else
            {
                Console.WriteLine("Forkert idnummer. Venligst prøv igen.");
            }
        }

        public void TilføjPizza(Pizza pizza)
        {
            pizzaMenu.Add(pizza);
        }

        public void FjernPizza(Pizza pizza)
        {
            pizzaMenu.Remove(pizza);
        }

        public void TilføjTopping(string topping)
        {
            toppings.Add(topping);
        }

        public void FjernTopping(string topping)
        {
            toppings.Remove(topping);
        }

        public void TilføjDrikke(DrikkeVare drikkeVare)
        {
            drinkMenu.Add(drikkeVare);
        }

        public void FjernDrikke(DrikkeVare drikkeVare)
        {
            drinkMenu.Remove(drikkeVare);
        }

        public void SeOrdreHistorik()
        {
            foreach (Ordre ordre in ordreHistorik)
            {
                Console.WriteLine(ordre.ToString());
            }
        }

        public void VisKundeKontaktInfo()
        {
            foreach (Kunde kunde in kunder)
            {
                Console.WriteLine($"Navn: {kunde.Navn}, Telefon: {kunde.TelefonNummer}, Email: {kunde.Email}");
            }
        }
    }
}



