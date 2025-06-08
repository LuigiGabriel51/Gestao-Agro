using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models
{
    public class Vaccination
    {
        public int Id { get; set; }
        // Identificador único da vacinação

        public string VaccineName { get; set; }
        // Nome da vacina, ex: "Brucelose", "Febre Aftosa"

        public DateTime VaccinationDate { get; set; }
        // Data da aplicação da vacina

        public string Veterinarian { get; set; }
        // Nome do veterinário responsável (opcional)

        public string Notes { get; set; }
        // Observações adicionais (ex: dose, lote, reações)

        public int AnimalId { get; set; }
        // Relacionamento com o animal (chave estrangeira, se usar banco)
    }
}
