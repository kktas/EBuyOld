using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.EF_Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Brand)
                .WithOne(s=>s.User).OnDelete(DeleteBehavior.NoAction); ;

            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.CartItems)
            //    .WithOne(c=>c.Product).OnDelete(DeleteBehavior.NoAction); ;

            modelBuilder.Entity<Role>().HasData(new Role[]
                {
                    new Role { Id = 1, RoleName = "Satıcı", Users = new List<User>() },
                    new Role { Id = 2, RoleName = "Alıcı", Users = new List<User>() },
                });

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, FirstName = "Ahmet Enes", LastName = "Ograğ", Email = "enesograg@gmail.com", Password ="aeo1234",RoleId = 1 },
                new User { Id = 2, FirstName = "Kaan Kerim", LastName = "Taş", Email = "kaankerimtas@gmail.com", Password ="kkt1234", RoleId = 1 },
                new User { Id = 3, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", Password="jd1234", RoleId = 2 },
                new User { Id = 4, FirstName = "Alice", LastName = "Smith", Email = "alicesmith@gmail.com", Password="as1234", RoleId = 2 }
            });

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand{Id=1, BrandName="Brand1", UserId=1},
                new Brand{Id=2, BrandName="Brand2", UserId=2}
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
           {
                new Product{Id=1, ProductName="Product1", BrandId=1, ImageName="brand1-product1.jpg", Stock=10, Price=1.00, DetailText= "Product1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit."},
                new Product{Id=2, ProductName="Product2", BrandId=2, ImageName="brand1-product2.jpg", Stock=20, Price=2.00, DetailText= "Product2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit."},
                new Product{Id=3, ProductName="Product3", BrandId=1, ImageName="brand1-product3.jpg", Stock=30, Price=3.00, DetailText= "Product3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit."},

                new Product{Id=4, ProductName="Product4", BrandId=2, ImageName="brand2-product4.jpg", Stock=40, Price=4.00, DetailText= "Product4 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit."},
                new Product{Id=5, ProductName="Product5", BrandId=1, ImageName="brand2-product5.jpg", Stock=50, Price=5.00, DetailText= "Product5 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit."},
                new Product{Id=6, ProductName="Product6", BrandId=2, ImageName="brand2-product6.jpg", Stock=60, Price=6.00, DetailText= "Product6 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit."}
           });


            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer{Id=1, UserId=3},
                new Customer{Id=2, UserId=4},
            });


            modelBuilder.Entity<Sale>().HasData(new Sale[]
           {
                new Sale{Id=1, CustomerId=1, ProductId=1, Amount=1, TotalPrice =1.00, Date= new DateTime(2022,8,15,14,39,47)},
                new Sale{Id=2, CustomerId=2, ProductId=2, Amount=2, TotalPrice =4.00, Date= new DateTime(2022,7,7,8,42,21)},
                new Sale{Id=3, CustomerId=1, ProductId=3, Amount=3, TotalPrice =9.00, Date= new DateTime(2022,6,5,17,53,53)},

                new Sale{Id=4, CustomerId=2, ProductId=4, Amount=4, TotalPrice =16.00, Date= new DateTime(2022,5,18,23,36,6)},
                new Sale{Id=5, CustomerId=1, ProductId=5, Amount=5, TotalPrice =25.00, Date= new DateTime(2022,4,22,13,15,32)},
                new Sale{Id=6, CustomerId=2, ProductId=6, Amount=6, TotalPrice =36.00, Date= new DateTime(2022,3,10,11,22,14)},
           });

            modelBuilder.Entity<CartItem>().HasData(new CartItem[]
           {
                new CartItem{Id=1, ProductId=1, Amount=5, TotalPrice=5.00, CustomerId=1},
                new CartItem{Id=2, ProductId=2, Amount=5, TotalPrice=10.00, CustomerId=2},
                new CartItem{Id=3, ProductId=3, Amount=5, TotalPrice=15.00, CustomerId=1},

                new CartItem{Id=4, ProductId=4, Amount=5, TotalPrice=20.00, CustomerId=2},
                new CartItem{Id=5, ProductId=5, Amount=5, TotalPrice=25.00, CustomerId=1},
                new CartItem{Id=6, ProductId=6, Amount=5, TotalPrice=30.00, CustomerId=2},
           });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=EBuy; Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public Context()
        {
        }
        public Context(DbContextOptions s) : base(s)
        {
        }
    }
}
