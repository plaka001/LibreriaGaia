//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Interfaz Libros                         *						   
//-------------------------------------------------------------*


namespace Libreria.BM.Libros
{

    using Libreria.DT.Libros;
    using Libreria.DT.Mensajes;
    using System.Collections.Generic;
    public interface IBMLibros
    {
        DTRespuesta<string> insertarLibro(DTLibro libro);
        DTRespuesta<IList<DTListLibros>> consultarLibro();
        DTRespuesta<string> eliminarLibro(DTLibro libro);
        DTRespuesta<string> actualizarLibro(DTLibro libro);
        DTRespuesta<DTLibro> getLibroByid(DTLibro libro);
    }
}
