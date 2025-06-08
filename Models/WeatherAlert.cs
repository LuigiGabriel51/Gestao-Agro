using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models
{
    public class WeatherAlert
    {
        public int Id { get; set; }

        public DateTime AlertDate { get; set; }                // Data em que o alerta foi emitido

        public string AlertType { get; set; }                  // Tipo de alerta (ex: "Rain", "Frost", "Heatwave", "Storm")

        public string Severity { get; set; }                   // Nível de severidade (ex: "Moderate", "Severe", "Extreme")

        public string Message { get; set; }                    // Mensagem do alerta (ex: "Chuvas intensas previstas para as próximas 24h")

        public string RecommendedActions { get; set; }         // Ações sugeridas (ex: "Evitar manejo de pasto", "Abrigar bezerros")

        public DateTime ValidFrom { get; set; }                // Início da validade do alerta

        public DateTime ValidTo { get; set; }                  // Fim da validade do alerta

        public bool IsActive => DateTime.Now >= ValidFrom && DateTime.Now <= ValidTo;

        public string Source { get; set; }                     // Fonte do alerta (ex: INMET, ClimaTempo, API externa)
    }
}
