namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Biciklisticki_Savez
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biciklisticki_Savez()
        {
            Biciklisticki_Klub = new HashSet<Biciklisticki_Klub>();
            Dokumentacijes = new HashSet<Dokumentacije>();
            Radnicis = new HashSet<Radnici>();
            Takmicaris = new HashSet<Takmicari>();
        }

        [Key]
        [StringLength(30)]
        public string NZV { get; set; }

        [Required]
        public string DRZ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biciklisticki_Klub> Biciklisticki_Klub { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dokumentacije> Dokumentacijes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Radnici> Radnicis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Takmicari> Takmicaris { get; set; }
    }
}
