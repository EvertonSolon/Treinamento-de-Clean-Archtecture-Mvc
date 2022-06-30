using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Accounts;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

            //Configuração do Identity padrão para usuários e roles e adiciona os serviços
            //para gerenciar usuários.
            services.AddIdentity<ApplicationUser, IdentityRole>()

                //Implementação do EF Core do Identity para realizar a persistência no SQL Server
                // dos usuários e roles.
                .AddEntityFrameworkStores<ApplicationDbContext>()

                //Adiciona os provedores de token padrão usados para gerar tokens para redefinição
                //de senhas, alteração de e-mail e alteração de número de telefone, e para a geração
                //de token de autenticação de dois fatores.
                .AddDefaultTokenProviders();

            //Configuração dos cookies da aplicação 
            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = "/Account/Login"); //Controller Account, Action Login


            //Registro os serviços dos repositórios
            //A recomendação para aplicações web é AddScoped
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
