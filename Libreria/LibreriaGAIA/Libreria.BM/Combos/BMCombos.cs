//-------------------------------------------------------------*
//--** AUTOR:           John Marlon Cano Castrillon            *
//--** Descripcion:     Negocio Combos                         *						   
//-------------------------------------------------------------*
namespace Libreria.BM.Combos
{
    using Libreria.DM.AccesoDM;
    using Libreria.DT.Combos;
    using Libreria.DT.Mensajes;
    using Libreria.DT.Settings;
    using Libreria.Soporte.Helpers;
    using Libreria.Soporte.Recursos;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    public class BMCombos : IBMCombos
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly LogHelper logHelper;
        DTSettings settings = new DTSettings();
        public BMCombos(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            settings.Timeout = _configuration.GetSection("Timeout").Value;
            settings.ConnectionString = _configuration.GetSection("connectionString").Value;
        }

        /// <summary>
        /// Consulta los departamentos segun el id de la ciudad
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        public DTRespuesta<IList<DTDepartamento>> consultarDepartamento(DTPais pais)
        {
            {
                DTRespuesta<IList<DTDepartamento>> respuesta = new DTRespuesta<IList<DTDepartamento>>();
                DTMensajes mensaje = new DTMensajes();
                string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
                try
                {

                    IList<DTDepartamento> paises = new DMAcceso<DTDepartamento>().ConsultarList(Recursos.SPConsultarDepartamento, pais, settings);
                    if (paises.Count >= 1)
                    {
                        mensaje.Error = false;
                        mensaje.Mensaje = Mensajes.Mensaje2;
                        respuesta.Mensaje = mensaje;
                        respuesta.Data = paises;
                    }
                    else
                    {
                        mensaje.Error = false;
                        mensaje.Mensaje = Mensajes.Mensaje3;
                        respuesta.Mensaje = mensaje;
                        respuesta.Data = paises;
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

        }

        /// <summary>
        /// Consulta los paises  
        /// </summary>
        /// <returns></returns>
        public DTRespuesta<IList<DTPais>> consultarPais()
        {
            DTRespuesta<IList<DTPais>> respuesta = new DTRespuesta<IList<DTPais>>();
            DTMensajes mensaje = new DTMensajes();
            string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
            try
            {
                DTPais entity = new DTPais();
                IList<DTPais> pais = new DMAcceso<DTPais>().ConsultarList(Recursos.SPConsultarPais, entity, settings);
                if (pais.Count >= 1)
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje2;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = pais;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Mensaje = Mensajes.Mensaje3;
                    respuesta.Mensaje = mensaje;
                    respuesta.Data = pais;
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
        /// consulta las ciudades segun el id del departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public DTRespuesta<IList<DTCiudad>> consultarCiudad(DTDepartamento departamento)
        {
            {
                DTRespuesta<IList<DTCiudad>> respuesta = new DTRespuesta<IList<DTCiudad>>();
                DTMensajes mensaje = new DTMensajes();
                string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
                try
                {

                    IList<DTCiudad> ciudad = new DMAcceso<DTCiudad>().ConsultarList(Recursos.SPConsultarCiudades, departamento, settings);
                    if (ciudad.Count >= 1)
                    {
                        mensaje.Error = false;
                        mensaje.Mensaje = Mensajes.Mensaje2;
                        respuesta.Mensaje = mensaje;
                        respuesta.Data = ciudad;
                    }
                    else
                    {
                        mensaje.Error = false;
                        mensaje.Mensaje = Mensajes.Mensaje3;
                        respuesta.Mensaje = mensaje;
                        respuesta.Data = ciudad;
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

        }

        /// <summary>
        /// Consulta los sexos disponibles
        /// </summary>
        /// <returns></returns>
        public DTRespuesta<IList<DTSexo>> consultarSexo()
        {

            {
                DTRespuesta<IList<DTSexo>> respuesta = new DTRespuesta<IList<DTSexo>>();
                DTMensajes mensaje = new DTMensajes();
                string rutaLog = _hostingEnvironment.ContentRootPath + "\\LogBM\\";
                try
                {
                    DTSexo entity = new DTSexo();
                    IList<DTSexo> sexo = new DMAcceso<DTSexo>().ConsultarList(Recursos.SPConsultarSexo, entity, settings);
                    if (sexo.Count >= 1)
                    {
                        mensaje.Error = false;
                        mensaje.Mensaje = Mensajes.Mensaje2;
                        respuesta.Mensaje = mensaje;
                        respuesta.Data = sexo;
                    }
                    else
                    {
                        mensaje.Error = false;
                        mensaje.Mensaje = Mensajes.Mensaje3;
                        respuesta.Mensaje = mensaje;
                        respuesta.Data = sexo;
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

        }
    }
}



