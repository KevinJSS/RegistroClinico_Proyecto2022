using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class ClinicalAnnotRepository : Repository<ClinicalAnnotation>, IClinicalAnnotRepository
    {
        private ApplicationDbContext _db;

        public ClinicalAnnotRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ClinicalAnnotation obj)
        {
            _db.ClinicalAnnotations.Update(obj);
        }
    }
}
