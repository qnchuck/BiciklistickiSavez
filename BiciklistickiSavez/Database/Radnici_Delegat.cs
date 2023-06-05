namespace BiciklistickiSavez.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Radnici_Delegat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Radnici_Delegat()
        {
            Takmicenjas = new HashSet<Takmicenja>();
        }

        [Key]
        [StringLength(13)]
        public string JMBG { get; set; }

        public virtual Radnici Radnici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Takmicenja> Takmicenjas { get; set; }
    }
}
