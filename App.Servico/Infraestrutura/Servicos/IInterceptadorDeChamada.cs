using System;

namespace App.Servico.Infraestrutura.Servicos
{
    public interface IInterceptadorDeChamada
    {
        void Execute(Action escopo);
    }
}
