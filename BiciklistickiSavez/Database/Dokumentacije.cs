namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dokumentacije")]
    public partial class Dokumentacije
    {
        [Key]
        public int ID_TXT { get; set; }

        [Required]
        public string TXT { get; set; }

        [Required]
        [StringLength(30)]
        public string NZV_SVZ { get; set; }

        public virtual Biciklisticki_Savez Biciklisticki_Savez { get; set; }
    }
}
