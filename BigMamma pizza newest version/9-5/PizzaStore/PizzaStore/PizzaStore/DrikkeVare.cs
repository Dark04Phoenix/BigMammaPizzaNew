using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    public class DrikkeVare
    
        {
            public string Name { get; set; }
            public decimal Pris { get; set; }

            public DrikkeVare(string name, decimal pris) {
                Name = name;
                Pris = pris;
            }
        }
    }

