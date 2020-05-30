﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinaria.Web.Models;

namespace Veterinaria.Web.Clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("admin@admin.com");

            if (userAsp == null)
            {
                CreateUserASP("admin@admin.com", "491566", "Admin");
            }
        }
        
        internal static void CheckClientDefault()
        {
            var clientdb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userclient = clientdb.FindByName("rodrigo@santana.com");
            if (userclient==null)
            {
                CreateUserASP("rodrigo@santana.com","491567","Owner");
                userclient = clientdb.FindByName("rodrigo@santana.com");
                var owner = new Owner
                {
                    UserId = userclient.Id,
                };

                db.Owners.Add(owner);
                db.SaveChanges();
            }

        }

        public static void CreateUserASP(string email, string password, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = email,
                Email = email,
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, rol);
        }
       



        public void Dispose()
        {
            db.Dispose();
        }

    }
}