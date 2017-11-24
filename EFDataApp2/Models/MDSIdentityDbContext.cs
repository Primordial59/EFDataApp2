using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EFDataApp2.Models
{

    // Старая рабочая реализация, необходимая для публикации БД: Identity и mobilesdb
    // public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
      public class MDSIdentityDbContext : IdentityDbContext<MDSUser>
    {

        public MDSIdentityDbContext(DbContextOptions<MDSIdentityDbContext> options)
        : base(options)  { }
    }
}

