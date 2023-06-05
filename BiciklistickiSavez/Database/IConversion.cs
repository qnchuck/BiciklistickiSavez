using BiciklistickiSavez.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciklistickiSavez.Conversion
{
    interface IConversion
    {

        SystemModels.Models.BiciklistickiSavez ConvertBiciklistickiSavez(Biciklisticki_Savez savez);
        SystemModels.Models.BiciklistickiKlub ConvertBiciklistickiKlub(Biciklisticki_Klub klub);
        SystemModels.Models.Dokumentacija ConvertDokumentacija(Dokumentacije dokumentacija);
        SystemModels.Models.Bicikli ConvertBicikli(Bicikli bicikli);
        SystemModels.Models.Takmicar ConvertTakmicar(Takmicari takmicari);
    }
}
