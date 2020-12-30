using Modelos;
using Modelos.DTO;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExamenAxxy.Controllers
{
    public class ContactosController : Controller
    {
        public RepositorioContacto repositorio = new RepositorioContacto();
        public RepositorioGenerico<Departamentos> repositoriodepartamento = new RepositorioGenerico<Departamentos>();
        string mensajeerror = string.Empty;
        // GET: Contactos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Editar(int IdContacto)
        {
            mensajeerror = string.Empty;
            DTO_Contactos data = new DTO_Contactos();
            var estado = repositorio.ObtenerPorId(ref data, IdContacto, ref mensajeerror);
            TempData["data"] = data;
            TempData["estado"] = estado;
            TempData["mensajeerror"] = mensajeerror;
            return View();
        }



        [HttpPost]
        public JsonResult ObtenerContactoPorID()
        {  
            return Json(new { data =  TempData["data"], estado = TempData["estado"], mensajeerror = TempData["mensajeerror"] });
        }




        [HttpPost]
        public JsonResult ObtenerListaContacto()
        {
            mensajeerror = string.Empty;
            List<DTO_Contactos> data = new List<DTO_Contactos>();
            var estado = repositorio.Listar(ref data, ref mensajeerror);
            return Json(new { estado, data, mensajeerror });
        }

        [HttpPost]
        public JsonResult GuardarContacto(DTO_Contactos Contacto)
        {
            mensajeerror = string.Empty;
            var estado = repositorio.Guardar(Contacto, ref mensajeerror);
            return Json(new { estado, mensajeerror });
        }


        [HttpPost]
        public JsonResult ActualizarContacto(DTO_Contactos Contacto)
        {
            mensajeerror = string.Empty;
            var estado = repositorio.Actualizar(Contacto, ref mensajeerror);
            return Json(new { estado, mensajeerror });
        }

        [HttpPost]
        public JsonResult EliminarContacto(int IdContacto)
        {
            mensajeerror = string.Empty;
            var estado = repositorio.Eliminar(IdContacto, ref mensajeerror);
            return Json(new { estado, mensajeerror });
        }

        [HttpPost]
        public JsonResult ObtenerDepartamento()
        {
            mensajeerror = string.Empty;
            List<Departamentos> data = new List<Departamentos>();
            var estado = repositoriodepartamento.Listar(ref data, ref mensajeerror);
            return Json(new { estado, data, mensajeerror });
        }




    }
}