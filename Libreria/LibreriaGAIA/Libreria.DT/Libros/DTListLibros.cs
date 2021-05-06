using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DT.Libros
{
   public class DTListLibros
    {
        public int? IdLibro { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEscritura { get; set; }
        public decimal Costo { get; set; }
        public string NombreAutor { get; set; }
    }
}
