using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1_Web.API_.Models;
using WebApplication1_Web.API_.Models.EntityModel;

namespace WebApplication1_Web.API_.Controllers
{
    public class YazarController : ApiController
    {
        DataContext db = new DataContext();

        // GET: Yazar
        public IEnumerable<Yazar> Get()
        {
            var yazar = db.Yazar.Where(x => x.IsDelete==false).ToList();
            return yazar;
        }

        public IHttpActionResult Get(int id)
        {
            var yazar = db.Yazar.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            if (yazar != null)
            {
                return Ok(yazar);// 200 kodu döner yani başarılı
            }
            else
            {
                return NotFound();// 404 kodu değer bulunamadı
            }
        }

        public IHttpActionResult Post([FromBody]Yazar yazar)
        {
            db.Yazar.Add(yazar);
            db.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            //var yazar = db.Yazar.Find(id);
            var yazar = db.Yazar.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            if (yazar != null)
            {
                yazar.IsDelete = true;
                db.SaveChanges();
                return Ok(yazar.Name+" Yazar Başarılı Bir Şekilde Silindi.");

            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody]Yazar yazar)
        {
            var edityazar = db.Yazar.FirstOrDefault(x => x.Id == yazar.Id && x.IsDelete == false);
            if (edityazar != null)
            {
                edityazar.Name = yazar.Name;
                edityazar.SurName = yazar.SurName;
                edityazar.Description = yazar.Description;
                edityazar.Status = yazar.Status;
                db.SaveChanges();

                return Ok(edityazar.Name + " " + edityazar.SurName
                    + "Adlı Yazar Başarılı Bir Şekilde Güncellendi");
            }
            else
            {
                return NotFound();
            }
        }
    }
}