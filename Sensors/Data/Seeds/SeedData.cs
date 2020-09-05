using Microsoft.Extensions.DependencyInjection;
using Sensors.Data;
using Sensors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensors.Seeds
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SQLiteDBContext>();
            context.Database.EnsureCreated();
            if (!context.Sensors.Any())
            {
                context.Sensors.AddRange(
                    new Sensor
                    {
                        Id = 1,
                        Timestamp = "1539112021301",
                        Tag = "brasil.sudeste.sensor01",
                        Value = "700"
                    },
                    new Sensor
                    {
                        Id = 2,
                        Timestamp = "1593892800",
                        Tag = "brasil.sudeste.sensor02",
                        Value = "300"
                    },
                     new Sensor
                     {
                         Id = 3,
                         Timestamp = "1593896400",
                         Tag = "brasil.sul.sensor01",
                         Value = "1250"
                     },
                    new Sensor
                    {
                        Id = 4,
                        Timestamp = "1593900000",
                        Tag = "brasil.sul.sensor02",
                        Value = "250"
                    },
                    new Sensor
                    {
                        Id = 5,
                        Timestamp = "1593900000",
                        Tag = "brasil.norte.sensor01",
                        Value = "2500"
                    },
                    new Sensor
                    {
                        Id = 6,
                        Timestamp = "1593900000",
                        Tag = "brasil.norte.sensor02",
                        Value = "200"
                    },
                    new Sensor
                    {
                        Id = 7,
                        Timestamp = "1593900000",
                        Tag = "brasil.nordeste.sensor01",
                        Value = "280"
                    },
                    new Sensor
                    {
                        Id = 8,
                        Timestamp = "1593900000",
                        Tag = "brasil.nordeste.sensor02",
                        Value = "500"
                    },
                    new Sensor
                    {
                        Id = 9,
                        Timestamp = "1593900000",
                        Tag = "brasil.centrooeste.sensor01",
                        Value = "2180"
                    },
                    new Sensor
                    {
                        Id = 10,
                        Timestamp = "1593900000",
                        Tag = "brasil.centrooeste.sensor02",
                        Value = "5200"
                    },
                    new Sensor
                    {
                        Id = 11,
                        Timestamp = "1539112021301",
                        Tag = "brasil.sudeste.sensor01",
                        Value = "900"
                    },
                    new Sensor
                    {
                        Id = 12,
                        Timestamp = "1593892800",
                        Tag = "brasil.sudeste.sensor02",
                        Value = "600"
                    },
                     new Sensor
                     {
                         Id = 13,
                         Timestamp = "1593896400",
                         Tag = "brasil.sul.sensor01",
                         Value = "1500"
                     },
                    new Sensor
                    {
                        Id = 14,
                        Timestamp = "1593900000",
                        Tag = "brasil.sul.sensor02",
                        Value = "750"
                    },
                    new Sensor
                    {
                        Id = 15,
                        Timestamp = "1593900000",
                        Tag = "brasil.norte.sensor01",
                        Value = "2200"
                    },
                    new Sensor
                    {
                        Id = 16,
                        Timestamp = "1593900000",
                        Tag = "brasil.norte.sensor02",
                        Value = "800"
                    },
                    new Sensor
                    {
                        Id = 17,
                        Timestamp = "1593900000",
                        Tag = "brasil.nordeste.sensor01",
                        Value = "680"
                    },
                    new Sensor
                    {
                        Id = 18,
                        Timestamp = "1593900000",
                        Tag = "brasil.nordeste.sensor02",
                        Value = "5100"
                    },
                    new Sensor
                    {
                        Id = 19,
                        Timestamp = "1593900000",
                        Tag = "brasil.centrooeste.sensor01",
                        Value = "180"
                    },
                    new Sensor
                    {
                        Id = 20,
                        Timestamp = "1593900000",
                        Tag = "brasil.centrooeste.sensor02",
                        Value = "5000"
                    }
                );
                
                context.SaveChanges();
            }

        }
    }
}
