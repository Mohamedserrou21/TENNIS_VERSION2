using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TENNIS_APP.Models;

namespace TENNIS_APP.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Joueur> joueurs { get; set; }
        public DbSet<Rencontre> rencontres { get; set; }
        public DbSet<Gain> gains { get; set; }
        public DbSet<Sponsor> sponsors { get; set; }
        
        public DbSet<Tournoi> Tournois { get; set; }
        public DbSet<Video> videos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TENNIS_APP.Models.Subvention> Subvention { get; set; }
        
        public DbSet<TENNIS_APP.Models.Ranking> Ranking { get; set; }
    }
}
