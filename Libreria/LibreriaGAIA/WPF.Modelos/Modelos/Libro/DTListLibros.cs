namespace WPF.Modelos.Modelos
{
    using System;
    public class DTListLibros
    {
        public int? IdLibro { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEscritura { get; set; }
        public decimal Costo { get; set; }
        public string NombreAutor { get; set; }
    }
}
