using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1_Web.API_.Models;
using WebApplication1_Web.API_.Models.EntityModel;

namespace WebApplication1_Web.API_.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //Tur tur = new Tur()UMUTUUUUUUUUUUUMMMMMMMMMMMMMMMMUUUUUUUUUUUTTTTTTTTTTTTTT
            //{
            //    Name = "Roman",
            //    Description = "Roman Kitapları",
            //    Status = true,
            //    IsDelete = false,
            //};

            //db.Tur.Add(tur);
            //db.SaveChanges();

            return View();
        }
    }
}
