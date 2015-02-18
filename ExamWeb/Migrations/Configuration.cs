namespace ExamWeb.Migrations
{
    using ExamWeb.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExamWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //ContextKey = "ExamWeb.Models.ApplicationDbContext";
        }

        protected override void Seed(ExamWeb.Models.ApplicationDbContext context)
        {
            var idManager = new IdentityManager();
            idManager.CreateRole("Admin");
            idManager.CreateRole("Coordinator");
            idManager.CreateRole("User");


            var newUser = new ApplicationUser()
            {
                UserName = "sithi1990",
                FirstName = "Sithira",
                LastName = "Pathirana",
                Email = "sithi1990@live.com"
            };


            idManager.CreateUser(newUser, "Admin123");
            idManager.AddUserToRole(newUser.Id, "Admin");
            idManager.AddUserToRole(newUser.Id, "Coordinator");
            idManager.AddUserToRole(newUser.Id, "User");
        }

        

    }
}
