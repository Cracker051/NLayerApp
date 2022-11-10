using NLayerApp.DAL.Data;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace NLayerApp.DAL.Repository
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly DataContext _context;
        public DoctorRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Doctors> GetDoctors() 
        {
            return _context.Doctors.OrderBy(p => p.Id).Include(p => p.Department).ToList();
        }
        public bool DoctorExist(int DoctorId)
        {
            return _context.Doctors.Any(p => p.Id == DoctorId);
        }
        public Doctors GetDoctorById(int id)
        {
            return _context.Doctors.Include(p=>p.Department).Where(p => p.Id == id).FirstOrDefault();
        }
        public ICollection<Doctors> GetDoctorsBySurname(string name)
        {
            return _context.Doctors.Include(p => p.Department).Where(p => p.surname == name).ToList();
        }
        public ICollection<Doctors> GetDoctorsByDepartment(string DepartmentName)
        {
            return _context.Doctors.Include(p => p.Department).Where(p => p.Department.Name == DepartmentName).ToList();
        }
    }
}
