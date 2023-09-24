using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdatechTask.Entities.Dtos
{
    public class BookAddDto
    {
        [DisplayName("Kitap Adı")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} {1} de büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} den kücük olmamalıdır")]
        public string Title { get; set; }

        [DisplayName("Yazarı")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} de büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} den kücük olmamalıdır")]
        public string Author { get; set; }

        [DisplayName("Yayın Tarihi")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        public DateTime PublicationDate { get; set; }

        [DisplayName("ISBN")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} de büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} den kücük olmamalıdır")]
        public string ISBN { get; set; }

        [DisplayName("Kitap Kategorisi")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} de büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} den kücük olmamalıdır")]
        public string Category { get; set; }

        [DisplayName("Sayfa Adedi")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        public int PageCount { get; set; }

        [DisplayName("Yayın evi")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} de büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} den kücük olmamalıdır")]
        public string Publisher { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        public bool IsActive { get; set; }
    }
}
