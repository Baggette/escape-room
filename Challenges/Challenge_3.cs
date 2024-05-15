using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace escape_room.Challenges
{
    public class Challenge_3
    {
        public void Challenge3() 
        {
            var getTrivia = new api.Api();
            var task = getTrivia.trivia();

            JObject o = JObject.Parse(task.Result);

            string correct_answer = (string)o["results"][0]["correct_answer"];
            Console.WriteLine($@"**Challenge 3:**

Time for some amazing Trivia!!!!!

{(string)o["results"][0]["question"]}

A. {(string)o["results"][0]["incorrect_answers"][1]}
B. {(string)o["results"][0]["incorrect_answers"][0]}
C. {(string)o["results"][0]["correct_answer"]}
D. {(string)o["results"][0]["incorrect_answers"][2]}

Please enter the letter next to the correct answer or the correct answer itself.");

            string answer = Console.ReadLine().ToLower();

            if (answer == "c")
            {
                Console.WriteLine("yay its right");
            }
            else if (answer == correct_answer.ToLower())
            {
                Console.WriteLine("yay its right");
            }
            else 
            {
                Console.WriteLine("nuh uhh wrong ");
            }

        }
    }
}
