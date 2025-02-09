using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTOs.Cities
{
    public class CitiesToEditDTO
    {
        public required int Id { get; set; } // Clave primaria autogenerada
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}
