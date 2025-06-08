using GestaoAgro.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.Animals
{
    public class Animal
    {
        public Guid Id { get; set; }
        // Identificador único do animal no sistema

        public string TagNumber { get; set; }
        // Número do brinco ou chip de identificação do animal

        public string Name { get; set; }
        // Nome do animal (opcional, para facilitar identificação)

        public string Gender { get; set; }
        // Sexo do animal: "M" para macho, "F" para fêmea

        public string Species { get; set; }
        // Espécie do animal: exemplo "Bovino", "Caprino", "Suíno"

        public string Breed { get; set; }
        // Raça do animal, como "Nelore", "Holandês", etc.

        public DateTime BirthDate { get; set; }
        // Data de nascimento do animal

        public string Category { get; set; }
        // Categoria zootécnica: exemplo "Bezerro", "Novilha", "Vaca em lactação"

        public double CurrentWeight { get; set; }
        // Peso atual do animal em quilogramas

        public bool IsActive { get; set; }
        // Indica se o animal ainda está ativo no rebanho ou já foi descartado/vendido

        public List<Vaccination> Vaccinations { get; set; } = new();
        // Lista de vacinações realizadas no animal
    }
}
