using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0115.Models;

public partial class Mission08QuadrantsContext : DbContext
{
    public Mission08QuadrantsContext()
    {
    }

    public Mission08QuadrantsContext(DbContextOptions<Mission08QuadrantsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Quadrant> Quadrants { get; set; }
    public virtual DbSet<TaskCategory> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Mission08Quadrants.sqlite");


    //This is for the Quadrants, specifically creating instances
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quadrant>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.Property(e => e.Key)
                .HasColumnType("NUMERIC");
            entity.Property(e => e.Quadrant1).HasColumnName("Quadrant");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
