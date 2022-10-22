using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_Web.API_.Models
{
    public class GenerateProp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
    }
}