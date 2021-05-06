
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPF.AD.Base
{
    public class RestService<T> : BaseRestService
    {
        #region Constructor
        public RestService(string baseUrl)
            : base(baseUrl)
        {
        }
        public RestService(string baseUrl, string token)
           : base(baseUrl, token)
        {
        }
        #endregion

        #region Private Methods
        public virtual async Task<string> GETAsync(string url)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            string result;

            response = await Client.GetAsync(url);
            result = await CastResponseAsync<string>(response);
            return result;

        }

        public virtual async Task<string> POSTAsync(string url, object postData)
        {
            string result;

            //Organizamos la petición
            object dataToParse = postData ?? string.Empty;
            string jsonString = JsonConvert.SerializeObject(dataToParse);
            StringContent postDataContent = new StringContent(jsonString, Encoding.UTF8, Resources.StringMediaType);

            //Realizamos la petición
            HttpResponseMessage response = new HttpResponseMessage();

           
                response = await Client.PostAsync(url, postDataContent);
                result = await CastResponseAsync<string>(response);
            return result;
        }

       
        #endregion
    }
}
