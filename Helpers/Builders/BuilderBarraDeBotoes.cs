using System;
using System.IO;
using System.Text.Encodings.Web;
using App.Web.Models;
using App.Web.Models.Componentes;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Helpers.Builders
{
    public class BuilderBarraDeBotoes : BuilderBase<BuilderBarraDeBotoes, ModelBarraDeBotoes>
    {        
        public BuilderBarraDeBotoes(
            IHtmlHelper htmlHelper,
            string propriedade,
            string idComponenteQueContemFormulario)
            :base(htmlHelper, propriedade)
        {            
            Model.SeletorFormulario = idComponenteQueContemFormulario == null 
                   ? string.Empty
                   : "#" + idComponenteQueContemFormulario + " form";
        }

        protected override string ObtenhaNomeDaView()
        {
            return "_BarraDeBotoes";
        }

        public BuilderBarraDeBotoes TelaInicial(Action<ModelActionLink> configureActionNovo = null)
        {            
            Novo(configureActionNovo);
            return this;
        }
        
        public BuilderBarraDeBotoes TelaEdicao(
            Action<ModelActionLink> configureActionSalvar = null,
            Action<ModelActionLink> configureActionExcluir = null,
            Action<ModelActionLink> configureActionCancelar = null)
        {
            Salvar(configureActionSalvar);
            Excluir(configureActionExcluir);
            Cancelar(configureActionCancelar);

            return this;
        }

        public BuilderBarraDeBotoes Novo(Action<ModelActionLink> configureAction = null)
        {
            Model.HabiliteNovo = true;
            Model.Novo = CrieActionLink("Novo", "Novo", configureAction);

            return this;
        }

        public BuilderBarraDeBotoes Salvar(Action<ModelActionLink> configureAction = null)
        {
            Model.HabiliteSalvar = true;
            Model.Salvar = CrieActionLink("Salvar", "Salvar", configureAction);

            return this;
        }

        public BuilderBarraDeBotoes Excluir(Action<ModelActionLink> configureAction = null)
        {
            Model.HabiliteExcluir = true;
            Model.Excluir = CrieActionLink("Excluir", "Excluir", configureAction);

            return this;
        }

        public BuilderBarraDeBotoes Cancelar(Action<ModelActionLink> configureAction = null)
        {
            Model.HabiliteCancelar = true;
            Model.Cancelar = CrieActionLink("Index", "Cancelar e voltar", configureAction);

            return this;
        }

        private ModelActionLink CrieActionLink(
            string action,
            string texto,
            Action<ModelActionLink> configureAction = null)
        {
            var actionLink = new ModelActionLink
            {
                Action = action,
                Texto = texto
            };

            if (configureAction != null)
            {
                configureAction(actionLink);
            }
            else
            {
                actionLink.ValorChave = 0;
            }

            return actionLink;
        }
    }
}
