using AutoMapper;
using Library.DTO.DTOs.CategoryDtos;
using Library.DTO.DTOs.MemberDtos;
using Library.DTO.DTOs.SubCategoryDtos;
using Library.Entities.Concreate;

namespace Library.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MemberSignUpDto, Member>();
            CreateMap<Member, MemberSignUpDto>();
            CreateMap<MemberSignInDto, Member>();
            CreateMap<Member, MemberSignInDto>();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<SubCategoryUpdateDto, SubCategory>();
            CreateMap<SubCategory, SubCategoryUpdateDto>();
            CreateMap<SubCategoryAddDto, SubCategory>();
            CreateMap<SubCategory, SubCategoryAddDto>();
            

        }
    }
}
