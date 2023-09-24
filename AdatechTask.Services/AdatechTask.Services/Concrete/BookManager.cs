using AdatechTask.Data.Abstract;
using AdatechTask.Entities.Concrete;
using AdatechTask.Entities.Dtos;
using AdatechTask.Services.Abstract;
using AdatechTask.Services.Utilities;
using AdatechTask.Shared.Utilities.Results.Abstract;
using AdatechTask.Shared.Utilities.Results.ComplexTypes;
using AdatechTask.Shared.Utilities.Results.Concrete;
using AutoMapper;

namespace AdatechTask.Services.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<BookDto>> AddAsync(BookAddDto bookAddDto, string createdByName)
        {
            var book = _mapper.Map<Book>(bookAddDto);
            book.CreatedByName = createdByName;
            book.ModifiedByName = createdByName;
            var added = await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveAsync();
            return new DataResult<BookDto>(ResultStatus.Success, Messages.Book.Add(bookAddDto.Title), new BookDto
            {
                Book = book,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Book.Add(bookAddDto.Title)
            });

        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var booksCount = await _unitOfWork.Books.CountAsync();
            if (booksCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, booksCount);
            }
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen Bir hata ile karşılasıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var booksCount = await _unitOfWork.Books.CountAsync(b => !b.IsDeleted);
            if (booksCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, booksCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen Bir hata ile karşılasıldı.", -1);
            }
        }

        public async Task<IDataResult<BookDto>> DeleteAsync(int bookId, string modifiedByName)
        {
            var book = await _unitOfWork.Books.GetAsync(b => b.Id == bookId);
            if (book != null)
            {
                book.IsDeleted = true;
                book.ModifiedByName = modifiedByName;
                book.ModifiedDate = DateTime.Now;
                var deletedBook = await _unitOfWork.Books.UpdateAsync(book);
                await _unitOfWork.SaveAsync();
                return new DataResult<BookDto>(ResultStatus.Success, Messages.Book.Delete(deletedBook.Title), new BookDto
                {
                    Book = deletedBook,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Book.Delete(deletedBook.Title)
                });
            }
            return new DataResult<BookDto>(ResultStatus.Error, Messages.Book.NotFound(isPlural: false), new BookDto
            {
                Book = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Book.NotFound(isPlural: false)
            });
        }

        public async Task<IDataResult<BookListDto>> GetAllAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync(null);
            if (books.Count > -1)
            {

                return new DataResult<BookListDto>(ResultStatus.Success, new BookListDto
                {
                    Books = books,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<BookListDto>(ResultStatus.Error, Messages.Book.NotFound(isPlural: true),
              new BookListDto
              {
                  Books = books,
                  ResultStatus = ResultStatus.Error,
                  Message = Messages.Book.NotFound(isPlural: true)

              });
        }

        public async Task<IDataResult<BookListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync(b => !b.IsDeleted && b.IsActive);
            if (books.Count > -1)
            {

                return new DataResult<BookListDto>(ResultStatus.Success, new BookListDto
                {
                    Books = books,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<BookListDto>(ResultStatus.Error, Messages.Book.NotFound(isPlural: true),
              new BookListDto
              {
                  Books = books,
                  ResultStatus = ResultStatus.Error,
                  Message = Messages.Book.NotFound(isPlural: true)

              });
        }

        public async Task<IDataResult<BookListDto>> GetAllByNonDeletedAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync(b => !b.IsDeleted);
            if (books.Count > -1)
            {

                return new DataResult<BookListDto>(ResultStatus.Success, new BookListDto
                {
                    Books = books,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<BookListDto>(ResultStatus.Error, Messages.Book.NotFound(isPlural: true),
              new BookListDto
              {
                  Books = books,
                  ResultStatus = ResultStatus.Error,
                  Message = Messages.Book.NotFound(isPlural: true)

              });
        }

        public async Task<IDataResult<BookDto>> GetAsync(int bookId)
        {
            var book = await _unitOfWork.Books.GetAsync(b => b.Id == bookId);
            if (book != null)
            {
                return new DataResult<BookDto>(ResultStatus.Success, new BookDto
                {
                    Book = book,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<BookDto>(ResultStatus.Error, Messages.Book.NotFound(isPlural: false), new BookDto
            {
                Book = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Book.NotFound(isPlural: false)
            });
        }

        public async Task<IDataResult<BookUpdateDto>> GetBookUpdateDtoAsync(int bookId)
        {
            var result = await _unitOfWork.Books.AnyAsync(b => b.Id == bookId);
            if (result)
            {
                var book = await _unitOfWork.Books.GetAsync(b => b.Id == bookId);
                var bookUpdateDto = _mapper.Map<BookUpdateDto>(book);
                return new DataResult<BookUpdateDto>(ResultStatus.Success, bookUpdateDto);
            }
            return new DataResult<BookUpdateDto>(ResultStatus.Error, Messages.Book.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int bookId)
        {
            var book = await _unitOfWork.Books.GetAsync(b => b.Id == bookId);
            if (book != null)
            {
                await _unitOfWork.Books.DeleteAsync(book);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Book.HardDelete(book.Title));
            }
            return new Result(ResultStatus.Error, Messages.Book.NotFound(isPlural: false));
        }

        public async Task<IDataResult<BookDto>> UpdateAsync(BookUpdateDto bookUpdateDto, string modifiedByName)
        {
            var oldBook = await _unitOfWork.Books.GetAsync(b => b.Id == bookUpdateDto.Id);
            var book = _mapper.Map<BookUpdateDto, Book>(bookUpdateDto, oldBook);
            book.ModifiedByName = modifiedByName;
            var updateBook = await _unitOfWork.Books.UpdateAsync(book);
            await _unitOfWork.SaveAsync();

            return new DataResult<BookDto>(ResultStatus.Success, Messages.Book.Update(bookUpdateDto.Title), new BookDto
            {
                Book = book,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Book.Update(bookUpdateDto.Title)

            });


        }
    }
}
