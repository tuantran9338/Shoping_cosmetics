using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Shopping.Models;

[assembly: OwinStartupAttribute(typeof(Shopping.Startup))]
namespace Shopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("ADMIN"))
            {
                // Tạo quyền cao nhất ADMIN
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "ADMIN";
                roleManager.Create(role);
                // Tạo Super Admin
                var user = new ApplicationUser();
                user.UserName = "admin@beep.com";
                user.Email = "admin@beep.com";
                string userPWD = "123456";
                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "ADMIN");
                }
            }

            if (!roleManager.RoleExists("MANAGER"))
            {
                // Tạo quyền cao nhất ADMIN
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "MANAGER";
                roleManager.Create(role);
                // Tạo MANAGER
                var userManager = new ApplicationUser();
                userManager.UserName = "manager@beep.com";
                userManager.Email = "manager@beep.com";
                string uManagerPWD = "123456";
                var chkUserManager = UserManager.Create(userManager, uManagerPWD);
                if (chkUserManager.Succeeded)
                {
                    var result = UserManager.AddToRole(userManager.Id, "MANAGER");
                }
                // Tạo tk editor thuộc MANAGER
                var userEditor = new ApplicationUser();
                userEditor.UserName = "editor@beep.com";
                userEditor.Email = "editor@beep.com";
                string userEditorPWD = "123456";
                var chkUserEditor = UserManager.Create(userEditor, uManagerPWD);
                if (chkUserEditor.Succeeded)
                {
                    var result = UserManager.AddToRole(userEditor.Id, "MANAGER");
                }
            }
            // Tạo MEMBER
            if (!roleManager.RoleExists("MEMBER"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "MEMBER";
                roleManager.Create(role);
            }
        }
    }
}

