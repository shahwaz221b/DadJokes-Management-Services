using DadJokes_Management_Business.Interface;
using DadJokes_Management_Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DadJokes_Management_Business.Implementation
{
    public class DadJokesBusiness : IDadJokesBusiness
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<DadJokesBusiness> logger;
        public DadJokesBusiness(IConfiguration configuration, ILogger<DadJokesBusiness> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<DadJokesResponse> GetJoke()
        {
            DadJokesResponse dadJokesResponse = new DadJokesResponse() { success = false };
            var BaseAddress = configuration.GetSection("MySettings").GetSection("BaseUrl").Value;
            var RapidAPIKey = configuration.GetSection("MySettings").GetSection("RapidAPIKey").Value;
            var RapidAPIHost = configuration.GetSection("MySettings").GetSection("RapidAPIHost").Value;
            using (var client = new HttpClient())
            {
                this.logger.LogInformation("Calling DadJokes API to get random joke");
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key" , RapidAPIKey);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidAPIHost);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("random/joke");
                if (response.IsSuccessStatusCode)
                {
                    this.logger.LogInformation("Recieved success result from DadJokes API");
                    var data = await response.Content.ReadAsStringAsync();
                    this.logger.LogInformation($"Result from DadJokes API for joke is {data}");
                    if (data != null)
                    {
                        dadJokesResponse = JsonSerializer.Deserialize<DadJokesResponse>(data);

                    }

                }
                else
                {
                    this.logger.LogInformation($"Method name : GetJoke - Failed to fetch result from Dadjokes API ");
                }
            }
            return dadJokesResponse;
        }

        public async Task<DadJokesResponse> GetJokes(int count)
        {
            DadJokesResponse dadJokesResponse = new DadJokesResponse() { success = false };
            using (var client = new HttpClient())
            {
                this.logger.LogInformation("Calling DadJokes API for Jokes as per count");
                client.BaseAddress = new Uri("https://dad-jokes.p.rapidapi.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "f9c92e95d0mshe16722c8c85ddcfp113b23jsn038e83cb6f6c");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "dad-jokes.p.rapidapi.com");
                //GET Method
                HttpResponseMessage response = await client.GetAsync($"random/joke?count={count}");
                if (response.IsSuccessStatusCode)
                {
                    this.logger.LogInformation("Recieved success result from DadJokes API");
                    var data = await response.Content.ReadAsStringAsync();
                    this.logger.LogInformation($"Result from DadJokes API for jokes as per count is {data}");
                    if (data != null)
                    {
                        dadJokesResponse = JsonSerializer.Deserialize<DadJokesResponse>(data);

                    }

                }
                else
                {
                    this.logger.LogInformation($"Method name : GetJokes - Failed to fetch result from Dadjokes API ");
                }
            }
            return dadJokesResponse;
        }

        public async Task<JokeCount> GetJokesCount()
        {
            JokeCount jokeCount = new JokeCount() { success = false };
            using (var client = new HttpClient())
            {
                this.logger.LogInformation("Calling DadJokes API for Jokes count");
                client.BaseAddress = new Uri("https://dad-jokes.p.rapidapi.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "f9c92e95d0mshe16722c8c85ddcfp113b23jsn038e83cb6f6c");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "dad-jokes.p.rapidapi.com");
                //GET Method
                HttpResponseMessage response = await client.GetAsync("joke/count");
                if (response.IsSuccessStatusCode)
                {
                    this.logger.LogInformation("Recieved success result from DadJokes API");
                    var data = await response.Content.ReadAsStringAsync();
                    this.logger.LogInformation($"Result from DadJokes API for count is {data}");
                    if (data != null)
                    {
                        jokeCount = JsonSerializer.Deserialize<JokeCount>(data);

                    }

                }
                else
                {
                    this.logger.LogInformation($"Method name : GetJokesCount - Failed to fetch result from Dadjokes API ");
                }
            }
            return jokeCount;
        }
    }
}
