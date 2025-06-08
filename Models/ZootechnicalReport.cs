using GestaoAgro.Models.Animals;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models
{
    public class ZootechnicalReport
    {
        public int Id { get; set; }

        public DateTime ReportDate { get; set; }                // Data de geração ou referência do relatório

        public Animal Animal { get; set; } = new Animal();

        public double AverageDailyGain { get; set; }            // Ganho de peso médio diário (kg/dia)

        public double FeedCost { get; set; }                    // Custo total com alimentação no período (R$)

        public double FeedConversionRate { get; set; }          // Conversão alimentar (kg de ração por kg de ganho)

        public int BirthsCount { get; set; }                    // Número de nascimentos no período

        public int FemalesExposedToBreeding { get; set; }       // Fêmeas expostas à reprodução

        public double BirthRate =>
            FemalesExposedToBreeding == 0 ? 0 : (double)BirthsCount / FemalesExposedToBreeding * 100; //taxa de natalidade

        public string? Notes { get; set; }                       // Observações adicionais
    }
}
