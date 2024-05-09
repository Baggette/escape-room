using Newtonsoft.Json.Linq;

namespace escape_room.api
{
    public class Ai
    {
        public string Prompt(string prompt)
        {
            try
            {
                //not 100% sure if this is needed, could probably just use a method instead of a constructor
                var postApi = new Api();
                //store the data in a constructor (at least thats what I think its called I dunno its late)
                string secret_key = File.ReadAllText(@"..\..\..\..\..\..\api.txt");

                var data = new Data { api_key = secret_key, prompt = $"{prompt}", gemini = true };

                //api endpoint
                var url = "https://something-lfu0.onrender.com";
                //execute the thing that does the post request
                var task = postApi.getPrompt(url, data);
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
    }
}
