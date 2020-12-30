using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class DTO_Contactos
    {
      
        public int IdContacto { get; set; }

       
        public int IdDepartamento { get; set; }

        public string NombreDepartamento;
        public string NombreContacto { get; set; }

   
        public bool Estado { get; set; }

 
        public DateTime Fecha { get; set; }

        public  List<DTO_Direcciones> Direcciones { get ;set ;}
    }
}
