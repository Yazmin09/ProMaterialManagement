using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WSMateriales.Entidades;

namespace WSMateriales.Services.Seguridad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioLogin" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioLogin
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "encriptar/{password}", ResponseFormat = WebMessageFormat.Json)]
        string Encriptar(string password);
        [OperationContract]
        [WebInvoke(UriTemplate = "desencriptar/{password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        string Desencriptar(string password);
        [OperationContract]
        [WebInvoke(UriTemplate = "desconectar", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool Desconectar();
        [OperationContract]
        [WebInvoke(UriTemplate = "conectar/{email},{password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        bool Conectar(string email, string password);
        [WebInvoke(Method = "GET", UriTemplate = "pormail/{email}", ResponseFormat = WebMessageFormat.Json)]
        Usuario BuscarPorMail(string email);
    }
}
