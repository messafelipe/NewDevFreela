using Microsoft.EntityFrameworkCore;
using NewDevFreela.API.Entities;

namespace NewDevFreela.API.Persistence
{
    public class NewDevFreelaDbContext : DbContext
    {
        public NewDevFreelaDbContext(DbContextOptions<NewDevFreelaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Skill>(e =>
                {
                    e.HasKey(s => s.Id); // Chave Primária para a entidade Skill
                });

            builder
                .Entity<UserSkill>(e =>
                {
                    e.HasKey(us => us.Id); // Chave Primária para a entidade UserSkill

                    e.HasOne(u => u.Skill) // Relacionamento: UserSkill tem uma Skill
                        .WithMany(u => u.UserSkills) // Skill tem muitas UserSkills
                        .HasForeignKey(s => s.IdSkill)  // A Foreign Key é IdSkill
                        .OnDelete(DeleteBehavior.Restrict); // Delete restrito
                });

            builder
                .Entity<ProjectComment>(e =>
                {
                    e.HasKey(p => p.Id);  // Chave Primária para a entidade ProjectComment

                    e.HasOne(p => p.Project) // Relacionamento: ProjectComment tem um Project
                        .WithMany(p => p.Comments) // Project tem muitos Comments
                        .HasForeignKey(p => p.IdProject) // A Foreign Key é IdProject
                        .OnDelete(DeleteBehavior.Restrict); // Delete restrito
                });

            builder
                .Entity<User>(e =>
                {
                    e.HasKey(u => u.Id); // Chave Primária para a entidade User

                    e.HasMany(u => u.Skills) // Relacionamento: User tem muitas Skills
                        .WithOne(us => us.User) // Cada Skill pertence a um User
                        .HasForeignKey(us => us.IdUser) // A Foreign Key é IdUser
                        .OnDelete(DeleteBehavior.Restrict); // Delete restrito
                });

            builder
                .Entity<Project>(e =>
                {
                    e.HasKey(p => p.Id); // Chave Primária para a entidade Project

                    e.HasOne(p => p.Freelancer) // Relacionamento: Project tem um Freelancer
                        .WithMany(f => f.FreelanceProjects) // Freelancer tem muitos FreelanceProjects
                        .HasForeignKey(p => p.IdFreelancer) // A Foreign Key é IdFreelancer
                        .OnDelete(DeleteBehavior.Restrict); // Delete restrito

                    e.HasOne(p => p.Client) // Relacionamento: Project tem um Client
                        .WithMany(c => c.OwnedProjects) // Client tem muitos projetos
                        .HasForeignKey(p => p.IdClient) // A Foreign Key é IdClient
                        .OnDelete(DeleteBehavior.Restrict); // Delete restrito
                });

            base.OnModelCreating(builder);
        }
    }
}
