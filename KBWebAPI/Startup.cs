using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Comm100.Framework.Authentication;
using Comm100.Framework.Module;
using Comm100.Framework.Web;

namespace KB.WebAPI
{
    public class Startup
    {

        private static readonly WindsorContainer Container = new WindsorContainer();

        private IModuleManager _moduleManager = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            Container.AddFacility<AspNetCoreFacility>(f => f.CrossWiresInto(services));

            Container.Register(Component.For<IWindsorContainer>().Instance(Container));

            services.Configure<IISServerOptions>(options => {
                options.AutomaticAuthentication = false;
            });

            var key = Encoding.ASCII.GetBytes("comm100-secret");

            services
                .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = "jwt";
                        options.DefaultScheme = "jwt";
                    })
                .AddScheme<JwtBearerAuthenticationOptions, JwtAuthenticationHandler>("jwt", options =>
                    {
                        options.Audience = "kb";
                    });

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})

            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            RegisterApplicationComponents(services);

            services.AddCors(options => {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(Comm100ExceptionFilter));
                options.MaxValidationDepth = 200;
            }).AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.IgnoreNullValues = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddHttpContextAccessor();

            return services.AddWindsor(Container,
                 opts => opts.UseEntryAssembly(this.GetType().Assembly));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/error");
            }


            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Articles}/{action=Index}/{id?}");
            });
        }

        

        private void RegisterApplicationComponents(IServiceCollection services)
        {
            Container.Install(new CoreInstaller());

            _moduleManager = Container.Resolve<IModuleManager>();
            _moduleManager.Initialize(typeof(WebAPIModule));
            _moduleManager.StartModules();
        }
    }
}
