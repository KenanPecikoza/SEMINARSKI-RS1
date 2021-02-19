using AutoMapper;
using eDnevnik.data.ViewModels;
using eDnevnik.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskiRS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public class UcenikService : IUcenikService
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;


        public UcenikService( DataBaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private Ucenici GetUcenik(int Id)
        {
            return _context.ucenici
                .Include(y => y.PodaciRodjenje).Include(y => y.PodaciRodjenje.Drzava).Include(y => y.PodaciRodjenje.Grad)
                .Include(y => y.PodaciStanovanje).Include(y => y.PodaciStanovanje.Drzava).Include(y => y.PodaciStanovanje.Grad)
                .Include(y=> y.OstaliPodaci).Include(y => y.OstaliPodaci.Porodica).Include(x=> x.ZavrsniIspit)
                .Where(y => y.UceniciID == Id)
                .SingleOrDefault();
        }

        public Ucenici Add(UcenikDodajVM model, int UserID)
        {
            if (model.UcenikID!=0){
                return Update(model);
            }

            PodaciRodjenje podaciRodjenje = new PodaciRodjenje
            {
                DatumRodjenja = model.DatumRodjenja,
                OpćinaRođenja = model.OpćinaRodjenja,
                GradID = model.GradRodjenjaID,
                DrzavaID = model.DrzavaRodjenjaID
            };
            _context.podaciRodjenje.Add(podaciRodjenje);

            PodaciStanovanje podaciStanovanje = new PodaciStanovanje
            {
                GradID = model.GradStanovanjaID,
                DrzavaID = model.DrzavaStanovanjaID,
                OpćinaPrebivalista = model.OpćinaPrebivalista,
                Adresa = model.Adresa,
                BrojTelefona = model.BrojTelefona,
                Email = model.Email
            };
            _context.podaciStanovanje.Add(podaciStanovanje);

            OstaliPodaci ostaliPodaci = new OstaliPodaci
            {
                Drzavljanstvo = model.Drzavljanstvo,
                Nacionalnost = model.Nacionalnost,
                PorodicaID=model.PorodicaID
            };
            _context.ostaliPodaci.Add(ostaliPodaci);

            Ucenici ucenici = new Ucenici
            {
                Ime = model.Ime,
                ImeRoditelja = model.ImeRoditelja,
                Prezime = model.Prezime,
                Pol = model.Pol,
                JMBG = model.JMBG,
                PodaciRodjenje = podaciRodjenje,
                OstaliPodaci = ostaliPodaci,
                PodaciStanovanje = podaciStanovanje
            };
            _context.ucenici.Add(ucenici);
            //MailSend.Send(_smtpConfig, nastavnoOsoblje.Ime + " " + nastavnoOsoblje.Prezime, "ajdincatic70230@gmail.com",
            //    "Dodani ste kao korisnik aplikacije.\nVaši login podaci: \nUsername: " + log.Username + "\nPassword: " + log.Password);

            int razrednikID = _context.nastavnoOsoblje.Where(y => y.LoginID == UserID).Select(x=> x.NastavnoOsobljeID).FirstOrDefault();

            // doadti provjeru da li se radi o akutelnoj skolskoj godini!!!
            UceniciOdjeljenje uceniciOdjeljenje = new UceniciOdjeljenje
            {
                odjeljenjeID = _context.odjeljenje.Where(x => x.RazrednikID ==razrednikID && x.skolskaGodina.Aktuelna).Select(x=> x.OdjeljenjeID).FirstOrDefault(),
                ucenici = ucenici,
                BrojUDneviku = 0
            };
            _context.uceniciOdjeljenje.Add(uceniciOdjeljenje);
            _context.SaveChanges();
            BrojUdenvniku(uceniciOdjeljenje.odjeljenjeID);
            return ucenici;
        }
        private IEnumerable<UceniciOdjeljenje>BrojUdenvniku(int odjeljenjeId)
        {
            var ucenici= _context.uceniciOdjeljenje.Include(x=> x.ucenici).Where(x => x.odjeljenje.OdjeljenjeID== odjeljenjeId).OrderBy(x=> x.ucenici.Prezime);
            int brojUDnevniku = 1;
            foreach (var i in ucenici)
            {
                i.BrojUDneviku = brojUDnevniku++;
            }
            _context.SaveChanges();
            return ucenici;
        }
        public UcenikDodajVM Edit(int UcenikID)
        {
            UcenikDodajVM ucenik = _context.ucenici.Where(x => x.UceniciID == UcenikID).Select(x => new UcenikDodajVM()
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                ImeRoditelja = x.ImeRoditelja,
                JMBG = x.JMBG,
                Pol = x.Pol,
                DatumUpisa = x.DatumUpisa,
                Adresa = x.PodaciStanovanje.Adresa,
                BrojTelefona=x.PodaciStanovanje.BrojTelefona,
                DrzavaStanovanjaID=x.PodaciStanovanje.DrzavaID,
                OpćinaPrebivalista=x.PodaciStanovanje.OpćinaPrebivalista,
                DatumRodjenja=x.PodaciRodjenje.DatumRodjenja,
                Drzavljanstvo=x.OstaliPodaci.Drzavljanstvo,
                Email=x.PodaciStanovanje.Email,
                Nacionalnost=x.OstaliPodaci.Nacionalnost,
                PorodicaID=x.OstaliPodaci.PorodicaID,
                GradRodjenjaID=x.PodaciRodjenje.GradID,
                GradStanovanjaID=x.PodaciStanovanje.GradID,
                DrzavaRodjenjaID=x.PodaciRodjenje.DrzavaID,
                UcenikID=x.UceniciID,
                ZavrsniIspitID=x.ZavrsniIspitID,
                OpćinaRodjenja=x.PodaciRodjenje.OpćinaRođenja,
                OcjenaZavrsnogIspita=x.ZavrsniIspit.OcjenaZavrsnogIspita,
                OcjenaZavrsnogRada=x.ZavrsniIspit.OcjenaZavrsnogRada,
                OcjenaOdbrane=x.ZavrsniIspit.OcjenaOdbrane,
                DatumPolaganja=x.ZavrsniIspit.DatumPolaganja,
            }).FirstOrDefault();
            PripremiCmbVMStavke(ucenik);
            return ucenik;
        }
        public Ucenici Update(UcenikDodajVM model)
        {
            Ucenici ucenici = _context.ucenici.Include(x=> x.PodaciRodjenje)
                                              .Include(x=> x.PodaciStanovanje)
                                              .Include(x=> x.OstaliPodaci)
                                              .Include(x=> x.ZavrsniIspit)
                                              .Where(x=> x.UceniciID==model.UcenikID).FirstOrDefault();
            ucenici.Ime = model.Ime;
            ucenici.Prezime = model.Prezime;
            ucenici.ImeRoditelja = model.ImeRoditelja;
            ucenici.Pol = model.Pol;
            ucenici.JMBG = model.JMBG;
            ucenici.PodaciRodjenje.DatumRodjenja = model.DatumRodjenja;
            ucenici.PodaciRodjenje.OpćinaRođenja = model.OpćinaRodjenja;
            ucenici.PodaciRodjenje.GradID = model.GradRodjenjaID;
            ucenici.PodaciRodjenje.DrzavaID = model.DrzavaRodjenjaID;
            ucenici.PodaciStanovanje.GradID = model.GradStanovanjaID;
            ucenici.PodaciStanovanje.DrzavaID = model.DrzavaStanovanjaID;
            ucenici.PodaciStanovanje.Adresa = model.Adresa;
            ucenici.PodaciStanovanje.OpćinaPrebivalista = model.OpćinaPrebivalista;
            ucenici.PodaciStanovanje.BrojTelefona = model.BrojTelefona;
            ucenici.PodaciStanovanje.Email = model.Email;
            ucenici.OstaliPodaci.Drzavljanstvo = model.Drzavljanstvo;
            ucenici.OstaliPodaci.Nacionalnost = model.Nacionalnost;
            ucenici.OstaliPodaci.PorodicaID = model.PorodicaID;
            ucenici.UceniciID = model.UcenikID;
            ucenici.DatumUpisa = model.DatumUpisa;
            if (ucenici.ZavrsniIspitID==null)
            {
                PodaciZavrsniIspit zavrsniIspit = new PodaciZavrsniIspit
                {
                    OcjenaOdbrane = model.OcjenaOdbrane,
                    OcjenaZavrsnogRada = model.OcjenaZavrsnogRada,
                    OcjenaZavrsnogIspita = model.OcjenaZavrsnogIspita,
                    DatumPolaganja = model.DatumPolaganja
                };
                _context.Add(zavrsniIspit);
                _context.SaveChanges();
                ucenici.ZavrsniIspitID = zavrsniIspit.ID;
            }
            else
            {
                ucenici.ZavrsniIspit.OcjenaZavrsnogIspita = model.OcjenaZavrsnogIspita;
                ucenici.ZavrsniIspit.DatumPolaganja = model.DatumPolaganja;
                ucenici.ZavrsniIspit.OcjenaOdbrane = model.OcjenaOdbrane;
                ucenici.ZavrsniIspit.OcjenaZavrsnogRada = model.OcjenaZavrsnogRada;
            }

            _context.SaveChanges();
            return ucenici;
        }
        public IEnumerable<UcenikPrikaziVM> GetList(int UserID)
        {
            // ako admin zahtjeva treba ispisati sve učenike
            var razrednik = _context.nastavnoOsoblje.Where(y => y.LoginID == UserID).FirstOrDefault();
            IList<UcenikPrikaziVM> ucenici;
            if (razrednik==null){
                ucenici = _mapper.Map<IList<UcenikPrikaziVM>>(_context.ucenici);
                foreach (var i in ucenici)
                {
                    i.User = "Admin";
                }
                if (ucenici.Count()==0)
                {
                    ucenici.Add(new UcenikPrikaziVM
                    {
                        User = "admin"
                    });
                }
            }
            else{
                //ucenici = _mapper.Map<IEnumerable<UcenikPrikaziVM>>
                //    (_context.uceniciOdjeljenje.Where(x => x.odjeljenje.RazrednikID == razrednik.NastavnoOsobljeID && x.odjeljenje.skolskaGodina.Aktuelna).Select(x => x.ucenici));
                ucenici = _mapper.Map<IEnumerable<UcenikPrikaziVM>>
                    (_context.uceniciOdjeljenje.Where(x => x.odjeljenje.RazrednikID == razrednik.NastavnoOsobljeID && x.odjeljenje.Aktivno).Select(x => x.ucenici)).ToList();

                foreach (var i in ucenici)
                {
                    i.User = "User";
                }
                if (ucenici.Count() == 0)
                {
                    ucenici.Add(new UcenikPrikaziVM
                    {
                        User = "admin"
                    });
                }
            }
            foreach (var i in ucenici)
            {
                i.BrojUDnevniku = _context.uceniciOdjeljenje.Where(x => x.uceniciID == i.UceniciID && x.odjeljenje.Aktivno).Select(x=> x.BrojUDneviku).FirstOrDefault();
            }
            var sortirani=ucenici.OrderBy(x => x.BrojUDnevniku);
                
            return sortirani;
        }
        public UcenikDodajVM PripremiCmbVMStavke(UcenikDodajVM ulazniModel)
        {
            ulazniModel.Gradovi = _context.grad
                    .Select(x => new SelectListItem(x.NazivGrada, x.GradID.ToString())).ToList();

            ulazniModel.Drzave = _context.drzava
                    .Select(x => new SelectListItem(x.NazivDrzave, x.DrzavaID.ToString())).ToList();

            ulazniModel.Porodica = _context.porodica
                    .Select(x => new SelectListItem(x.StatusPorodiceUcenika, x.PorodicaID.ToString())).ToList();
            return ulazniModel;
        }

        public UcenikDodajVM GetById(int Id)
        {
            //provjeriti
            Ucenici ucenici = GetUcenik(Id);
            UcenikDodajVM model = new UcenikDodajVM();

            model.Ime = ucenici.Ime;
            model.Prezime = ucenici.Prezime;
            model.ImeRoditelja = ucenici.ImeRoditelja;
            model.Pol = ucenici.Pol;
            model.JMBG = ucenici.JMBG;
            model.DatumRodjenja = ucenici.PodaciRodjenje.DatumRodjenja;
            model.OpćinaRodjenja = ucenici.PodaciRodjenje.OpćinaRođenja;
            model.GradRodjenjaID = ucenici.PodaciRodjenje.GradID;
            model.DrzavaRodjenjaID = ucenici.PodaciRodjenje.DrzavaID;
            model.GradStanovanjaID = ucenici.PodaciStanovanje.GradID;
            model.DrzavaStanovanjaID = ucenici.PodaciStanovanje.DrzavaID;
            model.Adresa = ucenici.PodaciStanovanje.Adresa;
            model.OpćinaPrebivalista = ucenici.PodaciStanovanje.OpćinaPrebivalista;
            model.BrojTelefona = ucenici.PodaciStanovanje.BrojTelefona;
            model.Email = ucenici.PodaciStanovanje.Email;
            model.Drzavljanstvo = ucenici.OstaliPodaci.Drzavljanstvo;
            model.Nacionalnost = ucenici.OstaliPodaci.Nacionalnost;
            model.PorodicaID = ucenici.OstaliPodaci.PorodicaID;
            model.UcenikID = ucenici.UceniciID;
            model.DatumUpisa = ucenici.DatumUpisa;
            if (ucenici.ZavrsniIspitID!=null)
            {
                model.OcjenaZavrsnogIspita = ucenici.ZavrsniIspit.OcjenaZavrsnogIspita;
                model.DatumPolaganja = ucenici.ZavrsniIspit.DatumPolaganja;
                model.OcjenaOdbrane = ucenici.ZavrsniIspit.OcjenaOdbrane;
                model.OcjenaZavrsnogRada = ucenici.ZavrsniIspit.OcjenaZavrsnogRada;

            }

            PripremiCmbVMStavke(model);
            return model;
        }
        // podaci završni ispit dodati

        public Ucenici Delete(int UcenikID)
        {
            try
            {
                var odjeljenje = _context.uceniciOdjeljenje.Include(x => x.odjeljenje).Where(y => y.uceniciID == UcenikID).Select(x => x.odjeljenje.OdjeljenjeID).FirstOrDefault();
                Ucenici ulazniModel = _context.ucenici.Where(x=> x.UceniciID==UcenikID).FirstOrDefault();
                if (ulazniModel.PodaciStanovanje!=null)
                    _context.podaciStanovanje.Remove(_context.podaciStanovanje.Find(ulazniModel.PodaciStanovanjeID));
                if (ulazniModel.PodaciRodjenje != null)
                    _context.podaciRodjenje.Remove(_context.podaciRodjenje.Find(ulazniModel.PodaciRodjenjeID));
                if (ulazniModel.OstaliPodaci!=null)
                    _context.ostaliPodaci.Remove(_context.ostaliPodaci.Find(ulazniModel.OstaliPodaciID));
                _context.uceniciOdjeljenje.Remove(_context.uceniciOdjeljenje.Where(x => x.uceniciID == UcenikID).SingleOrDefault());
                _context.ucenici.Remove(ulazniModel);
                _context.SaveChanges();
                BrojUdenvniku(odjeljenje);
                return ulazniModel;
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
