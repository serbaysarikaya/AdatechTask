using AdatechTask.Entities.Dtos;
using AdatechTask.Shared.Utilities.Results.Abstract;

namespace AdatechTask.Services.Abstract
{
    public interface IBookService
    {
        public Task<IDataResult<BookDto>> GetAsync(int bookId);

        public Task<IDataResult<BookUpdateDto>> GetBookUpdateDtoAsync(int bookId);
        public Task<IDataResult<BookListDto>> GetAllAsync();
        public Task<IDataResult<BookListDto>> GetAllByNonDeletedAsync();
        public Task<IDataResult<BookListDto>> GetAllByNonDeletedAndActiveAsync();
        public Task<IDataResult<BookDto>> AddAsync(BookAddDto bookAddDto, string createdByName);
        public Task<IDataResult<BookDto>> UpdateAsync(BookUpdateDto bookUpdateDto, string modifiedByName);
        public Task<IDataResult<BookDto>> DeleteAsync(int bookId, string modifiedByName);
        public Task<IResult> HardDeleteAsync(int bookId);
        public Task<IDataResult<int>> CountAsync();
        public Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
