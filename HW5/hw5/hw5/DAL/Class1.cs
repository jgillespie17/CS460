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
        public HomeworkContext() : base("name=Homework")
        {

        }

        public virtual DbSet<Homework>Homework { get; set; }
    }
}