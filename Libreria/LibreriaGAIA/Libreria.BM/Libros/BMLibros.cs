//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Negocio Libros                         *						   
//-------------------------------------------------------------*
namespace Libreria.BM.Libros
{
    using Libreria.DM.AccesoDM;
    using Libreria.DT.Libros;
    using Libreria.DT.Mensajes;
    using Libreria.DT.Settings;
    using Libreria.Soporte.Helpers;
    using Libreria.Soporte.Recursos;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;

    public class BMLibros : IBMLibros
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly LogHelper logHelper;
        DTSettings settings = new DTSettings();
        public BMLibros(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            settings.Timeout = _configuration.GetSection("Timeout").Value;
            settings.ConnectionString = _configuration.GetSection("connectionString").Value;
        }

        /// <summary>
        /// actualiza los libros
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public DTRespuesta<string> actualizarLibro(DTLibro libro)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTLibro resultado = new DMAcceso<DTLibro>().Operar(Recursos.SPActualizarLibros, libro, settings);
                mensaje.Error = false;
                mensaje.Mensaje = Mensajes.Mensaje2;
                respuesta.Mensaje = mensaje;
                respuesta.Data = Convert.ToString(resultado.IdAutor);

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
        /// Consulta los libros
        /// </summary>
        /// <returns></returns>
        public DTRespuesta<IList<DTListLibros>> consultarLibro()
        {
            DTRespuesta<IList<DTListLibros>> respuesta = new DTRespuesta<IList<DTListLibros>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTListLibros entity = new DTListLibros();
                IList<DTListLibros> libros = new DMAcceso<DTListLibros>().ConsultarList(Recursos.SPConsultarLibros, entity, settings);
                if (libros.Count >= 1)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje2;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = libros;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje3;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = libros;
                }
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
        /// Elimina los libros
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public DTRespuesta<string> eliminarLibro(DTLibro libro)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTLibro resultado = new DMAcceso<DTLibro>().Operar(Recursos.SPEliminarLibro, libro, settings);
                if (resultado.IdLibro != 0)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje2;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = respuesta.Data;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje4;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = "";
                }
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
        /// Inserta los libros
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public DTRespuesta<string> insertarLibro(DTLibro libro)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTLibro dtLibros = new DMAcceso<DTLibro>().Operar(Recursos.SPInsertarLibros, libro, settings);
                if (dtLibros.IdLibro != null)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje2;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = Convert.ToString(dtLibros.IdAutor);
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje3;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = null;
                }
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

        DTRespuesta<DTLibro> IBMLibros.getLibroByid(DTLibro libro)
        {
            DTRespuesta<DTLibro> respuesta = new DTRespuesta<DTLibro>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTLibro resultado = new DMAcceso<DTLibro>().Operar(Recursos.SPConsultarLibroById, libro, settings);
                mensaje.Error = false;
                mensaje.Mensaje = Mensajes.Mensaje2;
                respuesta.Mensaje = mensaje;
                respuesta.Data = resultado;

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
