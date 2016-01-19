using System;
using System.Threading.Tasks;
using BlocXamarin.Model;
using BlocXamarin.Util;
using Microsoft.WindowsAzure.MobileServices;

namespace BlocXamarin.Service
{
    public class ServicioDatosImpl:IServicioDatos
    {
        //Creamos la conexión con Azure Service Mobile

        #region Conexion con Azure Service Mobile

        private MobileServiceClient cliente;

        public ServicioDatosImpl()
        {
            cliente = new MobileServiceClient(CadenaConexion.UrlServicio, CadenaConexion.TokenServicio);
        }

        #endregion


        public async Task<Usuario> AddUsuario(Usuario us)
        {
            //Creamos la instancia para la tabla usuario con MobileServicesClient.GetTable
            var tabla = cliente.GetTable<Usuario>();
            //Obtemos los datos,creando la Query para la busqueda de usuarios
            var data = await tabla.CreateQuery().Where(o => o.Login == us.Login).ToListAsync();

            //Count devuelve el numero actual de registros
            if (data.Count > 0)
                throw new Exception("Usuario ya registrado");

            try
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar usuario");
            }

            return us;
        }

        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            var tabla = cliente.GetTable<Usuario>();
            var data =
                await tabla.CreateQuery().Where(o => o.Login == us.Login && o.Password == us.Password).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }

            return data[0];

        }


        public async Task<Usuario> UpdateUsuario(Usuario us)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteUsuario(string us)
        {
            throw new System.NotImplementedException();
        }
    }
}