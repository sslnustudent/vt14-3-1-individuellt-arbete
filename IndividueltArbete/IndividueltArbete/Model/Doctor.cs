using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IndividueltArbete.Model
{
    public class Doctor
    {
        public int DoctorID { get; set; }

        public string Name { get; set; }

        public string DoctorTypes { get; set; }

        public int DoctorTypeId { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges.")]
        [StringLength(50, ErrorMessage = "Förnamnet kan bestå av som mest 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges.")]
        [StringLength(50, ErrorMessage = "Efternamnet kan bestå av som mest 50 tecken.")]
        public string LastName { get; set; }

    }
}