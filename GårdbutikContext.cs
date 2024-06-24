using GårdbutikAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GårdbutikAPI
{
    public class GårdbutikContext : DbContext
    {
        public GårdbutikContext(DbContextOptions<GårdbutikContext> options) :base(options) { }

        public DbSet<Gårdbutik> Gårdbutik { get; set; }

        public DbSet<User> users { get; set; }
    }
}
