using Microsoft.EntityFrameworkCore;
using RollOff_Test4API.Models;
using RollOff_Test4API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Data
{
    public class RollOff4DbContext:DbContext
    {
       
        ///public DbSet<Employee> Employees { get; set; }
        public RollOff4DbContext(DbContextOptions<RollOff4DbContext>options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Register>Register { get; set; }
        public DbSet<feedbackform> feedbackforms { get; set; }
    }
}
