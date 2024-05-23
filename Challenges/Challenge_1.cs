using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escape_room.Challenges
{
    public class Challenge_1
    {
        public string code;
        public void Challenge1()
        {
            var ai = new api.Ai();
            Console.Clear();
            string challenge = @"**Challenge 1:**

Write a program in a language of your choice that takes user input in minutes and converts it into hours and minutes. For example, if the user inputs 180, the program should output ""3 hours and 0 minutes"".

**Instructions:**

1. Prompt the user to enter the number of minutes.
2. Read the user's input and convert it to an integer.
3. Calculate the number of hours by dividing the number of minutes by 60.
4. Calculate the remaining number of minutes by taking the modulus of the division by 60.
5. Print the result in the format ""hours hours and minutes minutes"".";

            Console.WriteLine(challenge + "\n6. Enter the code in a text file and drag the file into this window");
            string path = Console.ReadLine();
            //when the user drags a file into the console window it adds some extra quotations for some reason so this just removes that 
            try
            {
                code = File.ReadAllText(@path.Substring(1, path.Length - 2).TrimEnd('"'));
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Perhaps you did not enter a valid file path or an error occured. \n" + ex.ToString());
                Console.WriteLine("Press enter to Retry");
                Console.ReadKey();
                var rechallenge = new Challenge_1();
                rechallenge.Challenge1();
            }

            string workingOrNot = ai.Prompt("Given the challenge: " + challenge + " Compare it to this code: \n " + code + " \n determine if this code would be functional and meets the parameters of " + challenge + " \n If you see that this code is working then tell me 'working' if it does not work tell me 'not working'");

            if (workingOrNot.ToLower() == "working")
            {
                var challenge2 = new Challenge_2();
                challenge2.Challenge2();
            }
            else
            {
                Program failed = new Program();
                failed.Failure("Challenge 1");
            }

        }
    }
}
