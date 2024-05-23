using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace escape_room.Challenges
{
    public class Challenge_4
    {
        private static Random random = new Random();

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Encode(string path)
        { 
            var text = System.Text.Encoding.UTF8.GetBytes(path);
            return System.Convert.ToBase64String(text);
        }

        public void Challenge4()
        {

            Console.Clear();

            var file = new file.FileHash();

            string filename = RandomString();
            string path = file.writeToFileAndHash(RandomString(), filename);

            string hash = Encode(path);
            try
            {
                Console.WriteLine(@$"**Challenge 4:**

This is the 4th and final challenge of this escape room, to win you must locate the file that was randomly placed 
in a folder on your computer, you must then hash said file and return the hash here

{hash.Remove(hash.Length - 25)}

Happy trails");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(@$"**Challenge 4:**

This is the 4th and final challenge of this escape room, to win you must locate the file that was randomly placed 
in a folder on your computer, you must then hash said file and return the hash here

{hash.Remove(hash.Length - 10)}

Happy trails");
            }

            string md5 = file.HashFile(path + $"/{filename}.txt");

            //Console.WriteLine(md5);

            string answer = Console.ReadLine();

            if (answer == md5)
            {
                var success = new Program();
                success.Success();
            }
            else
            {
                var failed = new Program();
                failed.Failure("Challenge 4");
            }
        }

    }
}
