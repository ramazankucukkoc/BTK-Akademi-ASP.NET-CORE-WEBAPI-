
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { ID = 1, Name = "Hacivat ve Karagöz", Price = 75 },
                new Book { ID = 2, Name = "Peyami Safa", Price = 175 },
                new Book { ID = 3, Name = "Sabahsız Geceler", Price = 35 }
        );
                }
    }
}
