
namespace WPF.Servicios.Interfaces
{
    using System.Threading.Tasks;
    using WPF.Modelos.Modelos;

    public interface IAutorService
    {
       Task <string> consultarAutores();
        Task<string> CrearAutor(DTAutor dTAutor);
        Task<string> getAutorByiD(DTAutor dTAutor);
        Task<string> ActualizarAutor(DTAutor dTAutor);
        Task<string> eliminarAutorById(DTAutor dTAutor);
    }
}
