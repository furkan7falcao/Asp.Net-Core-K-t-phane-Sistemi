using Microsoft.AspNetCore.Identity;
using Library.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.CustomValidator
{
    public class CustomPasswordValidator : IPasswordValidator<Member>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<Member> manager, Member member, string password)
        {
            var errors = new List<IdentityError>();


            if (password.ToLower().Contains(member.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainUserName",

                    Description = "Şifre kullanıcı adı içermemeli"
                });

            }


            if (errors.Count > 0)
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            else
            {
                return Task.FromResult(IdentityResult.Success);
            }
        }
    }
}
