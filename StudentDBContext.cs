using Microsoft.EntityFrameworkCore;

namespace ReactASPCrud.Model
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext() : base() { }
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.; initial Catalogs=lbs; User Id=sa; password=123; TrustServerCertificate=True");
        }*/
    }
}
