namespace App.Web.Models.Componentes
{
    public class ModelTabela : ModelBase
    {
        public string[] Colunas { get; set; }

        public string[] Campos { get; set; }

        public int[] LarguraDasColunas { get; set; }

        public string CampoChave { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public bool HabiliteFiltro { get; set; }

        public bool HabilitePaginacao { get; set; }

        public int Pagina { get; set; }

        public int Quantidade { get; set; }
    }
}
