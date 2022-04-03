using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Infraestrutura.Conversores
{
    public class ConversorPaginado<TDto, TObjeto>
        where TDto : DtoComCodigoNumerico
        where TObjeto : ObjetoComCodigoNumerico
    {
        private IConversorComCodigoNumerico<TDto, TObjeto> _conversor;

        public ConversorPaginado(IConversorComCodigoNumerico<TDto, TObjeto> conversor)
        {
            _conversor = conversor;
        }

        public DtoPaginado<TDto> ConvertaParaDto(ObjetoPaginado<TObjeto> objetoPaginado)
        {
            if (objetoPaginado == null)
            {
                return null;
            }

            var lista = _conversor.Converta(objetoPaginado.Lista);

            var dtoPaginado = new DtoPaginado<TDto>
            {
                Pagina = objetoPaginado.Pagina,
                Quantidade = objetoPaginado.Quantidade,
                TotalDeItens = objetoPaginado.TotalDeItens,
                Lista = lista
            };

            return dtoPaginado;
        }
    }
}
