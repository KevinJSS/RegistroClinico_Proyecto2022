using RegistroClinico_Alina_Adriana_Kevin.Models;
using static RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository
{
    public interface IPatient_TreatmentRepository : IRepository<Patient_Treatment>
    {
        void Update(Patient_Treatment obj);
    }
}
