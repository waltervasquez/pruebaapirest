using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class DTO_Direcciones
    {
        
        public int IdDireccion { get; set; }
        
        public int IdContacto { get; set; }
        
        public string Direccion { get; set; }
        
        public bool Estado { get; set; }

        
        public DateTime Fecha { get; set; }
    }
}
