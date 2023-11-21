using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EBuy.DAL.Migrations
{
    public partial class ic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 1, "Satıcı" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 2, "Alıcı" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "enesograg@gmail.com", "Ahmet Enes", "Ograğ", "aeo1234", 1 },
                    { 2, "kaankerimtas@gmail.com", "Kaan Kerim", "Taş", "kkt1234", 1 },
                    { 3, "johndoe@gmail.com", "John", "Doe", "jd1234", 2 },
                    { 4, "alicesmith@gmail.com", "Alice", "Smith", "as1234", 2 }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName", "UserId" },
                values: new object[,]
                {
                    { 1, "Brand1", 1 },
                    { 2, "Brand2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "DetailText", "ImageName", "Price", "ProductName", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Product1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit.", "brand1-product1.jpg", 1.0, "Product1", 10 },
                    { 3, 1, "Product3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit.", "brand1-product3.jpg", 3.0, "Product3", 30 },
                    { 5, 1, "Product5 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit.", "brand2-product5.jpg", 5.0, "Product5", 50 },
                    { 2, 2, "Product2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit.", "brand1-product2.jpg", 2.0, "Product2", 20 },
                    { 4, 2, "Product4 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit.", "brand2-product4.jpg", 4.0, "Product4", 40 },
                    { 6, 2, "Product6 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo convallis condimentum. Suspendisse potenti. Vestibulum facilisis risus vitae turpis tempus, ut commodo turpis iaculis. Pellentesque eleifend neque id malesuada ultricies. Duis egestas velit sit amet arcu interdum, vel luctus risus commodo. Aenean a purus vitae libero mollis laoreet. Nulla pretium arcu ut est venenatis feugiat. Proin eget dolor at libero luctus consequat eu et lectus. Aenean vitae justo in lectus congue hendrerit.", "brand2-product6.jpg", 6.0, "Product6", 60 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "Amount", "CustomerId", "ProductId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, 5.0 },
                    { 3, 5, 1, 3, 15.0 },
                    { 5, 5, 1, 5, 25.0 },
                    { 2, 5, 1, 2, 10.0 },
                    { 4, 5, 1, 4, 20.0 },
                    { 6, 5, 1, 6, 30.0 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "CustomerId", "Date", "ProductId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 8, 15, 14, 39, 47, 0, DateTimeKind.Unspecified), 1, 1.0 },
                    { 3, 3, 1, new DateTime(2022, 6, 5, 17, 53, 53, 0, DateTimeKind.Unspecified), 3, 9.0 },
                    { 5, 5, 2, new DateTime(2022, 4, 22, 13, 15, 32, 0, DateTimeKind.Unspecified), 5, 25.0 },
                    { 2, 2, 1, new DateTime(2022, 7, 7, 8, 42, 21, 0, DateTimeKind.Unspecified), 2, 4.0 },
                    { 4, 4, 2, new DateTime(2022, 5, 18, 23, 36, 6, 0, DateTimeKind.Unspecified), 4, 16.0 },
                    { 6, 6, 2, new DateTime(2022, 3, 10, 11, 22, 14, 0, DateTimeKind.Unspecified), 6, 36.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserId",
                table: "Brands",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CustomerId",
                table: "CartItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
