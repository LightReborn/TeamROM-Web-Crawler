using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Model.Models;

namespace WebCrawler.Data.DAL
{
  public  class GameContext: DbContext
    {
      //how to Moq this GameContext
        public GameContext() : base("Data Source=BLAINESLAPTOP\\SQLEXPRESS;Initial Catalog=Crawler;Integrated Security=True;Connect Timeout=15;") { }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
