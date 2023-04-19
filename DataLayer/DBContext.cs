using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PGManagement.Models;

namespace PGManagement.DataLayer
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Guests> Guests { get; set; }
        public DbSet<GuestDetails> GuestDetails { get; set; }
        public DbSet<GuestHistory> GuestHistory { get; set; }
        public DbSet<Floors> Floors { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Beds> Beds { get; set; }
    }
}
