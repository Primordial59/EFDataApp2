using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataApp2.Models;
using Microsoft.AspNetCore.Identity;


namespace EFDataApp2.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator<MDSUser>
    {

        public override async Task<IdentityResult> ValidateAsync(
        UserManager<MDSUser> manager, MDSUser user, string password)
        {

             IdentityResult result = await base.ValidateAsync(manager,
             user, password);

              List<IdentityError> errors = result.Succeeded ?
            new List<IdentityError>() : result.Errors.ToList();

           // List<IdentityError> errors = new List<IdentityError>();
            
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    //     Description = "Password cannot contain username"
                    Description = "Пароль не должен содержать имени пользователя"
                });
            }
            if (password.Contains("12345678") || password.Contains("87654321") )
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Пароль не должен содержать числовой последовательности"
                });
            }

           
                        return errors.Count == 0 ? IdentityResult.Success
                        : IdentityResult.Failed(errors.ToArray());

       //     return Task.FromResult(errors.Count == 0 ? 
       //         IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));


        }
    }

}
