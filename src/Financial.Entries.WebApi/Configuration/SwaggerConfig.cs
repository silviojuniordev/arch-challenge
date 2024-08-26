using Microsoft.OpenApi.Models;

namespace Financial.Entries.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Architecture Challenge",
                    Description = "Esta API compoe o Desafio para o Banco Carrefour",
                    Contact = new OpenApiContact() { Name = "Silvio Stepheson", Email = "silviojuniordev@gmail.com" }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app) 
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
