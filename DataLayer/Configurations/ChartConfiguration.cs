using CoreLayer.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class ChartConfiguration : IEntityTypeConfiguration<Chart>
    {      
        public void Configure(EntityTypeBuilder<Chart> builder)
        {
                   
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
        }
    }
}
