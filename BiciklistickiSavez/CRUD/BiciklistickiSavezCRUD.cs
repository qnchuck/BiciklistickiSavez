using BiciklistickiSavez.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciklistickiSavez.CRUD
{
    public class BiciklistickiSavezCRUD: IRepository<SystemModels.Models.BiciklistickiSavez>
    {
        private static readonly Lazy<BiciklistickiSavezCRUD> _instance =
        new Lazy<BiciklistickiSavezCRUD>(() => new BiciklistickiSavezCRUD());

        private DBModels dBModels = DBModels.Instance;

        private DBConversion conversion = new DBConversion();
        public static BiciklistickiSavezCRUD Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Create(SystemModels.Models.BiciklistickiSavez savez)
        {
            dBModels.Biciklisticki_Savez.Add(new Biciklisticki_Savez
            {
                NZV = savez.Naziv,
                DRZ = savez.Drzava
            });
            dBModels.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SystemModels.Models.BiciklistickiSavez> GetAll()
        {
            List<SystemModels.Models.BiciklistickiSavez> savezi = new List<SystemModels.Models.BiciklistickiSavez>();
            dBModels.Biciklisticki_Savez.ToList().ForEach(t => savezi.Add(conversion.ConvertBiciklistickiSavez(t)));
            return savezi;
        }

        public int Modify(SystemModels.Models.BiciklistickiSavez entity)
        {
            throw new NotImplementedException();
        }
    }
}
