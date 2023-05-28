using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(prop => prop.Id)
                .ValueGeneratedNever();

            builder.Property<DateTime>("CreationDate").HasDefaultValueSql("GetDate()").HasColumnType("DateTime2");

            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(prop => prop.Description)
                .HasMaxLength(500);

            builder.Property(prop => prop.PartNumber)
                .IsRequired()
                .HasMaxLength(50);



        }
    }
}
