namespace App.Web.Models
{
    public class Funcionario : ModeloBase
    {
        public string Nome { get; set; }

        public Departamento Departamento { get; set; }
    }
}
