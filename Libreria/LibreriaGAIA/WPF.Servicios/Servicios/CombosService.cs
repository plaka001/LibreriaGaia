namespace WPF.Servicios.Servicios
{
    using System.Threading.Tasks;
    using WPF.AD.Base;
    using WPF.Modelos.Modelos;
    using WPF.Servicios.Interfaces;
    public class CombosService : ICombosService
    {
     
        private readonly string paises = "api/Combos/consultarPaises";
        private readonly string  departamentos= "api/Combos/ConsultarDepartamentos";
        private readonly string ciudades = "api/Combos/consultarCiudades";
        private readonly string sexo = "api/Combos/consultarSexo";

        public async Task<string> ConsultarCiudades(DTDepartamento departamento)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(ciudades, departamento);

            }
        }

        public async Task<string> ConsultarDepartamentos(DTPais pais)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(departamentos, pais);

            }
        }

        public async Task<string> ConsultarPaises()
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.GETAsync(paises);

            }
        }

        public async Task<string> GetGeneros()
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.GETAsync(sexo);

            }
        }
    }
}
