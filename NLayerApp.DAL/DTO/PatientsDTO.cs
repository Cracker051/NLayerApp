namespace NLayerApp.DAL.DTO
{
    public class PatientsDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string Phone { get; set; }
        public DoctorsDTO Doctor { get; set; }
        public DateOnly Arrive_date { get; set; }
        public DateOnly? Recovery_date { get; set; }
    }
}
