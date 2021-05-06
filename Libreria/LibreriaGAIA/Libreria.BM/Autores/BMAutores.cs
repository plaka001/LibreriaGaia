//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Capa negocio Autores                   *						   
//-------------------------------------------------------------*
namespace Libreria.BM.Autores
{
    using Libreria.DM.AccesoDM;
    using Libreria.DT.Autores;
    using Libreria.DT.Mensajes;
    using Libreria.DT.Settings;
    using Libreria.Soporte.Helpers;
    using Libreria.Soporte.Recursos;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;

    public class BMAutores : IBMAutores
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly LogHelper logHelper;
        DTSettings settings = new DTSettings();
        public BMAutores(IConfiguration configuration,IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            settings.Timeout = _configuration.GetSection("Timeout").Value;
            settings.ConnectionString = _configuration.GetSection("connectionString").Value;
        }

       
        /// <summary>
        /// consulta autores
        /// </summary>
        /// <returns></returns>
        public DTRespuesta<IList<DTAutorList>> consultarAutores()
        {
            DTRespuesta<IList<DTAutorList>> respuesta = new DTRespuesta<IList<DTAutorList>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTAutorList entity = new DTAutorList();
                IList<DTAutorList> autores = new DMAcceso<DTAutorList>().ConsultarList(Recursos.SPConsultarAutores, entity, settings);
                if (autores.Count >= 1)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje2;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = autores;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje3;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = autores;
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
        /// inserta autores
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public DTRespuesta<string> insertarAutores(DTAutor autor)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTAutor DTAutor = new DMAcceso<DTAutor>().Operar(Recursos.SPInsertarAutores, autor, settings);
                if (DTAutor.IdAutor != null)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje2;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = Convert.ToString(DTAutor.IdAutor);
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

        /// <summary>
        /// elimina autores
        /// </summary>
        /// <param name="IdAutor"></param>
        /// <returns></returns>
        public DTRespuesta<DTAutor> eliminarAutor(DTAutor IdAutor)
        {
            DTRespuesta<DTAutor> respuesta = new DTRespuesta<DTAutor>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTAutor resultado = new DMAcceso<DTAutor>().Operar(Recursos.SPEliminarAutor, IdAutor, settings);
                if (resultado.IdAutor != 0)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje2;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = resultado;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje4;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = resultado;
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
        /// actualiza los autores
        /// </summary>
        /// <param name="IdAutor"></param>
        /// <returns></returns>
        public DTRespuesta<string> actualizarAutor(DTAutor IdAutor)
        {
            DTRespuesta<string> respuesta = new DTRespuesta<string>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTAutor resultado = new DMAcceso<DTAutor>().Operar(Recursos.SPActualizarAutores, IdAutor, settings);
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

        public DTRespuesta<DTAutor> getAutorById(DTAutor autor)
        {
            DTRespuesta<DTAutor> respuesta = new DTRespuesta<DTAutor>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTAutor resultado = new DMAcceso<DTAutor>().Operar(Recursos.SPConsultarAutorById, autor, settings);
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
