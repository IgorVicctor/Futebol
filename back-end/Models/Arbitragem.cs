using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futebol.Models
{
    public class Arbitragem
    {
        public int numGols { get; set; } //Números de gols
        public int numCartAm { get; set; } //Números de cartões amarelos
        public int  numCartVer { get; set; } //Número de cartões vermelhos
        public int numFaltas { get; set; } //Número de faltas
        public int numImpedimentos { get; set; } //Número de Impedimentos

        public int jogoId { get; set; }
    }
}
