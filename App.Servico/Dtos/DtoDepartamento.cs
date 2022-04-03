using System;
using App.Servico.Infraestrutura.Dtos;

namespace App.Servico.Dtos
{
    [Serializable]
    public class DtoDepartamento : DtoComCodigoNumerico
    {
        public string Descricao { get; set; }
    }
}
