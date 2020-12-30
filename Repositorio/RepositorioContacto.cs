using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.DTO;
using Datos;
using Modelos;

namespace Repositorio
{
    public class RepositorioContacto : IRepositorioContacto
    {
        private Contexto _contexto; 

        public RepositorioContacto()
        {
            this._contexto = new Contexto(); 

        }
        public bool Actualizar(DTO_Contactos Data, ref string MensajeError)
        {
            try
            {
                Contactos contacto = _contexto.Contactos.Where(p => p.IdContacto == Data.IdContacto).FirstOrDefault();
                contacto.NombreContacto = Data.NombreContacto;
                contacto.IdDepartamento = Data.IdDepartamento;
                contacto.Estado = true;
                contacto.Fecha = DateTime.Now;
                _contexto.Entry<Contactos>(contacto).State = System.Data.Entity.EntityState.Modified;

                List<Direcciones> direcciones = _contexto.Direcciones.Where(p => p.IdContacto == Data.IdContacto & p.Estado == true).ToList();

                List<Direcciones> direccioneseliminar = _contexto.Direcciones.Where(p => p.IdContacto == Data.IdContacto & p.Estado == true).ToList();


                foreach (var item in direccioneseliminar)
                {
                    item.Estado = false;
                    item.Fecha = DateTime.Now;
                    _contexto.Entry<Direcciones>(item).State = System.Data.Entity.EntityState.Modified;
                }

                foreach (var item in Data.Direcciones)
                {
                    Direcciones direccion = _contexto.Direcciones.Where(p => p.IdDireccion == item.IdDireccion).FirstOrDefault();
                    if (direccion != null)
                    {
                        direccion.Direccion = item.Direccion;
                        direccion.Estado = true;
                        direccion.Fecha = DateTime.Now;
                        _contexto.Entry<Direcciones>(direccion).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        direccion = new Direcciones()
                        {
                            IdContacto = contacto.IdContacto,
                            Direccion = item.Direccion,
                            Estado = true,
                            Fecha = DateTime.Now
                        };
                        _contexto.Entry<Direcciones>(direccion).State = System.Data.Entity.EntityState.Added;
                    }
                    
                }
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
                Contactos contacto = _contexto.Contactos.Where(p => p.IdContacto == Id).FirstOrDefault();
                contacto.Estado = false;
                contacto.Fecha = DateTime.Now;
                _contexto.Entry<Contactos>(contacto).State = System.Data.Entity.EntityState.Modified;

                List<Direcciones> direcciones = _contexto.Direcciones.Where(p => p.IdContacto == Id & p.Estado == true).ToList();

                    
                foreach (var item in direcciones)
                {
                    item.Estado = false;
                    item.Fecha = DateTime.Now;
                    _contexto.Entry<Direcciones>(item).State = System.Data.Entity.EntityState.Modified;
                }
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;
                return false;
            }
        }

        public bool Guardar(DTO_Contactos Data, ref string MensajeError)
        {
            try
            {
                Contactos contacto = new Contactos()
                {
                    IdDepartamento = Data.IdDepartamento,
                    NombreContacto = Data.NombreContacto,
                    Fecha = DateTime.Now,
                    Estado = true
                };
                _contexto.Entry<Contactos>(contacto).State = System.Data.Entity.EntityState.Added;

                foreach (var item in Data.Direcciones)
                {
                    Direcciones direccion = new Direcciones()
                    {
                        IdContacto = contacto.IdContacto,
                        Direccion = item.Direccion,
                        Estado = true,
                        Fecha = DateTime.Now
                    };
                    _contexto.Entry<Direcciones>(direccion).State = System.Data.Entity.EntityState.Added;
                }
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;
                return false;
            }
        }

        public bool Listar(ref List<DTO_Contactos> Data, ref string MensajeError)
        {
            try
            {
                Data = _contexto.Contactos.Where(p => p.Estado == true).Select(p => new DTO_Contactos
                {
                    IdContacto = p.IdContacto,
                    NombreContacto = p.NombreContacto,
                    NombreDepartamento = p.Departamentos.NombreDepartamento,
                    Direcciones = _contexto.Direcciones.Where(c=> c.IdContacto == p.IdContacto & c.Estado == true).Select(i=> new DTO_Direcciones
                    {
                        IdDireccion = i.IdDireccion,
                        Direccion = i.Direccion
                    }).ToList()
                }).ToList();
                return true;
            }
            catch (Exception e)
            {
                MensajeError = e.Message;
                return false;
            }
        }

        public bool ObtenerPorId(ref DTO_Contactos Data, int Id, ref string MensajeError)
        {
            try
            {
                Data = _contexto.Contactos.Where(p => p.IdContacto == Id & p.Estado == true).Select(p => new DTO_Contactos
                {
                    IdContacto = p.IdContacto,
                    NombreContacto = p.NombreContacto,
                    IdDepartamento = p.IdDepartamento,
                    NombreDepartamento = p.Departamentos.NombreDepartamento,
                    Direcciones = _contexto.Direcciones.Where(c => c.IdContacto == p.IdContacto & c.Estado == true).Select(i => new DTO_Direcciones
                    {
                        IdDireccion = i.IdDireccion,
                        Direccion = i.Direccion
                    }).ToList()
                }).FirstOrDefault();
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
