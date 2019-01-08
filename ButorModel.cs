using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_01_03_Butorbolt
{
    public class ButorModel
    {
        public int Id { get; set; }
        public string Megnevezes { get; set; }
        public int Alapanyag { get; set; }
        public decimal? Ar { get; set; }
        public DateTime? Szallitas { get; set; }
        public string Szin { get; set; }

        public string AlapanyagNev { get; set; }

        public ButorModel()
        {

        }

        public ButorModel(MySqlDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["id"]);
            this.Megnevezes = reader["megnevezes"].ToString();
            this.Alapanyag = Convert.ToInt32(reader["alapanyag"]);
            this.Ar = reader["ar"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["ar"]);
            this.Szallitas = reader["szallitas"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["szallitas"]);
            this.Szin = reader["szin"].ToString();
            this.AlapanyagNev = reader["alapanyagnev"].ToString();
        }

        private static string conStr = "server=localhost;database=13a_butorbolt;uid=root;pwd=;";

        public static List<ButorModel> Select(int? alapanyagid, string megnevezes)
        {
            var list = new List<ButorModel>();
            using (var con = new MySqlConnection(conStr))
            {
                con.Open();
                var sql = "SELECT Butor.id, Butor.megnevezes, Butor.alapanyag, Alapanyag.megnevezes AS alapanyagnev, Butor.ar, Butor.szallitas, Butor.szin FROM Butor JOIN Alapanyag ON Butor.alapanyag = Alapanyag.id WHERE 1 = 1";
                if (alapanyagid != null) sql += " AND Butor.alapanyag = @alapanyag";
                if (!string.IsNullOrEmpty(megnevezes)) sql += " AND Butor.megnevezes LIKE @megnevezes";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@megnevezes", "%" + megnevezes + "%");
                    cmd.Parameters.AddWithValue("@alapanyag", alapanyagid);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read()) list.Add(new ButorModel(reader));
                }
            }
            return list;
        }

        public static void Delete(ButorModel butor)
        {
            using (var con = new MySqlConnection(conStr))
            {
                con.Open();
                var sql = "DELETE FROM butor WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", butor.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int Insert(ButorModel model)
        {
            using (var con = new MySqlConnection(conStr))
            {
                con.Open();
                var sql = "INSERT INTO butor(megnevezes, alapanyag, ar, szin, szallitas) VALUES (@megnevezes, @alapanyag, @ar, @szin, @szallitas)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@megnevezes", model.Megnevezes);
                    cmd.Parameters.AddWithValue("@alapanyag", model.Alapanyag);
                    cmd.Parameters.AddWithValue("@szin", model.Szin);
                    cmd.Parameters.AddWithValue("@szallitas", model.Szallitas);
                    cmd.Parameters.AddWithValue("@ar", model.Ar);
                    cmd.ExecuteNonQuery();
                    return (int)cmd.LastInsertedId;
                }
            }
        }

        public static void Update(ButorModel model)
        {
            using (var con = new MySqlConnection(conStr))
            {
                con.Open();
                var sql = "UPDATE butor SET megnevezes = @megnevezes, alapanyag = @alapanyag, szin = @szin, ar = @ar, szallitas = @szallitas WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@megnevezes", model.Megnevezes);
                    cmd.Parameters.AddWithValue("@alapanyag", model.Alapanyag);
                    cmd.Parameters.AddWithValue("@szin", model.Szin);
                    cmd.Parameters.AddWithValue("@szallitas", model.Szallitas);
                    cmd.Parameters.AddWithValue("@ar", model.Ar);
                    cmd.Parameters.AddWithValue("@id", model.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
