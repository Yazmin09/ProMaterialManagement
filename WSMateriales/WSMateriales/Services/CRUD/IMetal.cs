using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using WSMateriales.Entidades;
using System.Text;
using System.ServiceModel.Web;

namespace WSMateriales.Services.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMetales" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMetal
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAll", ResponseFormat = WebMessageFormat.Json)]
        List<Metales> BuscarTodos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get/{idMaterial}", ResponseFormat = WebMessageFormat.Json)]
        Metales BucarId(String idMaterial);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json)]
        bool Create(Metales metales);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat = WebMessageFormat.Json)]
        void Edit(Metales metales);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json)]
        bool Delete(Metales metales);
    }
}
