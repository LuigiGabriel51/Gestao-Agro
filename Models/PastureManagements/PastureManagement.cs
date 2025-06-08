using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.PastureManagements
{
    public class PastureManagement
    {
        public int Id { get; set; }

        public string AreaName { get; set; }                    // Nome ou número da área

        public List<GrazingRotation> LastGrazingRotation { get; set; } = [];    // Rotação de pasto

        public List<SoilAnalysis> LastSoilAnalysis { get; set; } = [];          // Última análise de solo

        public PastureProductivity Productivity { get; set; } = new();   // Dados de produtividade (massa seca, etc.)

        public string? ForageType { get; set; }                  // Tipo de capim ou forrageira plantada

        public double AreaSizeInHectares { get; set; }          // Tamanho da área em hectares

        public DateTime LastFertilizationDate { get; set; }     // Última adubação realizada

        public string? FertilizerUsed { get; set; }              // Tipo de adubo utilizado

        public DateTime LastLimeApplicationDate { get; set; }   // Última calagem

        public string? Notes { get; set; }                       // Observações gerais

        public bool IsActive { get; set; }                      // Indica se a área está em uso no momento
    }
}
