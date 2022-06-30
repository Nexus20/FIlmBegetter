using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace FilmBegetter.WEB.Util; 

public class RequestResponseService {

    private readonly IConfiguration _configuration;

    public RequestResponseService(IConfiguration configuration) {
        _configuration = configuration;
    }

    public async Task<string> Invoke(string firstMovieId, string secondMovieId) {
        
        using var client = new HttpClient();

        var scoreRequest = new {

            Inputs = new Dictionary<string, StringTable>() {
                {
                    "input1",
                    new StringTable()
                    {
                        ColumnNames = new[] {"userId", "movieId", "rating"},
                        Values = new[,] {  { "0", firstMovieId, "5" } },
                    }
                },
                {
                    "input2",
                    new StringTable()
                    {
                        ColumnNames = new[] {"userId", "movieId", "rating"},
                        Values = new[,] {  { "0", secondMovieId, "5" } },
                    }
                },
            },
            GlobalParameters = new Dictionary<string, string>() {
            }
        };
        
        
        // const string apiKey = "MRFnivl8aV6IWdREKWp0nPBWBXA+3NprmleQ3X5XWDGDBAD2tW8wT8sWUCmQPvfMAl4KI2a6UGZNNGPZ49ehQA=="; // Replace this with the API key for the web service
        var apiKey = _configuration["AzureMl:ApiKey"];
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var uri = _configuration["AzureMl:Uri"];
        
        client.BaseAddress = new Uri(uri);

        var k = new JsonContent(scoreRequest);

        var response = await client.PostAsync("", k);

        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadAsStringAsync();
        }
        else {
            Console.WriteLine($"The request failed with status code: {response.StatusCode}");

            // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
            Console.WriteLine(response.Headers.ToString());

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }

        return "";
    }
}

public class JsonContent : StringContent {
    public JsonContent(object obj) :
        base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
}