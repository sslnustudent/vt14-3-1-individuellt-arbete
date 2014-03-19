using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IndividueltArbete.Model.DAL;

namespace IndividueltArbete.Model
{
    public class Service
    {

        private PatientDAL _patientDAL;

        private PatientDAL PatientDAL { get{ return _patientDAL ?? (_patientDAL = new PatientDAL()); } }

        private DoctorDAL _doctorDAL;

        private DoctorDAL DoctorDAL { get { return _doctorDAL ?? (_doctorDAL = new DoctorDAL()); } }

        public IEnumerable<Patient> Getpatients()
        {
            return PatientDAL.GetPatients();

        }

        public Patient GetPatient(int id)
        {
            return PatientDAL.GetPatient(id);
        }

        public void AddPatient(Patient patient)
        {
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(patient, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            PatientDAL.AddPatient(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(patient, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            PatientDAL.EditPatient(patient);
        }

        public void DeletePatient(int id)
        {
            PatientDAL.DeletePatient(id);
        }

        public void AddDoctor(Doctor doctor)
        {
            DoctorDAL.AddDoctor(doctor);
        }

        public void DeleteDoctor(int id)
        {
            DoctorDAL.DeleteDoctor(id);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            DoctorDAL.UpdateDoctor(doctor);
        }

        public IEnumerable<Doctor> GetpDoctors()
        {
            return PatientDAL.GetDoctors();

        }

        public Doctor GetDoctor(int id)
        {
            return DoctorDAL.GetDoctor(id);
        }

        public IEnumerable<DoctorType> GetDoctorType()
        {
            return DoctorDAL.GetDoctorType();
                
        }

    }
}