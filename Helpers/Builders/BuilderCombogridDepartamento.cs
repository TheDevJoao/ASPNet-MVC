using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Helpers.Builders
{
    public class BuilderCombogridDepartamento : BuilderCombogrid<BuilderCombogridDepartamento>
    {
        public BuilderCombogridDepartamento(IHtmlHelper htmlHelper, string propriedade, bool obrigatorio = false)
            : base(htmlHelper, propriedade, obrigatorio)
        {            
            Model.Action = "ConsultePaginado";
            Model.Controller = "Departamento";
            Model.Colunas = "[{\"name\": \"codigo\", \"label\": \"Código\"}, {\"name\": \"descricao\", \"label\": \"Descrição\"}]";
            Model.CampoChave = "codigo";
            Model.CamposTemplate = new[] { "codigo", "descricao" };
        }

        public BuilderCombogridDepartamento(
            IHtmlHelper htmlHelper, 
            Expression<Func<object, object>> propriedade,
            bool obrigatorio = false)
            : this(htmlHelper, System.Web.Mvc.ExpressionHelper.GetExpressionText(propriedade), obrigatorio)
        {
        }
    }
}
