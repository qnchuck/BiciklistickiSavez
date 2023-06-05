using BiciklistickiSavez.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciklistickiSavez.Database
{
    public class DBConversion:IConversion
    {
        public DBConversion() { }
        public SystemModels.Models.BiciklistickiSavez ConvertBiciklistickiSavez(Biciklisticki_Savez savez)
        {
            List<SystemModels.Models.Takmicar> takmicari = new List<SystemModels.Models.Takmicar>();
            savez.Takmicaris.ToList().ForEach(t => takmicari.Add(ConvertTakmicar(t)));
            return new SystemModels.Models.BiciklistickiSavez
            {
                Naziv = savez.NZV,
                Drzava = savez.DRZ,
                Takmicari = takmicari
            };
            
        }

        public SystemModels.Models.Takmicar ConvertTakmicar(Takmicari takmicar)
        {

            return new SystemModels.Models.Takmicar
            {
                Ime = takmicar.IME,
                Prezime = takmicar.PRZ,
                Pol = takmicar.POL,
                JMBG = takmicar.JMBG,
                NazivSaveza = takmicar.NZV_SVZ
            };

        }
        public SystemModels.Models.Bicikli ConvertBicikli(Bicikli bicikli)
        {

            return new SystemModels.Models.Bicikli
            {
                ID = bicikli.ID_B,
                Model= bicikli.MOD ,
                Proizvodjac = bicikli.PRO,
                ZemljaPorekla = bicikli.ZEM_P
            };

        }
        public SystemModels.Models.BiciklistickiKlub ConvertBiciklistickiKlub(Biciklisticki_Klub klub)
        {
            return new SystemModels.Models.BiciklistickiKlub
            {
                ID = klub.ID_KLUB,
                Lokacija = klub.LOK,
                Naziv = klub.NZVK,
                NazivSaveza = klub.NZV_SVZ
            };
        }

        public SystemModels.Models.Dokumentacija ConvertDokumentacija(Dokumentacije dokumentacija)
        {
            return new SystemModels.Models.Dokumentacija
            {
                ID = dokumentacija.ID_TXT,
                Tekst = dokumentacija.TXT,
                NazivSaveza = dokumentacija.NZV_SVZ
            };
        }
    }
}
