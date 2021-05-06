//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Interfaz Autores                       *						   
//-------------------------------------------------------------*
namespace Libreria.BM.Autores
{
    using Libreria.DT.Autores;
    using Libreria.DT.Mensajes;
    using System.Collections.Generic;

    public interface IBMAutores
    {
        DTRespuesta<string> insertarAutores(DTAutor autor);
        DTRespuesta<IList<DTAutorList>> consultarAutores();
        DTRespuesta<DTAutor> eliminarAutor(DTAutor autor);
        DTRespuesta<string> actualizarAutor(DTAutor autor);
        DTRespuesta<DTAutor> getAutorById(DTAutor autor);
    }
}
