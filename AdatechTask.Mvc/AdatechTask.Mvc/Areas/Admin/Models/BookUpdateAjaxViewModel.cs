using AdatechTask.Entities.Dtos;

namespace AdatechTask.Mvc.Areas.Admin.Models
{
    public class BookUpdateAjaxViewModel
    {
        public BookUpdateDto BookUpdateDto { get; set; }
        public string BookUpdatePartial { get; set; }
        public BookDto BookDto { get; set; }

    }
}
