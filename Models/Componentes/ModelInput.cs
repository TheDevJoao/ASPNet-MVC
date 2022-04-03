namespace App.Web.Models.Componentes
{
    public class ModelInput : ModelObrigatorio
    {
        public int Tamanho { get; set; }

        public bool Autofocus { get; set; }

        public object Valor { get; set; }

        public string Placeholder { get; set; }

        public bool Habilite { get; set; }
    }
}
