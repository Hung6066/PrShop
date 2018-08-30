﻿namespace ProShop.Data.Migrations
{
    using PrShop.Data;
    using PrShop.Model.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PrShop.Data.PrShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PrShop.Data.PrShopDbContext context)
        {
            CreatedProductCategorySample(context);            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new PrShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new PrShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "Hung",
            //    Email = "thanhhung6066@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Hung Phan"

            //};
            //manager.Create(user, "123456");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("thanhhung6066@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User"});

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }

        private void CreatedProductCategorySample(PrShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>
            {
                new ProductCategory() {Name = "Điện lạnh",Alias="dien-lanh",Status=true },
                new ProductCategory() {Name = "Viễn thông",Alias="vien-thong",Status=true },
                new ProductCategory() {Name = "Đồ gia dụng",Alias="do-gia-dung",Status=true },
                new ProductCategory() {Name = "Mỹ phẩm",Alias="my-pham",Status=true },
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
    }
}