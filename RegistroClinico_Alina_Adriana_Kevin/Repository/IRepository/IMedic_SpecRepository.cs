using RegistroClinico_Alina_Adriana_Kevin.Models;
using static RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository
{
    public interface IMedic_SpecRepository : IRepository<Medic_Specialization>
    {
        void Update(Medic_Specialization obj);
    }
}
