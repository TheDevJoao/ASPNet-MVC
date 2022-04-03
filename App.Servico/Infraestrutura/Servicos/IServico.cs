using System.Collections.Generic;
using App.Servico.Infraestrutura.Dtos;

namespace App.Servico.Infraestrutura.Servicos
{
    public interface IServico<TDto> where TDto : DtoPadrao
    {
        void Cadastre(TDto dto);

        void Atualize(TDto dto);

        List<TDto> Consulte(string filtro, int quantidade);

        List<TDto> ConsulteLista();
    }
}
