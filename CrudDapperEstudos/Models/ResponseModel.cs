namespace CrudDapperEstudos.Models
{
    public class ResponseModel<T>
    {
        public T? Dado { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sattus { get; set; } = true;
    }
}
