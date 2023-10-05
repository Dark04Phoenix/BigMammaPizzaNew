using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
   public class DrikkeVareMenu
    {
        public List<DrikkeVare> drikkeVarer;

        public DrikkeVareMenu()
        {
            drikkeVarer = new List<DrikkeVare>();
            AddDrikkeVareFromLink();
        }

        public void AddDrikkeVareFromLink() 
        {
            
            // Adding drinks from the provided link
            drikkeVarer.Add(new DrikkeVare("Kilde vand (330 ml)", 15));
            drikkeVarer.Add(new DrikkeVare("Cocacola (330 ml)", 20));
            drikkeVarer.Add(new DrikkeVare("Cocacola Zero (330 ml)", 20));
            drikkeVarer.Add(new DrikkeVare("Sprite (330 ml)", 20));
            drikkeVarer.Add(new DrikkeVare("Fanta (330 ml)", 20));
            drikkeVarer.Add(new DrikkeVare("Pepsi (330 ml)", 20));
            drikkeVarer.Add(new DrikkeVare("Pepsi Max (330 ml)", 20));
            drikkeVarer.Add(new DrikkeVare("Carlsberg (330 ml)", 35));
            drikkeVarer.Add(new DrikkeVare("Tuborg Classic (330 ml)", 35));

        }
    }
}
