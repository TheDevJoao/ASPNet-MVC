using System;
using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Negocio
{
    [Serializable]
    public class Funcionario : ObjetoComCodigoNumerico
    {
        public virtual string Nome { get; set; }

        public virtual Departamento Departamento { get; set; }
    }
}
