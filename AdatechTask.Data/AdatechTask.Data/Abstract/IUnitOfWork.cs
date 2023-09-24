namespace AdatechTask.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IBookRepository Books { get; }
        public Task<int> SaveAsync();
    }
}
