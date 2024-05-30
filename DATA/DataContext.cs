using Microsoft.EntityFrameworkCore;
using Tashgheel_Api.Entities;

namespace Tashgheel_Api.DATA;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppSetting>().OwnsOne(a => a.TashgeelCompanyMapLocation);
    }
    public DbSet<AppUser> Users { get; set; }
    


    // here to add
public DbSet<UserCourse> UserCourses { get; set; }
public DbSet<Service> Services { get; set; }
public DbSet<Video> Videos { get; set; }
public DbSet<Chapter> Chapters { get; set; }
public DbSet<Category> Categorys { get; set; }
public DbSet<Course> Courses { get; set; }

public DbSet<EventRegistration> EventRegistrations { get; set; }
public DbSet<Events> Eventss { get; set; }

public DbSet<Article> Articles { get; set; }

public DbSet<FeedBack> FeedBacks { get; set; }
public DbSet<News> Newss { get; set; }
public DbSet<AppSetting> AppSettings { get; set; }
public DbSet<SlidingBar> SlidingBars { get; set; }
public DbSet<Message> Messages { get; set; }
    public DbSet<Notifications> Notifications { get; set; }
    public DbSet<Appointment> Appointments { get; set; }


    public virtual async Task<int> SaveChangesAsync(Guid? userId = null)
    {
        // await OnBeforeSaveChanges(userId);
        var result = await base.SaveChangesAsync();
        return result;
    }
}

public class DbContextOptions<T>
{
}
