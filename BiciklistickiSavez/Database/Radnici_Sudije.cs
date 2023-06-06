namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Radnici_Sudije
    {
        [Required]
        [StringLength(30)]
        public string TIP_D { get; set; }

        [Key]
        [StringLength(13)]
        public string JMBG { get; set; }

        public int? BR_LIC { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Radnici Radnici { get; set; }
    }
}
