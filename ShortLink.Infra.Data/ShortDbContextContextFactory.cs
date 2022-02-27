using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Infra.Data
{
    public class ShortDbContextContextFactory
    {
        public class ShopDbContextContextFactory : IDesignTimeDbContextFactory<ShortLinkContext>
        {
            public ShortLinkContext CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<ShortLinkContext>();
                optionBuilder.UseSqlServer("Server=.; Initial Catalog=ShortLink;Integrated Security=true");

                ShortLinkContext ctx = new ShortLinkContext(optionBuilder.Options);
                return ctx;
            }
        }
    }
}
