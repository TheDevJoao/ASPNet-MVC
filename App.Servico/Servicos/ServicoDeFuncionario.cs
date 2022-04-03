using System;
using System.Linq.Expressions;
using App.Servico.Dtos;
using App.Servico.Infraestrutura.Conversores;
using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Servicos;
using App.Servico.Interfaces.Repositorios;
using App.Servico.Interfaces.Servicos;
using App.Servico.Negocio;

namespace App.Servico.Servicos
{
    public class ServicoDeFuncionario : ServicoComCodigoNumerico<DtoFuncionario, Funcionario>, IServicoDeFuncionario
    {
        public ServicoDeFuncionario(IRepositorioFuncionario repositorio, IConversorComCodigoNumerico<DtoFuncionario, Funcionario> conversor)
            : base(repositorio, conversor)
        {
        }

        public override DtoPaginado<DtoFuncionario> ConsulteParcial(string filtro, int pagina, int quantidade)
        {
            var resultado = ((IRepositorioFuncionario)Repositorio).ConsulteParcial(
                filtro,
                pagina,
                quantidade,
                ObtenhaExpressao);

            var conversorFuncionario = (IConversorComCodigoNumerico<DtoFuncionario, Funcionario>)Conversor;
            var conversorPaginado = new ConversorPaginado<DtoFuncionario, Funcionario>(conversorFuncionario);

            var dtoPaginado = conversorPaginado.ConvertaParaDto(resultado);

            return dtoPaginado;
        }

        public override DtoPaginado<DtoFuncionario> ConsultePaginado(string filtro, int pagina, int quantidade)
        {
            var resultado = ((IRepositorioFuncionario)Repositorio).ConsultePaginada(filtro, pagina, quantidade, ObtenhaExpressao);

            var conversorFuncionario = (IConversorComCodigoNumerico<DtoFuncionario, Funcionario>)Conversor;
            var conversorPaginado = new ConversorPaginado<DtoFuncionario, Funcionario>(conversorFuncionario);

            var dtoPaginado = conversorPaginado.ConvertaParaDto(resultado);

            return dtoPaginado;
        }

        private Expression<Func<Funcionario, bool>> ObtenhaExpressao(string filtro)
        {
            if (int.TryParse(filtro, out int codigo))
            {
                return x => x.Codigo == codigo;
            }

            return x => x.Nome.ToUpperInvariant().StartsWith(filtro);
        }
    }
}
