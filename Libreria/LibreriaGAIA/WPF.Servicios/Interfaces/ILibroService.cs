namespace WPF.Servicios.Interfaces
{
    using System.Threading.Tasks;
    using WPF.Modelos.Modelos;

    public interface ILibroService
    {
        Task<string> CrearLibro(DTLibro dTLibro);
        Task<string> ConsultarLibros();
        Task<string> getLibroByiD(DTLibro dTLibro);
        Task<string> ActualizarLibro(DTLibro dTLibro);
        Task<string> eliminarAutorById(DTLibro dTLibro);
    }
}
