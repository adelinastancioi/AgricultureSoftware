using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AgriSoft.Models
{
    public partial class farm_managementContext : DbContext
    {
        public farm_managementContext()
        {
        }

        public farm_managementContext(DbContextOptions<farm_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgriculturalOperation> AgriculturalOperations { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Crop> Crops { get; set; }
        public virtual DbSet<CropXoperation> CropXoperations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<RawMaterial> RawMaterials { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<UseOfEquipment> UseOfEquipments { get; set; }
        public virtual DbSet<UseOfRawMaterial> UseOfRawMaterials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-O7P1ET8\\;Database=farm_management;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AgriculturalOperation>(entity =>
            {
                entity.HasKey(e => e.OperationId)
                    .HasName("PK__Agricult__A4F5FC44D216A993");

                entity.ToTable("AgriculturalOperation");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Period)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.AgriculturalOperations)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK__Agricultu__Stora__571DF1D5");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.AgriculturalOperations)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__Agricultu__Suppl__5812160E");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientType)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Purchases).IsUnicode(false);

                entity.Property(e => e.Qtty).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Crop>(entity =>
            {
                entity.ToTable("Crop");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PlantingPeriod)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Crops)
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Crop__StorageId__3F466844");
            });

            modelBuilder.Entity<CropXoperation>(entity =>
            {
                entity.HasKey(e => new { e.OperationId, e.CropId })
                    .HasName("PK__CropXOpe__EDD6AA55D238CC8A");

                entity.ToTable("CropXOperation");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.CropXoperations)
                    .HasForeignKey(d => d.CropId)
                   // .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CropXOper__CropI__5BE2A6F2");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.CropXoperations)
                    .HasForeignKey(d => d.OperationId)
                   // .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CropXOper__Opera__5AEE82B9");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cnp)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CNP");

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfEmployment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkProgram)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK__Equipment__Stora__49C3F6B7");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__Equipment__Suppl__4AB81AF0");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Mail)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RawMaterial>(entity =>
            {
                entity.ToTable("RawMaterial");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExpirationDate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.RawMaterials)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK__RawMateri__Stora__45F365D3");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.RawMaterials)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__RawMateri__Suppl__46E78A0C");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Date)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Provides).IsUnicode(false);

                entity.Property(e => e.Qtty).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SupplierType)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Task__EmployeeId__33D4B598");
            });

            modelBuilder.Entity<UseOfEquipment>(entity =>
            {
                entity.HasKey(e => new { e.EquipmentId, e.CropId })
                    .HasName("PK__UseOfEqu__7D641268E8185269");

                entity.ToTable("UseOfEquipment");

                entity.Property(e => e.Usage).IsUnicode(false);

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.UseOfEquipments)
                    .HasForeignKey(d => d.CropId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__UseOfEqui__CropI__4E88ABD4");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.UseOfEquipments)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__UseOfEqui__Equip__4D94879B");
            });

            modelBuilder.Entity<UseOfRawMaterial>(entity =>
            {
                entity.HasKey(e => new { e.RawMaterialId, e.CropId })
                    .HasName("PK__UseOfRaw__90BCF800FB029E7D");

                entity.ToTable("UseOfRawMaterial");

                entity.Property(e => e.Usage).IsUnicode(false);

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.UseOfRawMaterials)
                    .HasForeignKey(d => d.CropId)
                  //  .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UseOfRawM__CropI__52593CB8");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany(p => p.UseOfRawMaterials)
                    .HasForeignKey(d => d.RawMaterialId)
                 //   .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UseOfRawM__RawMa__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
