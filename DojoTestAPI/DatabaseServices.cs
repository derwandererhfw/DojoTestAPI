using MySql.Data.MySqlClient;
namespace DojoTestAPI
{
    public class DatabaseServices
    {
        private static string connectionString = "server=127.0.0.1;port=6666;user=root;password=;database=dojotestdb";
        public static void AdoWebhook(CreatedItemResponse response)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO testrequest2 (EventType, MessageText, ResourceId, WorkItemType) " +
                                   "VALUES (@EventType, @MessageText, @ResourceId, @WorkItemType)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventType", response.EventType);
                cmd.Parameters.AddWithValue("@MessageText", response.MessageText);
                cmd.Parameters.AddWithValue("@ResourceId", response.ResourceId);
                cmd.Parameters.AddWithValue("@WorkItemType", response.WorkItemType);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}");
            }
        }

        public static CreatedItemResponse GetAdoWebhook(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            CreatedItemResponse retrievedItem = new CreatedItemResponse();
            try
            {
                connection.Open();
                string query = "SELECT * FROM testrequest2 WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {   
                        retrievedItem.EventType = (string)reader["EventType"];
                        retrievedItem.MessageText = (string)reader["MessageText"];
                        retrievedItem.ResourceId = (int)reader["ResourceId"];
                        retrievedItem.WorkItemType = (string)reader["WorkItemType"];      
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}");
            }

            return retrievedItem;
        }
    }
}
