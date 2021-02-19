using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class DodjeliPredmetVM
    {
        public int OdjeljenjeID { get; set; }
        public List<SelectListItem> predmeti{ get; set; }
    }
}
