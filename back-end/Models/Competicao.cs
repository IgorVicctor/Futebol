using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futebol.Models
{
    public class Competicao
    {
        public string time { get; set; }
        public double premiacao { get; set; }
        public int jogos { get; set; }
        public string ganhador { get; set; }

        public int timeId { get; set; }
        public  int jogoId { get; set; }

        public List<Jogo> Jogo { get; set; }

        
        public List<Time> Times { get; set; }

    }
}
