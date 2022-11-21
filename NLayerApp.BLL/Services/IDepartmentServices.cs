using NLayerApp.BLL.DTO;

namespace NLayerApp.BLL.Services
{
    public interface IDepartmentServices
    {
        DepartmentsDTO Create(DepartmentsDTO department);
        DepartmentsDTO GetById(int id);
        DepartmentsDTO GetByName(string name);
        ICollection<DepartmentsDTO> GetDepartments();
    }
}