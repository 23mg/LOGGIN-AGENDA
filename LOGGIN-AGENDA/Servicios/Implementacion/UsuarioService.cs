
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LOGGIN_AGENDA.Models;
using LOGGIN_AGENDA.Servicios.Contrato;

namespace LOGGIN_AGENDA.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbAccesoContext _dbContext;
        public UsuarioService(DbAccesoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
