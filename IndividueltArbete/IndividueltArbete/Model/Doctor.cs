using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueltArbete.Model
{
    public class Doctor
    {
        public int DoctorID { get; set; }

        public string Name { get; set; }

        public string DoctorTypes { get; set; }

        public int DoctorTypeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}