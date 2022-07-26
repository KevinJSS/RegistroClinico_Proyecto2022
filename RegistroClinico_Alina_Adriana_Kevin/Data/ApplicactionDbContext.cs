using Microsoft.EntityFrameworkCore;
using RegistroClinico_Alina_Adriana_Kevin.Models;

namespace RegistroClinico_Alina_Adriana_Kevin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        /* DBSETs (MODELS) */
        public DbSet<Specialization> Specializations { get; set; }
        
        public DbSet<Treatment> Treatments { get; set; }
        
        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Illness> Illnesses { get; set; }

        public DbSet<Medic> Medics { get; set; }

        public DbSet<Medic_Specialization> Medic_Specializations { get; set; }

        public DbSet<Patient_Illness> Patient_Illnesses { get; set; }

        public DbSet<Patient_Medic> Patient_Medics { get; set; }

        public DbSet<Patient_Medicament> Patient_Medicaments { get; set; }

        public DbSet<Patient_Treatment> Patient_Treatments { get; set; }

        public DbSet<TestResult> TestResults { get; set; }

        public DbSet<ClinicalAnnotation> ClinicalAnnotations { get; set; }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } //Usuarios***
    }
}
