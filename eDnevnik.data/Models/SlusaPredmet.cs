using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class SlusaPredmet
    {
        public int Id { get; set; }
        public PredavaciPredmetiOdjeljenje predavaciPredmetiOdjeljenje { get; set; }
        public int predavaciPredmetiOdjeljenjeId { get; set; }
        public UceniciOdjeljenje uceniciOdjeljenje { get; set; }
        public int uceniciOdjeljenjeId { get; set; }
        public int ZaključnaOcjena { get; set; }
    }
}
