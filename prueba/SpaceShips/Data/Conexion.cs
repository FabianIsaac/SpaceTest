using System.Data.SqlClient;

namespace SpaceShips.Data
{
    public class Conexion
    {
        private const string privateStrin = "Data Source=DELLG3;Initial Catalog=spaceships;Integrated Security=True";
        public static string conectionString = privateStrin;


        public static SqlConnection getConn()
        {
            return new SqlConnection(conectionString);
        }
            
    }


}
