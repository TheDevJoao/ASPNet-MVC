using System.Collections.Generic;
using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Infraestrutura.Conversores
{
    public interface IConversor<TDto, TObjeto>
        where TDto : DtoPadrao
        where TObjeto : ObjetoCompartilhado
    {
        TDto Converta(TObjeto objeto);

        TObjeto Converta(TDto dto);

        TObjeto ConvertaParaObjetoPersistido(TDto dto);

        List<TDto> Converta(List<TObjeto> listaDeObjeto);

        List<TObjeto> Converta(List<TDto> listaDeDto);
    }
}
