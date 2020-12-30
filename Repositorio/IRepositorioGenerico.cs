using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IRepositorioGenerico<T> where T : class
    {
        bool Guardar(T Data, ref string MensajeError);
        bool Eliminar(int Id, ref string MensajeError);

        bool Actualizar(T Data, ref string MensajeError);

        bool ObtenerPorId(ref T Data, int Id, ref string MensajeError);

        bool Listar(ref List<T> Data, ref string MensajeError);
    }
}
