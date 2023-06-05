using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.Models
{
    public class BiciklistickiSavez
    {
        public string Naziv { get; set; }
        public string Drzava { get; set; }
        public List<BiciklistickiKlub> Klubovi { get; set; } = new List<BiciklistickiKlub>();
        public List<Takmicar> Takmicari { get; set; } = new List<Takmicar>();
        public List<Radnik> Radnici { get; set; } = new List<Radnik> ();
        public List<Dokumentacija> Dokumentacije { get; set; } = new List<Dokumentacija>();

    }
}
