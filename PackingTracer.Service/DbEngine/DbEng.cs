using System.Data;
using Microsoft.Data.SqlClient;
using PackingTracer.Data.PackingDay;

namespace PackingTracer.Service.DbEngine
{
    public class DbEng
    {
        static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=dbo.Unit_EventLog;Integrated Security=True";

        public PackedPerDay GetQuantityOfPackedSmc2MotorsByWholeDay(DateTime day)
        {
            // ToDo : Write connection to DataBase and SQL query here


            // Gathering data from SQL for whole packed units in particular day
            PackedPerDay packedPerDay = new PackedPerDay();

            string connectionString = SERVER_CONFIG;
            //string queryString = "select * from GO_SMC.dbo.Unit_EventLog where StationID = 210 and PostEventStateID = 2105 and Created between getdate() - 4 and GETDATE()";
            string queryString = "SELECT * FROM GO_SMC.dbo.Unit_EventLogwhere StationID = 210 AND PostEventStateID = 2105 AND Created BETWEEN '2022-08-23' AND '2022-08-23 ORDERED BY Created ASC";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSqlSingleRows((IDataRecord)reader, ref packedPerDay);
                }
                reader.Close();
            }

            Console.WriteLine(String.Format("Units packed: {0}", packedPerDay.PackedUnits.Count()));     

            return packedPerDay;
        }
        

        // add packed unit date to list of packed products
        private void ReadSqlSingleRows(IDataRecord record, ref PackedPerDay day )
        {
            PackedUnit packedUnit = new PackedUnit();

            packedUnit.PackedProduct = Convert.ToDateTime(record[8]);

            day.Day = packedUnit.PackedProduct;
            day.PackedUnits.Add(packedUnit);
        }


    }
}
