using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirPlaneCrudTeste.Models
{
    public class AirPlaneContex : DbContext
    {
        public AirPlaneContex(DbContextOptions<AirPlaneContex> options) : base(options)
        {

        }
        public DbSet<AirPlane> airPlane { get; set; }
    }
}
