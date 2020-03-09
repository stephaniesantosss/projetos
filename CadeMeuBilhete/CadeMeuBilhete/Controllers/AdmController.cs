using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuBilhete.Models;

namespace CadeMeuBilhete.Controllers
{
    public class AdmController : Controller
    {
        CadeMeuBilheteEntities3 db = new CadeMeuBilheteEntities3();
        // GET: Adm
        public ActionResult Cadastrar()
        {
            List<String> listaCargo = new List<string>();
            listaCargo.Add("Funcionário");
            listaCargo.Add("Estágiario");
            ViewBag.status = listaCargo;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Funcionario_Empresa user)
        {
            try
            {
                user.Status = "A";
                db.Funcionario_Empresa.Add(user);
                db.SaveChanges();
                return RedirectToAction("Listar", "Principal");
            }
            catch
            {

                return RedirectToAction("Listar", "Principal");
            }
        }
        public ActionResult Alterar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listar", "Principal");
            }
            else
            {
                List<String> listaCargo = new List<string>();
                listaCargo.Add("Funcionário");
                listaCargo.Add("Estágiario");
                ViewBag.status = listaCargo;

                List<String> listaStatus = new List<string>();
                listaStatus.Add("Ativo");
                listaStatus.Add("Inativo");
                ViewBag.Status = listaStatus;

                Funcionario_Empresa user = db.Funcionario_Empresa.Find(id);
                return View(user);
            }
        }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Alterar ([Bind(Include = "idUsuario,CPF,Nome,Data_Nascimento,RG,Cargo,Status")]Funcionario_Empresa user)
        {
            if (user.Status.Equals("Ativo"))
            {
                user.Status = "A";
            }
            else
            {
                user.Status = "I";
            }
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Listar", "Principal");

        }
    }
}
