namespace NLayerApp.DAL.Entities
{
    public class Doctors
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Departments Department { get; set; }

        public virtual ICollection<Patients> Patients { get; set; } = new List<Patients>();

    }
}
