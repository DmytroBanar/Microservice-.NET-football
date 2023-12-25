using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UnitOfWorkDemo.Infrastructure
{
    public class DbContextClass : DbContext
    {

        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {
       /*     Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=helloapp.db");
        //}

        public DbSet<FootballTeamDetails> Teams { get; set; }
        public DbSet<FootballLeagueDetails> Leagues { get; set; }
    }
}
