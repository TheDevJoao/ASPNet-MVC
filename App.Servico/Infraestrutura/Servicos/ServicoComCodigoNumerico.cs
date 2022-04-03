using System;
using App.Servico.Infraestrutura.Conversores;
using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Objetos;
using App.Servico.Infraestrutura.Repositorios;

namespace App.Servico.Infraestrutura.Servicos
{
    public abstract class ServicoComCodigoNumerico<TDto, TObjeto> : Servico<TDto, TObjeto>, IServicoComCodigoNumerico<TDto>
        where TDto : DtoComCodigoNumerico
        where TObjeto : ObjetoComCodigoNumerico
    {
        public ServicoComCodigoNumerico(IRepositorioComCodigoNumerico<TObjeto> repositorio, IConversorComCodigoNumerico<TDto, TObjeto> conversor)
            : base(repositorio, conversor)
        {
        }

        public TDto Consulte(int codigo)
        {
            var objeto = RepositorioComCodigoNumerico().Consulte(codigo);
            var dto = ConversorComCodigoNumerico().Converta(objeto);

            return dto;
        }

        public void Exclue(int codigo)
        {
            ExecuteServico(
                () =>
                {
                    var objeto = RepositorioComCodigoNumerico().Consulte(codigo);
                    ValideExclusao(objeto);
                    RepositorioComCodigoNumerico().Exclue(objeto);
                });
        }

        public virtual DtoPaginado<TDto> ConsulteParcial(string filtro, int pagina, int quantidade)
        {
            throw new NotImplementedException("Consulte parcial nao implementado.");
        }

        public virtual DtoPaginado<TDto> ConsultePaginado(string filtro, int pagina, int quantidade)
        {
            throw new NotImplementedException("Consulte paginada nao implementado.");
        }

        protected IRepositorioComCodigoNumerico<TObjeto> RepositorioComCodigoNumerico()
        {
            return (IRepositorioComCodigoNumerico<TObjeto>)Repositorio;
        }
        protected IConversorComCodigoNumerico<TDto, TObjeto> ConversorComCodigoNumerico()
        {
            return (IConversorComCodigoNumerico<TDto, TObjeto>)Conversor;
        }
    }
}
