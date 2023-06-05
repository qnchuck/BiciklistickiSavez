using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.Models
{
    public class BiciklistickiKlub
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public List<Takmicar> Takmicari { get; set; } = new List<Takmicar>();
        public string NazivSaveza { get; set; }
    }
}
