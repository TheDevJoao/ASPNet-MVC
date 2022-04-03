using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Infraestrutura.Repositorios
{
    public interface IRepositorio<TObjeto> where TObjeto : ObjetoCompartilhado
    {
        void Cadastre(TObjeto objeto);

        void Atualize(TObjeto objeto);

        void Exclue(TObjeto objeto);

        TObjeto Consulte(Guid id);

        List<TObjeto> Consulte(Expression<Func<TObjeto, bool>> expressao);

        List<TObjeto> Consulte(string filtro, int quantidade, Func<string, Expression<Func<TObjeto, bool>>> obtenhaFiltro);

        List<TObjeto> ConsulteLista();

        bool ExisteRegistro(Guid id);
    }
}
