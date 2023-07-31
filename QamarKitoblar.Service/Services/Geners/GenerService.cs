using QamarKitoblar.DataAccess.Interfaces.Geners;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Domain.Exceptions.Geners;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Geners;

namespace QamarKitoblar.Service.Services.Geners;

public class GenerService : IGenerService
{
    private readonly IGenerRepository _generRepository;
    private readonly IPaginator _paginator;

    public GenerService(IGenerRepository generRepository, IPaginator paginator)
    {
        this._generRepository = generRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync()
    {
        var result = await _generRepository.CountAsync();
        return result;
    }

    public async Task<bool> CreateAsync(GenerCreateDto dto)
    {
        Gener gener = new Gener()
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _generRepository.CreateAsync(gener);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long GenerId)
    {
        var resultDel = await _generRepository.GetByIdAsync(GenerId);
        if (resultDel is null) { throw new GenerNotFoundException(); }
        var result = await _generRepository.DeleteAsync(GenerId);
        return result > 0;
    }

    public async Task<IList<Gener>> GetAllAsync(PaginationParams @params)
    {
        var result = await _generRepository.GetAllAsync(@params);
        var count = await _generRepository.CountAsync();
        _paginator.Paginate(count, @params);
        return result;
    }

    public async Task<Gener> GetByIdAsync(long GenerId)
    {
        var result = await _generRepository.GetByIdAsync(GenerId);
        if (result == null) { throw new GenerNotFoundException(); }
        else { return result; }
    }

    public async Task<bool> UpdateAsync(long GenerId, GenerUpdateDto dto)
    {
        var gener = await _generRepository.GetByIdAsync(GenerId);
        if (gener is null) throw new GenerNotFoundException();

        gener.Name = dto.Name;
        gener.Description = dto.Description;
        gener.CreatedAt = gener.CreatedAt;
        gener.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _generRepository.UpdateAsync(GenerId, gener);
        return result > 0;

    }

}
