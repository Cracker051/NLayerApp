namespace NLayerApp.DAL.Entities
{
    public class Patients
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string Phone { get; set; }
        public string Diagnosis { get; set; }
        public virtual Doctors Doctor { get; set; }
        public DateOnly Arrive_date { get; set; }
        public DateOnly? Recovery_date { get; set; }
    }

}
