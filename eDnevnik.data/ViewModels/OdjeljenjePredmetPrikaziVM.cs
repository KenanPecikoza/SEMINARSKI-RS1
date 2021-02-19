using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class OdjeljenjePredmetPrikaziVM
    {
        public int PredavaciPredmetiOdjeljenjeId { get; set; }
        public string NazivOdjeljenja { get; set; }
        public string  NazivPredmeta { get; set; }
        public string  SkolskaGodina { get; set; }
        public bool Aktuelna{ get; set; }
    }
}
