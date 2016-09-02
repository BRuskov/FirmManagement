using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using WebFirmManagment.Models.Entities;

namespace FirmManagment.Models
{
    public class FirmManagementContext : DbContext
    {
        public FirmManagementContext() : base("name=FirmManagementContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}