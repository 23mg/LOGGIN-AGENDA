
using Microsoft.EntityFrameworkCore;
using LOGGIN_AGENDA.Models;


namespace LOGGIN_AGENDA.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);

    }

}
