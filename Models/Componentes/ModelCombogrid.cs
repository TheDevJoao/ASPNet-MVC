using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace App.Web.Models.Componentes
{
    [Serializable]
    public class ModelCombogrid : ModelInput
    {
        private string _identificadorDaPropriedade;

        public int QtdDeItensRetornados { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Colunas { get; set; }

        public string CampoChave { get; set; }

        public string[] CamposTemplate { get; set; }

        public string ItemSelecionado { get; set; }

        public virtual string IdentificadorDaPropriedade
        {
            get
            {
                return !string.IsNullOrEmpty(_identificadorDaPropriedade)
                               ? Regex.Replace(_identificadorDaPropriedade, "[\\[|\\]|\\.]", "_")
                               : Regex.Replace(Propriedade, "[\\[|\\]|\\.]", "_");
            }
            set
            {
                _identificadorDaPropriedade = value;
            }
        }
    }
}
