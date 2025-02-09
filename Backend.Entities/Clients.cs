using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Clients
    {
        public int Id { get; set; } // Clave primaria autogenerada
        public string RUC { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
