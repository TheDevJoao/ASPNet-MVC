using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ServicoDeDepartamento : ServicoComCodigoNumerico<DtoDepartamento, Departamento>, IServicoDeDepartamento
    {
        public ServicoDeDepartamento(IRepositorioDepartamento repositorio, IConversorComCodigoNumerico<DtoDepartamento, Departamento> conversor)
            : base(repositorio, conversor)
        {
        }

        public override DtoPaginado<DtoDepartamento> ConsulteParcial(string filtro, int pagina, int quantidade)
        {
            var resultado = ((IRepositorioDepartamento)Repositorio).ConsulteParcial(
                filtro,
                pagina,
                quantidade,
                ObtenhaExpressao);

            var conversorDepartamento = (IConversorComCodigoNumerico<DtoDepartamento, Departamento>)Conversor;
            var conversorPaginado = new ConversorPaginado<DtoDepartamento, Departamento>(conversorDepartamento);

            var dtoPaginado = conversorPaginado.ConvertaParaDto(resultado);

            return dtoPaginado;
        }

        public override DtoPaginado<DtoDepartamento> ConsultePaginado(string filtro, int pagina, int quantidade)
        {
            var resultado = ((IRepositorioDepartamento)Repositorio).ConsultePaginada(filtro, pagina, quantidade, ObtenhaExpressao);

            var conversorFuncionario = (IConversorComCodigoNumerico<DtoDepartamento, Departamento>)Conversor;
            var conversorPaginado = new ConversorPaginado<DtoDepartamento, Departamento>(conversorFuncionario);

            var dtoPaginado = conversorPaginado.ConvertaParaDto(resultado);

            return dtoPaginado;
        }

        public override List<DtoDepartamento> Consulte(string filtro, int quantidade)
        {
            var listaObjeto = Repositorio.Consulte(filtro, quantidade, ObtenhaExpressao);
            var listaDto = Conversor.Converta(listaObjeto);

            return listaDto.OrderBy(x => x.Codigo).ToList();
        }

        private Expression<Func<Departamento, bool>> ObtenhaExpressao(string filtro)
        {
            if (int.TryParse(filtro, out int codigo))
            {
                return x => x.Codigo == codigo;
            }

            return x => x.Descricao.ToUpperInvariant().StartsWith(filtro);
        }
    }
}
