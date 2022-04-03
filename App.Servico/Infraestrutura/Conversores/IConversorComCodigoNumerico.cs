using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Infraestrutura.Conversores
{
    public interface IConversorComCodigoNumerico<TDto, TObjeto> : IConversor<TDto, TObjeto>
        where TDto : DtoComCodigoNumerico
        where TObjeto : ObjetoComCodigoNumerico
    {
    }
}
