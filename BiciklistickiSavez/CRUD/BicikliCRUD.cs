using BiciklistickiSavez.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciklistickiSavez.CRUD
{
    public class BicikliCRUD : IRepository<SystemModels.Models.Bicikli>
    {
        private static readonly Lazy<BicikliCRUD> _instance =
        new Lazy<BicikliCRUD>(() => new BicikliCRUD());

        private DBModels dBModels = DBModels.Instance;

        private DBConversion conversion = new DBConversion();
        public static BicikliCRUD Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Create(SystemModels.Models.Bicikli bicikl)
        {
            dBModels.Biciklis.Add(new Bicikli
            {
                MOD = bicikl.Model,
                PRO = bicikl.Proizvodjac,
                ZEM_P = bicikl.ZemljaPorekla
            });
            dBModels.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SystemModels.Models.Bicikli> GetAll()
        {
            List<SystemModels.Models.Bicikli> bicikli = new List<SystemModels.Models.Bicikli>();
            dBModels.Biciklis.ToList().ForEach(t => bicikli.Add(conversion.ConvertBicikli(t)));
            return bicikli;
        }

        public int Modify(SystemModels.Models.Bicikli entity)
        {
            throw new NotImplementedException();
        }
    }
}
