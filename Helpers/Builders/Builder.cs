using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using App.Web.Models.Componentes;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace App.Web.Helpers.Builders
{
    public abstract class Builder<TBuilder, TModel> : IHtmlContent
        where TBuilder : class
    {
        protected Builder(IHtmlHelper htmlHelper)
        {            
            HtmlHelper = htmlHelper;
        }
        protected TModel Model { get; set; }

        protected IHtmlHelper HtmlHelper { get; set; }

        public virtual void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var nomeDaView = ObtenhaNomeDaView();

            PrepareModel();

            HtmlHelper.RenderPartialAsync(nomeDaView, Model, null);
        }
        
        protected abstract string ObtenhaNomeDaView();

        protected virtual void PrepareModel()
        {
        }
    }
}
