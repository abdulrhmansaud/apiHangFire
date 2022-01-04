using apiHangFire.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHangFire.DbConnection
{
    public class Dbconnect: DbContext
    {

    public Dbconnect(DbContextOptions<Dbconnect> opt) : base(opt)
    {
                

    }   

    public DbSet<book> books { get; set; }

    }
}
