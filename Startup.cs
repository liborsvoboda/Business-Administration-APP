using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.NodeServices;
using app.Extensions;
using Microsoft.AspNetCore.Http.Features;
using app.Scheduller.Scheduling;
using Microsoft.Extensions.Logging;
using app.Scheduller;


namespace WebApplication
{
    public class Startup
    {
 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //private bool firstCycle = false;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddSignInManager()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<FormOptions>(options => options.BufferBody = true);
            services.AddNodeServices();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //    builder => builder
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials()
            //    //.WithOrigins("*", "http://localhost")
            //    );

            //});

            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new XmlSerializerInputFormatter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                options.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            })
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddJsonOptions(options =>
               {
                   options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
               });

            //scheduller task

            //services.AddTransient<IScheduledTask, HeurekaApiTask>(); //restore if die
            //services.AddTransient<IScheduledTask, SmartEmailApiTask>(); //restore if die

            //services.AddScheduler((sender, args) =>
            //{
            //    services.AddTransient<IScheduledTask, HeurekaApiTask>();
            //    services.AddTransient<IScheduledTask, SmartEmailApiTask>();
            //    Console.Write(args.Exception.Message);
            //    args.SetObserved();

            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  remove async
        public void Configure(IApplicationBuilder app,IHostingEnvironment env, ILoggerFactory loggerFactory,[FromServices] INodeServices nodeServices)
        {
            //loggerFactory.AddDebug();
            //loggerFactory.AddConsole();



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    //HotModuleReplacement = true

                    //,
                    //HotModuleReplacementEndpoint = "/dist/__webpack_hmr",
                    //HotModuleReplacementServerPort = 50505
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            //app.UseCors("CorsPolicy");
            //app.Use(next => context => { context.Request.EnableRewind(); return next(context); }); //to double task
            //app.UseSmartEmailMiddlewareExtensionApi();
            app.UseMvc();
            
        }
    }
}