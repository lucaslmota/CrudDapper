using CrudDapperEstudos.Models;

namespace CrudDapperEstudos.DTO
{
    public class EmployeeTerritoryDTO
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public Employee Employee { get; set; }
        public Territory Territory { get; set; }
    }
}
