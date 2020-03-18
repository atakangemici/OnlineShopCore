using Esnafim.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Esnafim
{
    public class EsnafimContext : DbContext
    {

        public DbSet<Dukkanlar> Dukkanlar { get; set; }
        public DbSet<EsnafUser> EsnafUser { get; set; }
        public DbSet<Kategoriler> Kategoriler { get; set; }
        public DbSet<MusteriUser> MusteriUser { get; set; }
        public DbSet<Sikayetler> Sikayetler { get; set; }
        public DbSet<SiparisDetaylari> SiparisDetaylari { get; set; }
        public DbSet<Siparisler> Siparisler { get; set; }
        public DbSet<Urunler> Urunler { get; set; }


        public EsnafimContext(DbContextOptions<EsnafimContext> options) : base(options)
        {

        }
    }
}