using Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Contexto : DbContext 
    {
        public Contexto() : base("name=Conexion")
        {
        }
        
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Contactos> Contactos { get; set; }

        public DbSet<Direcciones> Direcciones { get; set; }
    }
}
