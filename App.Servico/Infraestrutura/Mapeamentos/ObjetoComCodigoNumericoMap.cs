using App.Servico.Infraestrutura.Objetos;

namespace App.Servico.Infraestrutura.Mapeamentos
{
    public abstract class ObjetoComCodigoNumericoMap<TObjeto> : ObjetoCompartilhadoMap<TObjeto> where TObjeto : ObjetoComCodigoNumerico
    {
        protected ObjetoComCodigoNumericoMap()
        {
            Map(objeto => objeto.Codigo, "CODIGO");
        }
    }
}
