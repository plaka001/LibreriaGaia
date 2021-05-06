//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Controlador libros                    *						   
//-------------------------------------------------------------*
namespace Libreria.Api.Controllers.LibrosController
{
    using Libreria.BM.Libros;
    using Libreria.DT.Libros;
    using Libreria.DT.Mensajes;
    using Libreria.Soporte.Helpers;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;

    [Route("api/Libros")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private IBMLibros objLibros;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly LogHelper logHelper;


        public LibrosController(IConfiguration configuration, IBMLibros iLibros, IHostingEnvironment hostingEnvironment)
        {
            objLibros = iLibros;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// Inserta los Libros a nuestra base de datos
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insertarLibro")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<string>> insertarLibros(DTLibro libro)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objLibros.insertarLibro(libro);
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
        /// Realiza la consulta de Libros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("consultarLibros")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<IList<DTListLibros>>> consultarLibros()
        {
            DTRespuesta<IList<DTListLibros>> respuesta = new DTRespuesta<IList<DTListLibros>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objLibros.consultarLibro();
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
        /// Elimina al libro según su ID
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("eliminarLibro")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<string>> eliminarLibros(DTLibro libro)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objLibros.eliminarLibro(libro);
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
        /// Actualiza un libro según su ID
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("actualizarLibro")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<string>> actualizarAutor(DTLibro libro)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objLibros.actualizarLibro(libro);
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

        [HttpPost]
        [Route("libroById")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTLibro>> getLibroByid(DTLibro libro)
        {
            DTRespuesta<DTLibro> respuesta = new DTRespuesta<DTLibro>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\Log\\";
            try
            {

                respuesta = objLibros.getLibroByid(libro);
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
