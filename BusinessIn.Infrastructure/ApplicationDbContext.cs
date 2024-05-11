using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.DbMapping.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BusinessIn.Infrastructure;

public class ApplicationDbContext : DbContext { // (DbContextOptions<ApplicationDbContext> options)

    // DbContextOptions<ApplicationDbContext> options,
    // public ApplicationDbContext() {}
    
    // public ApplicationDbContext(DbContextOptionsBuilder options) : base(options.Options) {}
    
    // Entities
    public DbSet<LocationEntity> Locations { set; get; } = null!;
    public DbSet<DepartmentEntity> Departments { set; get; } = null!;
    public DbSet<TeamEntity> Teams { set; get; } = null!;
    public DbSet<EmployeeEntity> Employees { set; get; } = null!;
    public DbSet<JobEntity> Jobs { set; get; } = null!;
    public DbSet<GroupMessageEntity> GroupMessages { set; get; } = null!;
    
    // ValueObjects
    public DbSet<Attendance> Attendances { set; get; } = null!;
    public DbSet<JobHistory> JobHistories { set; get; } = null!;
    
    public DbSet<LocationManager> LocationManagers { set; get; } = null!;
    public DbSet<DepartmentManager> DepartmentManagers { set; get; } = null!;
    public DbSet<TeamLeader> TeamLeaders { set; get; } = null!;
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        Console.WriteLine("hiiiiiiiiiiiiiiiiiiiiiii");
        if (optionsBuilder.IsConfigured) return;
        // string connectionString = configuration.GetConnectionString("DefaultSQLConnection");
        Console.WriteLine("Not configured");
        
        const string connectionString = @"server=LAPTOP-0SMKE22F\SQLEXPRESS01;TrustServerCertificate=True;Database=BusinessInDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        // ;TrustServerCertificate=True
        //server=LAPTOP-0SMKE22F\\SQLEXPRESS01;Database=BusinessInDb;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True
        // string cs = Secrets.ConnectionString;
        // Console.WriteLine(cs);
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        Console.WriteLine("OnModelCreating");
        modelBuilder.Entity<Attendance>().HasKey(e => new {e.EmployeeId, e.Date});
        modelBuilder.Entity<JobHistory>().HasKey(e => new {e.EmployeeId, e.JobId, e.StartDate});
        
        modelBuilder.Entity<LocationManager>().HasKey(e => new {e.LocationId, e.ManagerId, e.StartDate});
        modelBuilder.Entity<DepartmentManager>().HasKey(e => new {e.DepartmentId, e.ManagerId, e.StartDate});
        modelBuilder.Entity<TeamLeader>().HasKey(e => new {e.TeamId, e.LeaderId, e.StartDate});
        
        // modelBuilder.Entity<EmployeeEntity>()
        //     .HasOne(e => e.Supervisor)
        //     .WithMany()
        //     .HasForeignKey(e => e.SupervisorId)
        //     .OnDelete(DeleteBehavior.Restrict);
        
        // var locationId = Guid.NewGuid();
        //
        // modelBuilder.Entity<LocationEntity>().HasData(
        //     new LocationEntity {
        //         Id = locationId,
        //         Region = "North Africa", // Middle East
        //         Country = "Egypt",
        //         City = "Cairo",
        //         PostalCode = "CAIRO-15678"
        //     }
        // );
    }
}