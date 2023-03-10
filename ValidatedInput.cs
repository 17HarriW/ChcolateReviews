using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChcolateReviews
{
    class ValidatedInput
    {
        public static int ReadInt(string prompt)
        {
            // Default value
            int value = 0;

            // Show the prompt to the user
            Console.Write(prompt);

            // Keep asking until they enter an integer
            while(!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Pleaser enter a number");
            }

            // Return the result
            return value;
        }

        public static string ReadString(string prompt, int minLength, int maxLength)
        {
            // Default value
            string value = "";

            // Show the prompt to the user
            Console.Write(prompt);


            value = Console.ReadLine();

            while (value.Length < minLength || value.Length > maxLength)
            {
                Console.Write(prompt);
                value = Console.ReadLine();
            }

            // Return the result
            return value;
        }
    }
}
