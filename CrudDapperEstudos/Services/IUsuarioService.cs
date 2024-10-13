using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;

namespace CrudDapperEstudos.Services
{
    public interface IUsuarioService
    {
        Task<ResponseModel<List<UsuarioListDTO>>> BuscarUsuario();
        Task<ResponseModel<UsuarioListDTO>> BuscarUserId(int id);
        Task<ResponseModel<List<UsuarioListDTO>>> CriarUsuario(CriarUsuarioDTO criarUsuarioDTO);
        Task<ResponseModel<List<UsuarioListDTO>>> EditarUsuario(EditarUserDTO editarUserDTO);
        Task<ResponseModel<List<UsuarioListDTO>>> ExcluirUserId(int id);

    }
}
