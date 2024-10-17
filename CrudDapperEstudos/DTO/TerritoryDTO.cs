using CrudDapperEstudos.Models;
using Newtonsoft.Json;

namespace CrudDapperEstudos.DTO
{
    public class TerritoryDTO
    {
        public TerritoryDTO()
        {
            //EmployeeTerritoriesDTO = new List<EmployeeTerritoryDTO>();
            //Employees = new List<EmployeeDTO>();
        }
        public string TerritoryDescription { get; set; }

        //public ICollection<EmployeeTerritoryDTO> EmployeeTerritoriesDTO { get; private set; }
        [JsonIgnore]
        public ICollection<EmployeeDTO> Employees { get; set; }
    }
}
