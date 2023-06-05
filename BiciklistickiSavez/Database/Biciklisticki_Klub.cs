namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Biciklisticki_Klub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biciklisticki_Klub()
        {
            Takmicaris = new HashSet<Takmicari>();
        }

        [Key]
        public int ID_KLUB { get; set; }

        [Required]
        public string NZVK { get; set; }

        [Required]
        public string LOK { get; set; }

        [Required]
        [StringLength(30)]
        public string NZV_SVZ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Takmicari> Takmicaris { get; set; }

        public virtual Biciklisticki_Savez Biciklisticki_Savez { get; set; }
    }
}
