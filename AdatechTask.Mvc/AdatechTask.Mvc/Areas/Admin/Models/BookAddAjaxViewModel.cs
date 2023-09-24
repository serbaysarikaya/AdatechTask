using AdatechTask.Entities.Dtos;

namespace AdatechTask.Mvc.Areas.Admin.Models
{
    public class BookAddAjaxViewModel
    {
        public BookAddDto BookAddDto { get; set; }
        public string BookAddPartial { get; set; }
        public BookDto BookDto { get; set; }

    }
}
