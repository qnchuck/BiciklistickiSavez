using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.Models
{
    public enum TipZanimanja
    {
        Sudija,
        Delegat,
        Organizator
    }
    public class Radnik
    {
        public long JMBG { get; set; }
        public string Pol { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public TipZanimanja TipZanimanja { get; set; }

        public string NazivSaveza { get; set; }
    }
}
