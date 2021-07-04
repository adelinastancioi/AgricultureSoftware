using AgriSoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgriSoft.EntityTypeConfiguration
{
    public class CropConfiguration : IEntityTypeConfiguration<Crop>
    {
        public void Configure(EntityTypeBuilder<Crop> builder)
        {
            
                builder.ToTable("Crop", "dbo").HasKey(x => x.CropId);
            builder.HasOne<Storage>().WithMany().HasForeignKey(x => x.StorageId);
            
        }
    }
}
