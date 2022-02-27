using Microsoft.EntityFrameworkCore;
using ShortLink.Infra.Data.Models.Link;

namespace ShortLink.Infra.Data
{
    public class ShortLinkContext : DbContext
    {
        public ShortLinkContext(DbContextOptions<ShortLinkContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<PageLink> PageLinkes { get; set; }
    }

}