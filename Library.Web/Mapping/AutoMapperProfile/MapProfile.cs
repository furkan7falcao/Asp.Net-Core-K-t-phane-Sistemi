using AutoMapper;
using Library.DTO.DTOs.AuthorDtos;
using Library.DTO.DTOs.BookDtos;
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
            CreateMap<AuthorListDto, Author>();
            CreateMap<Author, AuthorListDto>();
            CreateMap<BookListDto, Book>();
            CreateMap<Book, BookListDto>();
            CreateMap<AuthorAddDto, Author>();
            CreateMap<Author, AuthorAddDto>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<Author, AuthorUpdateDto>();
            CreateMap<BookAddDto, Book>();
            CreateMap<Book, BookAddDto>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<Book, BookUpdateDto>();


        }
    }
}
