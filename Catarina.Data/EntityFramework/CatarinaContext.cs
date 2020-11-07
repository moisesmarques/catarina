using Catarina.Core.Entities;
using Catarina.Data.Seed;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Catarina.Data.EntityFramework
{
    public class CatarinaContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public CatarinaContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions ) : base( options, operationalStoreOptions )
        { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoLogradouro> TipoLogradouros { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfigurationsFromAssembly( Assembly.GetExecutingAssembly() );

            ApplicationSeed.Seed( modelBuilder );

            base.OnModelCreating( modelBuilder );
        }
    }
}
