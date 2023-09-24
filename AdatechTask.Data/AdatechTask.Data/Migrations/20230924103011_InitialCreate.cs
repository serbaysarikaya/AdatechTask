using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdatechTask.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CreatedByName", "CreatedDate", "ISBN", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Ahmet Yılmaz", "Programlama", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9656), "978-1234567890", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9657), 400, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "XYZ Yayınevi", "C# Programlama" },
                    { 2, "Mehmet Demir", "Programlama", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9666), "978-0987654321", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9667), 350, new DateTime(2021, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC Yayınevi", "Python Programlama" },
                    { 3, "Ayşe Kaya", "Programlama", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9673), "978-9876543210", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9674), 500, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "DEF Yayınevi", "Java Programlama" },
                    { 4, "Ali Can", "Veri Bilimi", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9680), "978-1357924680", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9681), 300, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GHI Yayınevi", "Veri Bilimi Temelleri" },
                    { 5, "Merve Eren", "Web Geliştirme", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9687), "978-5432109876", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9688), 250, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "JKL Yayınevi", "Web Geliştirme Temelleri" },
                    { 6, "Canan Yıldız", "Mobil Uygulama", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9693), "978-2468135790", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9694), 320, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MNO Yayınevi", "Mobil Uygulama Geliştirme" },
                    { 7, "Selim Kaya", "Yapay Zeka", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9700), "978-7654321098", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9701), 280, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "STU Yayınevi", "Yapay Zeka ve Makine Öğrenimi" },
                    { 8, "Ayşe Yılmaz", "Edebiyat", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9707), "978-8765432109", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9707), 320, new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "UVW Yayınevi", "Edebiyatın Derinlikleri" },
                    { 9, "Emre Can", "Tarih", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9713), "978-9876543210", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9714), 350, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "XYZ Yayınevi", "Tarih Sayfalarında Gezi" },
                    { 10, "Emirhan Aydın", "Tarih", "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9720), "978-3692581470", true, false, "InitialCreate", new DateTime(2023, 9, 24, 13, 30, 11, 163, DateTimeKind.Local).AddTicks(9720), 400, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "PQR Yayınevi", "Bilim ve Teknoloji Tarihi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
