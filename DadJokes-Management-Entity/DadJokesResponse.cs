using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadJokes_Management_Entity
{
    public class DadJokesResponse
    {
        public bool success { get; set; }

        public List<JokeModel> body { get; set; }
    }
}
