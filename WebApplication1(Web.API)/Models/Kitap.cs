using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_Web.API_.Models
{
    public class Kitap : GenerateProp
    {
      
        public int YazarID { get; set; }
        public Yazar Yazar { get; set; }
        public int TurID { get; set; }
        public Tur Tur { get; set; }
        public int RafID { get; set; }
        public Raf Raf { get; set; }

    }
}