
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;

using file_thing;

namespace escape_room;

    internal class Program
    {
        static void Main(string[] args)
        {
            file_stuff filestuff = new file_stuff();


           string fileHash = filestuff.writeToFileAndHash("what are you doing here lmao");
           string input = Console.ReadLine();
           string hased_input = filestuff.HashFile(input);

           if(hased_input == fileHash)
           {
                Console.WriteLine("you did it :D");
           }
           

            /*
            //not 100% sure if this is needed, could probably just use a method instead of a constructor
            var postApi = new postApi();
            //store the data in a constructor (at least thats what I think its called I dunno its late)
            string secret_key = File.ReadAllText(@"G:\comp sci 12\webapi test\api.txt");
            Console.WriteLine("Please enter a prompt");
            string prompt = Console.ReadLine();
            var data = new Data { api_key = secret_key, prompt = $"{prompt}", gemini = true };

            //api endpoint
            var url = "https://something-lfu0.onrender.com";
            //execute the thing that does the post request
            var task = postApi.SendData(url, data);
            //set the data in a variable
            var response = task.Result;

            
            //print to console what the output was*/
        }
    }
