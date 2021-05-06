namespace WPF.Servicios.Servicios
{
    using System.Threading.Tasks;
    using WPF.AD.Base;
    using WPF.Modelos.Modelos;
    using WPF.Servicios.Interfaces;
    public class LibroService : ILibroService
    {
        private readonly string crearLibro = "api/Libros/insertarLibro";
        private readonly string libros = "api/Libros/consultarLibros";
        private readonly string librosById = "api/Libros/libroById";
        private readonly string actualizarLibro = "api/Libros/actualizarLibro";
        private readonly string eliminarLibro = "api/Libros/eliminarLibro";

        public async Task<string> ActualizarLibro(DTLibro dTLibro)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(actualizarLibro, dTLibro);

            }
        }

        public async Task<string> ConsultarLibros()
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.GETAsync(libros);

            }
        }

        public async Task<string> CrearLibro(DTLibro dTLibro)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(crearLibro, dTLibro);

            }
        }

        public async Task<string> eliminarAutorById(DTLibro dTLibro)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(eliminarLibro, dTLibro);

            }
        }

        public async Task<string> getLibroByiD(DTLibro dTLibro)
        {
            string baseUrl = BaseRestService.GetConnectionStringByName(false);
            using (RestService<string> restService = new RestService<string>(baseUrl))
            {
                return await restService.POSTAsync(librosById, dTLibro);

            }
        }
    }
}
