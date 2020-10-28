using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU1_CondoriGutierrez.Models;

namespace EXPRACU1_CondoriGutierrez.Controllers
{
    public class ArrayLoginController : Controller
    {
        // GET: ArrayLogin
        String[] usuarios = { "usuario1", "usuario2" };
        String[] password = { "123456", "2468"};
        List<ClsUsuario> objLista = new List<ClsUsuario>();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Validar(ClsUsuario objLogin)
        {
            ClsUsuario objusuario = new ClsUsuario();
            objusuario.id = "usuario1";
            objusuario.contra = "123456";
            objLista.Add(objusuario);

            


            var query = (from u in objLista
                         where u.id.Equals(objLogin.id) && u.contra.Equals(objLogin.contra)
                         select u).ToList();

            if (query.Count > 0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View("Index");
            }
        }
    }
}