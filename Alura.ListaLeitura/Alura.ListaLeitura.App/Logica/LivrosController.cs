using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class LivrosController
    {
        public static Task Detalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }

        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("ParaLer");

            foreach (var item in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM", $"<li>{item.Titulo} - {item.Autor}</li>#NOVO-ITEM");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", "");
            return context.Response.WriteAsync(conteudoArquivo);

        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("Lendo");

            foreach (var item in _repo.Lendo.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM", $"<li>{item.Titulo} - {item.Autor}</li>#NOVO-ITEM");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", "");
            return context.Response.WriteAsync(conteudoArquivo);

        }

        public static Task Lido(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("Lido");

            foreach (var item in _repo.Lidos.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM", $"<li>{item.Titulo} - {item.Autor}</li>#NOVO-ITEM");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", "");
            return context.Response.WriteAsync(conteudoArquivo);

        }

        
    }
}
