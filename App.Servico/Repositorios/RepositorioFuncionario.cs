using App.Servico.Infraestrutura.Persistencias;
using App.Servico.Interfaces.Repositorios;
using App.Servico.Negocio;

namespace App.Servico.Repositorios
{
    public class RepositorioFuncionario : RepositorioComCodigoNumerico<Funcionario>, IRepositorioFuncionario
    {
    }
}
