namespace WPF.Servicios.Servicios
{
    using System.Threading.Tasks;
    using WPF.AD.Base;
    using WPF.Modelos.Modelos;
    using WPF.Servicios.Interfaces;
    public class AutorService : IAutorService
    {
        private readonly string ListaAutores = "api/Autores/consultarAutores";
        private readonly string crearAutor = "api/Autores/insertarAutor";
        private readonly string consultarAutorById = "api/Autores/IdAutor";
        private readonly string actualizarAutor = "api/Autores/actualizarAutor";
        private readonly string eliminarAutorId = "api/Autores/eliminarAutor";

        public async Task<string> ActualizarAutor(DTAutor dTAutor)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(actualizarAutor, dTAutor);

            }
        }

        public async Task<string> consultarAutores()
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.GETAsync(ListaAutores);

            }
        }

        public async Task<string> CrearAutor(DTAutor dTAutor)
        {
            
                string baseUrl = BaseRestService.GetConnectionStringByName(false);
                using (RestService<string> restService = new RestService<string>(baseUrl))
                {
                    return await restService.POSTAsync(crearAutor, dTAutor);

                }
            
        }

        public async Task<string> eliminarAutorById(DTAutor dTAutor)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(eliminarAutorId, dTAutor);

            }
        }

        public async Task<string> getAutorByiD(DTAutor dTAutor)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(consultarAutorById, dTAutor);

            }
        }
    }
}

