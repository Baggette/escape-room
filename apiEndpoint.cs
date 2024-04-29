using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace escape_room
{
    //this class stores the stuff 
    public class Data
    {
        public string api_key { get; set; }
        public string prompt { get; set; }
        public bool gemini { get; set; }
    }

    //create a new class where the post requests will be executed from
    public class postApi
    {

        //from what I can gather this just creates a new instance of HttpClient in preparation for doing the request
        private readonly HttpClient _client;

        public postApi()
        {
            _client = new HttpClient();
        }

        public async Task<string> SendData(string url, Data data)
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

    }
}
