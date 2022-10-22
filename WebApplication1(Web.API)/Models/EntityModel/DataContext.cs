using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebApplication1_Web.API_.Models.EntityModel
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection"){}
        public DbSet<Raf> Raf { get; set; }
        public DbSet<Yazar> Yazar { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<Kitap> Kitap { get; set; }
    }
}