using Microsoft.EntityFrameworkCore;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Helpers;
using Tashgheel_Api.Interface;
using Tashgheel_Api.Repository;
using Tashgheel_Api.Respository;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(
            options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IUserService, UserService>();
        // here to add
services.AddScoped<IServiceServices, ServiceServices>();
services.AddScoped<IVideoServices, VideoServices>();
services.AddScoped<IChapterServices, ChapterServices>();
services.AddScoped<ICategoryServices, CategoryServices>();
services.AddScoped<ICourseServices, CourseServices>();
services.AddScoped<IEventRegistrationServices, EventRegistrationServices>();
services.AddScoped<IEventsServices, EventsServices>();

services.AddScoped<IArticleServices, ArticleServices>();
services.AddScoped<IFeedBackServices, FeedBackServices>();
services.AddScoped<INewsServices, NewsServices>();
services.AddScoped<IAppSettingServices, AppSettingServices>();
services.AddScoped<ISlidingBarServices, SlidingBarServices>();
        services.AddScoped<IMessageServices, MessageServices>();
        services.AddScoped<IFacebookService, FacebookService>();
        services.AddScoped<ITwitterService, TwitterService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<ILinkedInService, LinkedInService>();
        services.AddSingleton<UsersHub>();
        services.AddHttpClient();
        





        return services;
    }
}
