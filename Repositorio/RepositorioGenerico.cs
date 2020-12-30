using Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private Contexto _contexto;
        private DbSet<T> tabla = null;

        public RepositorioGenerico()
        {
            this._contexto = new Contexto();
            this.tabla = this._contexto.Set<T>();

        }
        public bool Actualizar(T Data, ref string MensajeError)
        {
            try
            {
                tabla.Attach(Data);
                _contexto.Entry(Data).State = EntityState.Modified;
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;
                    
                return false;
            }
        }

        public bool Eliminar(int Id, ref string MensajeError)
        {
            try
            {
                T item = tabla.Find(Id);
                tabla.Remove(item);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;

                return false;
            }
        }

        public bool Guardar(T Data, ref string MensajeError)
        {
            try
            {
                tabla.Add(Data);
                _contexto.Entry(Data).State = EntityState.Added;
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;

                return false;
            }
        }

        public bool Listar(ref List<T> Data, ref string MensajeError)
        {
            try
            {
                Data = tabla.ToList();
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;

                return false;
            }
        }

        public bool ObtenerPorId(ref T Data, int Id, ref string MensajeError)
        {
            try
            {
                Data = tabla.Find(Id);
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;

                return false;
            }
        }
    }
}
