using FluentNHibernate.Mapping;
using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Infraestrutura.Mapeamentos
{
    public abstract class ObjetoCompartilhadoMap<TObjeto> : ClassMap<TObjeto> where TObjeto : ObjetoCompartilhado
    {
        protected ObjetoCompartilhadoMap()
        {
            Id(objeto => objeto.Id, "ID").GeneratedBy.Guid();
        }
    }
}
