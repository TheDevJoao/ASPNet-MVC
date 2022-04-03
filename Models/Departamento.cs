using System.ComponentModel;

namespace App.Web.Models
{
    public class Departamento : ModeloBase
    {
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
