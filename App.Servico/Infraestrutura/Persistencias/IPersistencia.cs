using System;
using System.Linq;
using NHibernate;
using App.Servico.Infraestrutura.Objetos;
using App.Servico.Infraestrutura.Repositorios;

namespace App.Servico.Infraestrutura.Persistencias
{
    public interface IPersistencia<TObjeto> : IQueryable<TObjeto>, IDisposable, IRepositorio<TObjeto> where TObjeto : ObjetoCompartilhado
    {
        ISQLQuery CreateSQLQuery(string sql);
    }
}
