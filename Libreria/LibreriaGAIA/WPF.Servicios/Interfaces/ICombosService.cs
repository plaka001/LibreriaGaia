namespace WPF.Servicios.Interfaces
{
    using System.Threading.Tasks;
    using WPF.Modelos.Modelos;

    public interface ICombosService
    {
        Task<string> ConsultarPaises();
        Task<string> ConsultarDepartamentos(DTPais pais);
        Task<string> ConsultarCiudades(DTDepartamento departamento);
        Task<string> GetGeneros();
    }
}
