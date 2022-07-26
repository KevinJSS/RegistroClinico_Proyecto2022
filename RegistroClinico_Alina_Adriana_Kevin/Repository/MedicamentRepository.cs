using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class MedicamentRepository : Repository<Medicament>, IMedicamentRepository
    {
        private ApplicationDbContext _db;

        public MedicamentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Medicament obj)
        {
            _db.Medicaments.Update(obj);
        }
    }
}
