using System.Data.SqlClient;

namespace SpaceShips.Data
{
    public class ShipData
    {
        public static List<Ship> GetAll()
        {
            List<Ship> shipList = new List<Ship>();
            SqlConnection sConn = Conexion.getConn();
            SqlCommand cmd = new SqlCommand("sp_get_all", sConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
            try
            {
                sConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    shipList.Add(MapShip(reader));
                } 

            }catch
            {
                sConn.Close();
                return shipList;
            }
        
            return shipList;
        }

        public static Ship Show(int id)
        {
            Ship ship = new Ship();
            SqlConnection sConn = Conexion.getConn();
            SqlCommand cmd = new SqlCommand("sp_show_ship", sConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                sConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ship = MapShip(reader);
                }

            }
            catch
            {
                sConn.Close();
                return ship;
            }
            
            return ship;
        }


        public static Ship Create(Ship nShip)
        {
            Ship ship = new Ship();
            SqlConnection sConn = Conexion.getConn();
            SqlCommand cmd = new SqlCommand("sp_create_ship", sConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", nShip.Name);
            cmd.Parameters.AddWithValue("@model", nShip.Model);
            cmd.Parameters.AddWithValue("@type", nShip.Type);
            cmd.Parameters.AddWithValue("@armor", nShip.Armor);
            cmd.Parameters.AddWithValue("@stamina", nShip.Stamina);
            cmd.Parameters.AddWithValue("@power", nShip.Power);
            cmd.Parameters.AddWithValue("@image", nShip.Image);
            cmd.Parameters.AddWithValue("@passengers", nShip.Passengers);
            cmd.Parameters.AddWithValue("@passengers_limit", nShip.PassengersLimit);
            cmd.Parameters.AddWithValue("@cargo", nShip.Cargo);
            cmd.Parameters.AddWithValue("@cargo_limit", nShip.CargoLimit);
            try
            {
                sConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ship = MapShip(reader);
                }

            }
            catch
            {
                sConn.Close();
                return ship;
            }

            return ship;
        }

        public static Ship Update(int id, Ship nShip)
        {
            Ship ship = new Ship();
            SqlConnection sConn = Conexion.getConn();
            SqlCommand cmd = new SqlCommand("sp_update_ship", sConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", nShip.Name);
            cmd.Parameters.AddWithValue("@model", nShip.Model);
            cmd.Parameters.AddWithValue("@type", nShip.Type);
            cmd.Parameters.AddWithValue("@armor", nShip.Armor);
            cmd.Parameters.AddWithValue("@stamina", nShip.Stamina);
            cmd.Parameters.AddWithValue("@power", nShip.Power);
            cmd.Parameters.AddWithValue("@image", nShip.Image);
            cmd.Parameters.AddWithValue("@passengers", nShip.Passengers);
            cmd.Parameters.AddWithValue("@passengers_limit", nShip.PassengersLimit);
            cmd.Parameters.AddWithValue("@cargo", nShip.Cargo);
            cmd.Parameters.AddWithValue("@cargo_limit", nShip.CargoLimit);
            try
            {
                sConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ship = MapShip(reader);
                }

            }
            catch
            {
                sConn.Close();
                return ship;
            }

            return ship;
        }

        public static bool Delete(int id)
        {
            Ship ship = new Ship();
            SqlConnection sConn = Conexion.getConn();
            SqlCommand cmd = new SqlCommand("sp_delete_ship", sConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                sConn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                sConn.Close();
                return false;
            }
        }

        public static Ship MapShip(SqlDataReader reader)
        {
            Ship ship = new Ship();
            ship.Id = Convert.ToInt32(reader["id"]);
            ship.Name = reader["name"].ToString() ?? String.Empty;
            ship.Model = reader["model"].ToString() ?? String.Empty;
            ship.Type = reader["type"].ToString() ?? String.Empty;
            ship.Armor = Convert.ToInt32(reader["armor"]);
            ship.Stamina = Convert.ToInt32(reader["stamina"]);
            ship.Power = Convert.ToInt32(reader["power"]);
            ship.Image = reader["image"].ToString() ?? String.Empty;
            ship.Passengers = bool.Parse(reader["passengers"].ToString() ?? "false");
            ship.PassengersLimit = Convert.ToInt32(reader["passengers_limit"]);
            ship.Cargo = bool.Parse(reader["cargo"].ToString() ?? "false");
            ship.CargoLimit = Convert.ToInt32(reader["cargo_limit"]);
            return ship;
        }
    }
}
