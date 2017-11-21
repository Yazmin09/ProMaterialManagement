using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using WSMateriales.Entidades;
using System.Text;

namespace WSMateriales.Services.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMaterialAceroGH" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMaterialAceroGH
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAll", ResponseFormat = WebMessageFormat.Json)]
        List<AceroGHerramienta> BuscarTodos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get/{idMaterial}", ResponseFormat = WebMessageFormat.Json)]
        AceroGHerramienta BucarId(String idMaterial);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json)]
        bool Create(AceroGHerramienta acerogh);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat = WebMessageFormat.Json)]
        void Edit(AceroGHerramienta acerogh);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json)]
        bool Delete(AceroGHerramienta acerogh);
    }
}
