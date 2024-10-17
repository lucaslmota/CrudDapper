using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;

namespace CrudDapperEstudos.Services
{
    public interface IEmployeeService
    {
        Task<ResponseModel<List<EmployeeDTO>>> GetAll();
    }
}
