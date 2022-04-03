using AutoMapper;
using App.Servico.Dtos;
using App.Servico.Infraestrutura.Conversores;
using App.Servico.Interfaces.Repositorios;
using App.Servico.Negocio;

namespace App.Servico.Conversores
{
    public class ConversorFuncionario : ConversorComCodigoNumerico<DtoFuncionario, Funcionario>
    {
        private IRepositorioDepartamento _repositorioDepartamento;

        public ConversorFuncionario(IRepositorioFuncionario repositorio, IMapper mapper, IRepositorioDepartamento repositorioDepartamento)
            : base(repositorio, mapper)
        {
            _repositorioDepartamento = repositorioDepartamento;
        }

        public ConversorFuncionario(IRepositorioFuncionario repositorio, IMapper mapper)
            : base(repositorio, mapper)
        {
        }

        protected override void AcaoAposConverterDeDtoParaObjeto(DtoFuncionario dto, Funcionario objeto)
        {
            ConvertaDadosComuns(dto, objeto);
        }

        protected override void AcaoAposConverterDeDtoParaObjetoPersistido(DtoFuncionario dto, Funcionario objeto)
        {
            ConvertaDadosComuns(dto, objeto);
        }

        private void ConvertaDadosComuns(DtoFuncionario dto, Funcionario objeto)
        {
            if (dto.Departamento != null)
            {
                var departamento = _repositorioDepartamento.Consulte(dto.Departamento.Codigo)
                    ?? new Departamento { Codigo = dto.Departamento.Codigo };

                objeto.Departamento = departamento;
            }
        }
    }
}
