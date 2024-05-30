
using AutoMapper;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Repository;
using Tashgheel_Api.Services;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;


public interface IChapterServices
{
Task<(List<ChapterDto> chapters, int? totalCount, string? error)> GetAll(ChapterFilter filter);
Task<(ChapterDto? chapter, string? error)> Update(Guid id , ChapterUpdate chapterUpdate);
Task<(ChapterDto? chapter, string? error)> Delete(Guid id);
Task<(VideoDto? video, string? error)> AddVideoToChapter(VideoForm videoForm, Guid chapterId);
Task<(ChapterDto? chapter, string? error)> GetById(Guid id);
}

public class ChapterServices : IChapterServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public ChapterServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}


public async Task<(List<ChapterDto> chapters, int? totalCount, string? error)> GetAll(ChapterFilter filter)
    {
       var (chapters, totalCount) = await _repositoryWrapper.Chapter.GetAll<ChapterDto>(
            x =>
                (filter.Title == null || x.Title.Contains(filter.Title))
            , filter.PageNumber, filter.PageSize);
       foreach (var chapter  in chapters)
       {
           var videos = await _repositoryWrapper.Video.GetAll(x => x.ChapterId == chapter.Id);
           chapter.Videos = videos.data.OrderBy(x => x.Order).ToList();
       }
        return (chapters, totalCount, null);
    }

public async Task<(ChapterDto? chapter, string? error)> Update(Guid id ,ChapterUpdate chapterUpdate)
    {
        var chapter = await _repositoryWrapper.Chapter.GetById(id);
        if (chapter == null) return (null, "Chapter not found");
        _mapper.Map(chapterUpdate, chapter);
        chapter = await _repositoryWrapper.Chapter.Update(chapter);
        return (_mapper.Map<ChapterDto>(chapter), null);
      
    }

    public async Task<(ChapterDto? chapter, string? error)> Delete(Guid id)
    {
        var chapter = await _repositoryWrapper.Chapter.GetById(id);
        if (chapter == null) return (null, "Chapter not found");

        // Get the videos associated with the chapter
        var videos = await _repositoryWrapper.Video.GetAll(x => x.ChapterId == id);

        // Delete the videos
        foreach (var video in videos.data)
        {
            await _repositoryWrapper.Video.Delete(video.Id);
        }

        // Now you can delete the chapter
        await _repositoryWrapper.Chapter.Delete(id);

        return (_mapper.Map<ChapterDto>(chapter), null);
    }
    public async Task<(VideoDto? video, string? error)> AddVideoToChapter(VideoForm videoForm, Guid chapterId)
    {
        var chapter = await _repositoryWrapper.Chapter.GetById(chapterId);
        if (chapter == null) return (null, "Chapter not found");
        var video = _mapper.Map<Video>(videoForm);
        video.ChapterId = chapterId;
        video = await _repositoryWrapper.Video.Add(video);
        return (_mapper.Map<VideoDto>(video), null);
    }
public async Task<(ChapterDto? chapter, string? error)> GetById(Guid id)
    {
        var chapter = await _repositoryWrapper.Chapter.GetById(id);
        if (chapter == null) return (null, "Chapter not found");
        var videos = await _repositoryWrapper.Video.GetAll(x => x.ChapterId == id);
        chapter.Videos = videos.data.OrderBy(x => x.Order).ToList();
        return (_mapper.Map<ChapterDto>(chapter), null);
    }

}
