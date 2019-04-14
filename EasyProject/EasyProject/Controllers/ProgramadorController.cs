using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyProject.BusinessLogic;
using EasyProject.Exceptions;
using EasyProject.Models;
using EasyProject.Repositories;
using Newtonsoft.Json;

namespace EasyProject.Controllers
{
    public class ProgramadorController : Controller
    {
        private ProgramadorBLL ProgramadorBLL = new ProgramadorBLL();
        private EasyProjectEntities db = new EasyProjectEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            return View();
        }

        public JsonResult GetProgramador(long idProgramador)
        {
            try
            {
                ContentProgramador prog = ProgramadorBLL.GetProgramador(idProgramador);
                return Json(prog, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = ExceptionHandler.HandleException(ex) });
            }
        }

        public JsonResult GetProgramadores()
        {
            try
            {
                List<ContentProgramador> prog = ProgramadorBLL.GetProgramadores();
                return Json(prog, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = ExceptionHandler.HandleException(ex) });
            }
        }

        public JsonResult Insert(Programador programador)
        {
            try
            {
                return Json(new { retorno = ProgramadorBLL.Add(programador), msg = "OK|Registro cadastrado com sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ExceptionHandler.HandleException(ex) });
            }
        }

        [HttpPost]
        public JsonResult Update(Programador updatedProgramador)
        {
            try
            {
                ProgramadorBLL.Update(updatedProgramador);
                return Json(new { msg = "OK|Registro alterado com sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ExceptionHandler.HandleException(ex) });
            }
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            try
            {
                ProgramadorBLL.Remove(id);
                return Json(new { msg = "OK|Registro deletado com sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ExceptionHandler.HandleException(ex) });
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
