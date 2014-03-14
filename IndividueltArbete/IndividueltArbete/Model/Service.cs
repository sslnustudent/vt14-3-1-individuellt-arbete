using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndividueltArbete.Model.DAL;

namespace IndividueltArbete.Model
{
    public class Service
    {

        private PatientDAL _patientDAL;

        private PatientDAL PatientDAL { get{ return _patientDAL ?? (_patientDAL = new PatientDAL()); } }

        public IEnumerable<Patient> Getpatients()
        {
            return PatientDAL.GetPatients();

        }

        public void AddPatient(Patient patient)
        {
            PatientDAL.AddPatient(patient);
        }

    }
}