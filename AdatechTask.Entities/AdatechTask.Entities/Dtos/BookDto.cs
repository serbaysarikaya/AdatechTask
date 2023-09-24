using AdatechTask.Entities.Concrete;
using AdatechTask.Shared.Entities.Abstract;

namespace AdatechTask.Entities.Dtos
{
    public class BookDto : DtoGetBase
    {
        public Book Book { get; set; }
    }
}
