using JobAppTracker.Demo.Model;
using Microsoft.EntityFrameworkCore;

public class JobTrackerSQLLiteContext : DbContext
{
    public JobTrackerSQLLiteContext(DbContextOptions<JobTrackerSQLLiteContext> options) : base(options)
    {

    }
    
    public DbSet<JobTracker> JobTrackerItems{ get; set; }

}