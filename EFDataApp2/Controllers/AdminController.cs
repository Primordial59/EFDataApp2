using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EFDataApp2.Models;

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
        
    }
}