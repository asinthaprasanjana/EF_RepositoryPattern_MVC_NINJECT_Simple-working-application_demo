using DataEntityManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class DataContext:DbContext
    {
        /// <summary>
        /// operations
        /// </summary>
        public DataContext() : base("StudentData") 
        {
        }
        public DbSet<Student> Students{ get; set; }

        public DbSet<Marks> Marks { get; set; }

        public DbSet<User> Users { get; set; }

        /// <summary>
        /// OnmodelCreating gives access to a ModelBuilder Instence that we can use to confogure the model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

