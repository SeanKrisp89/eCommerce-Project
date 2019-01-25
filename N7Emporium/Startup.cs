using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N7Emporium.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using N7Emporium.Services;
using Braintree;

namespace N7Emporium
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<N7EmporiumContext>(options =>
            //options.UseInMemoryDatabase("Default")
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<N7EmporiumContext>();

            services.AddTransient<SendGrid.ISendGridClient>((s) =>
            {
                return new SendGrid.SendGridClient(Configuration.GetValue<string>("SendGrid:Key"));
            });

            services.AddTransient<IEmailSender>((s) =>
            {
                return new EmailSender(s.GetService<ISendGridClient>());
            });

            services.AddTransient<SmartyStreets.IClient<SmartyStreets.USStreetApi.Lookup>>((s) =>
            {
                return new SmartyStreets.ClientBuilder(
                    Configuration.GetValue<string>("SmartyStreets:AuthId"),
                    Configuration.GetValue<string>("SmartyStreets:AuthToken")
                ).BuildUsStreetApiClient();
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<Data.N7EmporiumContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("N7EmporiumConnection")); });

            services.AddTransient<Braintree.IBraintreeGateway>((s) =>
            {
                return new Braintree.BraintreeGateway(
                    Configuration.GetValue<string>("Braintree:Environment"),
                    Configuration.GetValue<string>("Braintree:MerchantId"),
                    Configuration.GetValue<string>("Braintree:PublicKey"),
                    Configuration.GetValue<string>("Braintree:PrivateKey"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        
    }
}
