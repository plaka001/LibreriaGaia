//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Controlador Autores                    *						   
//-------------------------------------------------------------*
namespace Libreria.Api.Controllers.AutoresController
{
    using Libreria.BM.Autores;
    using Libreria.DT.Autores;
    using Libreria.DT.Mensajes;
    using Libreria.Soporte.Helpers;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;

    [Route("api/Autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private IBMAutores objAutores;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly LogHelper logHelper;
        public AutoresController(IConfiguration configuration,IBMAutores iAutores,IHostingEnvironment hostingEnvironment)
        {
            objAutores = iAutores;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// Inserta los autores a nuestra base de datos  
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insertarAutor")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<string>> insertarAutores(DTAutor autor)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objAutores.insertarAutores(autor);
            }
            catch (Exception ex)
            {
                new LogHelper(rutaLog).EscribirLog(Logtype.error, ex.Message);
                mensaje.Error = true;
                mensaje.Mensaje = Mensajes.Mensaje1;
                respuesta.Mensaje = mensaje;
                respuesta.Data = "";
            }
            return respuesta;
        }
        /// <summary>
        /// Realiza la consulta de autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("consultarAutores")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<IList<DTAutorList>>> consultarAutores()
        {
            DTRespuesta<IList<DTAutorList>> respuesta = new DTRespuesta<IList<DTAutorList>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objAutores.consultarAutores();
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
        /// Elimina al autor según su ID
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("eliminarAutor")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTAutor>> eliminarautores(DTAutor autor)
        {
            DTRespuesta<DTAutor> respuesta = new DTRespuesta<DTAutor>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objAutores.eliminarAutor(autor);
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
        /// Actualiza un autor según su ID
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("actualizarAutor")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<string>> actualizarAutor(DTAutor autor)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objAutores.actualizarAutor(autor);
            }
            catch (Exception ex)
            {
                new LogHelper(rutaLog).EscribirLog(Logtype.error, ex.Message);
                mensaje.Error = true;
                mensaje.Mensaje = Mensajes.Mensaje1;
                respuesta.Mensaje = mensaje;
                respuesta.Data = "";
            }
            return respuesta;
        }

        /// <summary>
        /// Consultar los autores según su ID
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IdAutor")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTAutor>> getAutorById(DTAutor autor)
        {
            DTRespuesta<DTAutor> respuesta = new DTRespuesta<DTAutor>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objAutores.getAutorById(autor);
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
