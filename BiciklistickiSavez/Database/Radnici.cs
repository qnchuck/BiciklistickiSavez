namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Radnici")]
    public partial class Radnici
    {
        [Key]
        [StringLength(13)]
        public string JMBG { get; set; }

        [Required]
        public string IME { get; set; }

        [Required]
        public string PRZ { get; set; }

        [Required]
        public string POL { get; set; }

        [Required]
        public string TIP_Z { get; set; }

        [Required]
        [StringLength(30)]
        public string NZV_SVZ { get; set; }

        public virtual Biciklisticki_Savez Biciklisticki_Savez { get; set; }

        public virtual Radnici_Delegat Radnici_Delegat { get; set; }

        public virtual Radnici_Organizator Radnici_Organizator { get; set; }

        public virtual Radnici_Sudije Radnici_Sudije { get; set; }
    }
}
