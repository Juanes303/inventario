using inventario.Dato;
using inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventario.Controllers
{
    public class inventarioController : Controller
    {

        InventarioAdmin admin = new InventarioAdmin();
        // GET: inventario
        public ActionResult Index()
        {
            IEnumerable<registros> lista = admin.Consultar();
            ViewBag.mensaje = "";
            return View(lista);
        }

        //vista de guardado
        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }

        public ActionResult Nuevo(registros modelo)
        {
            admin.Guardar(modelo);
            ViewBag.mensaje = "Registro guardado";
            return View("Guardar", modelo);
        }

        public ActionResult Detalle(int ID = 0)
        {
            registros modelo = admin.Consultar(ID);
            return View(modelo);
        }

        public ActionResult Modificar(int ID)
        {
            registros modelo = admin.Consultar(ID);
            ViewBag.mensaje = "";
            return View(modelo);
        }

        public ActionResult Actualizar(registros modelo)
        {
            admin.Modificar(modelo);
            ViewBag.mensaje = "Registro Modificado";
            return View("Modificar", modelo);
        }

        public ActionResult Eliminar(int ID = 0)
        {
            registros modelo = new registros()
            {
                ID = ID
            };
            admin.Eliminar(modelo);
            IEnumerable<registros> lista = admin.Consultar();
            ViewBag.mensaje = "Registro Eliminado";
            return View("Index", lista);
        }

    }
}