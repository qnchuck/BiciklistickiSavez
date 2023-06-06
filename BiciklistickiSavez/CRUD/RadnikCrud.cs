using BiciklistickiSavez.Conversion;
using BiciklistickiSavez.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels.Models;

namespace BiciklistickiSavez.CRUD
{
    public class RadnikCrud : IRepository<SystemModels.Models.Radnik>
    {
        IConversion conversion = new DBConversion();

        private static readonly Lazy<RadnikCrud> _instance =
                new Lazy<RadnikCrud>(() => new RadnikCrud());

        private DBModels dBModels = DBModels.Instance;
        public static RadnikCrud Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Create(SystemModels.Models.Radnik radnik)
        {
            try
            {
                dBModels.Radnicis.Add(new Radnici()
                {
                    IME = radnik.Ime,
                    PRZ = radnik.Prezime,
                    POL = radnik.Pol,
                    JMBG = radnik.JMBG.ToString(),
                    NZV_SVZ = radnik.NazivSaveza,
                    TIP_Z = radnik.TipZanimanja.ToString()
                });
                dBModels.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        public List<SystemModels.Models.Radnik> GetAll()
        {
            List<SystemModels.Models.Radnik> radnici = new List<SystemModels.Models.Radnik>();

            try
            {
                dBModels.Radnicis.ToList().ForEach(k => radnici.Add(conversion.ConvertRadnik(k)));
            }
            catch (Exception)
            {

                throw;
            }


            return radnici;
        }


        public List<SystemModels.Models.Radnik> GetSavezRadnici(SystemModels.Models.BiciklistickiSavez savez)
        {
            List<SystemModels.Models.Radnik> radnici = new List<SystemModels.Models.Radnik>();

            try
            {
                dBModels.Radnicis.Where(r=>r.NZV_SVZ == savez.Naziv)
                                 .ToList()
                                 .ForEach(k => radnici.Add(conversion.ConvertRadnik(k)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return radnici;
        }


        public int Delete(int id)
        {
            int ret = -1;
            try
            {
                dBModels.Radnicis.ToList().ForEach((x) =>
                {
                    if (x.JMBG == id.ToString())
                    {
                        dBModels.Radnicis.Remove(x);
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
        public int DeleteRadnik(string id)
        {
            int ret = -1;
            try
            {
                dBModels.Radnicis.ToList().ForEach((x) =>
                {
                    if (x.JMBG == id)
                    {
                        dBModels.Radnicis.Remove(x);
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


        public int Modify(Radnik entity)
        {
            int ret = -1;
            try
            {
                dBModels.Radnicis.ToList().ForEach((x) =>
                {
                    if (x.JMBG == entity.JMBG.ToString())
                    {
                        x.IME = entity.Ime;
                        x.PRZ = entity.Prezime;
                        x.POL = entity.Pol;
                        x.JMBG = entity.JMBG.ToString();
                        x.NZV_SVZ = entity.NazivSaveza;
                        x.TIP_Z = entity.TipZanimanja.ToString();
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
