using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //this.SeedData();
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }


        private async void SeedData()
        {
            if (this.Products.Count() <= 0)
            {
                var p1 = new Product() { ProductName = "Bup be", Price = 15000, ImageProduct = null, BarCode = "12412342", Description = "Day la bup be" };
                var p2 = new Product() { ProductName = "Kep toc", Price = 16500, ImageProduct = null, BarCode = "4635342", Description = "Day la kep toc" };
                var p3 = new Product() { ProductName = "Dep quai ngang", Price = 25000, ImageProduct = null, BarCode = "185673362", Description = "Day la dep quai ngang" };
                var p4 = new Product() { ProductName = "Vi da", Price = 11000, ImageProduct = null, BarCode = "74874564", Description = "Day la vi da" };
                var p5 = new Product() { ProductName = "Op dien thoai", Price = 5000, ImageProduct = null, BarCode = "135365776", Description = "Day la op dien thoai" };


                this.Products.Add(p1);
                this.Products.Add(p2);
                this.Products.Add(p3);
                this.Products.Add(p4);
                this.Products.Add(p5);


                this.SaveChanges();
            }
            if (this.Categories.Count() <= 0)
            {
                var c1 = new Category() { CategoryName = "Thoi trang" };
                var c2 = new Category() { CategoryName = "Gau bong" };
                var c3 = new Category() { CategoryName = "Phu kien" };


                this.Categories.Add(c1);
                this.Categories.Add(c2);
                this.Categories.Add(c3);


                this.SaveChanges();
            }
        }
    }
}