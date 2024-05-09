using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace escape_room.Challenges
{
    public class Challenge_3
    {
        public void Challenge3() 
        {
            var getTrivia = new api.Api();
            var task = getTrivia.trivia();
            Console.WriteLine(task);
        }
    }
}
