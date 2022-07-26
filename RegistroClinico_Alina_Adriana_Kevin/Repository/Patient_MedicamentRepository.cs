using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class Patient_MedicamentRepository : Repository<Patient_Medicament>, IPatient_MedicamentRepository
    {
        private ApplicationDbContext _db;

        public Patient_MedicamentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient_Medicament obj)
        {
            _db.Patient_Medicaments.Update(obj);
        }
    }
}
