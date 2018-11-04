using kfzteile24.CodingTask.BusinessLayer;
using kfzteile24.CodingTask.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NJsonSchema;
using NSwag.AspNetCore;

namespace kfzteile24.CodingTask.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger services
            services.AddSwagger();

            services.TryAddSingleton<ICounterRepository, CounterMemoryRepository>();
            services.TryAddScoped<ICounterService, CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Counter API";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Anton Tkachov",
                        Email = "ant.tkachov@gmail.com"
                    };
                };
            });

            app.UseMvc();
        }
    }
}
