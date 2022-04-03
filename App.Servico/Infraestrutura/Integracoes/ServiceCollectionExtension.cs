using Microsoft.Extensions.DependencyInjection;
using App.Servico.Conversores;
using App.Servico.Dtos;
using App.Servico.Infraestrutura.Conversores;
using App.Servico.Interfaces.Repositorios;
using App.Servico.Interfaces.Servicos;
using App.Servico.Negocio;
using App.Servico.Repositorios;
using App.Servico.Servicos;
using Microsoft.Extensions.Configuration;

namespace App.Servico.Infraestrutura.Integracoes
{
    public static class ServiceCollectionExtension
    {
        public static IConfiguration Configuration { get; private set; }

        public static void AddIntegracaoServico(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;

            // automappers
            services.AddAutoMapper(typeof(AutoMapperDepartamento));
            services.AddAutoMapper(typeof(AutoMapperFuncionario));

            // servicos
            services.AddSingleton<IServicoDeDepartamento, ServicoDeDepartamento>();
            services.AddSingleton<IServicoDeFuncionario, ServicoDeFuncionario>();

            // conversores
            services.AddSingleton<IConversorComCodigoNumerico<DtoDepartamento, Departamento>, ConversorDepartamento>();
            services.AddSingleton<IConversorComCodigoNumerico<DtoFuncionario, Funcionario>, ConversorFuncionario>();

            // repositorios
            services.AddSingleton<IRepositorioDepartamento, RepositorioDepartamento>();
            services.AddSingleton<IRepositorioFuncionario, RepositorioFuncionario>();
        }
    }
}
