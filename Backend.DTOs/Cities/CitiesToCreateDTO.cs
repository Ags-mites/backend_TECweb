using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTOs.Cities
{
    public class CitiesToCreateDTO
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}
