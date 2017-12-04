using EspirituSantoApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using EspirituSantoApp.Models;

namespace EspirituSantoApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<Models.EspirituSantoAppContext,
                    Migrations.Configuration>());
            ////conexion a base de datos para los roles
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);                //crear roles
            CreateSuperuser(db);            //crear super usuario
            AddPermisionsToSuperuser(db);   //agregar persimos a superusuario
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermisionsToSuperuser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("Admin"); //Buscar por nombre: Admin
            
            //revisar si no estan asignados todos los roles, para asignarselos al ejecutar el código
            if(!userManager.IsInRole(user.Id, "Admin")) //pertenece a ese rol? primer parametro id, luego el nombre del rol
            {
                userManager.AddToRole(user.Id, "Admin");
            }
            if (!userManager.IsInRole(user.Id, "Representante")) //pertenece a ese rol? primer parametro id, luego el nombre del rol
            {
                userManager.AddToRole(user.Id, "Representante");
            }
            if (!userManager.IsInRole(user.Id, "Editor")) //pertenece a ese rol? primer parametro id, luego el nombre del rol
            {
                userManager.AddToRole(user.Id, "Editor");
            }
        }

        private void CreateSuperuser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName("Admin");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "Admin"
                };
                userManager.Create(user, "AdminEs2017edu-1 pass");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            //ROLE MANAGER = permite crear roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists("Representante"))
            {
                roleManager.Create(new IdentityRole("Representante"));
            }
            if (!roleManager.RoleExists("Editor"))
            {
                roleManager.Create(new IdentityRole("Editor"));
            }
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
        }
    }
}
