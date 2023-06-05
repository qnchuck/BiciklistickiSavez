using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.Models
{
    public class Sudija:Radnik
    {
        public Disciplina Disciplina { get; set; }= new Disciplina(); 
    }
}
