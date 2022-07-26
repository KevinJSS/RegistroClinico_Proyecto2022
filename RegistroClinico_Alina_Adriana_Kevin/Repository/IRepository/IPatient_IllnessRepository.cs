using RegistroClinico_Alina_Adriana_Kevin.Models;
using static RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository
{
    public interface IPatient_IllnessRepository : IRepository<Patient_Illness>
    {
        void Update(Patient_Illness obj);
    }
}
