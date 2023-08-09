﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asp07Store.ShopUI.Migrations
{
    /// <inheritdoc />
    public partial class addCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "موبایل" },
                    { 2, "لپ تاپ" },
                    { 3, "کامپیوتر" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "  گوشی‌های هوشمند خانواده آیفون 13 در قالب چهار گوشی آیفون 13 پرو مکس، آیفون 13 پرو، آیفون 13 و آیفون 13 مینی معرفی شدند. بدون شک دو مدل پرو و پرو مکس به عنوان پرچمداران این شرکت از مشخصات فنی قدرتمند‌تری بهره برده‌اند. اما در این میان آیفون 13 به همراه مدل مینی با قیمتی مقرون‌به‌صرفه‌تر روانه بازار شده‌اند تا امکان خرید برای کاربران بیشتری امکان‌پذیر باشد. در این مقاله خواهیم دید که آیفون 13 به نسبت نسل قبلی چه مشخصاتی با خود به‌همراه داشته و در بخش‌های مختلف چه عملکردی را از خودش به‌نمایش می‌گذارد. شاید با توجه به مشخصات تقریبا مشابه آیفون 13 و آیفون 12، این سوال برای شما به وجود آید که چرا آیفون 13 می‌تواند عملکرد بهتری داشته باشد. پس با ما همراه باشید تا به دلایل عملکرد بهتر و قدرتمند‌تر آیفون 13 به نسبت آیفون 12 پی ببرید.", "گوشی موبایل اپل مدل iPhone 13 CH دو سیم‌ کارت ظرفیت 128 گیگابایت و رم 4 گیگابایت - نات اکتیو", 38850000 },
                    { 2, 1, "بدون هیچ تعریف اضافی باید بگوییم که گوشی‌های میان‌رده سری Redmi شرکت شیائومی توانسته‌اند عملکرد بسیار خوبی را به‌نمایش بگذارند. در این میان شاهد رونمایی برخی از محصولاتی بودیم که در برخی از مشخصات فنی در نظر گرفته شده چیزی کم از یک پرچمدار نداشتند. Redmi Note 12 4G هم یکی از این گوشی‌های هوشمند میان‌رده قدرتمند است که به نسبت قیمت در نظر گرفته شده، عملکرد بسیار خوبی را به‌نمایش گذاشته است. این گوشی به صفحه‌نمایش با ابعاد 6.67 اینچ و رزولوشن 1080×2400 پیکسل از نوع امولد مجهز ش", "گوشی موبایل شیائومی مدل Redmi Note 12 4G دو سیم کارت ظرفیت 128 گیگابایت و رم 8 گیگابایت - گلوبال", 76990000 },
                    { 3, 1, "سامسونگ در زمینه گوشی‌های هوشمند میان‌رده تا به امروز توانسته است با معرفی محصولاتی با مشخصات فنی مناسب و قیمتی مقرون به‌صرفه، عملکرد بسیار خوبی را به نمایش بگذارد. سامسونگ Galaxy A34 5G هم یکی از این گوشی‌های هوشمند دوست داشتنی این شرکت است. صفحه‌نمایش جذاب و قدرتمند 6.6 اینچی این گوشی با رزولوشن بسیار خوب و نرخ بروزرسانی فوق‌العاده 120 هرتز، چیزی کم از یک پرچمدار ندارد و سامسونگ دوباره ثابت کرد که در زمینه صفحه‌نمایش هنوز هم حرف‌های بسیاری برای گفتن دارد.", "گوشی موبایل سامسونگ مدل Galaxy A34 5G دو سیم کارت ظرفیت 128 گیگابایت و رم 8 گیگابایت", 11090000 },
                    { 4, 1, "اگر به دنبال خرید گوشی هوشمند میان‌رده‌ای هستید که در کنار بهره بردن از مشخصات فنی قدرتمند، قیمت مقرون به‌صرفه‌ای هم داشته باشد، بدون شک گوشی‌های سری poco شیائومی می‌توانند انتخاب بسیار خوبی باشند. یکی از این گوشی‌های با‌کیفین، Poco F5 است که بدون هیچ تعریف اضافی باید بگوییم که از مشخصات فنی قدرتمندی بهره برده است. صفحه‌نمایش 6.67 اینچی این گوشی با رزولوشن 1080×2400 پیکسل از نوع امولد که توانایی ارائه نرخ بروزرسانی 120 هرتز و حداکثر روشنایی 1000 نیت (nits) را دارد،", "گوشی موبایل شیائومی مدل Poco F5 دو سیم کارت ظرفیت 256 گیگابایت و رم 12 گیگابایت - گلوبال", 19299000 },
                    { 5, 2, "امکان برگشت کالا در گروه لپ‌تاپ و الترابوک با دلیل \"انصراف از خرید\" تنها در صورتی مورد قبول است که کالا در شرایط اولیه باشد (در صورت پلمپ بودن، کالا نباید باز شده باشد). تغییرات ایجادشده در لپ‌تاپ‌های کاستوم (برای مثال ارتقا هارد، رم و...) توسط شرکت گارانتی‌کننده و به صورت رسمی انجام شده است و شامل گارانتی می‌شوند. لپ تاپ کاستوم به معنی ارتقا فنی بعضی قطعات لپ تاپ نو (آکبند) و بر اساس استاندارد شرکت تولیدکننده است، لطفا برای اطلاعات بیشتر در این مورد، به سوالات متداول مراجعه فرمایید.", "لپ تاپ 12.4 اینچی مایکروسافت مدل Surface Laptop Go-i5 4GB 64SSD", 235000000 },
                    { 6, 2, "سری پردازنده :\r\n\r\nCore i3\r\n\r\nظرفیت حافظه RAM :\r\n\r\nچهار گیگابایت\r\n\r\nظرفیت حافظه داخلی :\r\n\r\nیک ترابایت\r\n\r\nسازنده پردازنده گرافیکی :\r\n\r\nIntel\r\n\r\nدقت صفحه نمایش :\r\n\r\n1080 × 1920 پیکسل - Full HD", "لپ تاپ 15.6 اینچی لنوو مدل IdeaPad 3 15ITL6-i3 4GB 1HDD", 13190000 },
                    { 7, 2, "سری پردازنده :\r\n\r\nCeleron\r\n\r\nظرفیت حافظه RAM :\r\n\r\nچهار گیگابایت\r\n\r\nظرفیت حافظه داخلی :\r\n\r\n256 گیگابایت\r\n\r\nسازنده پردازنده گرافیکی :\r\n\r\nIntel\r\n\r\nدقت صفحه نمایش :\r\n\r\nHD|1366x768", "لپ تاپ 14 اینچی ایسوس مدل Vivobook E410MA-BV1517", 117900000 },
                    { 8, 2, "سری پردازنده :\r\n\r\nCore i7\r\n\r\nظرفیت حافظه RAM :\r\n\r\n16 گیگابایت\r\n\r\nظرفیت حافظه داخلی :\r\n\r\nیک ترابایت و 512 گیگابایت\r\n\r\nسازنده پردازنده گرافیکی :\r\n\r\nNVIDIA\r\n\r\nدقت صفحه نمایش :\r\n\r\n1080 × 1920 پیکسل - Full HD", "لپ تاپ 15.6 اینچی ایسوس مدل X515JP-EJ408-i7 16GB 1HDD 512SSD MX330 - کاستوم شده", 32090000 },
                    { 9, 3, "سری پردازنده :\r\n\r\nCore i3\r\n\r\nظرفیت حافظه RAM :\r\n\r\nهشت گیگابایت\r\n\r\nظرفیت حافظه داخلی :\r\n\r\n240 گیگابایت\r\n\r\nحافظه اختصاصی کارت گرافیک :\r\n\r\nبدون حافظه اختصاصی مجزا\r\n\r\nدقت صفحه نمایش :\r\n\r\n1080 × 1920 پیکسل - Full HD", "کامپیوتر همه کاره 24 اینچ اینوورس مدل X2414B - A", 26000000 },
                    { 10, 3, "سری پردازنده :\r\n\r\nCore i7\r\n\r\nظرفیت حافظه RAM :\r\n\r\n8 گیگابایت\r\n\r\nظرفیت حافظه داخلی :\r\n\r\n512 گیگابایت\r\n\r\nحافظه اختصاصی کارت گرافیک :\r\n\r\nهشت گیگابایت\r\n\r\nدقت صفحه نمایش :\r\n\r\nپیکسل 2880 × 5120", " کامپیوتر همه کاره 27 اینچی اپل مدل iMac MXWV2 2020 با صفحه نمایش رتینا 5K ", 30000000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}