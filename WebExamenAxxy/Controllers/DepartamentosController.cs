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
    public class DepartamentosController : Controller
    {

        public RepositorioGenerico<Departamentos> repositorio = new RepositorioGenerico<Departamentos>();

        string mensajeerror = string.Empty;

        // GET: Departamentos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerDepartamento()
        {
            mensajeerror = string.Empty;
            List<Departamentos> data = new List<Departamentos>();
            var estado = repositorio.Listar(ref data, ref mensajeerror);
            return Json(new { estado, data, mensajeerror });
        }

        [HttpPost]
        public JsonResult GuardarDepartamento(Departamentos departamentos)
        {
            mensajeerror = string.Empty;
            var estado = repositorio.Guardar(departamentos, ref mensajeerror);
            return Json(new { estado, mensajeerror });
        }

        
    }
}