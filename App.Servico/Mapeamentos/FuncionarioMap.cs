using App.Servico.Infraestrutura.Mapeamentos;
using App.Servico.Negocio;

namespace App.Servico.Mapeamentos
{
    public class FuncionarioMap : ObjetoComCodigoNumericoMap<Funcionario>
    {
        public FuncionarioMap()
        {
            Table("FUNCIONARIO");

            Map(funcionario => funcionario.Nome, "NOME").Length(100).Not.Nullable();
            References(funcionario => funcionario.Departamento, "IDDEPARTAMENTO");
        }
    }
}
