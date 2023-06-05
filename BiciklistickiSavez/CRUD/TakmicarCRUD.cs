﻿using BiciklistickiSavez.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels.Models;

namespace BiciklistickiSavez.CRUD
{
    public class TakmicarCRUD : IRepository<SystemModels.Models.Takmicar>
    {
        private static readonly Lazy<TakmicarCRUD> _instance =
        new Lazy<TakmicarCRUD>(() => new TakmicarCRUD());

        private DBModels dBModels = DBModels.Instance;

        private DBConversion conversion = new DBConversion();
        public static TakmicarCRUD Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Create(SystemModels.Models.Takmicar takmicar)
        {
            dBModels.Takmicaris.Add(new Takmicari
            {
                JMBG = takmicar.JMBG.ToString(),
                IME = takmicar.Ime,
                PRZ = takmicar.Prezime,
                NZV_SVZ = takmicar.NazivSaveza,
                POL = takmicar.Pol 
            });
            dBModels.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SystemModels.Models.Takmicar> GetAll()
        {
            List<SystemModels.Models.Takmicar> takmicari = new List<SystemModels.Models.Takmicar>();
            dBModels.Takmicaris.ToList().ForEach(t => takmicari.Add(conversion.ConvertTakmicar(t)));
            return takmicari;
        }

        public int Modify(Takmicar entity)
        {
            throw new NotImplementedException();
        }
    }
}
