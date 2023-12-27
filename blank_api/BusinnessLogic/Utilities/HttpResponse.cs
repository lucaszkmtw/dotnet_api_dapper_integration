using BussinessLogic.ApiResponse;
using DataAccess.Helpers;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utilities
{
    public class HttpResponse
    {


        private static HttpResponse instance;
        //private Utils.DateUtilsService dateUtils;


        public static HttpResponse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpResponse();
                }
                return instance;
            }
        }

        public T Excepciones<T>(HttpResponseMessage data)
        {


            ResponseAPI response = new ResponseAPI();
            if ((int)data.StatusCode == 404)
            {
                response.CodigoRespuesta = ResponseAPI.CODIGO_ERROR;
                response.Mensaje = "Error en la Carga";
                response.Codigo = "404";
                response.DescripcionResultado = response.Error;
            }
            if ((int)data.StatusCode == 503)
            {
                response.CodigoRespuesta = ResponseAPI.CODIGO_ERROR;
                response.Mensaje = "Servidor Siep No disponible en estos Momentos";
                response.Codigo = "503";
                response.DescripcionResultado = response.Error;
            }
            if ((int)data.StatusCode == 400)
            {
                response.CodigoRespuesta = ResponseAPI.CODIGO_ATENCION;
                response.Mensaje = "Parametros Invalidos";
                response.Codigo = "400";
                response.DescripcionResultado = response.Error;
            }
            if ((int)data.StatusCode == 500)
            {
                throw (new Exception(response.Error));
            }
            return response.Adapt<T>();
        }
    }
}
