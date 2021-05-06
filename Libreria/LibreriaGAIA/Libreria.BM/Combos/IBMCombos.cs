//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Interfaz Combos                        *						   
//-------------------------------------------------------------*
namespace Libreria.BM.Combos
{
    using Libreria.DT.Combos;
    using Libreria.DT.Mensajes;
    using System.Collections.Generic;

    public interface IBMCombos
    {
        DTRespuesta<IList<DTPais>> consultarPais();
        DTRespuesta<IList<DTDepartamento>> consultarDepartamento(DTPais pais);
        DTRespuesta<IList<DTCiudad>> consultarCiudad(DTDepartamento departamento);
        DTRespuesta<IList<DTSexo>> consultarSexo();
    }
}
