using System;

namespace App.Servico.Infraestrutura.Dtos
{
    [Serializable]
    public abstract class DtoComCodigoNumerico : DtoPadrao
    {
        public int Codigo { get; set; }
    }
}
