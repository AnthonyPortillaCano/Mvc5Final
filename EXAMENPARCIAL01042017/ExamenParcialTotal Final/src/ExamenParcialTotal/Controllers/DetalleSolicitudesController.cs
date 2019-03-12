using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamenParcialTotal.Data.DataAccess.Interfaces;
using ExamenParcialTotal.Data.DataAccess;
using ExamenParcialTotal.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ExamenParcialTotal.Controllers
{
    [Authorize]
    public class DetalleSolicitudesController : Controller
    {

        private readonly IDetalleSolicitudesDA DetalleSolicitudesDA;
        private readonly ISolicitudesDA SolicitudesDA;
        public DetalleSolicitudesController(IDetalleSolicitudesDA DetalleSolicitudesDA, ISolicitudesDA SolicitudesDA)
        {
           this.DetalleSolicitudesDA = DetalleSolicitudesDA;
            this.SolicitudesDA = SolicitudesDA;
        }
        [Authorize(Policy = "PermitirVisualizarLista")]
        public IActionResult Index()
        {

          //pruebA asasa
            var model = DetalleSolicitudesDA.GetAll();

            return View(model);
        }

        [HttpPost]
        //[Authorize(Policy = "AllowEditDetalleSolicitud")]
        public IActionResult Solicitar(DetalleSolicitudes model)
        {

            //var da = new ProductDA();
            model.estado = 1;
            var result = DetalleSolicitudesDA.Insert(model);

            if (result > 0)
            {
                return RedirectToAction("IndexSolicitante"); //Redireccionamos al listado
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost]
        public IActionResult Aprobacion(DetalleSolicitudes model,String flagaprobacion)
        {

            //var da = new ProductDA();
            if(flagaprobacion== "Rechazar")
            {
                model.estado = 0;
            }
            else
            {
                model.estado = 2;
            }
          
            var result = DetalleSolicitudesDA.Update(model);


            if (result) //Si es verdadero
            {
                return RedirectToAction("Index"); //Redireccionamos al listado
            }
            else
            {
                return View(model);
            }
        }
       
        public IActionResult Aprobacion(int id)
        {

          
            ViewBag.SolicitudList = SolicitudesDA.GetAll();

            var model = DetalleSolicitudesDA.Get(id);
            return View(model);
            
        }

        public IActionResult VisualizarAprobacion(int id)
        {


            ViewBag.SolicitudList = SolicitudesDA.GetAll();

            var model = DetalleSolicitudesDA.Get(id);
            return View(model);

        }


        public IActionResult Solicitar()
        {

            ViewBag.SolicitudList = SolicitudesDA.GetAll();
            return View();
        }
        [Authorize(Policy = "PermitirCrearSolicitud")]
        public IActionResult IndexSolicitante()
        {
            var model = DetalleSolicitudesDA.GetAll();

            return View(model);

        }


    }
}