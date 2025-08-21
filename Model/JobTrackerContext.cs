using Microsoft.EntityFrameworkCore;

namespace JobAppTracker.Demo.Model
{
    public class JobTrackerContext:DbContext
    {
        public JobTrackerContext(DbContextOptions<JobTrackerContext> options) : base(options) { 
        //public JobTrackerContext(DbContextOptionsBuilder optionsBuilder) { 
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MyLocalDB;Database=JobTrackerDemo;ConnectRetryCount=0");


        }

        public DbSet<JobTracker> JobTrackerItems { get; set; } = null!;
    }
}
