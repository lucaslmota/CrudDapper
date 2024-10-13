using AutoMapper;
using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrudDapperEstudos.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<UsuarioListDTO>> BuscarUserId(int id)
        {
            var response = new ResponseModel<UsuarioListDTO>();

            using(var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                var sql = @"SELECT * FROM Usuario WHERE UsuarioID = @id";
                var userId = await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });

                if (userId == null)
                {
                    response.Mensagem = "Usuário não encontrado!";
                    response.Sattus = false;
                    return response;
                }

                var userMap = _mapper.Map<UsuarioListDTO>(userId);

                response.Dado = userMap;
                response.Mensagem = "Usuário locaizado com sucesso!";

            }

            return response;

        }

        public async Task<ResponseModel<List<UsuarioListDTO>>> BuscarUsuario()
        {
            var response = new ResponseModel<List<UsuarioListDTO>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                var user = await connection.QueryAsync<Usuario>("SELECT * FROM Usuario");

                if (user.Count() == 0) 
                {
                    response.Mensagem = "Usuário não encontrado!";
                    response.Sattus = false;
                    return response;
                }

                var userMap = _mapper.Map<List<UsuarioListDTO>>(user);

                response.Dado = userMap;
                response.Mensagem = "Usuário locaizado com sucesso!";

            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioListDTO>>> CriarUsuario(CriarUsuarioDTO criarUsuarioDTO)
        {
            var response = new ResponseModel<List<UsuarioListDTO>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                var sql = @"INSERT INTO Usuario (NomeCompleto, Email, Cargo, Salario, Cpf, Situacao,Senha)
                            VALUES(@NomeCompleto,@Email,@Cargo,@Salario,@Cpf,@Situacao,@Senha)";

                var addUser = await connection.ExecuteAsync(sql,criarUsuarioDTO);


                if(addUser == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao inserir Registro!";
                    response.Sattus = false;
                    return response;
                }


                var buscarUser = await ListarUsuario(connection);

                var userMap = _mapper.Map<List<UsuarioListDTO>>(buscarUser);

                response.Dado = userMap;
                response.Mensagem = "Usarios listados com sucesso!";

            }

            return response;
        }

        private static async Task<IEnumerable<Usuario>> ListarUsuario(SqlConnection connection)
        {
            return await connection.QueryAsync<Usuario>("SELECT * FROM Usuario");
        }

        public async Task<ResponseModel<List<UsuarioListDTO>>> EditarUsuario(EditarUserDTO editarUserDTO)
        {
            var response  = new ResponseModel<List<UsuarioListDTO>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                var sql = @"UPDATE Usuario SET 
                                NomeCompleto = @NomeCompleto,
                                Email = @Email,
                                Cargo = @Cargo,
                                Salario = @Salario,
                                Cpf = @Cpf,
                                Situacao = @Situacao
                           WHERE UsuarioId = @UsuarioId";


                var updateUser = await connection.ExecuteAsync(sql, editarUserDTO);

                if (updateUser == 0) 
                {
                    response.Mensagem = "Ocorreu um erro ao editar Registro!";
                    response.Sattus = false;
                    return response;
                }

                var buscarUser = await ListarUsuario(connection);

                var userMap = _mapper.Map<List<UsuarioListDTO>>(buscarUser);

                response.Dado = userMap;
                response.Mensagem = "Usarios listados com sucesso!";
            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioListDTO>>> ExcluirUserId(int id)
        {
            var response = new ResponseModel<List<UsuarioListDTO>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                var sql = @"DELETE FROM Usuario WHERE UsuarioId = @id";
                    
                var deleteUser = await connection.ExecuteAsync(sql, new {Id = id});

                if(deleteUser == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao editar Registro!";
                    response.Sattus = false;
                    return response;
                }

                var buscarUser = await ListarUsuario(connection);

                var userMap = _mapper.Map<List<UsuarioListDTO>>(buscarUser);

                response.Dado = userMap;
                response.Mensagem = "Usarios listados com sucesso!";
            }
            return response;
        }
    }
}
