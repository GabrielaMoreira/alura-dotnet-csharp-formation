using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            //app.UseMvcWithDefaultRoute();

            var builder = new RouteBuilder(app);
                                        
            builder.MapRoute("Livros/ParaLer", LivrosController.ParaLer);
            builder.MapRoute("Livros/Lendo", LivrosController.Lendo);
            builder.MapRoute("Livros/Lido", LivrosController.Lido);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroController.NovoLivroArgumento);
            builder.MapRoute("Livros/Detalhes/{id:int}", LivrosController.Detalhes);
            builder.MapRoute("Cadastro/NovoLivro", CadastroController.NovoLivro);
            builder.MapRoute("Cadastro/Incluir", CadastroController.Incluir);
            var rotas = builder.Build();

            app.UseRouter(rotas);


            //app.Run(Roteamento);
        }

        

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddRouting();
            services.AddMvc();
        }

        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                {"/Livros/ParaLer", LivrosController.ParaLer },
                { "/Livros/Lendo", LivrosController.Lendo },
                { "/Livros/Lidos", LivrosController.Lido }
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho não existe");
        }

        
    }
}