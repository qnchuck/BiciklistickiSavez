using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciklistickiSavez.Database
{
    public class DBConversion
    {
        public DBConversion() { }
        public SystemModels.Models.BiciklistickiSavez ConvertBiciklistickiSavez(Biciklisticki_Savez savez)
        {

            return new SystemModels.Models.BiciklistickiSavez
            {
                Naziv = savez.NZV,
                Drzava = savez.DRZ,
            };
            
        }

    }
}
