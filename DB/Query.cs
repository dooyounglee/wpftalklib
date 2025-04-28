using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Npgsql;
using System.Data;

namespace OTILib.DB
{
    public class Query
    {
        private static string connString = "Host=localhost;Username=postgres;Password=postgres;Database=postgres";

        public static NpgsqlDataReader select(string query)
        {
            var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand(query, conn);
            var reader = cmd.ExecuteReader();
            //while (await reader.ReadAsync())
            //{
            //    Debug.WriteLine(reader.GetString(0), reader.GetString(1));
            //}
            return reader;
        }

        public static async void selectAsync(string query)
        {
            string result = string.Empty;

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand(query, conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                Debug.WriteLine(reader.GetString(0), reader.GetString(1));
            }
        }

        public static DataTable? select1(string query)
        {
            var conn = new NpgsqlConnection();
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(new NpgsqlCommand(query, conn));
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    for (var j = 0; j < dt.Columns.Count; j++)
                    {
                        Debug.Write(dt.Rows[i][j] + "|");
                    }
                    Debug.WriteLine("");
                }

                return dt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int insert(string query)
        {
            var conn = new NpgsqlConnection();
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                return new NpgsqlCommand(query, conn).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
