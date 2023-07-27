using QamarKitoblar.DataAccess.Interfaces.Books;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.DataAccess.ViewModels.BooksVM;
using QamarKitoblar.Domain.Entities.Books;
using QamarKitoblar.Domain.Entities.Publishers;
using QamarKitoblar.Domain.Exceptions.Books;
using QamarKitoblar.Domain.Exceptions.File;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Books;
using QamarKitoblar.Service.Interafaces.Books;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;

    public BookService(IBookRepository bookRepository, IFileService fileService, IPaginator paginator) 
    {
        this._repository = bookRepository;
        this._fileService = fileService;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync()
    {
        var result=await _repository.CountAsync();
        return result;
    }

    public async Task<bool> CreateAsync(BookCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.ImagePath);
        Book book = new Book()
        {
            Name = dto.Name,
            Author = dto.Author,
            ImagePath = imagepath,
            UnitPrice = dto.UnitPrice,
            IsHaveElectron = dto.IsHaveElectron,
            GenerId = dto.GenerId,
            PublisherId = dto.PublisherId,
            Description =dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt=TimeHelper.GetDateTime()
            
        };
        var result = await _repository.CreateAsync(book);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long BookId)
    {
        var resultGet=await _repository.GetByIdAsync(BookId);
        if (resultGet is null) { throw new BookNotFoundException(); }

        var result = await _fileService.DeleteImageAsync(resultGet.ImagePath);
        if (result == false) { throw new ImageNotFoundException(); }

        var resultDel = await _repository.DeleteAsync(BookId);
        return resultDel > 0;
    }

    public async Task<IList<BookViewModel>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return result;
    }

    public async Task<BookViewModel> GetByIdAsync(long BookId)
    {
        var result=await _repository.GetByIdAsync(BookId);
        if(result is null) { throw new BookNotFoundException(); }
        else { return result; }
    }

    public async Task<(long ItemsCount, IList<BookViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        var result = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return result;
    }

    public async Task<bool> UpdateAsync(long BookId, BookUpdateDto dto)
    {
        var book=await _repository.GetByIdCheckBook(BookId);
        if(book is null) { throw new BookNotFoundException(); }

        if (dto.ImagePath is not null)
        {
            //Delete old image
            var deleteResult = await _fileService.DeleteImageAsync(book.ImagePath);
            if (deleteResult == false) { throw new ImageNotFoundException(); }

            //Upload image

            var newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);

            //save new path in publisher
            book.ImagePath = newImagePath;
        }

        book.Name = dto.Name;
        book.Author= dto.Author;
        book.IsHaveElectron = dto.IsHaveElectron;
        book.UnitPrice=dto.UnitPrice;
        book.GenerId= dto.GenerId;
        book.PublisherId=dto.PublisherId;

        //update time in UpdatedAt column
        book.UpdatedAt = TimeHelper.GetDateTime();

        var dvResult = await _repository.UpdateAsync(BookId, book);

        return dvResult > 0;
    }
}
