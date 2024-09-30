using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.EntityConfiguration
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ID");


            builder.Property(e => e.Name)
                .HasColumnName("NOME");


            builder.Property(e => e.Email)
                .HasColumnName("EMAIL");

            builder.Property(e => e.Password)
                .HasColumnName("SENHA");

            builder.Property(e => e.Gender)
                .HasColumnName("GENERO")
                .HasConversion(
                    v => v.ToString(),
                    v => (Gender)Enum.Parse(typeof(Gender), v));

        }

    }
}
