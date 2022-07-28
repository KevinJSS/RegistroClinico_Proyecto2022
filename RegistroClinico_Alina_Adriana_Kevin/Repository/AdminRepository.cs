using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private ApplicationDbContext _db;

        public AdminRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Admin obj)
        {
            _db.Admins.Update(obj);
        }
    }
}
