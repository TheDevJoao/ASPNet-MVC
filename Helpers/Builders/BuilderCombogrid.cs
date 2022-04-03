using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Web.Models;
using App.Web.Models.Componentes;

namespace App.Web.Helpers.Builders
{
    public abstract class BuilderCombogrid<TBuilder> : BuilderInput<TBuilder, ModelCombogrid>
        where TBuilder : class
    {
        protected BuilderCombogrid(IHtmlHelper htmlHelper, string propriedade, bool obrigatorio)
            : base(htmlHelper, propriedade, obrigatorio)
        {            
            Model.QtdDeItensRetornados = 7;
        }

        protected BuilderCombogrid(IHtmlHelper htmlHelper, Expression<Func<object, object>> propriedade, bool obrigatorio)
            : this(htmlHelper, System.Web.Mvc.ExpressionHelper.GetExpressionText(propriedade), obrigatorio)
        {
        }

        public TBuilder Action(string action)
        {
            Model.Action = action;
            return this as TBuilder;
        }

        public TBuilder Controller(string controller)
        {
            Model.Controller = controller;
            return this as TBuilder;
        }

        public TBuilder QuantidadeDeItensRetornados(int qtdDeItensRetornados)
        {
            Model.QtdDeItensRetornados = qtdDeItensRetornados;
            return this as TBuilder;
        }

        protected override void PrepareModel()
        {
            if (Model.Valor == null)
            {
                var modelViewData = HtmlHelper.ViewData.Model;
                Model.Valor = ObtenhaValorDaPropriedade(modelViewData, Model.Propriedade);
            }
        }

        protected override string ObtenhaNomeDaView()
        {
            return "_Combogrid";
        }
    }
}
