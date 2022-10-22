using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_Web.API_.Models
{
    public class Yazar : GenerateProp
    {
        
        public string SurName { get; set; }
        public List<Kitap> Kitap { get; set; }

    }
}