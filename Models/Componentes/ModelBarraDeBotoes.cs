namespace App.Web.Models.Componentes
{
    public class ModelBarraDeBotoes : ModelBase
    {
        public string SeletorFormulario { get; set; }

        public bool HabiliteNovo { get; set; }

        public bool HabiliteSalvar { get; set; }

        public bool HabiliteExcluir { get; set; }

        public bool HabiliteCancelar { get; set; }

        public ModelActionLink Novo { get; set; }

        public ModelActionLink Salvar { get; set; }

        public ModelActionLink Excluir { get; set; }

        public ModelActionLink Cancelar { get; set; }
    }
}
