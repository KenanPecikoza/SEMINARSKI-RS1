using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class PrikaziOdjeljenjeUcenikAdminVM
    {

        public List<Odjeljenja> odjeljenja { get; set; }
        public class Odjeljenja
        {
            public int OdjeljenjeId { get; set; }
            public string Razrednik { get; set; }
            public string Oznaka { get; set; }
            public int Razred { get; set; }
            public string SkolskaGodina { get; set; }
            public int NovoOdjeljenjeId { get; set; }
            public IEnumerable<SelectListItem> NovaOdjeljenja { get; set; }
            public List<Ucenici> ucenici { get; set; }
            public bool Aktivno { get; set; }

            public class Ucenici
            {
                public int UcenikId { get; set; }
                public string ImeIPrezime { get; set; }
                public int BrojUDnevniku { get; set; }
                public double ProsjecnaOcjena { get; set; }
            }
        }
    }
}
