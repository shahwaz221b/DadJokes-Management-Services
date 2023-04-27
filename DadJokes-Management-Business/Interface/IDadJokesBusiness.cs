using DadJokes_Management_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadJokes_Management_Business.Interface
{
    public interface IDadJokesBusiness
    {
        Task<DadJokesResponse> GetJoke();

        Task<DadJokesResponse> GetJokes(int count);

        Task<JokeCount> GetJokesCount();
    }
}
