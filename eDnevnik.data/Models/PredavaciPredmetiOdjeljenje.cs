﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class PredavaciPredmetiOdjeljenje
    {
        public int Id { get; set; }
        public Predmeti predmeti { get; set; }
        public int PredmetiID { get; set; }
        public Odjeljenje odjeljenje { get; set; }
        public int odjeljenjeID { get; set; }
    }
}
