
namespace CrudDapperEstudos.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
