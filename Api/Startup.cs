using Aplicacao.CalculoJuros;
using Aplicacao.TaxaJuros;
using Aplicacao.UrlGitHub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
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
            ConfigInjecao(services);
            services.AddSingleton(Configuration);
            services.AddHttpClient();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        private void ConfigInjecao(IServiceCollection services)
        {
            services.AddScoped<IAplicTaxaJuro, AplicTaxaJuro>();
            services.AddScoped<IAplicCalculoJuro, AplicCalculoJuro>();
            services.AddScoped<IAplicUrlGitHub, AplicUrlGitHub>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cálculo juros");
            });
        }
    }
}
