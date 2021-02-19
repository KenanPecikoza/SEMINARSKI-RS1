using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class ZakljuciOcjenuVM
    {
        [Range(1, 5)]
        public int Ocjena { get; set; }
        public int UcenikID { get; set; }
        public int PredavacId { get; set; }
        public string Ucenik { get; set; }
        public string Predmet { get; set; }
        public string Predavac { get; set; }

    }
}
