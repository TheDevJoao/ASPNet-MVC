using App.Servico.Infraestrutura.Mapeamentos;
using App.Servico.Negocio;

namespace App.Servico.Mapeamentos
{
    public class DepartamentoMap : ObjetoComCodigoNumericoMap<Departamento>
    {
        public DepartamentoMap()
        {
            Table("DEPARTAMENTO");

            Map(departamento => departamento.Descricao, "DESCRICAO").Length(100).Not.Nullable();
        }
    }
}
