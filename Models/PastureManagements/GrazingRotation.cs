using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models.PastureManagements
{
    public class GrazingRotation
    {
        public int Id { get; set; }
        public string PaddockName { get; set; }        // Nome ou número do piquete
        public DateTime EntryDate { get; set; }        // Data de entrada dos animais
        public DateTime ExitDate { get; set; }         // Data de saída
        public int NumberOfAnimals { get; set; }       // Quantidade de animais no piquete
        public string Notes { get; set; }              // Observações
    }
}
