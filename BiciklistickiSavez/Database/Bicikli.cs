namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bicikli
    {
        [Key]
        public int ID_B { get; set; }

        [Required]
        public string MOD { get; set; }

        [Required]
        public string ZEM_P { get; set; }

        [Required]
        public string PRO { get; set; }

        [StringLength(13)]
        public string JMBG_T { get; set; }

        public virtual Takmicari Takmicari { get; set; }
    }
}
