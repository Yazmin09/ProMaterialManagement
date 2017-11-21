using ClientePrueba.MaterialAceroGM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace ClientePrueba.Controllers
{
    public class AceroGMaquinariaController : Controller
    {
        Cliente.ClienteDeMaterialAGM C = new Cliente.ClienteDeMaterialAGM();
        //Controladores
        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Consultar()
        {
            ViewBag.acerogm = C.verTodos();
            return View();
        }
        public ActionResult Details(string idMaterial)
        {
            ViewBag.acerogm = C.encontrarUno(idMaterial);
            return View();
        }
        public ActionResult Edit(string idMaterial)
        {
            ViewBag.acccerogm = C.encontrarUno(idMaterial);
            return View();
        }
        public void Delete(string id)
        {
            MaterialAceroGM.AceroGMaquinaria acerogm = C.encontrarUno(id);
            C.eliminar(acerogm);
        }
    }
}