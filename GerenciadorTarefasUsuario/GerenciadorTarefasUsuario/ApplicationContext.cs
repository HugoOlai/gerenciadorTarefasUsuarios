
using backGerenciadorTarefasUsuario;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasUsuario
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Register>().HasKey(t => t.id);
            modelBuilder.Entity<Register>().HasMany(t => t.task).WithOne(t => t.user);
            modelBuilder.Entity<Task>().HasKey(t => t.id);

        }
        public DbSet<Task> Task { get; set; }

    }
}
