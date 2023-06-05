namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Takmicari")]
    public partial class Takmicari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Takmicari()
        {
            Biciklis = new HashSet<Bicikli>();
        }

        [Key]
        [StringLength(13)]
        public string JMBG { get; set; }

        [Required]
        public string IME { get; set; }

        [Required]
        public string PRZ { get; set; }

        [Required]
        public string POL { get; set; }

        public int? ID_KLUB { get; set; }

        [Required]
        [StringLength(30)]
        public string NZV_SVZ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bicikli> Biciklis { get; set; }

        public virtual Biciklisticki_Klub Biciklisticki_Klub { get; set; }

        public virtual Biciklisticki_Savez Biciklisticki_Savez { get; set; }
    }
}
