namespace Libreria.DT.Libros
{
    using System;
    public class DTLibro
    {
        public int? IdLibro { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEscritura { get; set; }
        public decimal Costo { get; set; }
        public int IdAutor { get; set; }
    }
}
