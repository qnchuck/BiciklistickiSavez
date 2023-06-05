using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.Models
{
    public class Takmicenje
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public string Tip { get; set; }
        public Disciplina Disciplina { get; set; } = new Disciplina();
        public List<Radnik> Delegati { get; set; } = new List<Radnik>();
    }
}
