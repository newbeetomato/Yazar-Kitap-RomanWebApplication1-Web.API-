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
    public class RafController : ApiController
    {
        DataContext db = new DataContext();

        // GET: Raf
        public IEnumerable<Raf> Get()
        {
            var raf = db.Raf.Where(x => x.IsDelete == false).ToList();
            return raf;
        }

        public IHttpActionResult Get(int id)
        {
            var raf = db.Raf.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (raf != null)
            {
                return Ok(raf);
            }
            else
            {
                return NotFound();
            }
        }

        public  IHttpActionResult Post([FromBody]Raf raf)
        {
            db.Raf.Add(raf);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var raf = db.Raf.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (raf != null)
            {
                raf.IsDelete = true;
                db.SaveChanges();
                return Ok("Raf Başarılı Bir Şekilde Silindi");
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody]Raf raf)
        {
            var editraf = db.Raf.FirstOrDefault(x => x.Id == raf.Id && x.IsDelete == false);
            if (editraf != null)
            {
                editraf.Name = raf.Name;
                editraf.Description = raf.Description;
                editraf.Status = raf.Status;
                editraf.IsDelete = raf.IsDelete;
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