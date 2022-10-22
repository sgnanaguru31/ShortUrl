using Microsoft.Extensions.Configuration;
using Npgsql;
using ShortUrlWebApi.DataProvider;
using System.Data;
using System.Text;

namespace ShortUrlWebApi.DataProviderImpl
{
    public class UrlDataHandler : IUrlDataHandler
    {
        internal const string UrlInsertQuery = "SELECT url_insert(:short_url, :long_url);";
        internal string connectionString { get; set; } 

        public UrlDataHandler(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void SaveShortUrl(string shortUrl, string longUrl)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(UrlInsertQuery, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("short_url", shortUrl);
                    cmd.Parameters.AddWithValue("long_url", longUrl);
                    cmd.ExecuteReader();
                }
            }
        }

        public string GetLongUrl(string shortUrl)
        {
            string query = $"SELECT long_url FROM url WHERE short_url='{shortUrl}'";
            string longurl = string.Empty;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            longurl = reader.GetString(0);
                        }
                    }
                }
            }

            return longurl;
        }
    }
}
