using GoDeliver.DatabaseData;
using GoDeliver.Entities;
using GoDeliver.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace GoDeliver
{
    public class Startup
    {

        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            var connectionstring = @"Server=DESKTOP-G8LM1VL\SQLEXPRESS;Database=GoDeliveryTester;Trusted_Connection=True";
           // var connectionstring = Startup.Configuration["Server=DESKTOP-G8LM1VL\SQLEXPRESS;Database=GoDeliveryTester;Trusted_Connection=True"];
            services.AddDbContext<GoDeliveryContext>(o => o.UseSqlServer(connectionstring));
           

            services.AddScoped<InfoRepository, DataInfoRepository>();

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
           ILoggerFactory loggerFactory, GoDeliveryContext goDeliveryContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }



            goDeliveryContext.EnsureSeedDataForContext();



            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Customer, Models.CustomerDto>();
            });







        }







    }
}
