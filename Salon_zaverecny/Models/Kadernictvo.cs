using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon_zaverecny.Models
{
    public class Kadernictvo

    {
        public int ID {get; set;}
        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public string Cislo { get; set; }
        public DateTime Datum { get; set; }
        public string Sluzba { get; set; }
        public bool Potvrdenie { get; set; }
    }

}
