using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSMateriales.Entidades;

namespace WSMateriales.Services.Seguridad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioLogin" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioLogin.svc o ServicioLogin.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioLogin : IServicioLogin
    {
        DataMasterEntities Mydata = new DataMasterEntities();
        public Usuario BuscarPorMail(string email)
        {
            Usuario user = new Usuario();
            var Query = from usuario in Mydata.Usuario
                        where usuario.Email == email
                        select usuario;

            foreach (var result in Query)
            {
                user = result;
            }

            return user;
        }
        public string Desencriptar(string password)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(password);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public string Encriptar(string password)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public bool Conectar(string email, string password)
        {
            string p = Encriptar(password);
            p = p + ",";
            bool correcto = false;
            Usuario user = new Usuario();
            var Query = from usuario in Mydata.Usuario
                        where usuario.Email == email
                        select usuario;

            foreach (var result in Query)
            {
                user = result;
            }
            p = Desencriptar(user.Password);
            if (p.Equals(password))
            {
                correcto = true;
            }
            else
            {
                correcto = false;
            }
            return correcto;
        }

        public bool Desconectar()
        {
            return true;
        }
    }
}
