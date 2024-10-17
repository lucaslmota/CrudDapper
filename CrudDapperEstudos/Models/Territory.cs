namespace CrudDapperEstudos.Models
{
    public class Territory
    {
        public Territory()
        {
            //EmployeeTerritories = new List<EmployeeTerritory>();
            //Employees = new List<Employee>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        //public Region Region { get; set; }
        //public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
