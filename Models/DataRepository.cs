using GestaoAgro.Models.Animals;
using GestaoAgro.Models.PastureManagements;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models
{
    public class DataRepository
    {
        // / List of animals
        public List<Bovine> BovineAnimals { get; set; } = [];
        public List<Swine> SwineAnimals { get; set; } = [];
        public List<Caprine> CaprineAnimals { get; set; } = [];

        // / List of pasture managements
        public List<PastureManagement> PastureManagements { get; set; } = [];

        // / List of zootechnical reports
        public List<ZootechnicalReport> ZootechnicalReports { get; set; } = [];
    }
}
