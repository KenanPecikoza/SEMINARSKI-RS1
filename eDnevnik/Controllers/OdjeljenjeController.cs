using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS1.Model;
using eDnevnik.data.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using eDnevnik.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.SignalR;
using eDnevnik.Hubs;

namespace eDnevnik.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private readonly DataBaseContext _context;
        private static IHubContext<NotifikacijskiHub> _hubContext;
        public OdjeljenjeController(DataBaseContext context, IHubContext<NotifikacijskiHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        private void BrojUdenvniku( int odjeljenjeId)
        {
           IEnumerable<UceniciOdjeljenje> ucenici = _context.uceniciOdjeljenje.Include(x => x.ucenici).Where(x =>  x.odjeljenjeID == odjeljenjeId).OrderBy(x => x.ucenici.Prezime);
            int brojUDnevniku = 1;
            foreach (var i in ucenici)
            {
                i.BrojUDneviku = brojUDnevniku++;
            }
            _context.SaveChanges();
            return;
        }

        public static void NotificirajSignalR(string poruka="")
        {
            _hubContext.Clients.All.SendAsync("ReceiveNotification", poruka);
        }

        public IActionResult DodajOdjeljenje()
        {
            OdjeljenjeDodajVM UlazniModel = new OdjeljenjeDodajVM
            {
                Nastavnici = _context.nastavnoOsoblje.Select(n => new SelectListItem
                {
                    Value = n.NastavnoOsobljeID.ToString(),
                    Text = n.Ime + "(" + n.ImeRoditelja + ")" + n.Prezime
                }).ToList(),
                SkolskeGodine = _context.skolskaGodina.Select(n => new SelectListItem
                {
                    Value = n.SkolskaGodinaID.ToString(),
                    Text = n.Naziv
                }).ToList(),
                Aktivno=true
            };
            return View(UlazniModel);
        }
        public IActionResult OdjeljenjeUredi(int? OID)
        {
            Odjeljenje obj = new Odjeljenje();
            var LoginId = HttpContext.GetLogiraniKorisnik().LoginID;
            var korisnikId = _context.nastavnoOsoblje.Where(x => x.LoginID == LoginId).Select(x => x.NastavnoOsobljeID).FirstOrDefault();
            if (korisnikId >0)
            {
               obj = _context.odjeljenje.Include(x=> x.skolskaGodina).Where(x => x.Aktivno &&x.RazrednikID == korisnikId ).FirstOrDefault();

            }
            else
            {
                obj = _context.odjeljenje.Where(x=> x.OdjeljenjeID== OID).FirstOrDefault();
            }
            OdjeljenjeDodajVM UlazniModel = new OdjeljenjeDodajVM
            {
                OdjeljenjeID=obj.OdjeljenjeID,
                Razred=obj.Razred,
                Oznaka=obj.Oznaka,
                Opis=obj.Opis,
                RazrednikID=obj.RazrednikID,
                PredsjenikID=obj.PredsjednikID,
                BlagajnikID=obj.BlagajnikID,
                SkolskaGodinaID=obj.skolskaGodinaID,
                Smjena=obj.Smjena,
                Aktivno=obj.Aktivno,
                LogiraniKorisnik=korisnikId,
                Nastavnici = _context.nastavnoOsoblje.Except(_context.odjeljenje.Where(x=> x.Aktivno && x.RazrednikID!= obj.RazrednikID ).Select(y=> y.Razrednik)).ToList().Select(n => new SelectListItem
                {
                    Value = n.NastavnoOsobljeID.ToString(),
                    Text = n.Ime + "(" + n.ImeRoditelja + ")" + n.Prezime
                }).ToList(),

                Ucenici = _context.uceniciOdjeljenje.Where(x=> x.odjeljenjeID==obj.OdjeljenjeID).Select(n => new SelectListItem
                {
                    Value = n.ucenici.UceniciID.ToString(),
                    Text = n.ucenici.Ime + "(" + n.ucenici.ImeRoditelja + ")" + n.ucenici.Prezime
                }).ToList(),
                SkolskeGodine = _context.odjeljenje.Where(x=> x.OdjeljenjeID==obj.OdjeljenjeID ).Select(n => new SelectListItem
                {
                    Value = n.skolskaGodina.SkolskaGodinaID.ToString(),
                    Text = n.skolskaGodina.Naziv
                }).ToList()
            };
            return View("DodajOdjeljenje", UlazniModel);
        }

        [ValidateAntiForgeryToken()]
        public IActionResult Snimi(OdjeljenjeDodajVM novo)
        {
            var korisnik = _context.login.Where(y => y.LoginID == HttpContext.GetLogiraniKorisnik().LoginID).FirstOrDefault();

            if (novo.OdjeljenjeID == 0)
            {
                Odjeljenje n = new Odjeljenje
                {
                    Razred = novo.Razred,
                    Oznaka = novo.Oznaka,
                    Opis = novo.Opis,
                    RazrednikID = novo.RazrednikID,
                    PredsjednikID = novo.PredsjenikID,
                    BlagajnikID = novo.BlagajnikID,
                    skolskaGodinaID = novo.SkolskaGodinaID,
                    Smjena = novo.Smjena,
                    Aktivno = novo.Aktivno
                };
                _context.odjeljenje.Add(n);
                _context.SaveChanges();
                if (novo.Aktivno)
                {

                    IEnumerable<Odjeljenje> stara = _context.odjeljenje.Where(x => x.RazrednikID == n.RazrednikID && x.OdjeljenjeID!=n.OdjeljenjeID);
                    foreach (var i in stara)
                    {
                        i.Aktivno = false;
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("PrikaziOdjeljenja");
            }
            else
            {
                 Odjeljenje n = _context.odjeljenje.Find(novo.OdjeljenjeID);
                 if (_context.administrator.Where(x => x.LoginID == korisnik.LoginID).Select(x => x.AdministratorID).FirstOrDefault() > 0)
                 {
                     n.Razred = novo.Razred;
                     n.Oznaka = novo.Oznaka;
                     n.Opis = novo.Opis;
                     n.RazrednikID = novo.RazrednikID;
                     n.PredsjednikID = novo.PredsjenikID;
                     n.BlagajnikID = novo.BlagajnikID;
                     n.skolskaGodinaID = novo.SkolskaGodinaID;
                     n.Smjena = novo.Smjena;
                     n.Aktivno = novo.Aktivno;
                     _context.SaveChanges();
                    if (novo.Aktivno)
                    {
                        IEnumerable<Odjeljenje> stara = _context.odjeljenje.Where(x => x.RazrednikID == n.RazrednikID && x.OdjeljenjeID != n.OdjeljenjeID);
                        foreach (var i in stara)
                        {
                            i.Aktivno = false;
                        }
                        _context.SaveChanges();
                    }
                     TempData["porukaUspjesno"] = "Uspjesno ste uredili odjeljenje";
                     return RedirectToAction("PrikaziOdjeljenja");
                 }
                 else
                 {
                     n.PredsjednikID = novo.PredsjenikID;
                     n.BlagajnikID = novo.BlagajnikID;
                     _context.SaveChanges();
                     TempData["porukaUspjesno"] = "Uspjesno ste uredili odjeljenje";
                     return RedirectToAction("OdjeljenjeUredi", new { odjeljenjeID = novo.OdjeljenjeID });
                 }
            }
        }
        public IActionResult OdjeljenjeObrisi(int OID)
        {
            try
            {
                Odjeljenje odjeljenje = _context.odjeljenje.Find(OID);
                _context.Remove(odjeljenje);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["porukaNeuspjesno"] = "Odjeljenje nije obrisano";
                return RedirectToAction("PrikaziOdjeljenja");
            }

            TempData["porukaUspjesno"] = "Uspjesno obrisano odjeljenje";
            return RedirectToAction("PrikaziOdjeljenja");
        }


        public IActionResult PrikaziOdjeljenja(int? page)
        {
            IPagedList<OdjeljenjePrikaziVM> odjeljenja = _context.odjeljenje.OrderByDescending(x=> x.OdjeljenjeID).Select(o => new OdjeljenjePrikaziVM
            {
                OdjeljenjeID=o.OdjeljenjeID,
                Razred=o.Razred,
                Oznaka=o.Oznaka,
                Razrednik=_context.nastavnoOsoblje.Where(y=> y.NastavnoOsobljeID== o.RazrednikID).Select(x=> x.Ime+" ("+x.ImeRoditelja+")" +x.Prezime ).FirstOrDefault(),
                SkolskaGodina=_context.skolskaGodina.Where(sk=> sk.SkolskaGodinaID==o.skolskaGodinaID).SingleOrDefault().Naziv,
                Smjena=o.Smjena,
            }).ToList().ToPagedList(page ?? 1, 5);
            return View(odjeljenja);
        }

        public IActionResult OdjeljenjeDetalji( int OID)
        {
            Odjeljenje o = _context.odjeljenje.Find(OID);

            OdjeljenjeDetaljiVM ulazniModel = new OdjeljenjeDetaljiVM
            {
                OdjeljenjeID = o.OdjeljenjeID,
                Razred = o.Razred,
                Oznaka = o.Oznaka,
                RazrednikID=o.RazrednikID,
                Smjena=o.Smjena,
                Opis=o.Opis,
                Aktivno=o.Aktivno,
                Razrednik = _context.nastavnoOsoblje.Where(y => y.NastavnoOsobljeID == o.RazrednikID).Select(x => x.Ime + " (" + x.ImeRoditelja + ")" + x.Prezime).FirstOrDefault(),
            };
            if (o.BlagajnikID >0 && o.PredsjednikID>0)
            {
                ulazniModel.Blagajnik = _context.ucenici.Where(x => x.UceniciID == o.BlagajnikID).Select(x => x.Ime + " (" + x.ImeRoditelja + ") " + x.Prezime).FirstOrDefault();
                ulazniModel.Predsjednik = _context.ucenici.Where(x => x.UceniciID == o.PredsjednikID).Select(x => x.Ime + " (" + x.ImeRoditelja + ") " + x.Prezime).FirstOrDefault();
            }
            return View(ulazniModel);
        }

        public IActionResult DodjeliPredmet(int OID)
        {
            DodjeliPredmetVM model = new DodjeliPredmetVM
            {
                OdjeljenjeID = OID,
                predmeti = _context.predmeti.Include(x => x.Predavac).Select(x => new SelectListItem
                {
                    Text = x.Naziv + " - " + x.Predavac.Ime + " " + x.Predavac.Prezime,
                    Value = x.PredmetiID.ToString(),
                    Selected=_context.PredavaciPredmetiOdjeljenje.Where(y=> y.odjeljenjeID==OID && y.PredmetiID== x.PredmetiID).Select(y=> y.Id).FirstOrDefault()>=0
                }).ToList()
            };

            return View(model);
        }

        public IActionResult DodjeliPredmetSnimi(DodjeliPredmetVM model)
        {
            IEnumerable<PredavaciPredmetiOdjeljenje> dodjeljeniPredmeti = _context.PredavaciPredmetiOdjeljenje.Where(x=> x.odjeljenjeID==model.OdjeljenjeID);
            foreach (var i in model.predmeti)
            {
                try
                {
                    if (!i.Selected && _context.PredavaciPredmetiOdjeljenje.Where(y => y.odjeljenjeID == model.OdjeljenjeID && y.PredmetiID == Int32.Parse(i.Value)).Select(y => y.Id).FirstOrDefault() > 0)
                    {
                        PredavaciPredmetiOdjeljenje obrisi = dodjeljeniPredmeti.Where(x => x.PredmetiID == Int32.Parse(i.Value)).FirstOrDefault();
                        _context.Remove(obrisi);
                    }
                    else if (i.Selected && _context.PredavaciPredmetiOdjeljenje.Where(y => y.odjeljenjeID == model.OdjeljenjeID && y.PredmetiID == Int32.Parse(i.Value)).Select(y => y.Id).FirstOrDefault() == 0)
                    {
                        PredavaciPredmetiOdjeljenje predmet = new PredavaciPredmetiOdjeljenje
                        {
                            PredmetiID = Int32.Parse(i.Value),
                            odjeljenjeID = model.OdjeljenjeID
                        };
                        _context.Add(predmet);
                    }
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["porukaNeuspjesno"] = "Predmete na odjeljenju nije moguće urediti";
                    NotificirajSignalR("Predmete na odjeljenju nije moguće urediti");
                    return RedirectToAction("DodjeliPredmet" , new {OID= model.OdjeljenjeID});
                }
            }
            TempData["porukaUspjesno"] = "Uspjesno su uređeni predmeti na odjeljenju";
            NotificirajSignalR("Uspjesno su uređeni predmeti na odjeljenju");
            return RedirectToAction("PrikaziOdjeljenja");
        }
        public IActionResult DodjeliPredmetPrikazi(int OID)
        {
            DodjeliPredmetVM model = new DodjeliPredmetVM
            {
                OdjeljenjeID = OID,
                predmeti = _context.PredavaciPredmetiOdjeljenje.Where(x=> x.odjeljenjeID==OID).Select(x => new SelectListItem
                {
                    Text = x.predmeti.Naziv + " - " + x.predmeti.Predavac.Ime + " " + x.predmeti.Predavac.Prezime,
                    Value = x.PredmetiID.ToString(),
                    Selected=true,
                }).ToList()
            };
            return View("DodjeliPredmet", model);
        }

        public IActionResult OdjeljenjePredmetPrikazi()
        {
            int UserID = HttpContext.GetLogiraniKorisnik().LoginID;
            var predavac = _context.nastavnoOsoblje.Where(y => y.LoginID == UserID).FirstOrDefault();
            IEnumerable<OdjeljenjePredmetPrikaziVM> model = _context.PredavaciPredmetiOdjeljenje.Where(x => x.predmeti.Predavac == predavac ).Select(x => new OdjeljenjePredmetPrikaziVM
            {
                PredavaciPredmetiOdjeljenjeId = x.Id,
                NazivOdjeljenja =x.odjeljenje.Oznaka+" "+x.odjeljenje.Razred,
                NazivPredmeta=x.predmeti.Naziv,
                SkolskaGodina=x.odjeljenje.skolskaGodina.Naziv,
                Aktuelna=x.odjeljenje.skolskaGodina.Aktuelna
            }).OrderByDescending(x=> x.PredavaciPredmetiOdjeljenjeId);
            return View(model);
        }

        public IActionResult PrikaziUcenikeUOdjeljenju(int PPO)
        {
            PrikaziUcenikeUOdjeljenjuVM model = new PrikaziUcenikeUOdjeljenjuVM();
            model.Predmet = _context.PredavaciPredmetiOdjeljenje.Where(x => x.Id == PPO).Select(x => x.predmeti.Naziv).FirstOrDefault();
            model.Odjeljenje = _context.uceniciOdjeljenje.Where(x => x.odjeljenjeID == _context.PredavaciPredmetiOdjeljenje.Find(PPO).odjeljenjeID).Select(x => x.odjeljenje.Oznaka + "- " + x.odjeljenje.Opis).FirstOrDefault();
            model.Predavac = _context.PredavaciPredmetiOdjeljenje.Where(x => x.Id == PPO).Select(x => x.predmeti.Predavac.Ime+" " + x.predmeti.Predavac.Prezime).FirstOrDefault();
            model.Ucenici = _context.uceniciOdjeljenje.Where(x => x.odjeljenjeID == _context.PredavaciPredmetiOdjeljenje.Find(PPO).odjeljenjeID).Select(x => new PrikaziUcenikeUOdjeljenjuVM.Row
            {
                BrojUDnevniku = x.BrojUDneviku,
                Ime = x.ucenici.Ime,
                ImeRoditelja = x.ucenici.ImeRoditelja,
                Prezime = x.ucenici.Prezime,
                UceniciOdjeljenjeID = x.Id,
                PredavaciOdjeljenjeID = PPO,
                Predavac = _context.PredavaciPredmetiOdjeljenje.Where(x => x.Id == PPO).Select(x => x.predmeti.Predavac.Ime + " " + x.predmeti.Predavac.Prezime).FirstOrDefault(),
                ZakljucnaOcjena = _context.slusaPredmet.Where(y => y.uceniciOdjeljenjeId == x.Id && y.predavaciPredmetiOdjeljenjeId == PPO).Select(x => x.ZaključnaOcjena).FirstOrDefault()
            });
            return View(model);
        }



        public IActionResult ZakljuciOcjenu(int ucenikID, int predavacId)
        {
            ZakljuciOcjenuVM model = _context.uceniciOdjeljenje.Where(x => x.Id == ucenikID).Select(x => new ZakljuciOcjenuVM
            {
                Ucenik = x.ucenici.Ime + " " + x.ucenici.Prezime,
                UcenikID = ucenikID,
                PredavacId = predavacId,
                Predmet = _context.PredavaciPredmetiOdjeljenje.Where(x => x.Id == predavacId).Select(x => x.predmeti.Naziv).FirstOrDefault(),
                Predavac = _context.PredavaciPredmetiOdjeljenje.Where(x => x.Id == predavacId).Select(x => x.predmeti.Predavac.Ime + " " + x.predmeti.Predavac.Prezime).FirstOrDefault(),
                Ocjena = _context.slusaPredmet.Where(y => y.uceniciOdjeljenjeId == x.Id && y.predavaciPredmetiOdjeljenjeId == predavacId).Select(x => x.ZaključnaOcjena).FirstOrDefault()

            }).FirstOrDefault();
            return View(model);
        }

        public IActionResult ZakljuciOcjenuSnimi(ZakljuciOcjenuVM model)
        {
            SlusaPredmet ocjena = _context.slusaPredmet.Where(x => x.uceniciOdjeljenjeId == model.UcenikID && x.predavaciPredmetiOdjeljenjeId == model.PredavacId).FirstOrDefault();
            if (ocjena!=null)
            {
                ocjena.ZaključnaOcjena = model.Ocjena;
                _context.SaveChanges();
                return RedirectToAction("PrikaziUcenikeUOdjeljenju", new { PPO = model.PredavacId });
            }
            else
            {
                _context.Add(new SlusaPredmet
                {
                    predavaciPredmetiOdjeljenjeId = model.PredavacId,
                    uceniciOdjeljenjeId = model.UcenikID,
                    ZaključnaOcjena = model.Ocjena
                });
                _context.SaveChanges();
            }
            return RedirectToAction("PrikaziUcenikeUOdjeljenju", new { PPO = model.PredavacId });
        }




        public IActionResult PrikaziOdjeljenjaUcenikAdmin()
        {
            PrikaziOdjeljenjeUcenikAdminVM model = new PrikaziOdjeljenjeUcenikAdminVM();
            model.odjeljenja = _context.odjeljenje.Include(x => x.skolskaGodina).OrderByDescending(x=> x.OdjeljenjeID).Select(x => new PrikaziOdjeljenjeUcenikAdminVM.Odjeljenja
            {
                OdjeljenjeId = x.OdjeljenjeID,
                Oznaka = x.Oznaka,
                SkolskaGodina = x.skolskaGodina.Naziv,
                Aktivno=x.Aktivno,
                Razred = x.Razred,
                Razrednik= _context.nastavnoOsoblje.Where(y=> y.NastavnoOsobljeID==x.RazrednikID).Select(y=> y.Ime+ " ("+ y.ImeRoditelja+ ") "+ y.Prezime).FirstOrDefault(),

                NovaOdjeljenja = _context.odjeljenje.Include(y=> y.Razrednik).Where(y=> y.skolskaGodina.Aktuelna && y.OdjeljenjeID != x.OdjeljenjeID).Select(y=> new SelectListItem
                {
                    Value=y.OdjeljenjeID.ToString(),
                    Text ="Razrednik- "+ y.Razrednik.Ime + " (" + y.Razrednik.ImeRoditelja + ") " + y.Razrednik.Prezime + " | Odjeljenje- " + y.Oznaka+ " | " + y.Razred + " | Škoslka godina- " + y.skolskaGodina.Naziv
                }),
                ucenici = _context.uceniciOdjeljenje.Include(y=> y.ucenici).Where(y=> y.odjeljenjeID==x.OdjeljenjeID).OrderBy(x=> x.BrojUDneviku).Select(y=> new PrikaziOdjeljenjeUcenikAdminVM.Odjeljenja.Ucenici
                {
                    BrojUDnevniku=y.BrojUDneviku,
                    UcenikId=y.uceniciID,
                    ProsjecnaOcjena= _context.slusaPredmet.Where(z=> z.uceniciOdjeljenjeId==y.Id).Average(z=> z.ZaključnaOcjena),
                    ImeIPrezime= y.ucenici.Ime + " (" + y.ucenici.ImeRoditelja + ") " + y.ucenici.Prezime,
                }).ToList()
            }).ToList();
            foreach (var i in model.odjeljenja)
            {
                foreach (var j  in i.ucenici)
                {
                    if (_context.slusaPredmet.Where(x => x.ZaključnaOcjena == 1 && x.uceniciOdjeljenjeId == _context.uceniciOdjeljenje.Where(y => y.odjeljenjeID == i.OdjeljenjeId && y.uceniciID ==j.UcenikId).Select(x => x.Id).FirstOrDefault()).Select(x => x.Id).FirstOrDefault() > 0)
                    {
                        j.ProsjecnaOcjena = 1;
                    }
                }
            } 
            return View(model);
        }


        public IActionResult PrebaciUcenike(int NovoOdjeljenjeId, int StaroOdjljenjeId)
        {
            IEnumerable<UceniciOdjeljenje> ucenici = _context.uceniciOdjeljenje.Where(x => x.odjeljenjeID == StaroOdjljenjeId);
            IEnumerable<SlusaPredmet> ocjene = _context.slusaPredmet.Include(x=> x.uceniciOdjeljenje).Where(x => x.uceniciOdjeljenje.odjeljenjeID == StaroOdjljenjeId);
            List<UceniciOdjeljenje> Pali = new List<UceniciOdjeljenje>();
            foreach (var i in ucenici)
            {
                foreach (var y in ocjene)
                {
                    if (y.uceniciOdjeljenjeId== i.Id && y.ZaključnaOcjena==1)
                    {
                        Pali.Add(i);
                    }
                }
            }

            foreach (var i in ucenici)
            {
                if (Pali.Where(x=> x.Id==i.Id ).Select(x=> x.Id).FirstOrDefault()==0)
                {
                    _context.Add(new UceniciOdjeljenje
                    {
                        odjeljenjeID = NovoOdjeljenjeId,
                        uceniciID = i.uceniciID,
                    });
                }
            }
            Odjeljenje staro = _context.odjeljenje.Where(x => x.OdjeljenjeID == StaroOdjljenjeId).FirstOrDefault();
            Odjeljenje novo = _context.odjeljenje.Where(x => x.OdjeljenjeID == NovoOdjeljenjeId).FirstOrDefault();
            staro.Aktivno = false;
            novo.Aktivno = true;
            _context.SaveChanges();
            BrojUdenvniku(NovoOdjeljenjeId);
            return RedirectToAction("PrikaziOdjeljenjaUcenikAdmin");
        }
    }
}


          