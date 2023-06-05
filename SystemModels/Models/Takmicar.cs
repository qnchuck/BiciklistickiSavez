using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.Models
{
    public class Takmicar
    {
        public string JMBG { get; set; }
        public string Pol { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string NazivSaveza { get; set; }
        public List<Bicikli> Bicikli { get; set; } = new List<Bicikli>();
    }
}
