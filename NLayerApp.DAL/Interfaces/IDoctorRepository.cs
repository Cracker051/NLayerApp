using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Interfaces
{
    public interface IDoctorRepository
    {
        ICollection<Doctors> GetDoctors();
        Doctors GetDoctorById(int id);
        ICollection<Doctors> GetDoctorsBySurname(string name);
        ICollection<Doctors> GetDoctorsByDepartment(string DepartmentName);
        bool DoctorExist(int doctorId);

    }
}
