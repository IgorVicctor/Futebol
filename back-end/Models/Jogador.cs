using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futebol.Models
{
    public class Jogador
    {
        public int numCamisa { get; set; } //Número da camisa
        public string nome { get; set; }
        public string posicao { get; set; }

        public int timeId { get; set; }
        public Time Time { get; set; }
    }


}
