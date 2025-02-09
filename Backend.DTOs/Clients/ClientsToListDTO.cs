using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTOs.Client
{
    public class ClientsToListDTO
    {
        public required int Id { get; set; } // Clave primaria autogenerada
        public required string RUC { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
    }
}
