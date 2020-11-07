using Catarina.Core.Entities;
using Catarina.Data.EntityFramework;
using Catarina.Web.Providers.Email;
using Elmah.Io.AspNetCore;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Catarina.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services)
        {
            //services.AddCors();

            services.AddDbContext<CatarinaContext>( options =>
                 options.UseSqlServer( Configuration.GetConnectionString( "CatarinaDb" ) ) );

            services.AddDefaultIdentity<ApplicationUser>( options => options.SignIn.RequireConfirmedAccount = true )
               .AddEntityFrameworkStores<CatarinaContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, CatarinaContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddLogging();

            var cors = new DefaultCorsPolicyService( new LoggerFactory().CreateLogger<DefaultCorsPolicyService>() )
            {
                AllowAll = true
            };

            services.AddSingleton<ICorsPolicyService>( cors );

            var emailConfig = Configuration.GetSection( "EmailSettings" ).Get<EmailSettings>();

            services.AddSingleton( emailConfig );

            services.AddSingleton<IEmailSender, EmailSender>();

            //services.AddControllers().AddNewtonsoftJson();
            services.AddSpaStaticFiles( configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            } );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseIdentityServer();

            app.UseAuthorization();

            //app.UseCors( options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() );

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}" );
                endpoints.MapRazorPages();
            } );

            app.UseSpa( spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if ( env.IsDevelopment() )
                {
                    spa.UseAngularCliServer( npmScript: "start" );
                }
            } );
        }
    }
}
