using DadJokes_Management_Business.Interface;
using DadJokes_Management_Entity;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes_Management_Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DadjokeController : ControllerBase
    {
        private readonly ILogger<DadjokeController> logger;
        private readonly IDadJokesBusiness dadJokesBusiness;
        public DadjokeController(ILogger<DadjokeController> logger, IDadJokesBusiness dadJokesBusiness)
        {
            this.logger = logger;
            this.dadJokesBusiness = dadJokesBusiness;
        }

        [HttpGet]
        [Route("api/GetRandomJokes")]
        public async Task<IActionResult> GetJoke()
        {
            DadJokesResponse dadJokesResponse = new DadJokesResponse();
            try
            {
                dadJokesResponse = await this.dadJokesBusiness.GetJoke();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occured :  {ex}");
            }
            return this.Ok(dadJokesResponse);
        }

        [HttpGet]
        [Route("api/GetRandomJokesWithCount/{count}")]
        public async Task<IActionResult> GetJokes(int count)
        {
            DadJokesResponse dadJokesResponse = new DadJokesResponse();
            try
            {
                dadJokesResponse = await this.dadJokesBusiness.GetJokes(count);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occured :  {ex}");
            }
            return this.Ok(dadJokesResponse);
        }

        [HttpGet]
        [Route("api/GetJokeCount")]
        public async Task<IActionResult> GetJokeCount()
        {
            JokeCount dadJokesResponse = new JokeCount();
            try
            {
                dadJokesResponse = await this.dadJokesBusiness.GetJokesCount();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occured :  {ex}");
            }
            return this.Ok(dadJokesResponse);
        }
    }
}
