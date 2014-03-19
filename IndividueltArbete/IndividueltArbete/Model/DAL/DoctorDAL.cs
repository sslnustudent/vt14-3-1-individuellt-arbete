using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace IndividueltArbete.Model.DAL
{
    public class DoctorDAL : DALBase
    {

        public void AddDoctor(Doctor doctor)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_adddoctor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fnamn", SqlDbType.VarChar, 50).Value = doctor.FirstName;
                    cmd.Parameters.Add("@Enamn", SqlDbType.VarChar, 50).Value = doctor.LastName;
                    cmd.Parameters.Add("@Läkartyp", SqlDbType.Int, 4).Value = int.Parse(doctor.DoctorTypes);


                    cmd.Parameters.Add("@LäkareID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    doctor.DoctorID = (int)cmd.Parameters["@LäkareID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fell uppstod");
                }
            }

        }

        public IEnumerable<DoctorType> GetDoctorType()
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var doctors = new List<DoctorType>(100);

                    var cmd = new SqlCommand("appSchema.usp_getdoctortype", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {                                         
                        var doctortypeID = reader.GetOrdinal("LäkartypID");
                        var doctortype = reader.GetOrdinal("Läkartyp");

                        while (reader.Read())
                        {
                            doctors.Add(new DoctorType
                            {
                                DoctorTypeId = reader.GetInt32(doctortypeID),
                                DoctorTypes = reader.GetString(doctortype)
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

        public void DeleteDoctor(int id)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_deletedoctor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LäkareID", id);

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

        public Doctor GetDoctor(int id)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_getdoctorbyid", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LäkareID", id);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var doctorID = reader.GetOrdinal("LäkareID");
                            var firstName = reader.GetOrdinal("Fnamn");
                            var lastName = reader.GetOrdinal("Enamn");
                            var doctortypeID = reader.GetOrdinal("LäkartypID");
                            var doctortype = reader.GetOrdinal("Läkartyp");

                            return new Doctor
                            {
                                DoctorID = reader.GetInt32(doctorID),
                                FirstName = reader.GetString(firstName),
                                LastName = reader.GetString(lastName),
                                DoctorTypeId = reader.GetInt32(doctortypeID),
                                DoctorTypes = reader.GetString(doctortype)
                            };

                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Det uppstod ett fel");
                }
            }
        }

        public void UpdateDoctor(Doctor doctor)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_updatedoctor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LäkareID", doctor.DoctorID);
                    cmd.Parameters.Add("@Fnamn", SqlDbType.VarChar, 50).Value = doctor.FirstName;
                    cmd.Parameters.Add("@Enamn", SqlDbType.VarChar, 50).Value = doctor.LastName;
                    cmd.Parameters.AddWithValue("@Läkartyp", doctor.DoctorTypeId);


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

    }
}