using Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public  interface IRepositorioContacto
    {
        bool Guardar(DTO_Contactos Data, ref string MensajeError);
        bool Eliminar(int Id, ref string MensajeError);

        bool Actualizar(DTO_Contactos Data, ref string MensajeError);

        bool ObtenerPorId(ref DTO_Contactos Data, int Id, ref string MensajeError);

        bool Listar(ref List<DTO_Contactos> Data, ref string MensajeError);
    }
}
