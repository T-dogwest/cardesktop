using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace cardesktop
{
    internal class CarService
    {
        MySqlConnection conn;
        private static string DB_HOST = "localhost";
        private static uint DB_PORT = 3306;
        private static string DB_USER = "root";
        private static string DB_PASSWORD = "";
        private static string DB_DATABASE = "vizsga-2022";

        public CarService()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server=DB_HOST;
            builder.Port=DB_PORT;
            builder.UserID=DB_USER;
            builder.Password=DB_PASSWORD;
            builder.Database=DB_DATABASE;
            conn = new MySqlConnection(builder.ConnectionString);
            conn.Open();
        }

        public List<Car> GetCars()
        {
            List<Car> list = new List<Car>();
            string sql = "SELECT * FROM cars";
            MySqlCommand cmd= conn.CreateCommand();
            cmd.CommandText=sql;
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    int id =reader.GetInt32("id");
                    string license_plate_number = reader.GetString("license_plate_number");
                    string brand = reader.GetString("brand");
                    string model = reader.GetString("model");
                    int daily_cost = reader.GetInt32("daily_cost");
                    Car car=new Car(id, license_plate_number,brand,model,daily_cost);
                    list.Add(car);
                }
            }
            return list;
        }
        internal void RemoveCar(Car car)
        {

            string sql = "DELETE FROM cars WHERE id=@id";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("id",car.Id);
            if (cmd.ExecuteNonQuery() == 0)
            {
                throw new Exception("Hiba a törlés során");
            }
        }
    }
}
