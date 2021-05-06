using Insight.Database;
using Libreria.DT.Settings;
using System.Collections.Generic;
namespace Libreria.DM.AccesoDM
{
    public class DMAcceso<T>
    {
        public IList<T> ConsultarList(string sp,object entity,DTSettings settings)
        {
            IList<T> response = Insight.DMInsight.defaultcnn(settings).Query<T>(sp, entity, commandTimeout: int.Parse(settings.Timeout));
            return response;
        }
        public T Operar(string sp,T entity,DTSettings settings)
        {
            T response = Insight.DMInsight.defaultcnn(settings).Insert<T>(sp, entity, commandTimeout: int.Parse(settings.Timeout));
            return response;
        }
        public T Consultar(string sp, object entity, DTSettings settings)
        {

            T response = Insight.DMInsight.defaultcnn(settings).ExecuteScalar<T>(sp, entity);

            return response;
        }
        public T OperarXML(string sp, string entity, DTSettings settings)
        {

            T res = Insight.DMInsight.defaultcnn(settings).ExecuteScalar<T>(sp, new { Xml = entity });
            return res;
        }

    }
}
