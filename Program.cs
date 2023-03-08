using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChcolateReviews
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = false;
            Console.WriteLine("Welcome to the Chocolate Bar Review admin console");
            Console.WriteLine("Main Menu:");
            Console.WriteLine("==========");

            while(!running)
            {
                Console.WriteLine("1) Show all reviews");
                Console.WriteLine("2) Add new review");
                Console.WriteLine("3) Update review");
                Console.WriteLine("4) Delete review");
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
                    case 'q':
                        running = false;
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
