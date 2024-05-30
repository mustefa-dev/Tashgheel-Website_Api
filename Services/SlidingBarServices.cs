using AutoMapper;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;

public interface ISlidingBarServices
{
    Task<(SlidingBar? slidingbar, string? error)> Create(SlidingBarForm slidingbarForm);

    Task<(List<SlidingBarDto> slidingbars, int? totalCount, string? error)> GetAll(SlidingBarFilter filter);
    Task<(SlidingBar? slidingbar, string? error)> GetById(Guid id);
    Task<(SlidingBar? slidingbar, string? error)> Update(Guid id, SlidingBarUpdate slidingbarUpdate);
    Task<(SlidingBar? slidingbar, string? error)> Delete(Guid id);
}

public class SlidingBarServices : ISlidingBarServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public SlidingBarServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(SlidingBar? slidingbar, string? error)> Create(SlidingBarForm slidingbarForm)
    {
        var slidingBar = _mapper.Map<SlidingBar>(slidingbarForm);
        var response = await _repositoryWrapper.SlidingBar.Add(slidingBar);
        return response == null ? (null, "SlidingBar Couldn't add") : (response, null);
    }

    public async Task<(List<SlidingBarDto> slidingbars, int? totalCount, string? error)> GetAll(SlidingBarFilter filter)
    {
        var (slidingBar, totalCount) = await _repositoryWrapper.SlidingBar.GetAll<SlidingBarDto>(
            filter.PageNumber, filter.PageSize);
        slidingBar = slidingBar.OrderBy(s => s.Priority).ToList();

        return (slidingBar, totalCount, null);
    }

    public async Task<(SlidingBar? slidingbar, string? error)> GetById(Guid id)
    {
        var slidingBar = await _repositoryWrapper.SlidingBar.GetById(id);
        if (slidingBar == null) return (null, "SlidingBar not found");
        return (slidingBar, null);
    }

    public async Task<(SlidingBar? slidingbar, string? error)> Update(Guid id, SlidingBarUpdate slidingbarUpdate)
    {
        var slidingBar = await _repositoryWrapper.SlidingBar.GetById(id);
        if (slidingBar == null) return (null, "SlidingBar not found");
        slidingBar = _mapper.Map(slidingbarUpdate, slidingBar);
        var response = await _repositoryWrapper.SlidingBar.Update(slidingBar);
        return response == null ? (null, "SlidingBar could not be updated") : (slidingbar: slidingBar, null);
    }

    public async Task<(SlidingBar? slidingbar, string? error)> Delete(Guid id)
    {
        var slidingBar = await _repositoryWrapper.SlidingBar.GetById(id);
        if (slidingBar == null) return (null, "SlidingBar not found");
        var result = await _repositoryWrapper.SlidingBar.SoftDelete(id);
        return result == null ? (null, "SlidingBar could not be deleted") : (result, null);
    }
}