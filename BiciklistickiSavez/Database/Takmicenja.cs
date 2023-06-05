namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Takmicenja")]
    public partial class Takmicenja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Takmicenja()
        {
            Radnici_Delegat = new HashSet<Radnici_Delegat>();
        }

        [Key]
        [Column(Order = 0)]
        public int ID_TAK { get; set; }

        [Required]
        public string NZV { get; set; }

        [Required]
        [StringLength(30)]
        public string TIP_D { get; set; }

        [Required]
        public string LOK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string JMBG_ORG { get; set; }

        [Required]
        public string TIP_T { get; set; }

        [Required]
        [StringLength(13)]
        public string Organizator_JMBG { get; set; }

        public virtual Radnici_Organizator Radnici_Organizator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Radnici_Delegat> Radnici_Delegat { get; set; }
    }
}
