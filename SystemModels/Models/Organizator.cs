using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.Models
{
    public class Organizator:Radnik
    {
        public List<Takmicenje> Takmicenja { get; set; } = new List<Takmicenje>();
    }
}
