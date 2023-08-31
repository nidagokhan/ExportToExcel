using ExportToExcel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExportToExcel.Context
{
    public class NortwindContext :DbContext
    {
        public NortwindContext()
        {

        }
        public NortwindContext(DbContextOptions opt) : base(opt)
        {

        }
        public virtual DbSet<Shipper> Shippers { get; set; }
    }
}
