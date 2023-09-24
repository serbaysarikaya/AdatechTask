using AdatechTask.Entities.Dtos;
using AdatechTask.Mvc.Areas.Admin.Models;
using AdatechTask.Services.Abstract;
using AdatechTask.Shared.Utilities.Extensions;
using AdatechTask.Shared.Utilities.Results.ComplexTypes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AdatechTask.Mvc.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookService.GetAllByNonDeletedAsync();
            return View(result.Data);
        }

        public async Task<JsonResult> GetAllBooks()
        {
            var result = await _bookService.GetAllByNonDeletedAsync();
            var books = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });

            return Json(books);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return PartialView("_BookAddPartial");

        }

        [HttpPost]
        public async Task<IActionResult> Add(BookAddDto bookAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookService.AddAsync(bookAddDto, "Serbay S.");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var bookAddAjaxModel = JsonSerializer.Serialize(new BookAddAjaxViewModel
                    {
                        BookDto = result.Data,
                        BookAddPartial = await this.RenderViewToStringAsync("_BookAddPartial", bookAddDto)
                    });
                    return Json(bookAddAjaxModel);
                }

            }
            var bookAjaxErrorModel = JsonSerializer.Serialize(new BookAddAjaxViewModel
            {
                BookAddPartial = await this.RenderViewToStringAsync("_BookAddPartial", bookAddDto)
            });
            return Json(bookAjaxErrorModel);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int bookId)
        {
            var result = await _bookService.DeleteAsync(bookId, "Serbay S.");
            var deletedBook = JsonSerializer.Serialize(result.Data);
            return Json(deletedBook);
        }

        [HttpGet]
        public IActionResult DownloadCsv()
        {
            try
            {
                var result = _bookService.GetAllByNonDeletedAsync().Result;
                var books = result.Data.Books;

                if (books != null)
                {
                    // CSV verilerini oluşturun ve bir dosya haline getirin
                    var csvData = "İşlemler,ID,Kitap Adı,Yazar,Yayın Tarihi,ISBN,Kitap Kategorisi,Sayfa Sayısı,Yayınevi,Aktif Mi?,Silinmiş Mi?,Kayıt Tarihi,Kayıt eden Kullanıcı,Düzenlenme Tarihi,Düzenleyen Kullanıcı\n";

                    foreach (var book in books)
                    {
                        // Her satırı CSV verisine ekleyin
                        csvData += $" ,{book.Id},{book.Title},{book.Author},{book.PublicationDate.ToShortDateString()},{book.ISBN},{book.Category},{book.PageCount},{book.Publisher},{(book.IsActive ? "Evet" : "Hayır")},{(book.IsDeleted ? "Evet" : "Hayır")},{book.CreatedDate.ToShortDateString()},{book.CreatedByName},{book.ModifiedDate.ToShortDateString()},{book.ModifiedByName}\n";
                    }

                    var bytes = Encoding.UTF8.GetBytes(csvData);
                    var stream = new MemoryStream(bytes);

                    // Dosyayı kullanıcıya indirme olarak sunun
                    return File(stream, "text/csv", "kitaplar.csv");
                }
                else
                {
                    return Content("CSV verileri bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunu işleyin ve uygun bir şekilde günlüğe kaydedin veya kullanıcıya bir hata mesajı gösterin
                return Content("CSV indirme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int bookId)
        {
            var result = await _bookService.GetBookUpdateDtoAsync(bookId);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_BookUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateDto bookUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookService.UpdateAsync(bookUpdateDto, "Serbay Sarıkaya");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var bookUpdateAjaxModel = JsonSerializer.Serialize(new BookUpdateAjaxViewModel
                    {
                        BookDto = result.Data,
                        BookUpdatePartial = await this.RenderViewToStringAsync("_BookUpdatePartial", bookUpdateDto)
                    });
                    return Json(bookUpdateAjaxModel);
                }
            }
            var bookUpdateAjaxErrorModel = JsonSerializer.Serialize(new BookUpdateAjaxViewModel
            {

                BookUpdatePartial = await this.RenderViewToStringAsync("_BookUpdatePartial", bookUpdateDto)
            });
            return Json(bookUpdateAjaxErrorModel);
        }

    }
}
