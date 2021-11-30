using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futebol.Models
{
    public class Time
    {
        public string nome { get; set; }

        public double dataFund { get; set; } //Data em que o clube foi fundado

        public int competicaoId { get; set; }
        public Competicao Competicao { get; set; }

        public List<Jogador> Jogadores { get; set; }
    }
}
