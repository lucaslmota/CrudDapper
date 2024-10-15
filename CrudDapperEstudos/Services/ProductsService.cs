using AutoMapper;
using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;
using Dapper;
using System.Data.SqlClient;

namespace CrudDapperEstudos.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProductsService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<ProductDTO>>> GetAll()
        {
            var response = new ResponseModel<List<ProductDTO>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr2")))
            {
                var sql = @"SELECT p.*, c.*
                FROM Products p 
                INNER JOIN Categories c ON p.CategoryID = c.CategoryID";

                var products = await connection.QueryAsync<Product, Category, Product>(sql, (product, category) => {
                    product.Category = category;
                    return product;
                },splitOn: "CategoryID");

                var userMap = _mapper.Map<List<ProductDTO>>(products);

                response.Dado = userMap;
                response.Mensagem = "num foi!";

            }
            return response;
        }

        public async Task<ResponseModel<List<ProductDTO>>> GetAllTeste()
        {
            var response = new ResponseModel<List<ProductDTO>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr2")))
            {
                var sql = @"SELECT ProductID, ProductName, CategoryID
                FROM Products ";

                var products = await connection.QueryAsync<Product>(sql);

                var userMap = _mapper.Map<List<ProductDTO>>(products);

                response.Dado = userMap;
                response.Mensagem = "num foi!";

            }
            return response;
        }
    }
}
