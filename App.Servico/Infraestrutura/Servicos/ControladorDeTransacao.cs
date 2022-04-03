using System;
using System.Data;
using App.Servico.Infraestrutura.Persistencias;

namespace App.Servico.Infraestrutura.Servicos
{
    public class ControladorDeTransacao : IInterceptadorDeChamada
    {
        public void Execute(Action escopo)
        {
            using (var transacao = UtilitarioNHibernate.Sessao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                UtilitarioNHibernate.Sessao.Clear();
                escopo();
                transacao.Commit();
            }
        }
    }
}
