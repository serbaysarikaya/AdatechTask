using AdatechTask.Entities.Concrete;
using AdatechTask.Shared.Data.Abstract;

namespace AdatechTask.Data.Abstract
{
    public interface IBookRepository : IEntityRepository<Book>
    {
        Task<Book> GetAsync(int bookId);
    }
}
