using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using QamarKitoblar.DataAccess.Interfaces.Geners;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Interafaces.Geners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Services.Geners;

public class GenerService : IGenerService
{
    private readonly IGenerRepository _generRepository;

    public GenerService(IGenerRepository generRepository) 
    {
        this._generRepository=generRepository;
    }

    public async Task<long> CountAsync()
    {
        var result=await _generRepository.CountAsync();
        return result;
    }

    public async Task<bool> CreateAsync(GenerCreateDto dto)
    {
        Gener gener = new Gener()
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt=TimeHelper.GetDateTime()
        };
        var result= await _generRepository.CreateAsync(gener);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long GenerId)
    {
        var result=await _generRepository.DeleteAsync(GenerId);
        return result > 0;
    }
}
