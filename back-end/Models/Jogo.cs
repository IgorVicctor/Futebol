using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futebol.Models
{
    public class Jogo
    {
        public string Arbitragem { get; set; }
        public bool substituicao { get; set; }
        public string resultado { get; set; }
        public string times { get; set; }
        public int numGols { get; set; } // Número de gols

        public int arbitragemId { get; set; }

    }
}
