using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadJokes_Management_Entity
{
    public class JokeModel
    {
        public string _id { get; set; }

        public string type { get; set; }

        public string setup { get; set; }

        public string punchline { get; set; }
    }
}
