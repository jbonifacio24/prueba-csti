using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaCSTI.Application.Dtos;
using PruebaCSTI.Application.Services;
using PruebaCSTI.Domain.Entities;

namespace PruebaCSTIWeb.Controllers
{
    public class InventarioController : Controller
    {
        private readonly InventarioService _service;

        public InventarioController(InventarioService service)
        {
            _service = service;
           
        }

        // LISTAR
        public ActionResult Index(DateTime? fechaInicio,
                                    DateTime? fechaFin,
                                    string tipoMovimiento,
                                    string nroDocumento)
        {
            var result = _service.Listar(
                                        fechaInicio,
                                        fechaFin,
                                        tipoMovimiento,
                                        nroDocumento
                                    );

                                            return View(result);
        }

        // DETALLE
        public ActionResult Details(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            var obj = _service.ObtenerPorId(
                codCia,
                companiaVenta3,
                almacenVenta,
                tipoMovimiento,
                tipoDocumento,
                nroDocumento,
                codItem2
            );

            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InventarioDto input)
        {
            var result = _service.Crear(input);

            if (!result.EsValido)
            {
                ModelState.AddModelError("", result.Mensaje);
                return View(input);
            }

            return RedirectToAction("Index");

        }

        // EDITAR
        public ActionResult Edit(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            var obj = _service.ObtenerPorId(
                codCia,
                companiaVenta3,
                almacenVenta,
                tipoMovimiento,
                tipoDocumento,
                nroDocumento,
                codItem2
            );

            return View(obj);
        }

        // EDITAR 
        [HttpPost]
        public ActionResult Edit(InventarioDto model)
        {
            if (ModelState.IsValid)
            {
                _service.Actualizar(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // ELIMINAR
        public ActionResult Delete(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            var obj = _service.ObtenerPorId(
                codCia,
                companiaVenta3,
                almacenVenta,
                tipoMovimiento,
                tipoDocumento,
                nroDocumento,
                codItem2
            );

            return View(obj);
        }

        // ELIMINAR
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            _service.Eliminar(
                codCia,
                companiaVenta3,
                almacenVenta,
                tipoMovimiento,
                tipoDocumento,
                nroDocumento,
                codItem2
            );

            return RedirectToAction("Index");
        }
    }
}