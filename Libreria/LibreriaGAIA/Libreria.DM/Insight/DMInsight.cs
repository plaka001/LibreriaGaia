using Insight.Database;
using Libreria.DT.Settings;
using Ninject;
using System.Data.SqlClient;

namespace Libreria.DM.Insight
{
     class DMInsight
    {
        [Inject]
        public static SqlConnection defaultcnn(DTSettings settings)
        {
            SqlInsightDbProvider.RegisterProvider();
            return new SqlConnection(settings.ConnectionString);
        }
    }
}
