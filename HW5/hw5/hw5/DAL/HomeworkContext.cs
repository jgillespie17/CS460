using hw5.Models;
using System.Data.Entity;

namespace hw5.DAL
{
    public class HomeworkContext : DbContext
    {
        public HomeworkContext() : base("name=OurHomeworkDB")
        {
            Database.SetInitializer<HomeworkContext>(null);
        }

        public virtual DbSet<Homework> Homework { get; set; }
    }
}