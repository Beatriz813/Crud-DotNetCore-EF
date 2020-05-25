using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEF.Models;
using ApiEF.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Validacao();
            CreateHostBuilder(args).Build().Run();
        }

        public static void Validacao () {
            Limpeza produto = new Limpeza();
            var resultado = new LimpezaValidation().Validate(produto);

            if (!resultado.IsValid) {
                foreach(var erro in resultado.Errors) {
                    Console.WriteLine($"Erro: {erro.PropertyName}");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
