using System;
using System.Threading.Tasks;
using BlocXamarin.Model;

namespace BlocXamarin.Service
{
    public interface IServicioDatos
    {
        Task<Usuario> ValidarUsuario(Usuario us);
        Task<Usuario> AddUsuario(Usuario us);
        Task<Usuario> UpdateUsuario(Usuario us);
        Task DeleteUsuario(String us);
    }
}