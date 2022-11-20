using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;

namespace NLayerApp.DAL.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public Departments GetDepartmentById(int id)
        {
            return _context.Departments.Where(p => p.Id == id).FirstOrDefault();
        }
        public Departments GetDepartmentByName(string name)
        {
            return _context.Departments.Where(p => p.Name == name).FirstOrDefault();
        }
        public bool DepartmentExist(int departmentId)
        {
            return _context.Departments.Any(p => p.Id == departmentId);
        }
        public ICollection<Departments> GetDepartments()
        {
            return _context.Departments.OrderBy(p => p.Id).ToList();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public void CreateDepartment(Departments department)
        {
            _context.Add(department);
        }
    }
}
