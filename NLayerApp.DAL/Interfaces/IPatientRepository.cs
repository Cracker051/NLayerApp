using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Interfaces
{
    public interface IPatientRepository
    {
        ICollection<Patients> GetPatients();
        Patients GetPatientById(int id);
        ICollection<Patients> GetPatientsBySurname(string surname);
        ICollection<Patients> GetPatientsByDiagnosis(string diagnosis);
        bool PatientExist(int id);
    }
}
