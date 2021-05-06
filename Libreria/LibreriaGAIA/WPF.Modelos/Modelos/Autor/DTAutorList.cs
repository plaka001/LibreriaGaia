using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Modelos.Modelos
{
  public  class DTAutorList
    {
        public int? IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Sexo { get; set; }
        public int CantidadLibros { get; set; }
    }
}
