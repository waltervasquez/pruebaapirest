using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Contactos
    {
        [Key]
        public int IdContacto { get; set; }

        [Required]
        [ForeignKey("Departamentos")]
        public int IdDepartamento { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreContacto { get; set; }

        [Required]
        public bool Estado { get; set; }


        [Required]
        public DateTime Fecha { get; set; }


        public virtual Departamentos Departamentos { get; set; }
    }
}
