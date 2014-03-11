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

                    var cmd = new SqlCommand("", conn);
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

                        while (reader.Read())
                        {
                            patients.Add(new Patient
                            {
                                PatientID = reader.GetInt32(patientID),
                                Name = reader.GetString(name),
                                Address = reader.GetString(address),
                                PostalCode = reader.GetString(postalCode),
                                City = reader.GetString(city),
                                Doctor = reader.GetString(doctor)


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

    }
}