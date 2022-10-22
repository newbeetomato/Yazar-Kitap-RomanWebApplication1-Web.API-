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
    public class KitapController : ApiController
    {
        DataContext db = new DataContext();

        public IEnumerable<Kitap> Get()
        {
            var kitap = db.Kitap.Where(x => x.IsDelete==false).ToList();
            return kitap;
        }

        public IHttpActionResult Get(int id)
        {
            var kitap = db.Kitap.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (kitap != null)
            {
                return Ok(kitap);

            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult GetbyYazarID(int id)
        {
            var kitap = db.Kitap.FirstOrDefault(x => x.YazarID == id && x.IsDelete == false);
            if (kitap != null)
            {
                return Ok(kitap);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody]Kitap kitap)
        {
            db.Kitap.Add(kitap);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete (int id)
        {
            var kitap = db.Kitap.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (kitap != null)
            {
                kitap.IsDelete = true;
                db.SaveChanges();
                return Ok("Kitap Başarıyla Silinmiştir");
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody]Kitap kitap)
        {
            var editkitap = db.Kitap.FirstOrDefault(x => x.Id == kitap.Id && x.IsDelete == false);
            if (editkitap != null)
            {
                editkitap.Name = kitap.Name;
                editkitap.Description = kitap.Description;
                editkitap.Status = kitap.Status;
                editkitap.RafID = kitap.RafID;
                editkitap.TurID = kitap.TurID;
                editkitap.YazarID = kitap.YazarID;
                db.SaveChanges();
                return Ok("Kitap Başarılı bir şekilde güncelledi.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}