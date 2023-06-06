using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BiciklistickiSavez.Database
{
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
        }
        private static readonly Lazy<DBModels> _instance =
       new Lazy<DBModels>(() => new DBModels());

       
        public static DBModels Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public virtual DbSet<Bicikli> Biciklis { get; set; }
        public virtual DbSet<Biciklisticki_Klub> Biciklisticki_Klub { get; set; }
        public virtual DbSet<Biciklisticki_Savez> Biciklisticki_Savez { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Dokumentacije> Dokumentacijes { get; set; }
        public virtual DbSet<Radnici> Radnicis { get; set; }
        public virtual DbSet<Radnici_Delegat> Radnici_Delegat { get; set; }
        public virtual DbSet<Radnici_Organizator> Radnici_Organizator { get; set; }
        public virtual DbSet<Radnici_Sudije> Radnici_Sudije { get; set; }
        public virtual DbSet<Takmicari> Takmicaris { get; set; }
        public virtual DbSet<Takmicenja> Takmicenjas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biciklisticki_Savez>()
                .HasMany(e => e.Biciklisticki_Klub)
                .WithRequired(e => e.Biciklisticki_Savez)
                .HasForeignKey(e => e.NZV_SVZ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Biciklisticki_Savez>()
                .HasMany(e => e.Dokumentacijes)
                .WithRequired(e => e.Biciklisticki_Savez)
                .HasForeignKey(e => e.NZV_SVZ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Biciklisticki_Savez>()
                .HasMany(e => e.Radnicis)
                .WithRequired(e => e.Biciklisticki_Savez)
                .HasForeignKey(e => e.NZV_SVZ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Biciklisticki_Savez>()
                .HasMany(e => e.Takmicaris)
                .WithRequired(e => e.Biciklisticki_Savez)
                .HasForeignKey(e => e.NZV_SVZ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discipline>()
                .HasMany(e => e.Radnici_Sudije)
                .WithRequired(e => e.Discipline)
                .HasForeignKey(e => e.TIP_D)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Radnici>()
                .HasOptional(e => e.Radnici_Delegat)
                .WithRequired(e => e.Radnici)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Radnici>()
                .HasOptional(e => e.Radnici_Organizator)
                .WithRequired(e => e.Radnici)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Radnici>()
                .HasOptional(e => e.Radnici_Sudije)
                .WithRequired(e => e.Radnici);

            modelBuilder.Entity<Radnici_Delegat>()
                .HasMany(e => e.Takmicenjas)
                .WithMany(e => e.Radnici_Delegat)
                .Map(m => m.ToTable("DelegatTakmicenje").MapLeftKey("Delegati_JMBG"));

            modelBuilder.Entity<Radnici_Organizator>()
                .HasMany(e => e.Takmicenjas)
                .WithRequired(e => e.Radnici_Organizator)
                .HasForeignKey(e => e.Organizator_JMBG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Takmicari>()
                .HasMany(e => e.Biciklis)
                .WithOptional(e => e.Takmicari)
                .HasForeignKey(e => e.JMBG_T);
        }
    }
}
