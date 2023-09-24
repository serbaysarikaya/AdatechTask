using AdatechTask.Entities.Concrete;
using AdatechTask.Shared.Entities.Abstract;

namespace AdatechTask.Entities.Dtos
{
    public class BookListDto : DtoGetBase
    {
        public IList<Book> Books { get; set; }


    }
}
