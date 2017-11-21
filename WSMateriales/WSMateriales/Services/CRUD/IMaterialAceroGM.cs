using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using WSMateriales.Entidades;

namespace WSMateriales.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMaterialAceroGM" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMaterialAceroGM
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool Insertar(AceroGMaquinaria acerogm);
        [OperationContract]
        [WebInvoke(UriTemplate = "edit", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        void Editar(AceroGMaquinaria acerogm);
        [OperationContract]
        [WebInvoke(UriTemplate = "delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        bool Eliminar(AceroGMaquinaria acerogm);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAll", ResponseFormat = WebMessageFormat.Json)]
        List<AceroGMaquinaria> ConsultarTodos();
        [OperationContract]
        List<AceroGMaquinaria> ConsultarPorCalidad(string calidad);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get/{idMaterial}", ResponseFormat = WebMessageFormat.Json)]
        AceroGMaquinaria ConsultarPorId(string idMaterial);

    }
}

