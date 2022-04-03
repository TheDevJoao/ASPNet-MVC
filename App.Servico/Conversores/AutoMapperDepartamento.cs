using App.Servico.Dtos;
using App.Servico.Infraestrutura.Conversores;
using App.Servico.Negocio;

namespace App.Servico.Conversores
{
    public class AutoMapperDepartamento : AutoMapperProfileComCodigoNumerico<DtoDepartamento, Departamento>
    {
    }
}
