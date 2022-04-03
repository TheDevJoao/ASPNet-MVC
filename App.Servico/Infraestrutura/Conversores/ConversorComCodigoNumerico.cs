using AutoMapper;
using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Objetos;
using App.Servico.Infraestrutura.Repositorios;

namespace App.Servico.Infraestrutura.Conversores
{
    public abstract class ConversorComCodigoNumerico<TDto, TObjeto> : Conversor<TDto, TObjeto>, IConversorComCodigoNumerico<TDto, TObjeto>
        where TDto : DtoComCodigoNumerico
        where TObjeto : ObjetoComCodigoNumerico
    {
        private IRepositorioComCodigoNumerico<TObjeto> _repositorio;

        public ConversorComCodigoNumerico(IRepositorioComCodigoNumerico<TObjeto> repositorio, IMapper mapper)
            : base(mapper)
        {
            _repositorio = repositorio;
        }

        protected override TObjeto ObtenhaObjetoPersistido(TDto dto)
        {
            var objeto = _repositorio.Consulte(dto.Codigo);
            return objeto;
        }
    }
}
