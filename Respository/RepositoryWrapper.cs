using AutoMapper;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Interface;
using Tashgheel_Api.Repository;

namespace Tashgheel_Api.Respository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;


    // here to add
private IUserCourseRepository _UserCourse;

public IUserCourseRepository UserCourse {
    get {
        if(_UserCourse == null) {
            _UserCourse = new UserCourseRepository(_context, _mapper);
        }
        return _UserCourse;
    }
}
private IServiceRepository _Service;

public IServiceRepository Service {
    get {
        if(_Service == null) {
            _Service = new ServiceRepository(_context, _mapper);
        }
        return _Service;
    }
}
private IVideoRepository _Video;

public IVideoRepository Video {
    get {
        if(_Video == null) {
            _Video = new VideoRepository(_context, _mapper);
        }
        return _Video;
    }
}
private IChapterRepository _Chapter;

public IChapterRepository Chapter {
    get {
        if(_Chapter == null) {
            _Chapter = new ChapterRepository(_context, _mapper);
        }
        return _Chapter;
    }
}
private ICategoryRepository _Category;

public ICategoryRepository Category {
    get {
        if(_Category == null) {
            _Category = new CategoryRepository(_context, _mapper);
        }
        return _Category;
    }
}
private ICourseRepository _Course;

public ICourseRepository Course {
    get {
        if(_Course == null) {
            _Course = new CourseRepository(_context, _mapper);
        }
        return _Course;
    }
}
    private IEventRegistrationRepository _EventRegistration;

    public IEventRegistrationRepository EventRegistration
    {
        get
        {
            if (_EventRegistration == null)
            {
                _EventRegistration = new EventRegistrationRepository(_context, _mapper);
            }

            return _EventRegistration;
        }
    }

private IEventsRepository _Events;

public IEventsRepository Events
{
    get
    {
        if (_Events == null)
        {
            _Events = new EventsRepository(_context, _mapper);
        }

        return _Events;
        
    }
}

private IArticleRepository _Article;

public IArticleRepository Article {
    get {
        if(_Article == null) {
            _Article = new ArticleRepository(_context, _mapper);
        }
        return _Article;
    }
}
private IFeedBackRepository _FeedBack;

public IFeedBackRepository FeedBack {
    get {
        if(_FeedBack == null) {
            _FeedBack = new FeedBackRepository(_context, _mapper);
        }
        return _FeedBack;
    }
}
private INewsRepository _News;

public INewsRepository News {
    get {
        if(_News == null) {
            _News = new NewsRepository(_context, _mapper);
        }
        return _News;
    }
}
private IAppSettingRepository _AppSetting;

public IAppSettingRepository AppSetting {
    get {
        if(_AppSetting == null) {
            _AppSetting = new AppSettingRepository(_context, _mapper);
        }
        return _AppSetting;
    }
}
private ISlidingBarRepository _SlidingBar;

public ISlidingBarRepository SlidingBar {
    get {
        if(_SlidingBar == null) {
            _SlidingBar = new SlidingBarRepository(_context, _mapper);
        }
        return _SlidingBar;
    }
}
private IMessageRepository _Message;
private IAppointmentRepository _Appointment;

public IAppointmentRepository Appointment {
    get {
        if(_Appointment == null) {
            _Appointment = new AppointmentRepository(_context, _mapper);
        }
        return _Appointment;
    }
}

public IMessageRepository Message {
    get {
        if(_Message == null) {
            _Message = new MessageRepository(_context, _mapper);
        }
        return _Message;
    }
}



    private IUserRepository _user;


    public RepositoryWrapper(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    

    public IUserRepository User
    {
        get
        {
            if (_user == null) _user = new UserRepository(_context, _mapper);
            return _user;
        }
    }

}
