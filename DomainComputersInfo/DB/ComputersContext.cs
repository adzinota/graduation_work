using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DomainComputersInfo
{
    public partial class ComputersContext : DbContext
    {
        public ComputersContext()
        {
        }

        public ComputersContext(DbContextOptions<ComputersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseBoard> BaseBoards { get; set; }
        public virtual DbSet<DiskDrive> DiskDrives { get; set; }
        public virtual DbSet<LogicalDisk> LogicalDisks { get; set; }
        public virtual DbSet<MainInfo> MainInfos { get; set; }
        public virtual DbSet<NetworkAdapter> NetworkAdapters { get; set; }
        public virtual DbSet<OperatingSystem> OperatingSystems { get; set; }
        public virtual DbSet<PhysicalMemory> PhysicalMemories { get; set; }
        public virtual DbSet<Processor> Processors { get; set; }
        public virtual DbSet<TotalMemory> TotalMemories { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Computers;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<BaseBoard>(entity =>
            {
                entity.ToTable("BaseBoard");

                entity.HasIndex(e => e.MainId, "UQ_BaseBoard_MainInfo")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithOne(p => p.BaseBoard)
                    .HasForeignKey<BaseBoard>(d => d.MainId)
                    .HasConstraintName("FK_BaseBoard_MainInfo");
            });

            modelBuilder.Entity<DiskDrive>(entity =>
            {
                entity.ToTable("DiskDrive");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.DiskDrives)
                    .HasForeignKey(d => d.MainId)
                    .HasConstraintName("FK_DiskDrive_MainInfo");
            });

            modelBuilder.Entity<LogicalDisk>(entity =>
            {
                entity.ToTable("LogicalDisk");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.LogicalDisks)
                    .HasForeignKey(d => d.MainId)
                    .HasConstraintName("FK_LogicalDisk_MainInfo");
            });

            modelBuilder.Entity<MainInfo>(entity =>
            {
                entity.ToTable("MainInfo");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Domain).IsRequired();
            });

            modelBuilder.Entity<NetworkAdapter>(entity =>
            {
                entity.ToTable("NetworkAdapter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.Macaddress).HasColumnName("MACAddress");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.NetworkAdapters)
                    .HasForeignKey(d => d.MainId)
                    .HasConstraintName("FK_NetworkAdapter_MainInfo");
            });

            modelBuilder.Entity<OperatingSystem>(entity =>
            {
                entity.ToTable("OperatingSystem");

                entity.HasIndex(e => e.MainId, "UQ_OperatingSystem_MainInfo")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithOne(p => p.OperatingSystem)
                    .HasForeignKey<OperatingSystem>(d => d.MainId)
                    .HasConstraintName("FK_OperatingSystem_MainInfo");
            });

            modelBuilder.Entity<PhysicalMemory>(entity =>
            {
                entity.ToTable("PhysicalMemory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.PhysicalMemories)
                    .HasForeignKey(d => d.MainId)
                    .HasConstraintName("FK_PhysicalMemory_MainInfo");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("Processor");

                entity.HasIndex(e => e.MainId, "UQ_Processor_MainInfo")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithOne(p => p.Processor)
                    .HasForeignKey<Processor>(d => d.MainId)
                    .HasConstraintName("FK_Processor_MainInfo");
            });

            modelBuilder.Entity<TotalMemory>(entity =>
            {
                entity.ToTable("TotalMemory");

                entity.HasIndex(e => e.MainId, "UQ__TotalMem__71F8F5AD044CF315")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.HasOne(d => d.Main)
                    .WithOne(p => p.TotalMemory)
                    .HasForeignKey<TotalMemory>(d => d.MainId)
                    .HasConstraintName("FK_TotalMemory_MainInfo");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MainID");

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.HasOne(d => d.Main)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.MainId)
                    .HasConstraintName("FK_UserProfile_MainInfo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}