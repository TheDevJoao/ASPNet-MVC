using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using Microsoft.Extensions.Configuration;
using App.Servico.Infraestrutura.Integracoes;

namespace App.Servico.Infraestrutura.Persistencias
{
    public class UtilitarioNHibernate
    {
        private static ISession _sessao;
        private static ISessionFactory _sessionFactory;
        
        public static ISession Sessao
        {
            get
            {
                if (_sessao == null)
                {
                    Inicialize();
                }

                if (!_sessao.IsOpen)
                {
                    _sessao = _sessionFactory.OpenSession();
                }

                return _sessao;
            }
        }

        public static void FinalizeSessao()
        {
            if (_sessao != null && _sessao.IsOpen)
            {
                _sessao.Close();
                _sessao.Dispose();
            }

            if (_sessionFactory != null && _sessionFactory.IsClosed == false)
            {
                _sessionFactory.Close();
                _sessionFactory.Dispose();
            }
        }

        private static void Inicialize()
        {
            var configuracoes = Fluently
                .Configure()
                .ExposeConfiguration(Configuracoes)
                .Database(CrieConexaoComBanco())
                .Cache(CrieCache)
                .Mappings(CrieMapeamento);

            _sessionFactory = configuracoes.BuildSessionFactory();

            _sessao = _sessionFactory.OpenSession();
            _sessao.FlushMode = FlushMode.Commit;
        }

        private static void Configuracoes(Configuration configuracoes)
        {
            configuracoes.SetInterceptor(new InterceptadorNHibernate());
        }

        private static IPersistenceConfigurer CrieConexaoComBanco()
        {
            MsSqlConfiguration configuracaoConexao = null;

            try
            {
                var stringDeConexao = ServiceCollectionExtension.Configuration["stringDeConexao"] ?? string.Empty;

                if (string.IsNullOrWhiteSpace(stringDeConexao))
                {
                    throw new ArgumentNullException("Não foi definido a string de conexão.");
                }
                                
                configuracaoConexao = MsSqlConfiguration.MsSql2012.ConnectionString(stringDeConexao);
            }
            catch (System.Configuration.ConfigurationErrorsException)
            {
                Console.WriteLine("Erro ao acessar app settings.");
            }

            return configuracaoConexao;
        }

        private static void CrieCache(CacheSettingsBuilder cache)
        {
            ////cache
            ////    .UseQueryCache()
            ////    .UseSecondLevelCache()
            ////    .ProviderClass<NHibernate.Cache.HashtableCacheProvider>();
        }

        private static void CrieMapeamento(MappingConfiguration mapConfiguration)
        {
            var diretorio = AppDomain.CurrentDomain.BaseDirectory;
            var dllPersistencia = Directory.GetFiles(diretorio, "App.Servico.dll").FirstOrDefault();

            if (dllPersistencia == null)
            {
                throw new NotImplementedException("Não foi encontrado a dll de persistencia.");
            }

            var assemblie = Assembly.LoadFrom(dllPersistencia);
            mapConfiguration.FluentMappings.AddFromAssembly(assemblie);
        }
    }
}
