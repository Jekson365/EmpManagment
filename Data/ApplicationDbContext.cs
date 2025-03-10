using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using MyApp.Models.Comments;
using MyApp.Models.Notes;
using MyApp.Models.Tasks;
using MyApp.Models.Vacations;

namespace MyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            modelBuilder.Entity<Models.Tasks.Task>()
                .HasOne(t => t.TaskStatus)
                .WithMany(ts => ts.Tasks)
                .HasForeignKey(t => t.TaskStatusId);
            modelBuilder.Entity<AssignedTask>()
                .HasIndex(at => new { at.TaskId, at.UserId })
                .IsUnique();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AssignedTask> AssignedTasks { get; set; }
        public DbSet<Models.Tasks.Task> Tasks { get; set; }
        public DbSet<Models.Statuses.TaskStatus> TaskStatuses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteAssigned> NotesAssigned { get; set; }
        public DbSet<Vacation> vacations {get;set;}
        public DbSet<VacationStatus> VacationStatuses {get;set;}
    }
}