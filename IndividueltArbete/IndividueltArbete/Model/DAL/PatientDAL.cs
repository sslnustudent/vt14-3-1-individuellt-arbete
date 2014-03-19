using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace IndividueltArbete.Model.DAL
{
    public class PatientDAL : DALBase
    {
        public IEnumerable<Patient> GetPatients()
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var patients = new List<Patient>(100);

                    var cmd = new SqlCommand("appSchema.usp_getpatients", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var patientID = reader.GetOrdinal("PatientID");
                        var name = reader.GetOrdinal("Namn");
                        var address = reader.GetOrdinal("Adress");
                        var postalCode = reader.GetOrdinal("Postnr");
                        var city = reader.GetOrdinal("Ort");
                        var doctor = reader.GetOrdinal("Läkare");
                        var doctorType = reader.GetOrdinal("Läkartyp");

                        while (reader.Read())
                        {
                            patients.Add(new Patient
                            {
                                PatientID = reader.GetInt32(patientID),
                                Name = reader.GetString(name),
                                Address = reader.GetString(address),
                                PostalCode = reader.GetString(postalCode),
                                City = reader.GetString(city),
                                Doctor = reader.GetString(doctor),
                                DoctorType = reader.GetString(doctorType)


                            });
                        }
                    }

                    patients.TrimExcess();

                    return patients;

                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när patienten skulle hämtas");
                }
            }
        }

        public Patient GetPatient(int id)
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var patients = new Patient();

                    var cmd = new SqlCommand("appSchema.usp_getpatientsbyid", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", id);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            var patientID = reader.GetOrdinal("PatientID");
                            var fname = reader.GetOrdinal("Fnamn");
                            var sname = reader.GetOrdinal("Enamn");
                            var address = reader.GetOrdinal("Adress");
                            var postalCode = reader.GetOrdinal("Postnr");
                            var city = reader.GetOrdinal("Ort");
                            var doctor = reader.GetOrdinal("Läkare");
                            var doctorType = reader.GetOrdinal("Läkartyp");
                            var doctorID = reader.GetOrdinal("LäkareID");

                            return new Patient
                            {
                                PatientID = reader.GetInt32(patientID),
                                FirstName = reader.GetString(fname),
                                LastName = reader.GetString(sname),
                                Address = reader.GetString(address),
                                PostalCode = reader.GetString(postalCode),
                                City = reader.GetString(city),
                                Doctor = reader.GetString(doctor),
                                DoctorType = reader.GetString(doctorType),
                                DoctorID = reader.GetInt32(doctorID)
                            };
                        }
                    }
                    return null;


                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när patienten skulle hämtas");
                }
            }
 
        }

        public void AddPatient(Patient patient)
        {
            using (var conn = CreateConnection())
            {
                try
                {                           
                    var cmd = new SqlCommand("appSchema.usp_addpatients", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fnamn", SqlDbType.VarChar, 50).Value = patient.FirstName;
                    cmd.Parameters.Add("@Enamn", SqlDbType.VarChar, 50).Value = patient.LastName;
                    cmd.Parameters.Add("@Adress", SqlDbType.VarChar, 50).Value = patient.Address;
                    cmd.Parameters.Add("@Postnr", SqlDbType.VarChar, 6).Value = patient.PostalCode;
                    cmd.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = patient.City;
                    cmd.Parameters.Add("@Läkare", SqlDbType.Int, 4).Value = int.Parse(patient.Doctor);


                    cmd.Parameters.Add("@PatientID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    patient.PatientID = (int)cmd.Parameters["@PatientID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fell uppstod");
                }
            }
 
        }

        public void EditPatient(Patient patient)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_updatepatient", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fnamn", SqlDbType.VarChar, 50).Value = patient.FirstName;
                    cmd.Parameters.Add("@Enamn", SqlDbType.VarChar, 50).Value = patient.LastName;
                    cmd.Parameters.Add("@Adress", SqlDbType.VarChar, 50).Value = patient.Address;
                    cmd.Parameters.Add("@Postnr", SqlDbType.VarChar, 6).Value = patient.PostalCode;
                    cmd.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = patient.City;

                    cmd.Parameters.Add("@LäkarID", SqlDbType.Int, 4).Value = patient.DoctorID;
                    cmd.Parameters.Add("@PatientID", SqlDbType.Int, 4).Value = patient.PatientID;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("Ett fell uppstod");
                }
            }
 
        }

        public void DeletePatient(int id)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_deletepatient", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientID", id);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return;


                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt");
                }
            }
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var doctors = new List<Doctor>(100);

                    var cmd = new SqlCommand("appSchema.usp_getdoctors", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var doctorID = reader.GetOrdinal("LäkareID");
                        var name = reader.GetOrdinal("Namn");
                        var fname = reader.GetOrdinal("Fnamn");
                        var sname = reader.GetOrdinal("Enamn");
                        var doctorType = reader.GetOrdinal("Läkartyp");

                        while (reader.Read())
                        {
                            doctors.Add(new Doctor
                            {
                                DoctorID = reader.GetInt32(doctorID),
                                Name = reader.GetString(name),
                                FirstName = reader.GetString(fname),
                                LastName = reader.GetString(sname),
                                DoctorTypes = reader.GetString(doctorType)
                            });
                        }
                    }

                    doctors.TrimExcess();

                    return doctors;

                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när läkarna skulle hämtas");
                }
            }
        }



    }
}