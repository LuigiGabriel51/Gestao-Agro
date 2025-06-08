using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.Animals
{
    public class Bovine : Animal
    {
        public bool IsDairy { get; set; }  // Indica se o bovino é leiteiro (true) ou de corte (false)

        public double MilkProductionPerDay { get; set; }  // Produção de leite diária em litros (se aplicável)

        public bool IsCornado { get; set; }  // se o gado tem chifres

    }
}
