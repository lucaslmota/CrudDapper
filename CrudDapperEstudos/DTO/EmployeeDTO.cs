using CrudDapperEstudos.Models;

namespace CrudDapperEstudos.DTO
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
            //EmployeeTerritoriesDTO = new List<EmployeeTerritoryDTO>();
            //Territories = new List<TerritoryDTO>();
        }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //public ICollection<EmployeeTerritoryDTO> EmployeeTerritoriesDTO { get; set; }
        public ICollection<TerritoryDTO> Territories { get; set; }
    }
}
