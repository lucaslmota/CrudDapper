using AutoMapper;
using CrudDapperEstudos.DTO;
using CrudDapperEstudos.Models;

namespace CrudDapperEstudos.Profiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Usuario, UsuarioListDTO>();

            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Category,CategoryDTO>().ReverseMap();
        }
    }
}
