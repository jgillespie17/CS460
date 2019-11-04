using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using hw5.Models;

namespace hw5.DAL
{
    public class HomeworkContext : DbContext
    {
        public HomeworkContext() : base("name=HomeworkDB")
        {
            Database.SetInitializer<HomeworkContext>(null);
        }

        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}