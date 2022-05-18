using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {
            //Registro do contexto: ApplicationDbContext
            //Definição do provedor do banco de dados: UseSqlServer
            //Definição do nome da cadeia de caracteres da conexão: DefaultConnection
            //Definição da pasta onde os arquivos das migração irão ficar: mesma pasta do projeto
            //Infra.Data onde o contexto ApplicationDbContext está .
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Registro os serviços dos repositórios
            //A recomendação para aplicações web é AddScoped
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            //services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}
