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

        public void AddPatient(Patient patient)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 101).Value = patient.Name;
                    cmd.Parameters.Add("@Adress", SqlDbType.VarChar, 30).Value = patient.Address;
                    cmd.Parameters.Add("@Postnr", SqlDbType.VarChar, 6).Value = patient.PostalCode;
                    cmd.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = patient.City;
                    cmd.Parameters.Add("@Läkare", SqlDbType.VarChar, 101).Value = patient.Doctor;


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
    }
}