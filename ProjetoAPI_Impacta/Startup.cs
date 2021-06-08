using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProjetoAPI_Impacta.Configuration;
using ProjetoAPI_Impacta.Interfaces;
using ProjetoAPI_Impacta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta
{

    public class Startup // A Classe Startup � a principal classe de configura��o do projeto
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<TarefaSettingsMongo>(Configuration.GetSection(nameof(TarefaSettingsMongo)));

            services.AddSingleton<ITarefaSettingsMongo>(sp => sp.GetRequiredService<IOptions<TarefaSettingsMongo>>().Value);

            services.AddSingleton<IUsuarioSettingsMongo>(sp => sp.GetRequiredService<IOptions<UsuarioSettingsMongo>>().Value);

            services.Configure<UsuarioSettingsMongo>(Configuration.GetSection(nameof(UsuarioSettingsMongo)));

            services.AddSingleton<TarefaRepository>();
            services.AddSingleton<UsuarioRepository>();

            //Configura��o da documenta��o da API (Swagger)
            services.AddSwaggerGen(
                    swagger =>
                    {
                        swagger.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "ProjetoAPI_Impacta",
                            Description = "API REST desenvolvida em .NET CORE com MongoDB",
                            Version = "v1",
                            Contact = new OpenApiContact
                            {
                                Name = "Criado por Nat�lia Sousa",
                                Url = new Uri("https://github.com/NatySousa")
                                
                            }
                        });
                    });

            //Configura��o do CORS- Cross Origin Resource Sharing (Permite que outros projetos possam acessar a API)
            services.AddCors(
              s => s.AddPolicy("DefaultPolicy", builder =>
              {
                  //permitindo que qualquer servidor fa�a requisi��es para a API
                  builder.AllowAnyOrigin()
                   //permitindo que qualquer m�todo da API seja executado (POST, PUT, DELETE, GET etc)
                   .AllowAnyMethod()
                   //permitindo que qualquer cabe�alho seja enviado para a API (Token por exemplo)
                   .AllowAnyHeader();
              }));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configura��o da documenta��o do Swagger
            app.UseSwagger();

            app.UseSwaggerUI(swagger => { swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI_Impacta"); });

            app.UseRouting();

            //Configura��o do CORS - Cross Origin Resource Sharing(Permite que outros projetos possam acessar a API)
            app.UseCors("DefaultPolicy");

            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


