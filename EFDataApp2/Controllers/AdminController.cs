using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EFDataApp2.Models;
using System.Threading.Tasks;

namespace EFDataApp2.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<MDSUser> userManager;
        public AdminController(UserManager<MDSUser> usrMgr)
        {
            userManager = usrMgr;
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

                        if (error.Description.ToString() == $"Passwords must have at least one lowercase ('a'-'z').")
                        {
                            ModelState.AddModelError("", "Пароль должен содержать не менее одного символа в нижнем регистре ('a'-'z').");
                        }
                        else  if (error.Description.ToString() == $"Passwords must have at least one uppercase ('A'-'Z').")
                            {
                                ModelState.AddModelError("", "Пароль должен содержать не менее одного символа в верхнем регистре ('A'-'Z').");
                            }
                        else
                        { ModelState.AddModelError("", error.Description); }


                    }
                }
            }
            return View(model);
        }


    }
}