using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace NLayerApp.DAL.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Patients> GetPatients()
        {
            return _context.Patients.OrderBy(p=>p.Id).Include(p=> p.Doctor).ToList();
        }
        public Patients GetPatientById(int id)
        {
            //return _context.Patients
            //    .Where(p => p.Id == id)
            //    .Select(p => new Patients
            //    {
            //        Id = p.Id,
            //        name = p.name,
            //        surname = p.surname,
            //        Phone = p.Phone,
            //        Diagnosis = p.Diagnosis,
            //        Arrive_date = p.Arrive_date,
            //        Recovery_date = p.Recovery_date,
            //        Doctor = p.Doctor.Select(d=>d.Id)
            //    }).AsNoTracking()
            //    .FirstOrDefault();
            return _context.Patients.Include(p => p.Doctor).Where(p => p.Id == id).FirstOrDefault();
        }
        public bool PatientExist(int id)
        {
            return _context.Patients.Any(p => p.Id == id);
        }
        public ICollection<Patients> GetPatientsBySurname(string name)
        {
            return _context.Patients.Include(p => p.Doctor).Where(p => p.surname==name).ToList();
        }
        public ICollection<Patients> GetPatientsByDiagnosis(string diagnosis)
        {
            return _context.Patients.Include(p => p.Doctor).Where(p => p.Diagnosis == diagnosis).ToList();
        }
    }
}
