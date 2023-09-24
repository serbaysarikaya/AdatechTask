using AdatechTask.Data.Abstract;
using AdatechTask.Data.Concrete.EntityFramework.Contexts;
using AdatechTask.Data.Concrete.EntityFramework.Repositories;

namespace AdatechTask.Data.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdatechTaskContext _context;
        private readonly EfBookRepository _bookRepository;

        public UnitOfWork(AdatechTaskContext context)
        {
            _context = context;
        }

        public IBookRepository Books => _bookRepository ?? new EfBookRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
