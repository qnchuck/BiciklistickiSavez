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
    public class DokumentacijaCrud : IRepository<SystemModels.Models.Dokumentacija>
    {
        IConversion conversion = new DBConversion();

        private static readonly Lazy<DokumentacijaCrud> _instance =
                new Lazy<DokumentacijaCrud>(() => new DokumentacijaCrud());

        private DBModels dBModels = DBModels.Instance;
        public static DokumentacijaCrud Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Create(SystemModels.Models.Dokumentacija dokumentacija)
        {
            try
            {
                dBModels.Dokumentacijes.Add(new Dokumentacije()
                {
                    ID_TXT = dokumentacija.ID,
                    NZV_SVZ = dokumentacija.NazivSaveza,
                    TXT = dokumentacija.Tekst
                });
                dBModels.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<SystemModels.Models.Dokumentacija> GetAll()
        {
            List<SystemModels.Models.Dokumentacija> dokumentacije = new List<SystemModels.Models.Dokumentacija>();
          
            try
            {
                dBModels.Dokumentacijes.ToList().ForEach(d => dokumentacije.Add(conversion.ConvertDokumentacija(d)));
            }
            catch (Exception)
            {

                throw;
            }
            return dokumentacije;
        }

        public int Delete(int id)
        {
            int ret = -1;
            try
            {
                dBModels.Dokumentacijes.ToList().ForEach((x) =>
                {
                    if (x.ID_TXT == id)
                    {
                        dBModels.Dokumentacijes.Remove(x);
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

        public int Modify(Dokumentacija entity)
        {
            int ret = -1;
            try
            {
                dBModels.Dokumentacijes.ToList().ForEach((x) =>
                {
                    if (x.ID_TXT == entity.ID)
                    {
                        x.ID_TXT = entity.ID;
                        x.NZV_SVZ = entity.NazivSaveza;
                        x.TXT = entity.Tekst;
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
