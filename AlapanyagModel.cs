using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_01_03_Butorbolt
{
    class AlapanyagModel
    {
        public int? Id { get; set; }
        public string Megnevezes { get; set; }

        public AlapanyagModel(MySqlDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["id"]);
            this.Megnevezes = reader["Megnevezes"].ToString();
        }

        private static string conStr = "server=localhost;database=13a_butorbolt;uid=root;pwd=;";

        public AlapanyagModel()
        {

        }

        public static List<AlapanyagModel> Select()
        {
            var list = new List<AlapanyagModel>();
            using (var con = new MySqlConnection(conStr))
            {
                con.Open();
                var sql = "SELECT id, megnevezes FROM alapanyag";
                using (var cmd = new MySqlCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                while (reader.Read()) list.Add(new AlapanyagModel(reader));
            }
            return list;
        }
    }
}
