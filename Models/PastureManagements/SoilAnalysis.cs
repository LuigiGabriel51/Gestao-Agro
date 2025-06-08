using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.PastureManagements
{
    public class SoilAnalysis
    {
        public int Id { get; set; }
        public string AreaName { get; set; }           // Área ou talhão analisado
        public DateTime SampleDate { get; set; }       // Data da coleta
        public double pH { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public double OrganicMatter { get; set; }
        public string Recommendations { get; set; }    // Recomendação técnica
    }
}
