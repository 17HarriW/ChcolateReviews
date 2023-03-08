using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChcolateReviews
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Reviews.mdf;Integrated Security=True";
            connection.Open();
            Console.WriteLine("Connection Succeeded");
            connection.Close();

            Console.WriteLine("Welcome to the Chocolate Bar Review admin console");
            Console.WriteLine("Main Menu:");
            Console.WriteLine("==========");

            bool running = true;

            while (running)
            {
                Console.WriteLine("1) Show all reviews");
                Console.WriteLine("2) Add new review");
                Console.WriteLine("3) Update review");
                Console.WriteLine("4) Delete review");
                Console.WriteLine("5) Show all users");
                Console.WriteLine("6) Add a new user");
                Console.WriteLine("7) Update user");
                Console.WriteLine("8) Delete user");
                Console.WriteLine("Q) Quit");

                char choice = Console.ReadLine().ToLower()[0];

                switch(choice)
                {
                    case '1':
                        Console.WriteLine("Showing all reviews:");
                        break;
                    case '2':
                        Console.WriteLine("Adding new review:");
                        break;
                    case '3':
                        Console.WriteLine("Which review would you like to update?: (EnterID)");
                        break;
                    case '4':
                        Console.WriteLine("Which review would you like to delete? (Enter ID):");
                        break;
                    case '5':
                        Console.WriteLine("Showing all users:");
                        break;
                    case '6':
                        Console.WriteLine("Adding new user:");
                        break;
                    case '7':
                        Console.WriteLine("Which user would you like to update?: (Enter ID)");
                        break;
                    case '8':
                        Console.WriteLine("Which user would you like to delete? (Enter ID):");
                        break;
                    case 'q':
                        running = false;
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
