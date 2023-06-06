using BiciklistickiSavez.Conversion;
using BiciklistickiSavez.CRUD;
using BiciklistickiSavez.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels.Models;

namespace BiciklistickiSavez.DBCrud
{
    public class KlubCrud : IRepository<SystemModels.Models.BiciklistickiKlub>
    {

        IConversion conversion = new DBConversion();

        private static readonly Lazy<KlubCrud> _instance =
                new Lazy<KlubCrud>(() => new KlubCrud());

        private DBModels dBModels = DBModels.Instance;
        public static KlubCrud Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Create(SystemModels.Models.BiciklistickiKlub klub)
        {
            try
            {
                dBModels.Biciklisticki_Klub.Add(new Biciklisticki_Klub()
                {
                    ID_KLUB = klub.ID,
                    LOK = klub.Lokacija,
                    NZVK = klub.Naziv,
                    NZV_SVZ = klub.NazivSaveza
                });
                dBModels.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<SystemModels.Models.BiciklistickiKlub> GetAll()
        {
            List<SystemModels.Models.BiciklistickiKlub> klubovi = new List<SystemModels.Models.BiciklistickiKlub>();

            try
            {
                dBModels.Biciklisticki_Klub.ToList().ForEach(k => klubovi.Add(conversion.ConvertBiciklistickiKlub(k)));
            }
            catch (Exception)
            {

                throw;
            }


            return klubovi;
        }

        public List<SystemModels.Models.BiciklistickiKlub> GetKluboviSavez(SystemModels.Models.BiciklistickiSavez savez)
        {
            List<SystemModels.Models.BiciklistickiKlub> klubovi = new List<SystemModels.Models.BiciklistickiKlub>();
            try
            {
                dBModels.Biciklisticki_Klub
                        .Where(k => savez.Naziv == k.NZV_SVZ)
                        .ToList()
                        .ForEach(k => klubovi.Add(conversion.ConvertBiciklistickiKlub(k)));
            }
            catch (Exception)
            {

                throw;
            }

            return klubovi;
        }




        public int Delete(int id)
        {
            int ret = -1;
            try
            {
                dBModels.Biciklisticki_Klub.ToList().ForEach((x) =>
                {
                    if (x.ID_KLUB == id)
                    {
                        dBModels.Biciklisticki_Klub.Remove(x);
                    }
                });

                ret = dBModels.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }


        public int Modify(BiciklistickiKlub entity)
        {
            int ret = -1;
            try
            {
                dBModels.Biciklisticki_Klub.ToList().ForEach((x) =>
                {
                    if (x.ID_KLUB == entity.ID)
                    {

                        x.ID_KLUB = entity.ID;
                        x.LOK = entity.Lokacija;
                        x.NZVK = entity.Naziv;
                        x.NZV_SVZ = entity.NazivSaveza;
                    }
                });

                ret = dBModels.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }
    }
}
