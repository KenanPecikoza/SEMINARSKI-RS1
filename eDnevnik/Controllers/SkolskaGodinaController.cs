using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eDnevnik.data.ViewModels;
using SeminarskiRS1.Model;
using eDnevnik.Helper;
using System.Xml.Linq;
using SQLitePCL;

namespace eDnevnik.Controllers
{
    //[Autorizacija(true, false)]
    public class SkolskaGodinaController : Controller
    {

        private DataBaseContext _context;

        public SkolskaGodinaController(DataBaseContext context)
        {
            _context = context;
        }
        public IActionResult Prikazi()
        {
            IEnumerable<SkolskaGodinaVM> godine = _context.skolskaGodina.Select(x => new SkolskaGodinaVM
            {
                Aktuelna = x.Aktuelna,
                Naziv = x.Naziv,
                SkolskaGodinaID = x.SkolskaGodinaID
            });
            return View(godine);
        }
        public IActionResult Dodaj()
        {

            return View();
        }
        void SkolskaGodinaFalse(int id)
        {
            IEnumerable<SkolskaGodina> godine = _context.skolskaGodina;
            foreach (var i in godine)
            {
                if (id!=i.SkolskaGodinaID)
                {
                    i.Aktuelna = false;
                }
            }
            _context.SaveChanges();
        }
        


        public IActionResult Snimi(SkolskaGodinaVM model)
        {
            if (model.SkolskaGodinaID>0)
            {
                SkolskaGodina godina = _context.skolskaGodina.Find(model.SkolskaGodinaID);
                godina.Aktuelna = model.Aktuelna;
                godina.Naziv = model.Naziv;
                _context.SaveChanges();
                SkolskaGodinaFalse(model.SkolskaGodinaID);
                return RedirectToAction("Prikazi");
            }
            SkolskaGodina Nova = new SkolskaGodina
            {
                Aktuelna = true,
                Naziv = model.Naziv,
            };
            _context.Add(Nova);
            _context.SaveChanges();
            SkolskaGodinaFalse(Nova.SkolskaGodinaID);
            // staviti sve ostale da nisu aktualne FALSE
            return RedirectToAction("Prikazi");
        }

        public IActionResult Obrisi(int ID)
        {
            try
            {
                _context.Remove(_context.skolskaGodina.Find(ID));
                _context.SaveChanges();

            }
            catch (Exception)
            {
                TempData["porukaNeuspjesno"] = "Skolsku godinu nije moguće obrisati";
                return RedirectToAction("Prikazi");

            }
            TempData["porukaUspjesno"] = "Skolska godina obrisana";


            return RedirectToAction("Prikazi");
        }
        public IActionResult Uredi(int ID)
        {
            SkolskaGodinaVM model = _context.skolskaGodina.Where(x=> x.SkolskaGodinaID==ID).Select(x=> new SkolskaGodinaVM
            {
                Aktuelna=x.Aktuelna,
                SkolskaGodinaID=x.SkolskaGodinaID,
                Naziv=x.Naziv
            }).FirstOrDefault();
            return View("Dodaj", model);
        }
    }
}