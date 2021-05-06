namespace Libreria.DT.Mensajes
{
    public class DTRespuesta<T>
    {
        public T Data{ get; set; }
        public DTMensajes Mensaje { get; set; }
    }
}
