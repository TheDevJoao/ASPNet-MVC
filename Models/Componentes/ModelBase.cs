using System.Collections.Generic;

namespace App.Web.Models.Componentes
{
    public class ModelBase
    {
        public string Propriedade { get; set; }

        public IDictionary<string, object> HtmlAttributes { get; set; }
    }
}
