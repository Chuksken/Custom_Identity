using Custom_Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Custom_Identity.Startup))]
namespace Custom_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserRoles();
        }
         public void CreateUserRoles()
        {
                ApplicationDbContext context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
               var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if(!roleManager.RoleExists("SuperAdmin"))
            {
                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "chuks2ken@gmail.com";
                user.Email = "chuks2ken@gmail.com";
                string pwd = "Passw0rd@123";

                var newUser = userManager.Create(user, pwd);
                if(newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }
            }
        }
    }
}
