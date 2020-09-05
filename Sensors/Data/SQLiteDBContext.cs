using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sensors.Models;

namespace Sensors.Data
{
    public class SQLiteDBContext: DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=SensorsSqlite.db");
    }
}
