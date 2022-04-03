using System;
using App.Servico.Infraestrutura.Dtos;

namespace App.Servico.Dtos
{
    [Serializable]
    public class DtoFuncionario : DtoComCodigoNumerico
    {
        public string Nome { get; set; }

        public DtoDepartamento Departamento { get; set; }
    }
}
