using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSMateriales.Entidades;
using WSMateriales.Services.CRUD;

namespace WSMateriales.Services.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AceroInoxidable" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AceroInoxidable.svc o AceroInoxidable.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MaterialAceroInox : IMaterialAceroInox
    {
        DataMasterEntities Mydata = new DataMasterEntities();

        public AceroInoxidable BucarId(string idMaterial)
        {
            AceroInoxidable mtinox = new AceroInoxidable();
            int ID = int.Parse(idMaterial);
            var Query = from aceroinox in Mydata.AceroInoxidable
                        where aceroinox.idMaterial == ID
                        select aceroinox;

            foreach (var result in Query)
            {
                mtinox = result;
            }

            return mtinox;
        }
        public List<AceroInoxidable> BuscarTodos()
        {
            List<AceroInoxidable> lista = new List<AceroInoxidable>();

            var Query = from aceroinox in Mydata.AceroInoxidable
                        select aceroinox;

            foreach (var result in Query)
            {
                lista.Add(result);
            }
            Console.WriteLine("Resultado " + lista.First());
            return lista;
        }

        public bool Create(AceroInoxidable aceroinox)
        {
            //Contruccion del objeto
            Mydata.AceroInoxidable.Add(aceroinox);
            Mydata.SaveChanges();
            return true;
        }

        public bool Delete(AceroInoxidable aceroinox)
        {
            AceroInoxidable mate = Mydata.AceroInoxidable.Find(aceroinox.idMaterial);
            Mydata.AceroInoxidable.Remove(mate);
            Mydata.SaveChanges();
            return true;
        }



        public void Edit(AceroInoxidable aceroinox)
        {
            var item = Mydata.AceroInoxidable.FirstOrDefault(x => x.idMaterial == aceroinox.idMaterial);

            item.Calidad = aceroinox.Calidad;
            item.Perfil = aceroinox.Perfil;
            item.Acabado = aceroinox.Acabado;
            item.Espesor = aceroinox.Espesor;
            item.Cantidad = aceroinox.Cantidad;
            Mydata.SaveChanges();
        }
    }

}


