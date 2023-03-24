using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateReviews
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = @"C:\tmp\Reviews.mdf";

            if(!File.Exists(filename))
            {
                Console.WriteLine($"Data not found at {filename}: copying a fresh version");
                if(!Directory.Exists(@"C:\tmp"))
                {
                    Directory.CreateDirectory(@"C:\tmp");
                }
                File.Copy("Reviews.mdf", filename);
            }

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\tmp\Reviews.mdf;Integrated Security=True";
            connection.Open();
            Console.WriteLine("Connection Succeeded");
            connection.Close();

            Console.WriteLine(@"
   ____ _                     ____            _               
  / ___| |__   ___   ___ ___ |  _ \ _____   _(_) _____      __
 | |   | '_ \ / _ \ / __/ _ \| |_) / _ \ \ / / |/ _ \ \ /\ / /
 | |___| | | | (_) | (_| (_) |  _ <  __/\ V /| |  __/\ V  V / 
  \____|_| |_|\___/ \___\___/|_| \_\___| \_/ |_|\___| \_/\_/  
                                                              
");
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

                string prompt = Console.ReadLine().ToLower();
                char choice;
                if (prompt.Length > 0)
                {
                    choice = prompt[0];
                }
                else
                {
                    choice = 'x';
                }
                string sql = "";

                switch(choice)
                {
                    case '1':
                        Console.WriteLine("Showing all reviews:");
                        sql = "SELECT * FROM Reviews";

                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataReader r = cmd.ExecuteReader();
                        while(r.Read())
                        {
                            Review existingReview = new Review(r);

                            Console.WriteLine(existingReview);
                        }
                        connection.Close();
                        break;

                    case '2':
                        Console.WriteLine("Adding new review:");
                        Review newReview = new Review(
                            -1,
                            ValidatedInput.ReadInt("Enter chocolate bar ID:"),
                            ValidatedInput.ReadInt("User ID:"),
                            ValidatedInput.ReadInt("Review score:"),
                            ValidatedInput.ReadString("Enter review:", 0, 255)
                            );
                        connection.Open();
                        sql = $"INSERT INTO Reviews (ChocolateBarID, UserID, Score, Comment) VALUES ({newReview.ChocolateBarID}, {newReview.UserID}, {newReview.Score}, '{newReview.Comment}')";
                        SqlCommand addCommand = new SqlCommand(sql, connection);
                        addCommand.ExecuteNonQuery();
                        connection.Close();
                        break;

                    case '3':
                        int reviewID = ValidatedInput.ReadInt("Which review would you like to update?: (Enter ID)");
                        connection.Open();
                        sql = "SELECT * FROM Reviews WHERE ReviewID = @ReviewID";
                        SqlCommand editCommand = new SqlCommand(sql, connection);
                        editCommand.Parameters.AddWithValue("ReviewID", reviewID);
                        r = editCommand.ExecuteReader();
                        if(r.Read())
                        {
                            Review reviewToEdit = new Review(r);
                            Console.WriteLine("Record found: " + reviewToEdit);

                            reviewToEdit.ChocolateBarID = ValidatedInput.ReadInt("Enter new ChocolateBarID: ");
                            reviewToEdit.UserID = ValidatedInput.ReadInt("Enter new UserID");
                            reviewToEdit.Score = ValidatedInput.ReadInt("Enter new score (1-10)");
                            reviewToEdit.Comment = ValidatedInput.ReadString("Enter new comment", 0, 255);
                            sql = "UPDATE Reviews " +
                                "SET ChocolateBarID=@ChocolateBarID, UserID=@UserID, Score=@Score, Comment=@Comment " +
                                "WHERE ReviewID=@ReviewID";
                            connection.Close();

                            SqlCommand editCommandUpdate = new SqlCommand(sql, connection);
                            connection.Open();
                            editCommand.Parameters.AddWithValue("ChocolateBarID", reviewToEdit.ChocolateBarID);
                            editCommand.Parameters.AddWithValue("UserID", reviewToEdit.UserID);
                            editCommand.Parameters.AddWithValue("Score", reviewToEdit.Score);
                            editCommand.Parameters.AddWithValue("Comment", reviewToEdit.Comment);
                            editCommand.Parameters.AddWithValue("ReviewID", reviewToEdit.ReviewID);
                            Console.WriteLine("Record updated");
                        }
                        else
                        {
                            Console.WriteLine("Record not found");
                        }
                        connection.Close();
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

                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
            }
        }
    }
}
