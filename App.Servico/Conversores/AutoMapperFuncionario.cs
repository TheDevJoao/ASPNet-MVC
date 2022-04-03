using AutoMapper;
using App.Servico.Dtos;
using App.Servico.Infraestrutura.Conversores;
using App.Servico.Infraestrutura.Utilitarios;
using App.Servico.Negocio;

namespace App.Servico.Conversores
{
    public class AutoMapperFuncionario : AutoMapperProfileComCodigoNumerico<DtoFuncionario, Funcionario>
    {
        protected override void IgnorePropriedades(IMappingExpression<DtoFuncionario, Funcionario> map)
        {
            map.IgnorePropriedade(x => x.Departamento);

            base.IgnorePropriedades(map);
        }
    }
}
