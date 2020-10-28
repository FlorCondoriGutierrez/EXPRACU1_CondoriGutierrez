using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU1_CondoriGutierrez.Models;


namespace EXPRACU1_CondoriGutierrez.Controllers
{
    public class ListaController : Controller
    {
        // GET: Lista
        public static List<ClsNumeros> lista1 = new List<ClsNumeros>();
        public static List<ClsNumeros> lista2 = new List<ClsNumeros>();
       
        ViewModel userViewModel = new ViewModel();

        // GET: Ejer5
        public ActionResult Index()
        {
            ViewModel userViewModel1 = new ViewModel();
            return View(userViewModel1);
        }

        public ActionResult Envio()
        {
            string dato = Request["txt1"];
            if (dato == "" || dato == null)
            {
                userViewModel.Numero1 = lista1;
                userViewModel.Numero2 = lista2;
                return View("Index", userViewModel);
            }
            string radio = Request["radio"];
            if (radio == "" || radio == null)
            {
                userViewModel.Numero1 = lista1;
                userViewModel.Numero2 = lista2;
                return View("Index", userViewModel);
            }

            if (radio.Equals("lista1"))
            {
                ClsNumeros o = new ClsNumeros();
                o.numero = int.Parse(dato);
                lista1.Add(o);
                userViewModel.Numero1 = lista1;
                userViewModel.Numero2 = lista2;
                return View("Index", userViewModel);
            }
            if (radio.Equals("lista2"))
            {
                ClsNumeros o = new ClsNumeros();
                o.numero = int.Parse(dato);
                lista2.Add(o);
                userViewModel.Numero1 = lista1;
                userViewModel.Numero2 = lista2;
                return View("Index", userViewModel);
            }

            return View("Index", userViewModel);
        }

        public ActionResult Calcular()
        {

            var result = lista1.Union(lista2).ToList();
            var repetidos = from p in result
                            group p by new { p.numero } into grupo
                            select grupo;

            List<Resultado> lis = new List<Resultado>();
            foreach (var grupo in repetidos)
            {
                if (grupo.Count() > 1)
                {
                    Resultado re = new Resultado();
                    re.resultado = grupo.Key.numero + " Repetidos " + grupo.Count();
                    lis.Add(re);
                }

            }
            return Json(lis, JsonRequestBehavior.AllowGet);
        }
    }
}