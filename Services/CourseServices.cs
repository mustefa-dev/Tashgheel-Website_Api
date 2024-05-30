using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;

public interface ICourseServices
{
    Task<(Course? course, string? error)> Create(CourseForm courseForm, Guid userId);
    Task<(List<CourseDto> courses, int? totalCount, string? error)> GetAll(CourseFilter filter);
    Task<(Course? course, string? error)> Update(Guid id, CourseForm courseUpdate);
    Task<(Course? course, string? error)> Delete(Guid id);
    Task<(CourseDto course, string? error)> GetById(Guid id);
    Task<(ChapterDto? chapter, string? error)> AddChapterForCourse(ChapterForm chapterForm, Guid courseId);
    Task<CourseDto> BuyCourse(Guid userId, Guid courseId);
}

public class CourseServices : ICourseServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public CourseServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(Course? course, string? error)> Create(CourseForm courseForm, Guid userId)
    {
        var course = _mapper.Map<Course>(courseForm);
        course.CreatorId = userId;
        var user = await _repositoryWrapper.User.Get(x => x.Id == userId);
        if (user == null) return (null, "User not found");
        var result = await _repositoryWrapper.Course.Add(course);
        if (result == null) return (null, "Error in creating course");
        return (result, null);
    }

    public async Task<(List<CourseDto> courses, int? totalCount, string? error)> GetAll(CourseFilter filter)
    {
        var (courses, totalCount) = await _repositoryWrapper.Course.GetAll<CourseDto>(
            x =>
                (filter.Name == null || x.Name.Contains(filter.Name)) &&
                (filter.Price == null || x.Price == filter.Price) &&
                (filter.Discount == null || x.Discount == filter.Discount)
            , filter.PageNumber, filter.PageSize);
        foreach (var course in courses)
        {
            course.Chapters = course.Chapters.OrderBy(x => x.order).ToList();
        }
     

        return (courses, totalCount, null);
    }

    public async Task<(Course? course, string? error)> Update(Guid id, CourseForm courseUpdate)
    {
        var course = await _repositoryWrapper.Course.Get(x => x.Id == id);
        if (course == null) return (null, "Course not found");
        _mapper.Map(courseUpdate, course);
        var result = await _repositoryWrapper.Course.Update(course);
        if (result == null) return (null, "Error in updating course");
        return (result, null);
    }

    public async Task<(Course? course, string? error)> Delete(Guid id)
    {
        var course = await _repositoryWrapper.Course.Get(x => x.Id == id);
        if (course == null) return (null, "Course not found");
        var result = await _repositoryWrapper.Course.SoftDelete(id);
        if (result == null) return (null, "Error in deleting course");
        return (result, null);
    }

    public async Task<(CourseDto course, string? error)> GetById(Guid id)
    {

var Course = await _repositoryWrapper.Course.GetAll<CourseDto>(x => x.Id == id);
var course = Course.data.FirstOrDefault();
        if (course == null) return (null, "Course not found");
        course.Chapters = course.Chapters.OrderBy(x => x.order).ToList();
        return (_mapper.Map<CourseDto>(course), null);
    }

    public async Task<(ChapterDto? chapter, string? error)> AddChapterForCourse(ChapterForm chapterForm, Guid courseId)
    {
        var chapter = _mapper.Map<Chapter>(chapterForm);
        chapter.CourseId = courseId;
        var result = await _repositoryWrapper.Chapter.Add(chapter);
        if (result == null) return (null, "Error in creating chapter");
        var resultDto = _mapper.Map<ChapterDto>(result);
        return (resultDto, null);
    }
  
    public async Task<CourseDto> BuyCourse(Guid userId, Guid courseId)
    {
        var userCourse = await _repositoryWrapper.UserCourse.Get(x => x.UserId == userId && x.CourseId == courseId);
        if (userCourse == null)
        {
            var newUserCourse = new UserCourse
            {
                UserId = userId,
                CourseId = courseId,
                IsPurchased = true
            };
            await _repositoryWrapper.UserCourse.Add(newUserCourse);
        }
        else
        {
            userCourse.IsPurchased = true;
            await _repositoryWrapper.UserCourse.Update(userCourse);
        }

        var course = await _repositoryWrapper.Course.Get(x => x.Id == courseId);
        return _mapper.Map<CourseDto>(course);
    }
    private async Task<bool> UserHasAccess(Guid userId, Guid courseId)
    {
        
        return await _repositoryWrapper.UserCourse.Exists(x => x.UserId == userId && x.CourseId == courseId && x.IsPurchased == true);
            
    }
}