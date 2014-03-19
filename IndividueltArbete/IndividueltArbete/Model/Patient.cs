using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IndividueltArbete.Model
{
    public class Patient
    {

        public int PatientID { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges.")]
        [StringLength(50, ErrorMessage = "Förnamnet kan bestå av som mest 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges.")]
        [StringLength(50, ErrorMessage = "efternamn kan bestå av som mest 50 tecken.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "En adress måste anges.")]
        [StringLength(30, ErrorMessage = "adress kan bestå av som mest 30 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ett postnummer måste anges.")]
        [StringLength(5, ErrorMessage = "postnummer kan bestå av som mest 5 tecken.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "En ort måste anges.")]
        [StringLength(25, ErrorMessage = "Ort kan bestå av som mest 25 tecken.")]
        public string City { get; set; }

        public string Doctor { get; set; }

        public int DoctorID { get; set; }

        public string DoctorType { get; set; }
    }
}