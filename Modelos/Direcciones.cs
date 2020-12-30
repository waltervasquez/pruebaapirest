using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Direcciones
    {
        [Key]
        public int IdDireccion { get; set; }

        [Required]
        [ForeignKey("Contactos")]
        public int IdContacto { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public virtual Contactos Contactos { get; set; }
    }
}
