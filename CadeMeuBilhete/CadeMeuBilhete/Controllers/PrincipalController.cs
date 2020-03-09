using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuBilhete.Models;

namespace CadeMeuBilhete.Controllers
{
    public class PrincipalController : Controller
    {
        CadeMeuBilheteEntities3 db = new CadeMeuBilheteEntities3();
        // GET: Listar
        public ActionResult Listar()
        {
            return View(db.Funcionario_Empresa.ToList());
        }
    }
}