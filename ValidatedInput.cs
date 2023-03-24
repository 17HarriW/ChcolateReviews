using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateReviews
{
    class ValidatedInput
    {
        /// <summary>
        /// Ask the user to enter a number
        /// The user will be prompted repeatedly until they enter an integer
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Ask the user to enter a string 
        /// Input will be validated using a length check between a minimum and maximum length
        /// </summary>
        /// <param name="prompt">Prompt to display to the user</param>
        /// <param name="minLength">Minimum length (inclusive)</param>
        /// <param name="maxLength">Maximum length (inclusive)</param>
        /// <returns>Value that the user enters</returns>
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
