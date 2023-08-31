using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExportToExcel.Models
{
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public bool? Aktifmi { get; set; }

    }
}
