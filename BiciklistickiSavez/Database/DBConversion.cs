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
            List<SystemModels.Models.BiciklistickiKlub> klubovi = new List<SystemModels.Models.BiciklistickiKlub>();
            List<SystemModels.Models.Dokumentacija> dokumentacije  = new List<SystemModels.Models.Dokumentacija>();

            savez.Takmicaris.ToList().ForEach(t => takmicari.Add(ConvertTakmicar(t)));
            savez.Biciklisticki_Klub.ToList().ForEach(bk => klubovi.Add(ConvertBiciklistickiKlub(bk)));
            savez.Dokumentacijes.ToList().ForEach(d => dokumentacije.Add(ConvertDokumentacija(d)));
            return new SystemModels.Models.BiciklistickiSavez
            {
                Naziv = savez.NZV,
                Drzava = savez.DRZ,
                Takmicari = takmicari,
                Dokumentacije = dokumentacije,
                Klubovi = klubovi
            };
            
        }

        public SystemModels.Models.Takmicar ConvertTakmicar(Takmicari takmicar)
        {

            List<SystemModels.Models.Bicikli> bicikli = new List<SystemModels.Models.Bicikli>();

            takmicar.Biciklis.ToList().ForEach(b => bicikli.Add(ConvertBicikli(b)));
           
            return new SystemModels.Models.Takmicar
            {
                Ime = takmicar.IME,
                Prezime = takmicar.PRZ,
                Pol = takmicar.POL,
                JMBG = takmicar.JMBG,
                NazivSaveza = takmicar.NZV_SVZ,
                Bicikli = bicikli
            };

        }
        public SystemModels.Models.Bicikli ConvertBicikli(Bicikli bicikli)
        {

            return new SystemModels.Models.Bicikli
            {
                ID = bicikli.ID_B,
                Model= bicikli.MOD ,
                Proizvodjac = bicikli.PRO,
                ZemljaPorekla = bicikli.ZEM_P,
                JmbgT = bicikli.JMBG_T
            };

        }
        public SystemModels.Models.BiciklistickiKlub ConvertBiciklistickiKlub(Biciklisticki_Klub klub)
        {

            List<SystemModels.Models.Takmicar> takmicari = new List<SystemModels.Models.Takmicar>();
            klub.Takmicaris.ToList().ForEach(t => takmicari.Add(ConvertTakmicar(t)));

            return new SystemModels.Models.BiciklistickiKlub
            {
                ID = klub.ID_KLUB,
                Lokacija = klub.LOK,
                Naziv = klub.NZVK,
                NazivSaveza = klub.NZV_SVZ,
                Takmicari = takmicari
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
        public SystemModels.Models.Radnik ConvertRadnik(Radnici radnici)
        {

            SystemModels.Models.TipZanimanja enumValue;
            enumValue = (SystemModels.Models.TipZanimanja)Enum.Parse(typeof(SystemModels.Models.TipZanimanja), radnici.TIP_Z);

            return new SystemModels.Models.Radnik
            {
                Ime = radnici.IME,
                Prezime = radnici.PRZ,
                Pol = radnici.POL,
                JMBG = (radnici.JMBG),
                NazivSaveza = radnici.NZV_SVZ,
                TipZanimanja = enumValue
            };
        }
    }
}
