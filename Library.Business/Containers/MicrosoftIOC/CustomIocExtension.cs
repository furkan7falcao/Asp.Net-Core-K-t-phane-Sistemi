using FluentValidation;
using Library.Business.Concreate;
using Library.Business.Interfaces;
using Library.Business.ValidationRules.FluentValidation;
using Library.DataAccess.Concreate.EntityFrameworkCore.Repositories;
using Library.DataAccess.Interfaces;
using Library.DTO.DTOs.CategoryDtos;
using Library.DTO.DTOs.MemberDtos;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Business.Containers.MicrosoftIOC
{
    public static class CustomIocExtension 
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDAL<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IBookDAL, EfBookRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EfCategoryRepository>();
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IAuthorDAL, EfAuthorRepository>();
            services.AddScoped<IMemberService, MemberManager>();
            services.AddScoped<IMemberDAL, EfMemberRepository>();
            services.AddScoped<IRequestService, RequestManager>();
            services.AddScoped<IRequestDAL, EfRequestRepository>();
            services.AddScoped<ISubCategoryService, SubCategoryManager>();
            services.AddScoped<ISubCategoryDAL, EfSubCategoryRepository>();


            services.AddTransient<IValidator<MemberSignUpDto>, MemberSignUpValidator>();
            services.AddTransient<IValidator<MemberSignInDto>, MemberSignInValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();




        }
    }
}
