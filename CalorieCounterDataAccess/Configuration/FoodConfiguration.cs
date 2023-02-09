using CalorieCounterEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterDataAccess.Configuration
{
    public class FoodConfiguration : IEntityTypeConfiguration<FoodEntity>
    {
        public void Configure(EntityTypeBuilder<FoodEntity> builder)
        {
            // Primary Key
            builder.HasKey(x => x.FoodID);

            // OneToMany Relation
            builder.HasOne(x => x.FoodCategoryEntity)
                   .WithMany(x => x.FoodEntity)
                   .HasForeignKey(x => x.FoodCategoryID);
        }
    }
}
