using System.Diagnostics;
using NHibernate;
using NHibernate.SqlCommand;

namespace App.Servico.Infraestrutura.Persistencias
{
    public class InterceptadorNHibernate : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
#if DEBUG
            Trace.WriteLine(sql.ToString());
            return sql;
#endif
        }
    }
}
