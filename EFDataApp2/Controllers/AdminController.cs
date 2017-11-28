using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EFDataApp2.Models;
using System.Threading.Tasks;

namespace EFDataApp2.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<MDSUser> userManager;
        private IUserValidator<MDSUser> userValidator;
        private IPasswordValidator<MDSUser> passwordValidator;
        private IPasswordHasher<MDSUser> passwordHasher;

        public AdminController(UserManager<MDSUser> usrMgr,
        IUserValidator<MDSUser> userValid,
        IPasswordValidator<MDSUser> passValid,
        IPasswordHasher<MDSUser> passwordHash)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
        }
        
        public ViewResult Index() => View(userManager.Users);

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                MDSUser user = new MDSUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                IdentityResult result
                = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {

                        AddErrorsFromResult(result);
                    }
                }
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            MDSUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View("Index", userManager.Users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            MDSUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string phonenumber,
        string password)
        {
            MDSUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                user.PhoneNumber = phonenumber;
                IdentityResult validEmail
                = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager,
                    user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user,
                        password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null)
                || (validEmail.Succeeded
                && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {

                    if (error.Description.ToString() == $"Passwords must have at least one lowercase ('a'-'z').")
                    {
                        ModelState.AddModelError("", "Пароль должен содержать не менее одного символа в нижнем регистре ('a'-'z').");
                    }
                    else if (error.Description.ToString() == $"Passwords must have at least one uppercase ('A'-'Z').")
                    {
                        ModelState.AddModelError("", "Пароль должен содержать не менее одного символа в верхнем регистре ('A'-'Z').");
                    }
                    else if (error.Description.ToString() == $"Passwords must be at least 8 characters.")
                    {
                        ModelState.AddModelError("", "Пароль должен быть не менее 8-ми символов.");
                    }
                    else if (error.Description.ToString().EndsWith("is invalid, can only contain letters or digits."))
                    {
                        ModelState.AddModelError("", "Имя не должно содержать спецсимволы и буквы верхнего регистра.");
                    }
                    else if (error.Description.ToString().EndsWith("is already taken."))
                    {
                        ModelState.AddModelError("", "Этот адрес почты уже используется.");
                    }
                    else if (error.Description.ToString() == $"The Password field is required.")
                    {
                        ModelState.AddModelError("", "Поле Пароль обязательное для заполения.");
                    }
                    else if (error.Description.ToString() == $"The Name field is required.")
                    {
                        ModelState.AddModelError("", "Поле Имя обязательное для заполения.");
                    }

                    else
                    { ModelState.AddModelError("", error.Description); }


               

               
            }
        }

    }
}