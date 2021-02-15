namespace Api.Data.Mapping
{
    using Domain.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PeopleMap : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.ToTable("People", "main");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Address)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Age);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Phone);
        }
    }
}