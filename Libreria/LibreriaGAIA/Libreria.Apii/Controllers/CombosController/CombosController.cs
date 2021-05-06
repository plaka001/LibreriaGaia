//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Controlador Combos                    *						   
//-------------------------------------------------------------*
namespace Libreria.Api.Controllers.CombosController
{
    using Libreria.BM.Combos;
    using Libreria.DT.Combos;
    using Libreria.DT.Mensajes;
    using Libreria.Soporte.Helpers;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;

    [Route("api/Combos")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private IBMCombos objCombos;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly LogHelper logHelper;
        public CombosController(IConfiguration configuration, IBMCombos iCombos, IHostingEnvironment hostingEnvironment)
        {
            objCombos = iCombos;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// Consultar los países disponibles 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("consultarPaises")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<IList<DTPais>>> consultarPaises()
        {
            DTRespuesta<IList<DTPais>> respuesta = new DTRespuesta<IList<DTPais>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objCombos.consultarPais();
            }
            catch (Exception ex)
            {
                new LogHelper(rutaLog).EscribirLog(Logtype.error, ex.Message);
                mensaje.Error = true;
                mensaje.Mensaje = Mensajes.Mensaje1;
                respuesta.Mensaje = mensaje;
                respuesta.Data = null;
            }
            return respuesta;
        }
        /// <summary>
        /// Consultar los departamentos disponibles según su país
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("consultarDepartamentos")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<IList<DTDepartamento>>> consultarDepartamentos(DTPais pais)
        {
            DTRespuesta<IList<DTDepartamento>> respuesta = new DTRespuesta<IList<DTDepartamento>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objCombos.consultarDepartamento(pais);
            }
            catch (Exception ex)
            {
                new LogHelper(rutaLog).EscribirLog(Logtype.error, ex.Message);
                mensaje.Error = true;
                mensaje.Mensaje = Mensajes.Mensaje1;
                respuesta.Mensaje = mensaje;
                respuesta.Data = null;
            }
            return respuesta;
        }
        /// <summary>
        /// Consultar las ciudades según su departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("consultarCiudades")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<IList<DTCiudad>>> consultarCiudades(DTDepartamento departamento)
        {
            DTRespuesta<IList<DTCiudad>> respuesta = new DTRespuesta<IList<DTCiudad>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objCombos.consultarCiudad(departamento);
            }
            catch (Exception ex)
            {
                new LogHelper(rutaLog).EscribirLog(Logtype.error, ex.Message);
                mensaje.Error = true;
                mensaje.Mensaje = Mensajes.Mensaje1;
                respuesta.Mensaje = mensaje;
                respuesta.Data = null;
            }
            return respuesta;
        }
        /// <summary>
        /// Consultar los sexos disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("consultarSexo")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<IList<DTSexo>>> consultarSexo()
        {
            DTRespuesta<IList<DTSexo>> respuesta = new DTRespuesta<IList<DTSexo>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objCombos.consultarSexo();
            }
            catch (Exception ex)
            {
                new LogHelper(rutaLog).EscribirLog(Logtype.error, ex.Message);
                mensaje.Error = true;
                mensaje.Mensaje = Mensajes.Mensaje1;
                respuesta.Mensaje = mensaje;
                respuesta.Data = null;
            }
            return respuesta;
        }
    }
}
