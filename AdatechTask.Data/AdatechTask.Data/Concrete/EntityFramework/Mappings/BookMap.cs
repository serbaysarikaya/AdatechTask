using AdatechTask.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdatechTask.Data.Concrete.EntityFramework.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Title).HasMaxLength(70);
            builder.Property(b => b.Author).IsRequired();
            builder.Property(b => b.Author).HasMaxLength(100);
            builder.Property(b => b.PublicationDate).IsRequired();
            builder.Property(b => b.ISBN).IsRequired();
            builder.Property(b => b.ISBN).HasMaxLength(100);
            builder.Property(b => b.Category).IsRequired();
            builder.Property(b => b.Category).HasMaxLength(100);
            builder.Property(b => b.PageCount).IsRequired();
            builder.Property(b => b.Publisher).IsRequired();
            builder.Property(b => b.Publisher).HasMaxLength(100);
            builder.Property(b => b.CreatedByName).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50);
            builder.Property(b => b.ModifiedByName).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.ToTable("Books");
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "C# Programlama",
                    Author = "Ahmet Yılmaz",
                    PublicationDate = DateTime.Parse("2022-01-15"),
                    ISBN = "978-1234567890",
                    Category = "Programlama",
                    PageCount = 400,
                    Publisher = "XYZ Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 2,
                    Title = "Python Programlama",
                    Author = "Mehmet Demir",
                    PublicationDate = DateTime.Parse("2021-12-20"),
                    ISBN = "978-0987654321",
                    Category = "Programlama",
                    PageCount = 350,
                    Publisher = "ABC Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 3,
                    Title = "Java Programlama",
                    Author = "Ayşe Kaya",
                    PublicationDate = DateTime.Parse("2022-03-10"),
                    ISBN = "978-9876543210",
                    Category = "Programlama",
                    PageCount = 500,
                    Publisher = "DEF Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 4,
                    Title = "Veri Bilimi Temelleri",
                    Author = "Ali Can",
                    PublicationDate = DateTime.Parse("2022-02-28"),
                    ISBN = "978-1357924680",
                    Category = "Veri Bilimi",
                    PageCount = 300,
                    Publisher = "GHI Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 5,
                    Title = "Web Geliştirme Temelleri",
                    Author = "Merve Eren",
                    PublicationDate = DateTime.Parse("2022-04-15"),
                    ISBN = "978-5432109876",
                    Category = "Web Geliştirme",
                    PageCount = 250,
                    Publisher = "JKL Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 6,
                    Title = "Mobil Uygulama Geliştirme",
                    Author = "Canan Yıldız",
                    PublicationDate = DateTime.Parse("2022-03-01"),
                    ISBN = "978-2468135790",
                    Category = "Mobil Uygulama",
                    PageCount = 320,
                    Publisher = "MNO Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 7,
                    Title = "Yapay Zeka ve Makine Öğrenimi",
                    Author = "Selim Kaya",
                    PublicationDate = DateTime.Parse("2022-06-10"),
                    ISBN = "978-7654321098",
                    Category = "Yapay Zeka",
                    PageCount = 280,
                    Publisher = "STU Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 8,
                    Title = "Edebiyatın Derinlikleri",
                    Author = "Ayşe Yılmaz",
                    PublicationDate = DateTime.Parse("2022-06-20"),
                    ISBN = "978-8765432109",
                    Category = "Edebiyat",
                    PageCount = 320,
                    Publisher = "UVW Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 9,
                    Title = "Tarih Sayfalarında Gezi",
                    Author = "Emre Can",
                    PublicationDate = DateTime.Parse("2022-07-05"),
                    ISBN = "978-9876543210",
                    Category = "Tarih",
                    PageCount = 350,
                    Publisher = "XYZ Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                },
                new Book
                {
                    Id = 10,
                    Title = "Bilim ve Teknoloji Tarihi",
                    Author = "Emirhan Aydın",
                    PublicationDate = DateTime.Parse("2022-05-20"),
                    ISBN = "978-3692581470",
                    Category = "Tarih",
                    PageCount = 400,
                    Publisher = "PQR Yayınevi",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now
                });
        }
    }
}
