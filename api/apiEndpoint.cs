using System.Runtime.CompilerServices;
using System.Text;

namespace escape_room.api
{
    //this class stores the stuff 
    public class Data
    {
        public string api_key { get; set; }
        public string prompt { get; set; }
        public bool gemini { get; set; }
    }

    //create a new class where the post requests will be executed from
    public class Api
    {

        //from what I can gather this just creates a new instance of HttpClient in preparation for doing the request
        private readonly HttpClient _client;

        public Api()
        {
            _client = new HttpClient();
        }

        public async Task<string> getPrompt(string url, Data data)
        {
            //convert the data from the Data class into json
            var jsonData = System.Text.Json.JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //actually send the request now and return the response back to where it was executed
            HttpResponseMessage response = await _client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                //convert returned data to string
                string json = await response.Content.ReadAsStringAsync();
                //return the data back to where it was executed

                return json;
            }
            else
            {
                //temp probably if there was nothing
                return "nothing";
            }
        }

        public async Task<string> trivia()
        {
            HttpResponseMessage response = await _client.GetAsync("https://opentdb.com/api.php?amount=1&category=18&difficulty=hard");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                return "nothing";
            }
        }

    }
}
