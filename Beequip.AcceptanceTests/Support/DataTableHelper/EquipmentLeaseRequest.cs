using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beequip.AcceptanceTests.Support.DataTableHelper
{
    public class EquipmentLeaseRequest
    {
        public string Type { get; set; } = string.Empty;
        public string? SubType { get; set; } = string.Empty;
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public int MaxKm { get; set; }
        public int Cylinders { get; set; }
    }
}
