using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using QamarKitoblar.DataAccess.Interfaces.Publishers;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Publishers;
using QamarKitoblar.Domain.Exceptions.File;
using QamarKitoblar.Domain.Exceptions.Publishers;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Publishers;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Services.Publishers;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _repository;
    private readonly IFileService _fileservice;
    private readonly IPaginator  _paginator;

    public PublisherService(IPublisherRepository publisherRepository, IFileService fileService, IPaginator paginator) 
    {
        this._repository = publisherRepository;
        this._fileservice=fileService;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync()
    {
        var result = await _repository.CountAsync();
        return result;
    }

    public async Task<bool> CreateAsync(PublisherCreateDto dto)
    {
        string imagepath =await _fileservice.UploadImageAsync(dto.ImagePath);
        Publisher publisher = new Publisher()
        {
            Name = dto.Name,
            Description = dto.Description,
            ImagePath = imagepath,
            PhoneNumber=dto.PhoneNumber,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt=TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(publisher);

        return result > 0;

    }

    public async Task<bool> DeleteAsync(long PublisherId)
    {
        var publisher = await _repository.GetByIdAsync(PublisherId);
        if(publisher == null) { throw new PublisherNotFoundException(); }

        var result = await _fileservice.DeleteImageAsync(publisher.ImagePath);
        if (result == false) { throw new ImageNotFoundException(); }

        var dbresult = await _repository.DeleteAsync(PublisherId);
        return dbresult > 0;
    }

    public async Task<IList<Publisher>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return result;
    }

    public async Task<Publisher> GetByIdAsync(long PublisherId)
    {
        var result=await _repository.GetByIdAsync(PublisherId);
        if (result is null) { throw new PublisherNotFoundException(); }
        else { return result; }
    }

    public async Task<bool> UpdateAsync(long PublisherId, PublisherUpdateDto dto)
    {
        var publisher=await _repository.GetByIdAsync(PublisherId);
        if(publisher == null) { throw new PublisherNotFoundException(); }

        publisher.Name= dto.Name;
        publisher.Description= dto.Description;
        if(dto.ImagePath is not null)
        {
            //Delete old image
            var deleteResult = await _fileservice.DeleteImageAsync(publisher.ImagePath);
            if (deleteResult == false) { throw new ImageNotFoundException(); }

            //Upload image

            var newImagePath = await _fileservice.UploadImageAsync(dto.ImagePath);

            //save new path in publisher
            publisher.ImagePath= newImagePath;
        }

        publisher.PhoneNumber = dto.PhoneNumber;

        //update time in UpdatedAt column
        publisher.UpdatedAt = TimeHelper.GetDateTime();

        var dvResult=await  _repository.UpdateAsync(PublisherId, publisher);

        return dvResult > 0;
    }
}
