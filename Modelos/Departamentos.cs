using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Departamentos
    {
        [Key]
        public int IdDepartamento { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreDepartamento { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
