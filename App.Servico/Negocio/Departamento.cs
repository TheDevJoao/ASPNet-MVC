using System;
using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Negocio
{
    [Serializable]
    public class Departamento : ObjetoComCodigoNumerico
    {
        public virtual string Descricao { get; set; }
    }
}
