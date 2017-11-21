using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSMateriales.Entidades;

namespace WSMateriales.Services.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Metales" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Metales.svc o Metales.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Metal : IMetal
    {
        DataMasterEntities Mydata = new DataMasterEntities();

            public Metales BucarId(string idMaterial)
            {

                {
                    Metales item = new Metales();
                    int ID = int.Parse(idMaterial);
                    var Query = from metales in Mydata.Metales
                                where metales.idMaterial == ID
                                select metales;

                    foreach (var result in Query)
                    {
                        item = result;
                    }

                    return item;
                }
            }

            public List<Metales> BuscarTodos()
            {
                List<Metales> lista = new List<Metales>();

                var Query = from metales in Mydata.Metales
                            select metales;

                foreach (var result in Query)
                {
                    lista.Add(result);
                }
                Console.WriteLine("Resultado " + lista.First());
                return lista;
            }

            public bool Create(Metales metales)
            {
                //Contruccion del objeto
                Mydata.Metales.Add(metales);
                Mydata.SaveChanges();
                return true;
            }

            public bool Delete(Metales metales)
            {
                Metales mate = Mydata.Metales.Find(metales.idMaterial);
                Mydata.Metales.Remove(mate);
                Mydata.SaveChanges();
                return true;
            }



            public void Edit(Metales metales)
            {
                var item = Mydata.Metales.FirstOrDefault(x => x.idMaterial == metales.idMaterial);

                item.Estado = metales.Estado;
                item.MateriaPrima = metales.MateriaPrima;
                item.Mineral = metales.Mineral;
                item.SemiFabricado = metales.SemiFabricado;
                item.Cantidad = metales.Cantidad;
                Mydata.SaveChanges();
            }
        }
    }

