using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueltArbete.Model
{
    public class Patient
    {

        public int PatientID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Doctor { get; set; }

        public string DoctorType { get; set; }
    }
}