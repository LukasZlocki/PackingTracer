using System.Data;
using Microsoft.Data.SqlClient;
using PackingTracer.Data.PackingDay;

namespace PackingTracer.Service.DbEngine
{
    public class DbEng
    {
        // ToDo: server config load from setup file
        static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=dbo.Unit_EventLog;Integrated Security=True; TrustServerCertificate=True";

        /// <summary>
        /// Returns WorkDaySheet object by DateTime day
        /// </summary>
        /// <param name="day">DateTime day</param>
        /// <returns>WorkDaySheet object</returns>
        public WorkDaySheet GetQuantityOfPackedSmc2MotorsByWholeDay3Shifts(DateTime day)
        {
            WorkDaySheet workDaySheet = new WorkDaySheet();

            string _day = day.ToString("d");
            string _dayNext = day.AddDays(1).ToString("d");

            // ToDo: Query load from file
            string queryString = "SELECT DATEPART(HOUR, Created) AS[WorkingHour], Created " +
                           "FROM[dbo.Unit_EventLog].dbo.dbPackingSMC " +
                               "WHERE StationID = 210 AND PostEventStateID = 2105 AND Created BETWEEN '" + _day + " 06:00:00' AND '" + _dayNext + " 05:59:59' " +
                                   "ORDER BY Created";

            string connectionString = SERVER_CONFIG;

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PackedUnit packedUnit = new PackedUnit();

                    packedUnit.Hour = (int)reader["WorkingHour"];
                    packedUnit.PackedDate = (DateTime)reader["Created"];

                    workDaySheet.Packed.Add(packedUnit);
                }
                reader.Close();
            }
            return workDaySheet;
        }
        

    }
}
