using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Cities
    {
        public int Id { get; set; } // Clave primaria autogenerada
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
