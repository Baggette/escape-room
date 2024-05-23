using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escape_room.Challenges
{
    public class Challenge_2
    {
        public void Challenge2() 
        {
            Console.Clear();

            Console.WriteLine($@"**Challenge 2:**
FVB OHCL MVBUK AOL HUZDLY

The answer to your question is what is a commonly used salad dressing and what is 72 divided by 10.28571428571429.

");

            string answer;
            int times = 0;
            do
            {
                if (times >= 1)
                {
                    Console.WriteLine("Enter your answer again you are have tried " + times + " times you have 3 tries to get it right" );
                }
                answer = Console.ReadLine();
                times++;
                Program failed = new Program();
                var challenge = new Challenges.Challenge_3();
                if (times >= 4) failed.Failure("Challenge 2");
                if (answer.ToLower() == "you have found the answer") challenge.Challenge3();
            } while (answer.ToLower() != "you have found the answer");
        }
    }
}
