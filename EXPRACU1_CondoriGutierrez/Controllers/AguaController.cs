using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU1_CondoriGutierrez.Models;

namespace EXPRACU1_CondoriGutierrez.Controllers
{
    public class AguaController : Controller
    {
        //declaramos costo fijo 
        int cuotafija = 40;
        // GET: Agua
        public ActionResult Index(ClsAgua objagua)
        {
            //validamos
            if (Request.Form["Calcular"] != null)
            {
                if (objagua.litros > 200)
                {
                    cuotafija += (objagua.litros - 200) * 2;
                    objagua.litros -= (cuotafija - 40) / 2;
                }
                //&& objagua.litros == 0
                if (objagua.litros >= 50 && objagua.litros <= 200)
                {
                    cuotafija += objagua.litros - 49;
                    objagua.litros -= 0;
                }
            }
            ViewBag.Cuota = cuotafija.ToString();
            if (Request.Form["litros"] == "")
            {
                ViewBag.cuota = "No existe valor".ToString();
            }

            return View(objagua);
        }
    }
}