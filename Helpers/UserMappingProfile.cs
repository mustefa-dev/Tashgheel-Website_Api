using AutoMapper;
using OneSignalApi.Model;
using Tashgheel;
using Tashgheel_Api.DATA.DTOs.User;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;

namespace Tashgheel_Api.Helpers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        var baseUrl = "http://localhost:5051/";

       
        CreateMap<AppUser, UserDto>();
        CreateMap<UpdateUserForm, AppUser>();
        CreateMap<AppUser, TokenDTO>();

        CreateMap<RegisterForm, App>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      
        CreateMap<AppUser, AppUser>();


        // here to add
CreateMap<UserCourse, UserCourseDto>();
CreateMap<UserCourseForm,UserCourse>();
CreateMap<UserCourseUpdate,UserCourse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Service, ServiceDto>();
CreateMap<ServiceForm,Service>();
CreateMap<ServiceUpdate,Service>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Video, VideoDto>();
CreateMap<VideoForm,Video>();
CreateMap<VideoUpdate,Video>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Chapter, ChapterDto>();
CreateMap<ChapterForm,Chapter>();
CreateMap<ChapterUpdate,Chapter>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Category, CategoryDto>();
CreateMap<CategoryForm,Category>();
CreateMap<CategoryUpdate,Category>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<ChapterForm,Chapter>();
CreateMap<Course, CourseDto>()
    .ForMember(dest => dest.CreatorName, opt 
        => opt.MapFrom(src => src.Creator!.FullName));
CreateMap<CourseForm, Course>(); //.ForMember(dist => dist.Chapters,
  //  opt => opt.MapFrom(src => src.ChaptersForm));
CreateMap<CourseUpdate,Course>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<EventRegistration, EventRegistrationDto>();
CreateMap<EventRegistrationForm,EventRegistration>();
CreateMap<EventRegistrationUpdate,EventRegistration>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Events, EventsDto>();
CreateMap<EventsForm,Events>();
CreateMap<EventsUpdate,Events>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Article, ArticleDto>();
CreateMap<ArticleForm,Article>();
CreateMap<ArticleUpdate,Article>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<FeedBack, FeedBackDto>();
CreateMap<FeedBackForm,FeedBack>();
CreateMap<FeedBackUpdate,FeedBack>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<News, NewsDto>()
    .ForMember(dest => dest.Images, opt => 
        opt.MapFrom(src => ImageListConfig(src.Images)));
CreateMap<NewsForm,News>();
CreateMap<NewsUpdate,News>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<AppSetting, AppSettingDto>();
CreateMap<AppSettingForm,AppSetting>();
CreateMap<AppSettingUpdate,AppSetting>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<SlidingBar, SlidingBarDto>();
CreateMap<SlidingBarForm,SlidingBar>();
CreateMap<SlidingBarUpdate,SlidingBar>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Message, MessageDto>();
CreateMap<MessageForm,Message>();
CreateMap<MessageUpdate,Message>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

CreateMap<Appointment, AppointmentDto>();
CreateMap<AppointmentForm,Appointment>();
CreateMap<Appointment, Appointment>().ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
    
    public static List<string> ImageListConfig(List<string>? images)
    {
        if (images == null)
        {
            return new List<string>();
        }

        return images.Select(image => Utils.Util.Url + image).ToList();
    }
}
