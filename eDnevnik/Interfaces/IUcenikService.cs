using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.data.ViewModels;
using SeminarskiRS1.Model;

namespace eDnevnik.Interfaces
{
    public interface IUcenikService
    {

        IEnumerable<UcenikPrikaziVM> GetList(int UserID);
        Ucenici Add(UcenikDodajVM model, int UserID);
        Ucenici Delete(int UcenikID);
        Ucenici Update(UcenikDodajVM model);
        UcenikDodajVM PripremiCmbVMStavke(UcenikDodajVM ulazniModel);
        UcenikDodajVM Edit(int UcenikID);
        UcenikDodajVM GetById(int Id);

    }
}
