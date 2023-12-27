using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ApiResponse
{
    public class ResponseAPI 
    {
        public static string CodigoOtros = "999";
        public static string CodigoKeyIncorrecta = "101";
        public static string CodigoResponseSuccess = "200";
        public static string CodigoUsuarioIncorrecto = "100";
        public static string CodigoBadRequest = "400";
        public static string CodigoNotFound = "404";
        public static string CodigoInternalServerError = "500";

        
        public static string MensajeRepsonseSuccess = "Success";
        public static string MensajeUsuarioIncorrecto = "El nombre de usuario es incorrecto.";
        public static string MensajeKeyIncorrecta = "La key de validación es incorrecta.";
        public static string MensajeBadRequest = "Datos incorrectos";
        public static string MensajeNotFound = "Url no encontrada";
        public static string MensajeInternalServerError = "Algo a ocurrido en el servidor interno de Pagos";

        //ESTO ES PARA LOS WS
        public static string CODIGO_OK = "OK";
        public static string CODIGO_ATENCION = "ATENCION";
        public static string CODIGO_ERROR = "ERROR";

        public int StatusCode { get; set; }
        /// <summary>
        /// Codigo de la respuesta
        /// </summary>
        /// 

        public string CodigoRespuesta { get; set; }
        /// <summary>
        /// Mensaje de la respues
        /// </summary>
        public string Mensaje { get; set; }

        public string Error { get; set; }
        //ESTO ES PARA LOS WS
        public string Codigo { get; set; }
        public string DescripcionResultado { get; set; }
        public string CodigoOperacion { get; set; }
    }
}


