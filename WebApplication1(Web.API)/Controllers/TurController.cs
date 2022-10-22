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
    public class TurController : ApiController
    {
        DataContext db = new DataContext();

        // GET: Raf
        public IEnumerable<Tur> Get()
        {
            var tur = db.Tur.Where(x => x.IsDelete == false).ToList();
            return tur;
        }

        public IHttpActionResult Get(int id)
        {
            var tur = db.Tur.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (tur != null)
            {
                return Ok(tur);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody]Tur tur)
        {
            db.Tur.Add(tur);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var tur = db.Tur.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (tur != null)
            {
                tur.IsDelete = true;
                db.SaveChanges();
                return Ok("Raf Başarılı Bir Şekilde Silindi");
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody]Tur tur)
        {
            var edittur = db.Tur.FirstOrDefault(x => x.Id == tur.Id && x.IsDelete == false);
            if (edittur != null)
            {
                
                edittur.Name = tur.Name;
                edittur.Description = tur.Description;
                edittur.Status = tur.Status;
                edittur.IsDelete = tur.IsDelete;
                db.SaveChanges();
                return Ok("Raf Başarılı bir şekilde güncellendi.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}