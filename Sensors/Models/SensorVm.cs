using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sensors.Models
{
    public class SensorVm
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Tag { get; set; }

        [Required]
        [MaxLength(128)]
        public string Value { get; set; }
    }
}
