using AutoMapper;
using App.Servico.Dtos;
using App.Servico.Infraestrutura.Conversores;
using App.Servico.Interfaces.Repositorios;
using App.Servico.Negocio;

namespace App.Servico.Conversores
{
    public class ConversorDepartamento : ConversorComCodigoNumerico<DtoDepartamento, Departamento>
    {
        public ConversorDepartamento(IRepositorioDepartamento repositorio, IMapper mapper)
            : base(repositorio, mapper)
        {
        }
    }
}
