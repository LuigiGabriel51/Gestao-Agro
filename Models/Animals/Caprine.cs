using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.Animals
{
    public class Caprine : Animal
    {
        public double MilkProductionPerDay { get; set; }  // Produção de leite diária em litros (para cabras leiteiras)

        public bool IsHorned { get; set; }                 // Indica se o animal tem chifres

    }
}
