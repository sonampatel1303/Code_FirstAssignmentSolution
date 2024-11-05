namespace Code_FirstAssignment.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientID { get; set; }   
        public int Doctorid { get; set; }
        public DateTime AppointmentTime { get; set; }

    }
}
