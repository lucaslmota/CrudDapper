namespace CrudDapperEstudos.DTO
{
    public class CriarUsuarioDTO
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public double Salario { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public bool Situacao { get; set; } // 1 ativo 0 inativo
        public string Senha { get; set; } = string.Empty;
    }
}
