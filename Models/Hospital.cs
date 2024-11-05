﻿namespace Code_FirstAssignment.Models
{
    public class Hospital
    {
        public int HospitalID {get; set; }
        public string HospitalName {get; set; }
        public string Location {get; set; }

        public virtual ICollection<Doctor>? Doctors {get; set; }    
    }
}
