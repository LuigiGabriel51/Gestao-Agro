using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.Animals
{
    public class Swine : Animal
    {
        public int NumberOfPigletsBorn { get; set; }  // Número total de leitões nascidos (para fêmeas reprodutoras)

        public bool IsBreedingSow { get; set; }      // Indica se é uma matriz reprodutora

    }
}
