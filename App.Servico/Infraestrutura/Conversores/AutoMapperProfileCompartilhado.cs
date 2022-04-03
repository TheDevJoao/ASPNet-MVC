using AutoMapper;
using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Objetos;
using App.Servico.Infraestrutura.Utilitarios;

namespace App.Servico.Infraestrutura.Conversores
{
    public abstract class AutoMapperProfileCompartilhado<TDto, TObjeto> : Profile
        where TDto : DtoPadrao
        where TObjeto : ObjetoCompartilhado
    {
        protected AutoMapperProfileCompartilhado()
        {
            var map = CreateMap<TDto, TObjeto>()
                .IgnorePropriedade(x => x.Id)
                .IgnoreTodasPropriedadesNaoExistente();

            IgnorePropriedades(map);

            map.ReverseMap();
        }

        protected virtual void IgnorePropriedades(IMappingExpression<TDto, TObjeto> map)
        {
        }
    }
}
