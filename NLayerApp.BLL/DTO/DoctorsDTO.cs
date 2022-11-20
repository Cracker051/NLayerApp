
namespace NLayerApp.BLL.DTO
{
    public class DoctorsDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DepartmentsDTO Department { get; set; }

        public ICollection<PatientsDTO> Patients { get; set; } = new List<PatientsDTO>();
    }
}
