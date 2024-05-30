
using AutoMapper;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Repository;
using Tashgheel_Api.Services;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;


public interface IVideoServices
{
Task<(Video? video, string? error)> Create(VideoForm videoForm );
Task<(List<VideoDto> videos, int? totalCount, string? error)> GetAll(VideoFilter filter);
Task<(Video? video, string? error)> Update(Guid id , VideoUpdate videoUpdate);
Task<(Video? video, string? error)> Delete(Guid id);
Task<(List<string>? files, string? error)> GetVideoParts(string fileName);
}

public class VideoServices : IVideoServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public VideoServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
 

   
public async Task<(Video? video, string? error)> Create(VideoForm videoForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<VideoDto> videos, int? totalCount, string? error)> GetAll(VideoFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(Video? video, string? error)> Update(Guid id ,VideoUpdate videoUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Video? video, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }
    public async Task<(List<string>? files, string? error)> GetVideoParts(string fileName)
    {
        var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Attachments");
        var files = Directory.GetFiles(attachmentsDir, $"{fileName}_ch*");
        return (files.ToList(), null);
    }

}
