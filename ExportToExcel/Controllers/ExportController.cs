using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using ExportToExcel.Context;
using ExportToExcel.Models;

namespace ExportToExcel.Controllers
{
    public class ExportController : Controller
    {
        private NortwindContext Context { get; }

        public ExportController(NortwindContext _context)
        {
            this.Context = _context;
        }
        public IActionResult Index()
        {
            List<Shipper> shippers=(from shipper in this.Context.Shippers.Take(10)
                                      select shipper).ToList();
            return View(shippers);
        }

        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4]
            {
                new DataColumn("ShipperID"),
                new DataColumn("CompanyName"),
                new DataColumn("Phone"),
                new DataColumn("Aktifmi")
            });

            var shippers = from shipper in this.Context.Shippers.Take(10) select shipper;

            foreach (var shipper in shippers)
            {
                dt.Rows.Add(shipper.ShipperID, shipper.CompanyName, shipper.Phone, shipper.Aktifmi);
            }

            using(XLWorkbook wb=new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using(MemoryStream stream=new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Data.xlsx");
                }
            }
        }
    }
}
