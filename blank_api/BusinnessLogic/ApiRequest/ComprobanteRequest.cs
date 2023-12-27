using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiRequest
{
    public class ComprobanteRequest
    {

        /// <summary>
        /// cut (código único de trámite): integer (Identificación del trámite. Este dato es
        ///provisto por el método ministerio/tramites).
        /// </summary>
        public int cut { get; set; }
        /// <summary>
        //cup(código único de pago) : integer(Identificación de la tasa perteneciente al
        //trámite. Este dato es provisto por el método ministerio/tramites).
        /// </summary>
        public int cup { get; set; }
        /// <summary>
        /// cut (código único de trámite): integer (Identificación del trámite. Este dato es
        ///provisto por el método ministerio/tramites).
        /// </summary>
        public long nroDoc { get; set; }
        /// <summary>
        /// nroDoc: integer (Número de cuit del usuario final. Máximo 11 dígitos -
        /// O PCIONAL)

        /// </summary>
        public string apellido { get; set; }

        public string nombre { get; set; }
     
        public string razonSocial { get; set; }
        /// <summary>
        /// libre: integer (Máximo 10 dígitos. Es para los casos en donde el organismo desee agregar una codificación propia.El mismo se retorna en el método comprobante - OPCIONAL).
        /// </summary>
        public int libre { get; set; }
        ///<summary>    textoOrganismo: string (Es un texto que desee el organismo que se incorpore al a boleta de pago.Máximo 255 dígitos - OPCIONAL).
        ///</summary>


        public string textoOrganismo { get; set; }
        ///<summary>    textoOrganismo: string (Es un texto que desee el organismo que se incorpore al a boleta de pago.Máximo 255 dígitos - OPCIONAL).
        
            ///        importe: integer(Importe total del pago. Máximo 6 dígitos en la parte entera y
            ///2 dígitos en la parte fraccionaria, separados por coma). Si el valor de la tasa es
            ///fi ja y debe tomarse de la misma, entonces este dato debe ser 0.
            ///</summary>
        public string importe { get; set; }
        ///<summary>  
           ///        integer(Identificación del ministerio.Este dato es provisto por el
           
        ///m étodo ministerio/tramites)
                 ///</summary>
        public int mrioId { get; set; }
        ///<summary>  
        ///dependeId: integer(Identificación de la dependencia del ministerio. Este dato es
        ///provisto por el método ministerio/tramites)
             ///</summary>
        public int dependeId { get; set; }
        ///<summary> 
        ///municipal: char (‘S’ o ‘N’, representa si es o no municipio)
        ///</summary>
        public string municipal { get; set; }
        ///<summary> 
        ///  callbackUrl: string (URL de retorno sólo para los casos en donde el medio de
        ///p ago será Tarjeta de Crédito/Débito).
        ///</summary>

        public string callbackUrl { get; set; }
        ///<summary> 
       /// fVencimiento: String(Fecha de vencimiento del comprobante que puede ser
        ///estipulada por el organismo. Si el parámetro no existe, el valor por defecto será
            ///de 30 días a partir de la fecha actual - OPCIONAL)
        ///</summary>
        public DateTime fVencimiento { get; set; }

    }
}
