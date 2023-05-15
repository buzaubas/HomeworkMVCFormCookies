using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeworkMVCFormCookies.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cookie> Cookies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=223-10;Database=Homework; Trusted_Connection=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cookie>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
