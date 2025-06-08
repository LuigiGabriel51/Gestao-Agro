using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models
{
    public class ManagementSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateSchedule { get; set; }

        public Vaccination Vaccination { get; set; } = new Vaccination();
        public string? Observation { get; set; }
    }
}
