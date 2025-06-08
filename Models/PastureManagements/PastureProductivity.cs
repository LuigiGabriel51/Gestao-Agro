using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.PastureManagements
{
    public class PastureProductivity
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public DateTime EvaluationDate { get; set; }
        public double DryMatterYield { get; set; }     // Produção de massa seca (kg/ha)
        public string? ForageType { get; set; }         // Tipo de pastagem (ex: Brachiaria, Panicum)
        public string? Notes { get; set; }
    }
}
