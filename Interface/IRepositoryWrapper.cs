namespace Tashgheel_Api.Interface;

public interface IRepositoryWrapper
{
    IUserRepository User { get; }
   

    // here to add
IUserCourseRepository UserCourse{get;}
IServiceRepository Service{get;}
IVideoRepository Video{get;}
IChapterRepository Chapter{get;}
ICategoryRepository Category{get;}
ICourseRepository Course{get;}
IEventRegistrationRepository EventRegistration{get;}
IEventsRepository Events{get;}
IArticleRepository Article{get;}
IFeedBackRepository FeedBack{get;}
INewsRepository News{get;}
IAppSettingRepository AppSetting{get;}
ISlidingBarRepository SlidingBar{get;}
IMessageRepository Message{get;}
IAppointmentRepository Appointment { get; }


}
