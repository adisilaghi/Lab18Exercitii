using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18Exercitii.Models
{
    public class TechnicalBook
    {
        public int Id { get; set; }
        public int CC { get; set; }
        public int ManufacturingYear { get; set; }
        public string VINNumber { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
