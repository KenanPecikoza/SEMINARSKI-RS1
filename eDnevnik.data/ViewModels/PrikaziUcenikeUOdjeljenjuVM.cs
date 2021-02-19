using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class PrikaziUcenikeUOdjeljenjuVM
    {
        public string Odjeljenje { get; set; }
        public string Predmet { get; set; }
        public string Predavac { get; set; }
        public IEnumerable<Row> Ucenici { get; set; }

        public class Row
        {
            public int UceniciOdjeljenjeID { get; set; }
            public int PredavaciOdjeljenjeID { get; set; }
            public string Ime { get; set; }
            public string ImeRoditelja { get; set; }
            public string Prezime { get; set; }
            public int BrojUDnevniku { get; set; }
            public int ZakljucnaOcjena { get; set; }
            public string Predavac { get; set; }
        }

    }
}
