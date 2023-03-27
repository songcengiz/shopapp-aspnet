using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageAuthor = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PaymentId = table.Column<string>(nullable: true),
                    ConversationId = table.Column<string>(nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    OrderState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsHome = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    ISBN = table.Column<int>(nullable: false),
                    NumberOfPage = table.Column<int>(nullable: false),
                    PaperType = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Appellation = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 14, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    ImageLogo = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Translators",
                columns: table => new
                {
                    TranslatorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ImageTranslator = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translators", x => x.TranslatorId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAuthor",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAuthor", x => new { x.AuthorId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAuthor_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPublisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPublisher", x => new { x.PublisherId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductPublisher_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPublisher_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslator",
                columns: table => new
                {
                    TranslatorId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslator", x => new { x.TranslatorId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductTranslator_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTranslator_Translators_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "Translators",
                        principalColumn: "TranslatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 1, null, "7.jpg", "Haluk Yavuzer", "haluk-yavuzer" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 2, null, "8.jpg", "İskender Pala", "iskender-pala" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 3, null, "6.jpg", "Yahya Kemal", "yahya-kemal" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 4, null, "2.jpg", "Sait Faik Abasıyanık", "sait-faik" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 5, null, "1.jpg", "Cengiz Aytmatov", "cengiz-aytmatov" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 6, null, "3.jpg", "Ömer Seyfettin", "ömer-seyfettin" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 7, null, "5.jpg", "Tolstoy", "tolstoy" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Description", "ImageAuthor", "Name", "Url" },
                values: new object[] { 8, null, "4.jpg", "Orhan Kemal", "orhan-kemal" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "Url" },
                values: new object[] { 1, "Ev-Aile-Toplum", "ev-aile-toplum" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "Url" },
                values: new object[] { 2, "Deneme-İnceleme", "deneme-inceleme" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "Url" },
                values: new object[] { 3, "Öykü", "oyku" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "Url" },
                values: new object[] { 4, "Modern Türk Edebiyatı", "modern-turk-edebiyatı" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 8, "Öykü Serisi", 1234533666, "9.jpg", true, false, "Almanca", "İstanbul İstanbul", 250, "3.Hamur", 17.0, "istanbul-istanbul" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 7, "Öykü Serisi", 1234331166, "6.jpg", false, false, "Türkçe", "İnsan Ne İle Yaşar", 900, "Kuşe Kağıt", 33.0, "insan-ne-ile-yasar" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 6, "Öykü Serisi", 12345996, "4.jpg", true, false, "Türkçe", "Falaka", 800, "3.Hamur", 49.0, "falaka" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 5, "Öykü Serisi", 12344666, "2.jpg", true, false, "İngilizce", "Toprak Ana", 600, "1.Hamur", 17.0, "toprak-ana" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 2, "Deneme-İnceleme Serisi", 1230066, "5.jpg", true, false, "Türkçe", "Bülbülün Kırk Şarkısı", 300, "Kuşe Kağıt", 19.0, "bulbulun-kırk-sarkısı" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 3, "Deneme-İnceleme Serisi", 12345666, "3.jpg", true, false, "Türkçe", "Aziz İstanbul", 400, "1.Hamur", 49.0, "aziz-istanbul" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 1, "Ev-Aile-Toplum Serisi", 123456776, "7.jpg", true, false, "Türkçe", "Mutlu Yaşlanmak", 200, "Kuşe Kağıt", 17.0, "mutlu-yaslanmak" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ISBN", "ImageUrl", "IsApproved", "IsHome", "Language", "Name", "NumberOfPage", "PaperType", "Price", "Url" },
                values: new object[] { 4, "Modern Türk Edebiyatı Serisi", 1211300666, "8.jpg", false, false, "Türkçe", "Lüzumsuz Adam", 500, "2.Hamur", 33.0, "luzumsuz-adam" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Address", "Appellation", "Description", "Email", "ImageLogo", "Name", "Phone", "Url", "Website" },
                values: new object[] { 1, null, "Yapı Kredi Yayınları Ltd. Şti", null, "iletisim@ykykultur.com.tr", "4.jpg", "Yapı Kredi Yayınları", null, "yapi-kredi", "www.yapikrediyayinlari.com.tr/iletisim" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Address", "Appellation", "Description", "Email", "ImageLogo", "Name", "Phone", "Url", "Website" },
                values: new object[] { 2, null, "Can Sanat Yayınları Ltd. Şti", null, null, "1.jpg", "Can Yayınları", null, "can", "https://www.canyayinlari.com/" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Address", "Appellation", "Description", "Email", "ImageLogo", "Name", "Phone", "Url", "Website" },
                values: new object[] { 3, null, "Doğan Yayınları Ltd. Şti", null, null, "2.jpg", "Doğan Yayınları", null, "dogan", "www.dogankitap.com.tr" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Address", "Appellation", "Description", "Email", "ImageLogo", "Name", "Phone", "Url", "Website" },
                values: new object[] { 4, null, "Remzi Yayınları Ltd. Şti", null, "post@remzi.com.tr", "3.jpg", "Remzi Yayınları", "212 - 282 - 20 - 80", "remzi", "www.remzi.com.tr" });

            migrationBuilder.InsertData(
                table: "Translators",
                columns: new[] { "TranslatorId", "Description", "ImageTranslator", "Name", "Url" },
                values: new object[] { 2, null, "1.jpg", "Veysel Ataman", "veysel-ataman" });

            migrationBuilder.InsertData(
                table: "Translators",
                columns: new[] { "TranslatorId", "Description", "ImageTranslator", "Name", "Url" },
                values: new object[] { 1, null, "3.jpg", "Zeynep Arık", "zeynep-arik" });

            migrationBuilder.InsertData(
                table: "Translators",
                columns: new[] { "TranslatorId", "Description", "ImageTranslator", "Name", "Url" },
                values: new object[] { 3, null, "2.jpg", "Özgür Orhangazi", "ozgur-orhangazı" });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 8, 8 });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 7, 7 });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "ProductAuthor",
                columns: new[] { "AuthorId", "ProductId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 2, 3, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 3, 7, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 3, 6, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 3, 8, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 3, 5, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 4, 4, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 2, 2, 0 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "PublisherId" },
                values: new object[] { 4, 1, 0 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 3, 7 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 3, 8 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "ProductPublisher",
                columns: new[] { "PublisherId", "ProductId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "ProductTranslator",
                columns: new[] { "TranslatorId", "ProductId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "ProductTranslator",
                columns: new[] { "TranslatorId", "ProductId" },
                values: new object[] { 2, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAuthor_ProductId",
                table: "ProductAuthor",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPublisher_ProductId",
                table: "ProductPublisher",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslator_ProductId",
                table: "ProductTranslator",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductAuthor");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductPublisher");

            migrationBuilder.DropTable(
                name: "ProductTranslator");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Translators");
        }
    }
}
