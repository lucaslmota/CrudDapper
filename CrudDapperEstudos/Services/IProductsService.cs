using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;

namespace CrudDapperEstudos.Services
{
    public interface IProductsService
    {
        Task<ResponseModel<List<ProductDTO>>> GetAll();
        Task<ResponseModel<List<ProductDTO>>> GetAllTeste();
    }
}
