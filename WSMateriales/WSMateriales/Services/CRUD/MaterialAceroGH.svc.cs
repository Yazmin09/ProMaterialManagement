using System;
using System.Collections.Generic;
using System.Linq;
using WSMateriales.Entidades;

namespace WSMateriales.Services.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MaterialAceroGH" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MaterialAceroGH.svc o MaterialAceroGH.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MaterialAceroGH : IMaterialAceroGH
    {
        DataMasterEntities Mydata = new DataMasterEntities();

        public AceroGHerramienta BucarId(string idMaterial)
        {

            {
                AceroGHerramienta item = new AceroGHerramienta();
                int ID = int.Parse(idMaterial);
                var Query = from acerogh in Mydata.AceroGHerramienta
                            where acerogh.idMaterial == ID
                            select acerogh;

                foreach (var result in Query)
                {
                    item = result;
                }

                return item;
            }
        }

        public List<AceroGHerramienta> BuscarTodos()
        {
            List<AceroGHerramienta> lista = new List<AceroGHerramienta>();

            var Query = from acerogh in Mydata.AceroGHerramienta
                        select acerogh;

            foreach (var result in Query)
            {
                lista.Add(result);
            }
            Console.WriteLine("Resultado " + lista.First());
            return lista;
        }

        public bool Create(AceroGHerramienta acerogh)
        {
            //Contruccion del objeto
            Mydata.AceroGHerramienta.Add(acerogh);
            Mydata.SaveChanges();
            return true;
        }

        public bool Delete(AceroGHerramienta acerogh)
        {
            AceroGHerramienta mate = Mydata.AceroGHerramienta.Find(acerogh.idMaterial);
            Mydata.AceroGHerramienta.Remove(mate);
            Mydata.SaveChanges();
            return true;
        }



        public void Edit(AceroGHerramienta acerogh)
        {
            var item = Mydata.AceroGHerramienta.FirstOrDefault(x => x.idMaterial == acerogh.idMaterial);

            item.Calidad = acerogh.Calidad;
            item.Perfil = acerogh.Perfil;
            item.Acabado = acerogh.Acabado;
            item.Medidas = acerogh.Medidas;
            item.Cantidad = acerogh.Cantidad;
            Mydata.SaveChanges();
        }
    }
}

