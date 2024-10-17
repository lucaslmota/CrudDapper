using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;
using CrudDapperEstudos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapperEstudos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProductsService _productsService;
        private readonly IEmployeeService _employeesService;

        public UsuarioController(IUsuarioService usuarioService, IProductsService productsService, IEmployeeService employeesService)
        {
            _usuarioService = usuarioService;
            _productsService = productsService;
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuario()
        {
            var user = await _usuarioService.BuscarUsuario();

            if (user == null)
            {
                return NotFound(user);
            }

            return Ok(user);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> BuscarUserId(int usuarioId)
        {
            var usuario = await _usuarioService.BuscarUserId(usuarioId);

            if(usuario.Sattus == false)
            {
                return NotFound(usuarioId);
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> InserirUsuario(CriarUsuarioDTO criarUsuarioDTO)
        {
            var criarUser = await _usuarioService.CriarUsuario(criarUsuarioDTO);

            if (criarUser.Sattus == false)
            {
                return BadRequest(criarUser);
            }
            return Ok(criarUser);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(EditarUserDTO editarUserDTO)
        {
            var editarUser = await _usuarioService.EditarUsuario(editarUserDTO);

            if(editarUser.Sattus == false) 
            { 
                return BadRequest(editarUser); 
            }
            return Ok(editarUser);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirUsuario (int id)
        {
            var excluirUsuario = await _usuarioService.ExcluirUserId(id);

            if (excluirUsuario.Sattus == false)
            {
                return BadRequest(excluirUsuario);
            }
            return Ok(excluirUsuario);
        }

        [HttpGet("teste")]
        public async Task<IActionResult> GetProducts()
        {
            var produ = await _productsService.GetAll();
            if (produ == null)
            {
                return NotFound(produ);
            }

            return Ok(produ);
        }

        [HttpGet("territory")]
        public async Task<IActionResult> GetManyTerritory()
        {
            var produ = await _employeesService.GetAll();
            if (produ == null)
            {
                return NotFound(produ);
            }

            return Ok(produ);
        }

    }
}
