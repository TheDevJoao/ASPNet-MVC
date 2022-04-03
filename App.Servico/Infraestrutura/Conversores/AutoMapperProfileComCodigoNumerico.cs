using AutoMapper;
using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Objetos;
using App.Servico.Infraestrutura.Utilitarios;

namespace App.Servico.Infraestrutura.Conversores
{
    public abstract class AutoMapperProfileComCodigoNumerico<TDto, TObjeto> : AutoMapperProfileCompartilhado<TDto, TObjeto>
        where TDto : DtoComCodigoNumerico
        where TObjeto : ObjetoComCodigoNumerico
    {
        protected override void IgnorePropriedades(IMappingExpression<TDto, TObjeto> map)
        {
            map.IgnorePropriedade(x => x.Codigo);
        }
    }
}
