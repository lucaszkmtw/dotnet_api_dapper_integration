using BussinessLogic.ApiResponse;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiResponse
{
    public class ComprobanteInfoResponse : ResponseAPI
    {
        public virtual string denominacionSolicitante { get; set; } 
        public virtual string cut { get; set; } 
        public virtual string fGeneracion { get; set; } 
        public virtual string fVencimiento { get; set; } 
        public virtual string monto { get; set; } 
        public virtual string codigoBarras { get; set; } 
        public virtual string codigoPagoElectronico { get; set; } 
        public virtual string nroTransaccion { get; set; } 
        public virtual string callbackUrl { get; set; } 
        public virtual string eMaiil { get; set; } 
        public virtual string textoLibreOriginal { get; set; } 
        public virtual string observaciones { get; set; } 
        public virtual string tipoDocId { get; set; } 
        public virtual string cuit { get; set; } 
        public virtual string cup { get; set; } 



    }
}
