namespace CrudDapperEstudos.DTO
{
    public class UsuarioListDTO
    {
        public int UsuarioId { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public double Salario { get; set; }
        public bool Situacao { get; set; } // 1 ativo 0 inativo
    }
}
