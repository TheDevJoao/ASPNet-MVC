using System.ComponentModel;

namespace App.Web.Models
{
    public class Movimentacao
    {
        [DisplayName("Data da Ocorrência")]
        public object DataDaOcorrencia { get; set; }

        [DisplayName("Funcionário")]
        public Funcionario Funcionario { get; set; }

        [DisplayName("Departamento atual")]
        public Departamento DepartamentoAtual { get; set; }

        [DisplayName("Departamento Destino")]
        public Departamento DepartamentoDestino { get; set; }
    }
}
