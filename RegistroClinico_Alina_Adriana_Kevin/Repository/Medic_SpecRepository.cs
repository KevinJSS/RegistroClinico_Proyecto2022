using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class Medic_SpecRepository : Repository<Medic_Specialization>, IMedic_SpecRepository
    {
        private ApplicationDbContext _db;

        public Medic_SpecRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Medic_Specialization obj)
        {
            _db.Medic_Specializations.Update(obj);
        }
    }
}
