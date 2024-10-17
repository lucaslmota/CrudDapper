using AutoMapper;
using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;
using Dapper;
using System.Data.SqlClient;

namespace CrudDapperEstudos.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public EmployeeService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ResponseModel<List<EmployeeDTO>>> GetAll()
        {
            var response = new ResponseModel<List<EmployeeDTO>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr2")))
            {

                var sql = @"SELECT e.* ,t.*

                           FROM Employees e

                            INNER JOIN EmployeeTerritories et ON e.EmployeeID = et.EmployeeID
                            INNER JOIN Territories t ON t.TerritoryID = et.TerritoryID";
                var employeeDictionary = new Dictionary<int, Employee>();

                var employees = await connection.QueryAsync<Employee,Territory, Employee>(sql,(employee,territorie) =>
                {
                    if (!employeeDictionary.TryGetValue(employee.EmployeeId, out var currentEmployee))
                    {
                        currentEmployee = employee;
                        currentEmployee.Territories = new List<Territory>();
                        employeeDictionary.Add(currentEmployee.EmployeeId, currentEmployee);
                    }

                    currentEmployee.Territories.Add(territorie);
                    return currentEmployee;
                }, splitOn: "TerritoryID");

                var userMap = _mapper.Map<List<EmployeeDTO>>(employees);

                response.Dado = userMap;
                response.Mensagem = "num foi!";

            }
            return response;
        }
    }
}
