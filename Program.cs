
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace escape_room;

internal class Program
{
    static string Prompt(string prompt) 
    {
        try
        {
            //not 100% sure if this is needed, could probably just use a method instead of a constructor
            var postApi = new postApi();
            //store the data in a constructor (at least thats what I think its called I dunno its late)
            string secret_key = File.ReadAllText(@"G:\api.txt");

            var data = new Data { api_key = secret_key, prompt = $"{prompt}", gemini = true };

            //api endpoint
            var url = "https://something-lfu0.onrender.com";
            //execute the thing that does the post request
            var task = postApi.SendData(url, data);
            //set the data in a variable
            var response = task.Result;

            JObject o = JObject.Parse(response);

            return (string)o["response"];
        }
        catch (Exception ex)
        {
            return ex.Message + "\nTry Restarting the program";
        }
    }
    static void Main(string[] args)
    {
        //init the api and make sure it is online (it goes offline after a length of time of being offline)
        Console.WriteLine("Loading");
        string init = Prompt("this is a test");
        Console.WriteLine("Finished initializing");
        Console.Clear();
        Console.WriteLine(Prompt("Generate a cool name for an escape room and welcome the user to it, do not use the word enigma, keep it short just a basic welcome"));
        string prompt = Console.ReadLine();
        string response = Prompt(prompt);
        
        Console.WriteLine(response);
        //print to console what the output was

    }
}
