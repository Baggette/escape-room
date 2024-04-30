using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escape_room
{
    public class challenge_1
    {
        public void Challenge1()
        {
            var ai = new Ai();
            string challenge = @"**Challenge:**

Write a program in a language of your choice that takes user input in minutes and converts it into hours and minutes. For example, if the user inputs 180, the program should output ""3 hours and 0 minutes"".

**Instructions:**

1. Prompt the user to enter the number of minutes.
2. Read the user's input and convert it to an integer.
3. Calculate the number of hours by dividing the number of minutes by 60.
4. Calculate the remaining number of minutes by taking the modulus of the division by 60.
5. Print the result in the format ""hours hours and minutes minutes"".";

            Console.WriteLine(challenge + "\n6. Enter the code in a text file and drag the file into this window");
            string path = Console.ReadLine();
            string code = File.ReadAllText(@path.Substring(1, path.Length - 2).TrimEnd('"'));

            Console.WriteLine(ai.Prompt("Given the challenge: " + challenge + " Compare it to this code: \n " + code + " \n determine if this code would be functional and meets the parameters of " + challenge + " \n If you see that this code is working then tell me 'working' if it does not work tell me 'not working'"));
        }
    }
}
