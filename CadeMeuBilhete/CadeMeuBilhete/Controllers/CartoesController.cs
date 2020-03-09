using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuBilhete.Controllers
{
    public class CartoesController : Controller
    {
        // GET: Cartoes
        public ActionResult Index()
        {
            return View();
        }
    }
}