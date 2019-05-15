using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace FirstTry
{
    class Program
    {
        static void Main(string[] args)
        {
            var DatabaseInformation = "Host=localhost;Username=Vincent;Password=VerySecurePassword;Database=GettingStarted";

            using (var connection = new NpgsqlConnection(DatabaseInformation))
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT title, price FROM products WHERE price < 25", connection))
                {
                    Console.WriteLine("All the books in the database which cost less that 25 Euro are:");
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine(System.Convert.ToString(reader.GetValue(0)) + " which costs "+ System.Convert.ToString(reader.GetValue(1)) + "Euro's");

                }
            }
            Console.ReadKey();
        }
    }
}
