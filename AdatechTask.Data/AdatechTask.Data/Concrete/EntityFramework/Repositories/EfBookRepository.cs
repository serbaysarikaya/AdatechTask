using AdatechTask.Data.Abstract;
using AdatechTask.Data.Concrete.EntityFramework.Contexts;
using AdatechTask.Entities.Concrete;
using AdatechTask.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AdatechTask.Data.Concrete.EntityFramework.Repositories
{
    public class EfBookRepository : EfEntityRepositoryBase<Book>, IBookRepository
    {
        public EfBookRepository(DbContext context) : base(context) { }

        public async Task<Book> GetAsync(int bookId)
        {
            return await AdatechTaskContext.Books.SingleAsync(b => b.Id == bookId);
        }
        private AdatechTaskContext AdatechTaskContext
        {
            get
            {
                return _context as AdatechTaskContext;
            }
        }
    }
}
