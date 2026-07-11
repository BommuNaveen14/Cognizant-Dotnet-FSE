using System.Data.SqlClient;

namespace PlayersManagerLib
{
    public class PlayerMapper : IPlayerMapper
    {
        private readonly string connectionString =
            "Data Source=(local);Initial Catalog=GameDB;Integrated Security=True";

        public bool IsPlayerNameExistsInDb(string name)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText =
                    "SELECT COUNT(*) FROM Player WHERE Name=@name";

                cmd.Parameters.AddWithValue("@name", name);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public void AddNewPlayerIntoDb(string name)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText =
                    "INSERT INTO Player(Name) VALUES(@name)";

                cmd.Parameters.AddWithValue("@name", name);

                cmd.ExecuteNonQuery();
            }
        }
    }
}